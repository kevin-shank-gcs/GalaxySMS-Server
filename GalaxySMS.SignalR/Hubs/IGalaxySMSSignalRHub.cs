using GalaxySMS.Business.Entities;
using GCS.Core.Common.SignalR;

namespace GalaxySMS.SignalR.Hubs
{
    public interface IGalaxySMSSignalRHub
    {
        Task JoinGroup(SignalRGroup group);
        Task LeaveGroup(SignalRGroup group);
        Task SendMessage(string message);
        Task NotifyPanelBoardInformationCollection(PanelBoardInformationCollectionSignalR data);
        Task NotifySerialChannelGalaxyDoorModuleDataCollection(SerialChannelGalaxyDoorModuleDataCollection data);
        Task NotifySerialChannelGalaxyInputModuleDataCollection(SerialChannelGalaxyInputModuleDataCollection data);
        Task NotifyPanelInqueryReply(PanelInqueryReplySignalR data);
        Task NotifyPingReply(PingReplySignalR data);
        Task NotifyCardCountReply(CredentialCountReplySignalR data);
        Task NotifyLoggingStatusReply(LoggingStatusReplySignalR data);
        Task NotifyFlashProgressMessage(FlashProgressMessage data);
        Task NotifyPanelLoadDataReply(PanelLoadDataReplySignalR data);
        Task NotifyAccessPortalStatusReply(AccessPortalStatusReply data);
        Task NotifyInputDeviceStatusReply(InputDeviceStatusReply data);
        Task NotifyInputDeviceVoltagesReply(InputDeviceVoltagesReply data);
        Task NotifyCpuConnectionInfo(CpuConnectionInfo data);
        Task NotifyBackgroundJobInfo(BackgroundJobInfo data);
        Task NotifyOperationStatusInfo(OperationStatusInfo data);
        Task NotifyPanelActivityLogMessage(PanelActivityLogMessage data);
        Task NotifyPanelCredentialActivityLogMessage(PanelCredentialActivityLogMessage data);
        Task NotifyAcknowledgedAlarmBasicData(AcknowledgedAlarmBasicData data);
        Task NotifyPanelActivityAlarmLogMessage(PanelActivityLogMessage data);
        Task NotifyPanelCredentialActivityAlarmLogMessage(PanelCredentialActivityLogMessage data);

    }
}
