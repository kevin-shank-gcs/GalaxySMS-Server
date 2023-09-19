using GCS.PanelDataProcessors.Interfaces;
using System;
using GCS.Core.Common.Logger;
using GCS.Framework.MessageQueue.Messaging;
using System.Threading.Tasks;

#if NETFRAMEWORK
using GalaxySMS.MessageQueue.Integration;
#elif NETCOREAPP

#endif


namespace GCS.PanelOutputDataHandlers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A class for handling panel data messages. </summary>
    ///
    /// <remarks>   This class sends messages that have been received from a panel and sends them to downstream processing queues.  </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PanelOutputDataMessageHandler : IPanelOutputDataMessageHandler
    {
        public SystemType SystemType { get; private set; }

        public PanelOutputDataMessageHandler()
        {
            SystemType = SystemType.Galaxy;

#if NETFRAMEWORK
            this.Log().Info($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType.Name} creating MessageQueues");

            try
            {
                var queuePanelMessage = MessageQueueFactory.CreateOutbound(QueueNames.PanelMessage, MessagePattern.FireAndForget);
                var queueRecorder = MessageQueueFactory.CreateOutbound(QueueNames.PanelMessageRecorder, MessagePattern.FireAndForget);

                //var msg = new Message
                //{
                //    Body = "Creation message",
                //};
                //queuePanelMessage.Send(msg);
                //queueRecorder.Send(msg);

            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
#elif NETCOREAPP

#endif
        }

        public void HandleMessage(object data)
        {
#if NETFRAMEWORK
            try
            {

                var msg = new Message
                {
                    Body = data,
                };

                var queuePanelMessage = MessageQueueFactory.CreateOutbound(QueueNames.PanelMessage, MessagePattern.FireAndForget);
                queuePanelMessage.Send(msg);

                var queueRecorder = MessageQueueFactory.CreateOutbound(QueueNames.PanelMessageRecorder, MessagePattern.FireAndForget);
                queueRecorder.Send(msg);
        }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
#elif NETCOREAPP

#endif
        }

        public async Task HandleMessageAsync(object data)
        {
#if NETFRAMEWORK
            try
            {

                var msg = new Message
                {
                    Body = data,
                };

                var queuePanelMessage = MessageQueueFactory.CreateOutbound(QueueNames.PanelMessage, MessagePattern.FireAndForget);
                queuePanelMessage.Send(msg);

                var queueRecorder = MessageQueueFactory.CreateOutbound(QueueNames.PanelMessageRecorder, MessagePattern.FireAndForget);
                queueRecorder.Send(msg);
            }
            catch (Exception ex)
            {
                this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            }
#elif NETCOREAPP

#endif
        }
    }
}
