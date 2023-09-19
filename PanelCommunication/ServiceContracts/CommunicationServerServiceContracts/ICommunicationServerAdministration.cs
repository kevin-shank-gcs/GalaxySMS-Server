using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using GCS.DataContracts.PanelEntities.Enums;
using GCS.DataContracts.PanelEntities;
using GCS.DataContracts.ServiceControl;

namespace GCS.CommunicationServerServiceContracts
{
    [ServiceContract(Namespace = "GCS.CommunicationServerAdmin")]
    public interface ICommunicationServerAdministration
    {
        [OperationContract]
        CommunicationServerSettings SetCommunicationServerSettings(CommunicationServerSettings settings);

        [OperationContract]
        CommunicationServerSettings GetCommunicationServerSettings();

        [OperationContract]
        YesNo IsCommunicationServerStarted();

        [OperationContract]
        YesNo StartCommunicationServer();

        [OperationContract]
        YesNo StopCommunicationServer();

        [OperationContract]
        CpuConnectionInfo[] GetConnections();
    }
}
