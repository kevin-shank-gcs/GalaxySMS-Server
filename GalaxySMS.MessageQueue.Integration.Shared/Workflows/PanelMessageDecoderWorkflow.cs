#if NETFRAMEWORK
#if SignalRCore
#else
using GalaxySMS.Business.SignalR;
#endif
#elif NETCOREAPP
#endif
using GalaxySMS.MessageQueue.Integration.Workflows.Spec;
using GCS.Core.Common.Logger;
using System;
using System.Threading.Tasks;

namespace GalaxySMS.MessageQueue.Integration.Workflows
{
    public class PanelMessageDecoderWorkflow : IPanelMessageWorkflow
    {
        #region Implementation of IPanelMessageWorkflow

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
            //var msg = $"ClusterGroupId: {Data.ClusterGroupId}, Cluster #:{Data.ClusterNumber}, Panel #:{Data.PanelNumber}, CPU #:{Data.CpuNumber}";
            var msg = string.Empty;
            if (Data != null)
                msg = Data.GetType().ToString();
#if NETFRAMEWORK
            this.Log().InfoFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageDecoderWorkflow processing message: {msg}");
#elif NETCOREAPP
            //            this.Log().InfoFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageDecoderWorkflow processing message: {msg}");
#endif
        }

        #endregion
    }
}
