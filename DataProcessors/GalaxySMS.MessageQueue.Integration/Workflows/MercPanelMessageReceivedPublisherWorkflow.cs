using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Business.SignalR;
using GalaxySMS.MessageQueue.Integration.Workflows.Spec;
using GCS.Framework.MessageQueue.Messaging;

namespace GalaxySMS.MessageQueue.Integration.Workflows
{
    public class MercPanelMessageReceivedPublisherWorkflow : IPanelMessageWorkflow
    {
        public object Data { get; set; }
        public SignalRClient SignalRClient { get; set; }

        public void Run()
        {
            SendNotificationEvent();
        }

        
        private void SendNotificationEvent()
        {
            var eventData = new {
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
