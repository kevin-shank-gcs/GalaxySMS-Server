using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Contracts;
using GalaxySMS.Client.Entities;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.ServiceModel.Extensions;

namespace GalaxySMS.Client.Proxies
{
    [Export(typeof(IGalaxyPanelCommunicationManagerService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    //[ApplicationUserSessionHeaderInspectorBehavior]
    public class GalaxyPanelCommunicationManagerClient : UserClientBase<IGalaxyPanelCommunicationManagerService>, IGalaxyPanelCommunicationManagerService
    {
        public void Start()
        {
            base.InsertUserDataToOutgoingHeader();
            Channel.Start();
        }

        public void Stop()
        {
            base.InsertUserDataToOutgoingHeader();
            Channel.Stop();
        }

        public bool GetRunningStatus()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetRunningStatus();
        }

        public Entities.CpuConnectionInfo[] GetConnections(GetCpuConnectionsParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetConnections(parameters);
        }

        public void SendDataPacket(RawDataToSend dataPacket)
        {
            base.InsertUserDataToOutgoingHeader();
            Channel.SendDataPacket(dataPacket);
        }

        public Entities.TestData[] GetTestDataItems()
        {
            base.InsertUserDataToOutgoingHeader();
            TestData[] temp = Channel.GetTestDataItems();
            return temp;
        }
        public Entities.TestData GetTestData()
        {
            base.InsertUserDataToOutgoingHeader();
            TestData temp = Channel.GetTestData();
            return temp;
        }

        public String[] GetTestStrings()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetTestStrings();
        }


        public SendDataResponse<AbaSettings> SendAbaSettings(SendDataParameters<AbaSettings> data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendAbaSettings(data);
        }

        public SendDataResponse<Cluster_CommonPanelLoadData> SendClusterCommonSettingsToPanels(SendDataParameters<Cluster_CommonPanelLoadData> data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendClusterCommonSettingsToPanels(data);
        }
        public SendDataResponse<GalaxyInterfaceBoardSection_PanelLoadData> SendInterfaceBoardSectionData(SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData> data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendInterfaceBoardSectionData(data);
        }

        public SendDataResponse<AccessPortal_PanelLoadData> SendAccessPortalSettingsToPanel(SendDataParameters<AccessPortal_PanelLoadData> data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendAccessPortalSettingsToPanel(data);
        }

        public SendDataResponse<GalaxyPanelResetCommand> SendResetCommandToPanel(SendDataParameters<GalaxyPanelResetCommand> data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendResetCommandToPanel(data);
        }

        public Task StartAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.StartAsync();
        }

        public Task StopAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.StopAsync();
        }

        public Task<bool> GetRunningStatusAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetRunningStatusAsync();
        }

        public Task<Entities.CpuConnectionInfo[]> GetConnectionsAsync(GetCpuConnectionsParameters parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetConnectionsAsync(parameters);
        }

        public Task SendDataPacketAsync(RawDataToSend dataPacket)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendDataPacketAsync(dataPacket);
        }
        public Task<Entities.TestData[]> GetTestDataItemsAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetTestDataItemsAsync();
        }
         
        public Task<Entities.TestData> GetTestDataAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetTestDataAsync();
        }

        public Task<String[]> GetTestStringsAsync()
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetTestStringsAsync();
        }

        public Task<SendDataResponse<AbaSettings>> SendAbaSettingsAsync(SendDataParameters<AbaSettings> data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendAbaSettingsAsync(data);
        }

        public Task<SendDataResponse<Cluster_CommonPanelLoadData>> SendClusterCommonSettingsToPanelsAsync(SendDataParameters<Cluster_CommonPanelLoadData> data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendClusterCommonSettingsToPanelsAsync(data);
        }

        public Task<SendDataResponse<GalaxyInterfaceBoardSection_PanelLoadData>> SendInterfaceBoardSectionDataAsync(SendDataParameters<GalaxyInterfaceBoardSection_PanelLoadData> data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendInterfaceBoardSectionDataAsync(data);
        }

        public Task<SendDataResponse<AccessPortal_PanelLoadData>> SendAccessPortalSettingsToPanelAsync(SendDataParameters<AccessPortal_PanelLoadData> data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendAccessPortalSettingsToPanelAsync(data);
        }

        public Task<SendDataResponse<GalaxyPanelResetCommand>> SendResetCommandToPanelAsync(SendDataParameters<GalaxyPanelResetCommand> data)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SendResetCommandToPanelAsync(data);
        }


    }


    [Export(typeof(IGalaxyPanelCommunicationEventService))]
    [Export(typeof(IGalaxyPanelCommunicationEventServiceCallback))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    //[ApplicationUserSessionHeaderInspectorBehavior]
    public class GalaxyPanelCommunicationEventClient : UserDuplexClientBase<IGalaxyPanelCommunicationEventService>, IGalaxyPanelCommunicationEventService, IGalaxyPanelCommunicationEventServiceCallback
    {
        [ImportingConstructor]
        public GalaxyPanelCommunicationEventClient(object callbackInstance) : base(callbackInstance) { }


        public void RegisterClient(GalaxyPanelCommunicationManagerEventSubscriber client)
        {
            Channel.RegisterClient(client);
        }

        public void UnregisterClient(GalaxyPanelCommunicationManagerEventSubscriber client)
        {
            Channel.UnregisterClient(client);
        }

        public void SetConnectionDebuggingModeForClient(ConnectionDebuggingModeForSubscriber client)
        {
            Channel.SetConnectionDebuggingModeForClient(client);
        }

        public void BroadcastCpuConnectionInfoToClient(CpuConnectionInfo cpuInfo)
        {
        }

        public void BroadcastPanelInformationToClient(GalaxyCpuInformation galaxyCpuInfo)
        {
        }

        public void BroadcastPanelDebugPacketToClient(CpuDataPacket dataPacket)
        {
        }


    }

}
