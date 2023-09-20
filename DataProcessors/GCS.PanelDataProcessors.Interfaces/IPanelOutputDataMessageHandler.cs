using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.PanelDataProcessors.Interfaces
{
    public interface IPanelOutputDataMessageHandler
    {
        void HandleMessage(object msg);
    }
}
