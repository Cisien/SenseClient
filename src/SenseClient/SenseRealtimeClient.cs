using SenseClient.ObjectModel.Realtime;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using ApiRealtimeUpdate = SenseClient.ApiModel.Realtime.RealtimeUpdate;

namespace SenseClient
{
    public class SenseRealtimeClient
    {
        private readonly string _wssUrl;
        private readonly ClientWebSocket _wsClient;
        private readonly CancellationTokenSource _receiverCts;
        private readonly ArrayPool<byte> _receiveBufferPool;
        private static readonly SemaphoreSlim _wsConnectionLock = new SemaphoreSlim(1, 1);
        private Task _receiver;

        private readonly Dictionary<string, Handler> _handlers = new Dictionary<string, Handler>();
        private delegate Task Handler(string body);

        public event Func<Message, Task> RealtimeUpdateReceived;


        internal SenseRealtimeClient(int monitorId, string token)
        {
            _handlers["realtime_update"] = HandleRealtimeUpdate;

            _wssUrl = $"wss://clientrt.sense.com/monitors/{monitorId}/realtimefeed?access_token={token}";
            _receiverCts = new CancellationTokenSource();
            _wsClient = new ClientWebSocket();
            _receiveBufferPool = ArrayPool<byte>.Create(65536, 20);

            var version = GetType().Assembly.GetName().Version.ToString();
            var uaHeader = new ProductInfoHeaderValue(new ProductHeaderValue(HttpUtility.UrlEncode("https://github.com/cisien/SenseClient"), version));
            _wsClient.Options.SetRequestHeader("User-Agent", uaHeader.ToString());
        }

        public Task StartAsync()
        {
            _receiver = new Task(async () => await StartReceiveLoop(), _receiverCts.Token, TaskCreationOptions.LongRunning);
            _receiver.Start(TaskScheduler.Default);
            return Task.CompletedTask;
        }

        public async Task StopAsync()
        {
            _receiverCts.Cancel();
            await _receiver;
            if (_wsClient.State == WebSocketState.Open || _wsClient.State == WebSocketState.CloseReceived || _wsClient.State == WebSocketState.CloseSent)
            {
                await _wsClient.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            }
        }

        private async Task StartReceiveLoop()
        {
            while (!_receiverCts.Token.IsCancellationRequested)
            {
                await ReceiveInternal();
            }
        }

        private async Task ReceiveInternal()
        {
            await EnsureConnected();

            var array = _receiveBufferPool.Rent(65536);
            try
            {
                var buffer = new Memory<byte>(array, 0, array.Length);
                var result = await _wsClient.ReceiveAsync(buffer, CancellationToken.None);

                var body = Encoding.UTF8.GetString(buffer.ToArray(), 0, result.Count);
                var document = JsonDocument.Parse(body);
                if(result.Count > 4096)
                {
                    Debugger.Break();
                }

                if(_handlers.TryGetValue(document.RootElement.GetProperty("type").GetString(), out var handler))
                {
                    await handler(body); 
                }
            }
            finally
            {
                _receiveBufferPool.Return(array, true);
            }
        }

        private async Task EnsureConnected()
        {
            if (_wsClient.State == WebSocketState.Open)
            {
                return;
            }

            await _wsConnectionLock.WaitAsync();
            try
            {
                if (_wsClient.State != WebSocketState.Open && _wsClient.State != WebSocketState.Connecting)
                {
                    await _wsClient.ConnectAsync(new Uri(_wssUrl), CancellationToken.None);
                    while (_wsClient.State != WebSocketState.Open)
                    {
                        await Task.Delay(1);
                    };
                }
            }
            finally
            {
                _wsConnectionLock.Release();
            }
        }

        private Task HandleRealtimeUpdate(string body)
        {
            var rtUpdate = JsonSerializer.Deserialize<ApiRealtimeUpdate>(body);
            return OnRealtimeUpdateReceived(rtUpdate);
        }

        private Task OnRealtimeUpdateReceived(ApiRealtimeUpdate update)
        {
            if (update is null)
            {
                return Task.CompletedTask;
            }

            if (RealtimeUpdateReceived is null)
            {
                return Task.CompletedTask;
            }
            var message = Message.Create(update.Payload);

            var invocationList = RealtimeUpdateReceived.GetInvocationList();
            var tasks = new List<Task>(invocationList.Length);

            foreach (Func<Message, Task> handler in invocationList)
            {
                tasks.Add(handler(message));
            }
            return Task.WhenAll(tasks);
        }
    }
}
