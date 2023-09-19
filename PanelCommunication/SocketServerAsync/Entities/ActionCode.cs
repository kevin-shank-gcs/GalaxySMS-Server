using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.PanelCommunicationServerAsync.Entities
{
    public enum ActionCode
    {
        RefreshCpuDatabaseInformation,
        DisconnectCpu,
        DisconnectDeletedCpu,
        SendTimeToPanel
    }
}
