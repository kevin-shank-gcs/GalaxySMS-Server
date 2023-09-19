#if NETFRAMEWORK
#if SignalRCore
#else
using GalaxySMS.Business.SignalR;
#endif
#elif NETCOREAPP
#endif
using System.Threading.Tasks;
using GalaxySMS.MessageQueue.Integration.Workflows.Spec;
using GCS.Framework.MessageQueue.Messaging;

namespace GalaxySMS.MessageQueue.Integration.Workflows
{
    public class MercPanelMessageReceivedPublisherWorkflow : IPanelMessageWorkflow
    {
        public object Data { get; set; }
#if NETFRAMEWORK
#if SignalRCore
        public SignalRCore.SignalRClient SignalRClient { get; set; }
#else
        public SignalRClient SignalRClient { get; set; }
#endif
#elif NETCOREAPP
#endif

        public void Run()
        {
            SendNotificationEvent();
        }


        private void SendNotificationEvent()
        {
            var eventData = new
            {
                data = Data
            };

            var queue = MessageQueueFactory.CreateOutbound(QueueNames.MercPanelMessagePublisher, MessagePattern.PublishSubscribe);
            queue.Send(new Message
            {
                Body = eventData
            });
        }
    }
}
