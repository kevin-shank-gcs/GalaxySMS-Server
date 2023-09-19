using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Business.SignalR;

namespace GalaxySMS.MessageQueue.Integration.Workflows.Spec
{
    public interface IPanelMessageWorkflow
    {
        SignalRClient SignalRClient {get; set;}
        object Data {get;set;}
        void Run();
    }
}
