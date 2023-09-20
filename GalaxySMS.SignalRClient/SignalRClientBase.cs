using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace GalaxySMS.SignalRCore
{
    public abstract class SignalRCoreClientBase
        : ISignalRCoreClient, IAsyncDisposable
    {
        protected bool Started { get; private set; }

        protected SignalRCoreClientBase(string hubUrl, string hubPath) =>
            HubConnection = new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .WithAutomaticReconnect()
                .Build();

        public bool IsConnected =>
            HubConnection.State == HubConnectionState.Connected;

        protected HubConnection HubConnection { get; private set; }

        public async ValueTask DisposeAsync()
        {
            if (HubConnection != null)
            {
                await HubConnection.DisposeAsync();
            }
        }

        public async Task Start()
        {
            if (!Started)
            {
                await HubConnection.StartAsync();
                Started = true;
            }
        }
    }

}
