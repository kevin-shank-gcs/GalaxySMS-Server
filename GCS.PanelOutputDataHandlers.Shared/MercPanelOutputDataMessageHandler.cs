using GalaxySMS.MessageQueue.Integration;
using GCS.Core.Common.Logger;
using GCS.Framework.MessageQueue.Messaging;
using GCS.PanelDataProcessors.Interfaces;
using System;
using System.Threading.Tasks;

#if NETFRAMEWORK
#elif NETCOREAPP

#endif

namespace GCS.PanelOutputDataHandlers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A class for handling panel data messages. </summary>
    ///
    /// <remarks>   This class sends messages that have been received from a panel and sends them to downstream processing queues.  </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class MercPanelOutputDataMessageHandler : IPanelOutputDataMessageHandler
    {
        public SystemType SystemType { get; private set; }

#if NETFRAMEWORK
        public MercPanelOutputDataMessageHandler()
        {
            SystemType = SystemType.Mercury;

            this.Log().Info($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType.Name} creating MessageQueues");

            try
            {
                var queuePanelMessage = MessageQueueFactory.CreateOutbound(QueueNames.MercPanelMessage, MessagePattern.FireAndForget);
                var queueRecorder = MessageQueueFactory.CreateOutbound(QueueNames.MercPanelMessageRecorder, MessagePattern.FireAndForget);

            }
            catch (Exception ex)
            {
                this.Log()
                    .Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex}");
            }
        }
#elif NETCOREAPP
        public MercPanelOutputDataMessageHandler()
        {
            SystemType = SystemType.Mercury;

//            this.Log().Info($"{System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType.Name} creating MessageQueues");

            try
            {
                var queuePanelMessage = MessageQueueFactory.CreateOutbound(QueueNames.MercPanelMessage, MessagePattern.FireAndForget);
                var queueRecorder = MessageQueueFactory.CreateOutbound(QueueNames.MercPanelMessageRecorder, MessagePattern.FireAndForget);

            }
            catch (Exception ex)
            {
                //this.Log().Error($"{DateTimeOffset.Now}:{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex}");
            }
        }

#endif

        public void HandleMessage(object data)
        {
#if NETFRAMEWORK
            try
            {

                var msg = new Message
                {
                    Body = data,
                };

                var queuePanelMessage = MessageQueueFactory.CreateOutbound(QueueNames.MercPanelMessage, MessagePattern.FireAndForget);
                queuePanelMessage.Send(msg);

                var queueRecorder = MessageQueueFactory.CreateOutbound(QueueNames.MercPanelMessageRecorder, MessagePattern.FireAndForget);
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

                var queuePanelMessage = MessageQueueFactory.CreateOutbound(QueueNames.MercPanelMessage, MessagePattern.FireAndForget);
                queuePanelMessage.Send(msg);

                var queueRecorder = MessageQueueFactory.CreateOutbound(QueueNames.MercPanelMessageRecorder, MessagePattern.FireAndForget);
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
