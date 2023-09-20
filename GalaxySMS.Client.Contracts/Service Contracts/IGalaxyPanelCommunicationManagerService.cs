using GalaxySMS.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Client.Contracts
{
    [ServiceContract(CallbackContract = typeof(IGalaxyPanelCommunicationEventServiceCallback))]
    public interface IGalaxyPanelCommunicationEventService : IServiceContract
    {
        [OperationContract(IsOneWay = true)]
        void RegisterClient(GalaxyPanelCommunicationManagerEventSubscriber client);

        [OperationContract(IsOneWay = true)]
        void UnregisterClient(GalaxyPanelCommunicationManagerEventSubscriber client);
      
        [OperationContract(IsOneWay = true)]
        void SetConnectionDebuggingModeForClient(ConnectionDebuggingModeForSubscriber client);
    }

    public interface IGalaxyPanelCommunicationEventServiceCallback : IServiceContract
    {
        [OperationContract(IsOneWay = true)]
        void BroadcastCpuConnectionInfoToClient(CpuConnectionInfo cpuInfo);

        [OperationContract(IsOneWay = true)]
        void BroadcastPanelInformationToClient(GalaxyCpuInformation galaxyCpuInfo);

        [OperationContract(IsOneWay = true)]
        void BroadcastPanelDebugPacketToClient(CpuDataPacket dataPacket);
    }

    [ServiceContract]
    public interface IGalaxyPanelCommunicationManagerService : IServiceContract
    {
        #region Sync Operations

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        void Start();

        [OperationContract]
        void Stop();

        [OperationContract]
        Boolean GetRunningStatus();

        [OperationContract]
        CpuConnectionInfo[] GetConnections();

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

        #endregion

        #region Async operations
        [OperationContract]
        Task StartAsync();

        [OperationContract]
        Task StopAsync();

        [OperationContract]
        Task<Boolean> GetRunningStatusAsync();

        [OperationContract]
        Task<CpuConnectionInfo[]> GetConnectionsAsync();
        
        [OperationContract]
        Task SendDataPacketAsync(RawDataToSend dataPacket);
       
        [OperationContract]
        Task<TestData[]> GetTestDataItemsAsync();

        [OperationContract]
        Task<TestData> GetTestDataAsync();

        [OperationContract]
        Task<String[]> GetTestStringsAsync();

        [OperationContract]
        Task<SendDataResponse<AbaSettings>> SendAbaSettingsAsync(SendDataParameters<AbaSettings> data);

        [OperationContract]
        Task<SendDataResponse<Cluster_CommonPanelLoadData>> SendClusterCommonSettingsToPanelsAsync(SendDataParameters<Cluster_CommonPanelLoadData> data);

        [OperationContract]
        Task<SendDataResponse<GalaxyInterfaceBoardSection_PanelLoadData>> SendInterfaceBoardSectionDataAsync(SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData> data);

        [OperationContract]
        Task<SendDataResponse<AccessPortal_PanelLoadData>> SendAccessPortalSettingsToPanelAsync(SendDataParameters<AccessPortal_PanelLoadData> data);

        [OperationContract]
        Task<SendDataResponse<GalaxyPanelResetCommand>> SendResetCommandToPanelAsync(SendDataParameters<GalaxyPanelResetCommand> data);


        #endregion
    }
}
