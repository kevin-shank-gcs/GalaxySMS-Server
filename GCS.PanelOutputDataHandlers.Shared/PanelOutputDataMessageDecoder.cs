using GCS.PanelDataProcessors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.PanelOutputDataHandlers
{
    public class PanelOutputDataMessageDecoder : IPanelOutputDataMessageHandler
    {
        public SystemType SystemType { get; private set; }

        public PanelOutputDataMessageDecoder()
        {
            SystemType = SystemType.Galaxy;
        }


        public void HandleMessage(object msg)
        {

        }

        public async Task HandleMessageAsync(object msg)
        {

        }
    }
}
