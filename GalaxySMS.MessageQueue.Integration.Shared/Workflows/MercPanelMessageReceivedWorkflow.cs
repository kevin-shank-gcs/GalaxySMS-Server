
#if NETFRAMEWORK
#if SignalRCore
#else
using GalaxySMS.Business.SignalR;
#endif
#elif NETCOREAPP
#endif

using GalaxySMS.MessageQueue.Integration.Workflows.Spec;
using System;
using System.Threading.Tasks;

namespace GalaxySMS.MessageQueue.Integration.Workflows
{
    public class MercPanelMessageReceivedWorkflow : IPanelMessageWorkflow
    {
#if NETFRAMEWORK
#if SignalRCore
        public SignalRCore.SignalRClient SignalRClient { get; set; }
#else
        public SignalRClient SignalRClient { get; set; }
#endif
#elif NETCOREAPP
#endif
        public object Data { get; set; }

        public void Run()
        {
            var msg = string.Empty;
            if (Data != null)
            {
                var t = Data.GetType();
                msg = t.ToString();
                var logString = $"{DateTimeOffset.Now.TimeOfDay} MercPanelMessageReceivedWorkflow processing message: {msg}";

                //                this.Log().InfoFormat(logString);
            }
        }


        private void SendNotificationEvent()
        {
        }
    }
}