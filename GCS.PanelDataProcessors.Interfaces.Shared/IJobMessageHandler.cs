using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.PanelDataProcessors.Interfaces
{
    public interface IJobMessageHandler
    {
        void HandleMessage(object msg);
        Task HandleMessageAsync(object msg);
    }
}
