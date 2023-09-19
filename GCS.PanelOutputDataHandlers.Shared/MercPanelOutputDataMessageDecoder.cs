using GCS.PanelDataProcessors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.PanelOutputDataHandlers
{
    public class MercPanelOutputDataMessageDecoder : IPanelOutputDataMessageHandler
    {
        public SystemType SystemType { get; private set; }

        public MercPanelOutputDataMessageDecoder()
        {
            SystemType = SystemType.Mercury;
        }


        public void HandleMessage(object msg)
        {
            
        }

        public async Task HandleMessageAsync(object msg)
        {

        }
    }
}
