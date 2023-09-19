using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationServerWinForm.Interfaces
{
    interface IConnectionDebugWindow
    {
        void HandlePacket(GCS.PanelCommunication.PanelCommunicationServerAsync.ConnectionDebugPacketEventArgs e);
        void InitializeComponent();
        string InstanceGuid { get; }
    }
}
