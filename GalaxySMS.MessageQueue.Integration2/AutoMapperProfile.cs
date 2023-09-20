using AutoMapper;
using NetEntities = GalaxySMS.Business.Entities;
using NetStdEntities = GalaxySMS.Business.Entities.NetStd2;

namespace GalaxySMS.MessageQueue.Integration2
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            this.CreateMap<NetEntities.PanelCredentialActivityLogMessage, NetStdEntities.PanelCredentialActivityLogMessage>().ReverseMap();
            this.CreateMap<NetEntities.PanelActivityLogMessage, NetStdEntities.PanelActivityLogMessage>().ReverseMap();
            this.CreateMap<NetEntities.PanelActivityLogMessageBase, NetStdEntities.PanelActivityLogMessageBase>().ReverseMap();
            this.CreateMap<NetEntities.AccessPortalStatusReply, NetStdEntities.AccessPortalStatusReply>().ReverseMap();
            this.CreateMap<NetEntities.PanelMessageBase, NetStdEntities.PanelMessageBase>().ReverseMap();
            this.CreateMap<NetEntities.BoardSectionNodeHardwareAddress, NetStdEntities.BoardSectionNodeHardwareAddress>().ReverseMap();
            this.CreateMap<NetEntities.BoardSectionHardwareAddress, NetStdEntities.BoardSectionHardwareAddress>().ReverseMap();
            this.CreateMap<NetEntities.BoardHardwareAddress, NetStdEntities.BoardHardwareAddress>().ReverseMap();
            this.CreateMap<NetEntities.CpuHardwareAddress, NetStdEntities.CpuHardwareAddress>().ReverseMap();
            this.CreateMap<NetEntities.CpuHardwareAddress, NetStdEntities.CpuHardwareAddressSimple>().ReverseMap();
            this.CreateMap<NetEntities.ClusterAddress, NetStdEntities.ClusterAddress>().ReverseMap();
            this.CreateMap<NetEntities.ClusterAddress, NetStdEntities.ClusterAddressSimple>().ReverseMap();

            this.CreateMap<NetEntities.GalaxyRegion, NetStdEntities.GalaxyRegion>().ReverseMap();
            this.CreateMap<NetEntities.GalaxySite, NetStdEntities.GalaxySite>().ReverseMap();

            this.CreateMap<NetEntities.InputDeviceStatusReply, NetStdEntities.InputDeviceStatusReply>().ReverseMap();
            this.CreateMap<NetEntities.PanelBoardInformationCollection, NetStdEntities.PanelBoardInformationCollection>().ReverseMap();
            this.CreateMap<NetEntities.PanelBoardInformationCollection, NetStdEntities.PanelBoardInformationCollectionSignalR>();

            this.CreateMap<NetEntities.PanelBoardInformation, NetStdEntities.PanelBoardInformation>().ReverseMap();
            this.CreateMap<NetEntities.PanelInqueryReply, NetStdEntities.PanelInqueryReply>().ReverseMap();
            this.CreateMap<NetEntities.PanelInqueryReply, NetStdEntities.PanelInqueryReplySignalR>();
            this.CreateMap<NetEntities.FirmwareVersion, NetStdEntities.FirmwareVersion>().ReverseMap();
            this.CreateMap<NetEntities.CredentialCountReply, NetStdEntities.CredentialCountReply>().ReverseMap();
            this.CreateMap<NetEntities.CredentialCountReply, NetStdEntities.CredentialCountReplySignalR>();
            this.CreateMap<NetEntities.LoggingStatusReply, NetStdEntities.LoggingStatusReply>().ReverseMap();
            this.CreateMap<NetEntities.LoggingStatusReply, NetStdEntities.LoggingStatusReplySignalR>().ReverseMap();
            this.CreateMap<NetEntities.FlashProgressMessage, NetStdEntities.FlashProgressMessage>().ReverseMap();
            this.CreateMap<NetEntities.PanelLoadDataReply, NetStdEntities.PanelLoadDataReply>().ReverseMap();
            this.CreateMap<NetEntities.PanelLoadDataReply, NetStdEntities.PanelLoadDataReplySignalR>();
            this.CreateMap<NetEntities.CredentialLoadedData, NetStdEntities.CredentialLoadedData>().ReverseMap();
            this.CreateMap<NetEntities.SerialChannelGalaxyDoorModuleDataCollection, NetStdEntities.SerialChannelGalaxyDoorModuleDataCollection>().ReverseMap();
            this.CreateMap<NetEntities.SerialChannelGalaxyDoorModuleData, NetStdEntities.SerialChannelGalaxyDoorModuleData>().ReverseMap();
            this.CreateMap<NetEntities.SerialChannelGalaxyInputModuleDataCollection, NetStdEntities.SerialChannelGalaxyInputModuleDataCollection>().ReverseMap();
            this.CreateMap<NetEntities.SerialChannelGalaxyInputModuleData, NetStdEntities.SerialChannelGalaxyInputModuleData>().ReverseMap();
            this.CreateMap<NetEntities.AcknowledgedAlarmBasicData, NetStdEntities.AcknowledgedAlarmBasicData>().ReverseMap();
            this.CreateMap<NetEntities.InputDeviceVoltagesReply, NetStdEntities.InputDeviceVoltagesReply>().ReverseMap();
            this.CreateMap<NetEntities.CpuConnectionInfo, NetStdEntities.CpuConnectionInfo>().ReverseMap();
            this.CreateMap<NetEntities.BackgroundJobInfo, NetStdEntities.BackgroundJobInfo>().ReverseMap();
            this.CreateMap<NetEntities.BackgroundJobStateChangeInfo, NetStdEntities.BackgroundJobStateChangeInfo>().ReverseMap();
            this.CreateMap<NetEntities.GalaxyCpuInformation, NetStdEntities.GalaxyCpuInformation>().ReverseMap();
            this.CreateMap<NetEntities.GalaxyCpuDatabaseInformation, NetStdEntities.GalaxyCpuDatabaseInformation>().ReverseMap();
            this.CreateMap<NetEntities.GalaxyPanel_GetAlertEventAcknowledgeData, NetStdEntities.GalaxyPanel_GetAlertEventAcknowledgeData>().ReverseMap();
            this.CreateMap<NetEntities.GalaxyCpuCommandBase, NetStdEntities.GalaxyCpuCommandBase>().ReverseMap();
            this.CreateMap<NetEntities.InitializeBoardSectionSettings, NetStdEntities.InitializeBoardSectionSettings>().ReverseMap();
            this.CreateMap<NetEntities.GalaxyRawActivityEvent, NetStdEntities.GalaxyRawActivityEvent>().ReverseMap();
            this.CreateMap<NetEntities.AccessPortalActivityEvent, NetStdEntities.AccessPortalActivityEvent>().ReverseMap();
            this.CreateMap<NetEntities.GalaxyPanelActivityEvent, NetStdEntities.GalaxyPanelActivityEvent>().ReverseMap();
            this.CreateMap<NetEntities.InputDeviceActivityEvent, NetStdEntities.InputDeviceActivityEvent>().ReverseMap();
            this.CreateMap<NetEntities.OutputDeviceActivityEvent, NetStdEntities.OutputDeviceActivityEvent>().ReverseMap();
            this.CreateMap<NetEntities.CredentialToDeleteFromCpu, NetStdEntities.CredentialToDeleteFromCpu>().ReverseMap();
            this.CreateMap<NetEntities.GalaxyCpuSaveInformationData, NetStdEntities.GalaxyCpuSaveInformationData>().ReverseMap();
            this.CreateMap<NetEntities.GalaxyPanelAlarmEventAcknowledgment, NetStdEntities.GalaxyPanelAlarmEventAcknowledgment>().ReverseMap();
            this.CreateMap<NetEntities.InputDeviceAlarmEventAcknowledgment, NetStdEntities.InputDeviceAlarmEventAcknowledgment>().ReverseMap();
            this.CreateMap<NetEntities.AccessPortalAlarmEventAcknowledgment, NetStdEntities.AccessPortalAlarmEventAcknowledgment>().ReverseMap();
            this.CreateMap<NetEntities.AccessPortalActivityAlarmEvent, NetStdEntities.AccessPortalActivityAlarmEvent>().ReverseMap();
            this.CreateMap<NetEntities.InputDeviceActivityAlarmEvent, NetStdEntities.InputDeviceActivityAlarmEvent>().ReverseMap();
            this.CreateMap<NetEntities.OperationStatusInfo, NetStdEntities.OperationStatusInfo>().ReverseMap();
            this.CreateMap<NetEntities.SignalREnvelope<NetEntities.OperationStatusInfo>, NetStdEntities.SignalREnvelope<NetStdEntities.OperationStatusInfo>>().ReverseMap();
            this.CreateMap<NetEntities.PingReply, NetStdEntities.PingReply>().ReverseMap();
            this.CreateMap<NetEntities.PingReply, NetStdEntities.PingReplySignalR>();
            this.CreateMap<NetEntities.CredentialCommandReply, NetStdEntities.CredentialCommandReply>().ReverseMap();
            this.CreateMap<NetEntities.CredentialCommandReply, NetStdEntities.CredentialCommandReplySignalR>();

            //this.CreateMap<NetEntities.InputDeviceActivityEvent, NetStdEntities.InputDeviceActivityEvent>().ReverseMap();
            //this.CreateMap<NetEntities.InputDeviceActivityEvent, NetStdEntities.InputDeviceActivityEvent>().ReverseMap();
            //this.CreateMap<NetEntities.InputDeviceActivityEvent, NetStdEntities.InputDeviceActivityEvent>().ReverseMap();
            //this.CreateMap<NetEntities.InputDeviceActivityEvent, NetStdEntities.InputDeviceActivityEvent>().ReverseMap();
            //this.CreateMap<NetEntities.InputDeviceActivityEvent, NetStdEntities.InputDeviceActivityEvent>().ReverseMap();
            //this.CreateMap<NetEntities.InputDeviceActivityEvent, NetStdEntities.InputDeviceActivityEvent>().ReverseMap();

        }
    }

}
