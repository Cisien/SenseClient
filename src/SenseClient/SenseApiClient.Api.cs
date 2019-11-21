#nullable enable

using SenseClient.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ApiMonitorInfo = SenseClient.ApiModel.MonitorInfo;

namespace SenseClient
{
    public partial class SenseApiClient
    {
        public IReadOnlyCollection<Monitor> GetMonitors()
        {
            if(_authResult is null)
            {
                throw new InvalidOperationException("User has not logged in");
            }
            
            return _authResult.Monitors.Select(a => Monitor.Create(a)).ToList().AsReadOnly();
        }

        public async Task<MonitorInfo> GetMonitorInfo(int monitorId)
        {
            if (monitorId == default)
            {
                throw new ArgumentNullException(nameof(monitorId));
            }

            var monitorStatusResponse = await _client.GetAsync($"app/monitors/{monitorId}/status");
            var monitorStatusBody = await monitorStatusResponse.Content.ReadAsStringAsync();

            if (!monitorStatusResponse.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"{monitorStatusResponse.StatusCode}: Unable to retrieve monitor status for {monitorId}. {monitorStatusBody}");
            }
            var monitorStatus = JsonSerializer.Deserialize<ApiMonitorInfo>(monitorStatusBody, _serializerOptions);

            return MonitorInfo.Create(monitorStatus);
        }
    }
}
