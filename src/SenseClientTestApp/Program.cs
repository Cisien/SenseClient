using Microsoft.Extensions.Configuration;
using SenseClient;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SenseClientTestApp
{
    class Program
    {
        private static SenseRealtimeClient _rtClient;

        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                            .AddUserSecrets("fd63efa9-5ead-4e3c-83fa-518fa6ac1782")
                            .Build();
            var client = await SenseApiClient.Create(config["email"], config["password"]);

            var monitors = client.GetMonitors();
            foreach (var monitor in monitors)
            {
                Console.WriteLine($"Info for monitor {monitor.Id}");
                var monitorInfo = await client.GetMonitorInfo(monitor.Id);
                var result = JsonSerializer.Serialize(monitorInfo);
                Console.WriteLine(result);
            }

            _rtClient = client.GetMonitorClient(monitors.First().Id);
            _rtClient.RealtimeUpdateReceived += update =>
            {
                Console.WriteLine($"RUR: {update.SampleTime:o} | {update.VoltageA:F02} | {update.VoltageB:F02} | {update.Current:000} | {update.Watts:F02} | {update.Frequency:F02}");
                return Task.CompletedTask;
            };

            await _rtClient.StartAsync();

            Console.ReadKey(true);
            await _rtClient.StopAsync();
        }
    }
}
