using System;
using System.Threading.Tasks;
#if NETFRAMEWORK
#if SignalRCore
#else
using GalaxySMS.Business.SignalR;
#endif

#elif NETCOREAPP
#endif
using GalaxySMS.MessageQueue.Integration.Workflows.Spec;
using GCS.Core.Common.Logger;

namespace GalaxySMS.MessageQueue.Integration.Workflows
{
    public class MercPanelMessageDecoderWorkflow : IPanelMessageWorkflow
    {
        #region Implementation of IPanelMessageWorkflow

#if NETFRAMEWORK
#if SignalRCore
        public SignalRCore.SignalRClient SignalRClient { get; set; }
#else
        public SignalRClient SignalRClient { get; set; }
#endif
        public object Data { get; set; }
        public void Run()
        {
            //var msg = $"ClusterGroupId: {Data.ClusterGroupId}, Cluster #:{Data.ClusterNumber}, Panel #:{Data.PanelNumber}, CPU #:{Data.CpuNumber}";
            var msg = string.Empty;
            if (Data != null)
                msg = Data.GetType().ToString();
            this.Log().InfoFormat($"{DateTimeOffset.Now.TimeOfDay} MercPanelMessageDecoderWorkflow processing message: {msg}");
        }
#elif NETCOREAPP

        public object Data { get; set; }
        public void Run()
        {
            //var msg = $"ClusterGroupId: {Data.ClusterGroupId}, Cluster #:{Data.ClusterNumber}, Panel #:{Data.PanelNumber}, CPU #:{Data.CpuNumber}";
            var msg = string.Empty;
            if (Data != null)
                msg = Data.GetType().ToString();
            //            this.Log().InfoFormat($"{DateTimeOffset.Now.TimeOfDay} MercPanelMessageDecoderWorkflow processing message: {msg}");
        }
#endif

        #endregion
    }
}
