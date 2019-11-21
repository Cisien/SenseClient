#nullable enable

#nullable enable
using System;
using System.Threading.Tasks;

namespace SenseClient
{
    public partial class SenseApiClient
    {
        public SenseRealtimeClient GetMonitorClient(int monitorId)
        {
            if(_authResult is null)
            {
                throw new InvalidOperationException("User has not logged in yet");
            }

            if(monitorId == default)
            {
                throw new ArgumentNullException(nameof(monitorId));
            }

            var rtClient = new SenseRealtimeClient(monitorId, _authResult.AccessToken);
            return rtClient;
        }
    }
}
