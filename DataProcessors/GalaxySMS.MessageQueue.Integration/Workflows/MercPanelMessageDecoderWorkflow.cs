using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Business.SignalR;
using GalaxySMS.MessageQueue.Integration.Workflows.Spec;
using GCS.Core.Common.Logger;

namespace GalaxySMS.MessageQueue.Integration.Workflows
{
    public class MercPanelMessageDecoderWorkflow : IPanelMessageWorkflow
    {
        #region Implementation of IPanelMessageWorkflow

        public SignalRClient SignalRClient { get; set; }
        public object Data { get; set; }
        public void Run()
        {
            //var msg = $"ClusterGroupId: {Data.ClusterGroupId}, Cluster #:{Data.ClusterNumber}, Panel #:{Data.PanelNumber}, CPU #:{Data.CpuNumber}";
            var msg = string.Empty;
            if( Data != null)
                msg = Data.GetType().ToString();
            this.Log().InfoFormat($"{DateTimeOffset.Now.TimeOfDay} MercPanelMessageDecoderWorkflow processing message: {msg}");
        }

        #endregion
    }
}
