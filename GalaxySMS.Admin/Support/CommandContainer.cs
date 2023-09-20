using GCS.Core.Common.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Admin.Support
{
    public class CommandContainer
    {
        public string Text { get; set; }
        public string ToolTip { get; set; }
        public DelegateCommand<object> TheCommand { get; set; }
        public string HexCommandString { get; set; }
        public GCS.PanelProtocols.Enums.PacketDataCodeTo6xx CommandCode { get; set; }
    }
}
