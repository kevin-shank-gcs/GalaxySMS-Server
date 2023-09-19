using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Business.Contracts
{
    [ServiceContract(CallbackContract = typeof(IGalaxyPanelCommunicationEventServiceCallback))]
    public interface IGalaxyPanelCommunicationEventService
    {
        [OperationContract(IsOneWay = true)]
        void RegisterClient(GalaxyPanelCommunicationManagerEventSubscriber client);

        [OperationContract(IsOneWay = true)]
        void UnregisterClient(GalaxyPanelCommunicationManagerEventSubscriber client);

        [OperationContract(IsOneWay = true)]
        void SetConnectionDebuggingModeForClient(ConnectionDebuggingModeForSubscriber client);

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for galaxy panel communication event service callback. </summary>
    ///
    /// <remarks>   Kevin, 3/25/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface IGalaxyPanelCommunicationEventServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void BroadcastCpuConnectionInfoToClient(CpuConnectionInfo cpuInfo);
       
        [OperationContract(IsOneWay = true)]
        void BroadcastPanelInformationToClient(GalaxyCpuInformation galaxyCpuInfo);
        
        [OperationContract(IsOneWay = true)]
        void BroadcastPanelDebugPacketToClient(CpuDataPacket dataPacket);
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for galaxy panel communication manager service. </summary>
    ///
    /// <remarks>   Kevin, 3/20/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [ServiceContract]
    public interface IGalaxyPanelCommunicationManagerService
    {
        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        void Start();

        [OperationContract]
        void Stop();

        [OperationContract]
        Boolean GetRunningStatus();

        [OperationContract]
        CpuConnectionInfo[] GetConnections(GetCpuConnectionsParameters parameters);
        
        [OperationContract]
        bool IsPanelOnline(int clusterGroupId, int clusterNumber, int panelNumber);

        [OperationContract]
        void SendDataPacket(RawDataToSend dataPacket);

        [OperationContract]
        TestData[] GetTestDataItems();

        [OperationContract]
        TestData GetTestData();

        [OperationContract]
        String[] GetTestStrings();

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        SendDataResponse<AbaSettings> SendAbaSettings(SendDataParameters<AbaSettings> data);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        SendDataResponse<Cluster_CommonPanelLoadData> SendClusterCommonSettingsToPanels(SendDataParameters<Cluster_CommonPanelLoadData> data);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        SendDataResponse<GalaxyInterfaceBoardSection_PanelLoadData> SendInterfaceBoardSectionData(SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData> data);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        SendDataResponse<AccessPortal_PanelLoadData> SendAccessPortalSettingsToPanel(SendDataParameters<AccessPortal_PanelLoadData> data);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        SendDataResponse<GalaxyPanelResetCommand> SendResetCommandToPanel(SendDataParameters<GalaxyPanelResetCommand> data);


    }
}
