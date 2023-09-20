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

    public class JobMessageHandler : IJobMessageHandler
    {

        public JobMessageHandler()
        {
#if NETFRAMEWORK
            var declaringType = System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType;
            if (declaringType != null)
                this.Log().Info(
                    $"{declaringType?.Name} creating JobQueue");

            try
            {
                var queuejobMessage = MessageQueueFactory.CreateOutbound(QueueNames.GalaxyJob, MessagePattern.FireAndForget);

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

                var queueJobMessage = MessageQueueFactory.CreateOutbound(QueueNames.GalaxyJob, MessagePattern.FireAndForget);
                queueJobMessage.Send(msg);

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

                var queueJobMessage = MessageQueueFactory.CreateOutbound(QueueNames.GalaxyJob, MessagePattern.FireAndForget);
                queueJobMessage.Send(msg);

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
