using System;
using GalaxySMS.Business.Entities;
using GalaxySMS.Business.SignalR;
using GalaxySMS.Common.Enums;
using GalaxySMS.MessageQueue.Integration.Workflows.Spec;
using GCS.Core.Common.Logger;

namespace GalaxySMS.MessageQueue.Integration.Workflows
{
    public class PanelMessageReceivedWorkflow : IPanelMessageWorkflow
    {
        public SignalRClient SignalRClient { get; set; }
        public object Data { get; set; }

        public void Run()
        {
            var msg = string.Empty;
            if (Data != null)
            {
                var t = Data.GetType();
                msg = t.ToString();
                var logString = $"{DateTimeOffset.Now.TimeOfDay} PanelMessageReceivedWorkflow processing message: {msg}";
                //this.Log().InfoFormat( logString);
                if (t == typeof(PanelCredentialActivityLogMessage))
                {
                    if (Data is PanelCredentialActivityLogMessage activityLogMessage)
                        try
                        {
                            if (SignalRClient != null)
                                SignalRClient.NotifyPanelCredentialActivityMessageAsync(activityLogMessage);
                            logString += $"{Environment.NewLine}{activityLogMessage.DateTimeOffset}, {activityLogMessage.DeviceDescription}, {activityLogMessage.PanelActivityType}, {activityLogMessage.PersonDescription}";
                            //this.Log().InfoFormat(
                            //    $"{activityLogMessage.DateTimeOffset}, {activityLogMessage.DeviceDescription}, {activityLogMessage.PanelActivityType}, {activityLogMessage.PersonDescription}");
                        }
                        catch (Exception e)
                        {
                            this.Log().ErrorFormat(
                                $"{DateTimeOffset.Now.TimeOfDay} PanelMessageReceivedWorkflow PanelActivityLogMessageCredential error: {e}");
                        }
                }
                else if (t == typeof(PanelActivityLogMessage))
                {
                    if (Data is PanelActivityLogMessage activityLogMessage)
                        try
                        {
                            SignalRClient.NotifyPanelActivityMessageAsync(activityLogMessage);
                            switch (activityLogMessage.PanelActivityType)
                            {
                                case PanelActivityEventCode.IoGroupDisarmedBySchedule:
                                case PanelActivityEventCode.IoGroupArmedBySchedule:
                                case PanelActivityEventCode.IoGroupArmedByCommand:
                                case PanelActivityEventCode.IoGroupDisarmedByCommand:
                                case PanelActivityEventCode.IoGroupShuntedByCommand:
                                case PanelActivityEventCode.IoGroupUnshuntedByCommand:
                                case PanelActivityEventCode.IoGroupArmByCard:
                                case PanelActivityEventCode.IoGroupDisarmByCard:
                                    logString += $"{Environment.NewLine}{activityLogMessage.DateTimeOffset}, {activityLogMessage.DeviceDescription}, {activityLogMessage.PanelActivityType} IOGroup:{activityLogMessage.InputOutputGroupNumber}, {activityLogMessage.InputOutputGroupName}";
                                    break;

                                case PanelActivityEventCode.DoorForcedOpen:
                                case PanelActivityEventCode.DoorLeftOpen:
                                case PanelActivityEventCode.DoorClosed:
                                case PanelActivityEventCode.ReadError:
                                case PanelActivityEventCode.DoorContactShunted:
                                case PanelActivityEventCode.DoorRequestToExit:
                                case PanelActivityEventCode.DoorUnlockBySchedule:
                                case PanelActivityEventCode.DoorLockBySchedule:
                                case PanelActivityEventCode.DoorDelayedUnlock:
                                case PanelActivityEventCode.CpuWarmReset:
                                case PanelActivityEventCode.CpuColdReset:
                                case PanelActivityEventCode.PointInTrouble:
                                //case PanelActivityEventCode.PointInTroubleOpenCircuit:
                                case PanelActivityEventCode.PointTroubleShortCircuit:
                                case PanelActivityEventCode.PointSecureUnarmed:
                                case PanelActivityEventCode.PointAlarmUnarmed:
                                case PanelActivityEventCode.PointSecureArmed:
                                case PanelActivityEventCode.PointAlarmArmed:
                                case PanelActivityEventCode.PointShuntedByCommand:
                                case PanelActivityEventCode.PointUnshuntedByCommand:
                                case PanelActivityEventCode.PointTakenOutOfServiceByCommand:
                                case PanelActivityEventCode.PointReturnedToServiceByCommand:
                                case PanelActivityEventCode.OutputOffBySchedule:
                                case PanelActivityEventCode.OutputOnBySchedule:
                                case PanelActivityEventCode.OutputOnByCommand:
                                case PanelActivityEventCode.OutputOffByCommand:
                                case PanelActivityEventCode.OutputTakenOutOfServiceByCommand:
                                case PanelActivityEventCode.OutputReturnedToServiceByCommand:
                                case PanelActivityEventCode.DeviceOffline:
                                case PanelActivityEventCode.DeviceOnline:
                                case PanelActivityEventCode.Relay2OffBySchedule:
                                case PanelActivityEventCode.Relay2OnBySchedule:
                                case PanelActivityEventCode.DoorContactTroubleOpenCircuit:
                                case PanelActivityEventCode.DoorContactTroubleShortCircuit:
                                case PanelActivityEventCode.DoorHeartbeartAlarm:
                                case PanelActivityEventCode.DoorHeartbeatRestored:
                                case PanelActivityEventCode.DoorContactTroubleCleared:
                                case PanelActivityEventCode.BoardCommunicationStopped:
                                case PanelActivityEventCode.BoardCommunicationStarted:
                                case PanelActivityEventCode.ReaderHeartbeatStopped:
                                case PanelActivityEventCode.ReaderHeartbeatStarted:
                                case PanelActivityEventCode.ReaderLowBattery:
                                case PanelActivityEventCode.ReaderBatteryFlat:
                                case PanelActivityEventCode.ReaderBatteryOk:
                                case PanelActivityEventCode.CredentialNotInPanelMemory:
                                case PanelActivityEventCode.CredentialNotInPanelMemoryReverse:
                                case PanelActivityEventCode.AccessGrantedNoCardCodeLookup:
                                case PanelActivityEventCode.AccessDeniedAttemptPivCardExpired:
                                case PanelActivityEventCode.AccessDenied:
                                case PanelActivityEventCode.AccessGranted:
                                case PanelActivityEventCode.AccessGrantedDoorNotOpened:
                                case PanelActivityEventCode.AutoUnlockActivatedByAccessGranted:
                                case PanelActivityEventCode.CredentialDoublePresentDoorUnlocked:
                                case PanelActivityEventCode.CredentialDoublePresentDoorLocked:

                                case PanelActivityEventCode.AccessGrantedWithPinData:
                                case PanelActivityEventCode.Duress:
                                case PanelActivityEventCode.PassbackViolation:
                                case PanelActivityEventCode.IncorrectPinEntered:
                                case PanelActivityEventCode.PassbackForgivenForUser:
                                case PanelActivityEventCode.PassbackForgivenForAllUsers:
                                case PanelActivityEventCode.CredentialActivated:
                                case PanelActivityEventCode.CredentialDeactivated:
                                case PanelActivityEventCode.OtisElevatorAudit:
                                case PanelActivityEventCode.ReaderRadioInterferenceDetected:
                                case PanelActivityEventCode.ReaderRadioInterferenceCleared:
                                case PanelActivityEventCode.ReaderPrivacyModeEntered:
                                case PanelActivityEventCode.ReaderPrivacyModeExited:
                                case PanelActivityEventCode.ReaderOfficeModeEntered:
                                case PanelActivityEventCode.ReaderOfficeModeExited:
                                case PanelActivityEventCode.ReaderNdeMagnetAlertNeedsCalibrated:
                                case PanelActivityEventCode.ReaderNdeMagnetSafeCalibrated:
                                case PanelActivityEventCode.DoorContactChange:
                                case PanelActivityEventCode.VeridtReaderTamperAlarm:
                                case PanelActivityEventCode.VeridtReaderTamperSafe:
                                case PanelActivityEventCode.VeridtCardCertificateProblem:
                                case PanelActivityEventCode.VeridtReaderFactorModeSet:
                                case PanelActivityEventCode.CpuTamperRestored:
                                case PanelActivityEventCode.CpuTamperAlarm:
                                case PanelActivityEventCode.CpuLowBatteryRestored:
                                case PanelActivityEventCode.CpuLowBatteryAlarm:
                                case PanelActivityEventCode.CpuAcFailureRestored:
                                case PanelActivityEventCode.CpuAcFailureAlarm:
                                case PanelActivityEventCode.EmergencyUnlockInactive:
                                case PanelActivityEventCode.EmergencyUnlockActive:
                                case PanelActivityEventCode.ReaderTamperAlarm:
                                case PanelActivityEventCode.ReaderTamperRestored:
                                case PanelActivityEventCode.CrisisModeActivated:
                                case PanelActivityEventCode.CrisisModeDeActivated:
                                case PanelActivityEventCode.CrisisModeActivatedByCommand:
                                case PanelActivityEventCode.CrisisModeDeActivatedByCommand:
                                case PanelActivityEventCode.CpuTurnLoggingOn:
                                case PanelActivityEventCode.CpuTurnLoggingOff:
                                case PanelActivityEventCode.DualSerialInterfaceRelayBoardOffline:
                                case PanelActivityEventCode.DualSerialInterfaceRelayBoardOnline:
                                case PanelActivityEventCode.DualSerialInterfaceDoorModuleOffline:
                                case PanelActivityEventCode.DualSerialInterfaceDoorModuleOnline:
                                case PanelActivityEventCode.DualSerialInterfaceInputModuleOffline:
                                case PanelActivityEventCode.DualSerialInterfaceInputModuleOnline:
                                case PanelActivityEventCode.CardTourStarting:
                                case PanelActivityEventCode.CardTourContinuing:
                                case PanelActivityEventCode.CardTourCompleted:
                                case PanelActivityEventCode.CardTourOverdue:
                                case PanelActivityEventCode.CardTourIncorrectStartReader:
                                case PanelActivityEventCode.CardTourNonExistantTour:
                                case PanelActivityEventCode.CommandUnlockDoor:
                                case PanelActivityEventCode.CommandLockDoor:
                                case PanelActivityEventCode.CommandDisableDoor:
                                case PanelActivityEventCode.CommandEnableDoor:
                                case PanelActivityEventCode.CommandPulseDoor:
                                case PanelActivityEventCode.CommandRelay2Off:
                                case PanelActivityEventCode.CommandRelay2On:
                                case PanelActivityEventCode.CommandUnlockDoorGroup:
                                case PanelActivityEventCode.CommandLockDoorGroup:
                                case PanelActivityEventCode.CommandDisableDoorGroup:
                                case PanelActivityEventCode.CommandEnableDoorGroup:
                                case PanelActivityEventCode.CommandShuntIOGroup:
                                case PanelActivityEventCode.CommandUnshuntIOGroup:
                                case PanelActivityEventCode.CommandDisableInput:
                                case PanelActivityEventCode.CommandEnableInput:
                                case PanelActivityEventCode.CommandArmIOGroup:
                                case PanelActivityEventCode.CommandDisarmIOGroup:
                                case PanelActivityEventCode.CommandShuntInput:
                                case PanelActivityEventCode.CommandUnshuntInput:
                                case PanelActivityEventCode.CommandOutputOn:
                                case PanelActivityEventCode.CommandOutputOff:
                                case PanelActivityEventCode.CommandOutputEnable:
                                case PanelActivityEventCode.CommandOutputDisable:
                                case PanelActivityEventCode.CommandElevatorPulse:
                                case PanelActivityEventCode.CommandElevatorEarlyOn:
                                case PanelActivityEventCode.CommandElevatorEarlyOff:
                                case PanelActivityEventCode.CommandElevatorCancelEarlyOn:
                                case PanelActivityEventCode.CommandElevatorCancelEarlyOff:
                                default:
                                    logString += $"{Environment.NewLine}{activityLogMessage.DateTimeOffset}, {activityLogMessage.DeviceDescription}, {activityLogMessage.PanelActivityType}";
                                    break;
                            }
                        }
                        catch (Exception e)
                        {
                            this.Log().ErrorFormat(
                                $"{DateTimeOffset.Now.TimeOfDay} PanelMessageReceivedWorkflow PanelActivityLogMessage error: {e}");
                        }
                }
                else if (t == typeof(AccessPortalStatusReply))
                {
                    if (Data is AccessPortalStatusReply apsr)
                    {
                        SignalRClient.NotifyAccessPortalStatusReplyAsync(apsr);
                        logString += $" {apsr.UniqueId}";
                    }
                }
                else if (t == typeof(InputDeviceStatusReply))
                {
                    if (Data is InputDeviceStatusReply idsr)
                    {
                        SignalRClient.NotifyInputDeviceStatusReplyAsync(idsr);
                        logString += $" {idsr.UniqueId}";
                    }
                }
                else if (t == typeof(PanelBoardInformationCollection))
                {
                    if (Data is PanelBoardInformationCollection pbic)
                    {
                        SignalRClient.NotifyPanelBoardInformationCollectionAsync(pbic);
                        logString += $" {pbic.UniqueId}";
                    }
                }
                else if (t == typeof(PanelInqueryReply))
                {
                    if (Data is PanelInqueryReply o)
                    {
                        SignalRClient.NotifyPanelInqueryReplyAsync(o);
                        logString += $" {o.UniqueId}";
                    }
                }
                else if (t == typeof(CredentialCountReply))
                {
                    if (Data is CredentialCountReply o)
                    {
                        SignalRClient.NotifyCardCountReplyAsync(o);
                        logString += $" {o.UniqueId}";
                    }
                }
                else if (t == typeof(LoggingStatusReply))
                {
                    if (Data is LoggingStatusReply o)
                    {
                        SignalRClient.NotifyLoggingStatusReplyAsync(o);
                        logString += $" {o.UniqueId}";
                    }
                }
                else if (t == typeof(FlashProgressMessage))
                {
                    if (Data is FlashProgressMessage o)
                    {
                        SignalRClient.NotifyFlashProgressMessageAsync(o);
                        logString += $" {o.UniqueCpuId}";
                    }
                }
                else if (t == typeof(PanelLoadDataReply))
                {
                    if (Data is PanelLoadDataReply o)
                    {
                        SignalRClient.NotifyPanelLoadDataReplyAsync(o);
                        logString += $"{Environment.NewLine}{o.UniqueId} {DateTimeOffset.Now.TimeOfDay} PanelLoadDataReply: {o}, {o.DataType} => {o.AckNack}";
                    }
                }
                else if (t == typeof(SerialChannelGalaxyDoorModuleDataCollection))
                {
                    if (Data is SerialChannelGalaxyDoorModuleDataCollection mdc)
                    {
                        SignalRClient.NotifySerialChannelGalaxyDoorModuleDataCollectionAsync(mdc);
                        logString += $" {mdc.UniqueId}";
                    }
                }
                else if (t == typeof(SerialChannelGalaxyInputModuleDataCollection))
                {
                    if (Data is SerialChannelGalaxyInputModuleDataCollection mdc)
                    {
                        SignalRClient.NotifySerialChannelGalaxyInputModuleDataCollectionAsync(mdc);
                        logString += $" {mdc.UniqueId}";
                    }
                }
                else if (t == typeof(PanelMessageBase))
                {
                    if (Data is PanelMessageBase panelMessageBase)
                    {
                        logString += $"{Environment.NewLine}{panelMessageBase.UniqueId} {panelMessageBase.RawData[0]:x02} {panelMessageBase.RawData[1]:x02} {panelMessageBase.RawData[2]:x02} {panelMessageBase.RawData[3]:x02}";

                    }
                }
                else if (t == typeof(AcknowledgedAlarmBasicData))
                {
                    if (Data is AcknowledgedAlarmBasicData o)
                    {
                        SignalRClient.NotifyAcknowledgedAlarmBasicDataAsync(o);
                        logString += $"{Environment.NewLine}{o.AckedUpdatedDateTime}: {o.AckedByUserDisplayName} - {o.Response}";

                    }
                }
                else if (t == typeof(InputDeviceVoltagesReply))
                {
                    if (Data is InputDeviceVoltagesReply idvr)
                    {
                        SignalRClient.NotifyInputDeviceVoltagesReplyAsync(idvr);
                        logString += $" {idvr.UniqueId}";
                    }
                }
                else if( t == typeof(CpuConnectionInfo))
                {
                    if (Data is CpuConnectionInfo cpuConnInfo)
                    {
                        SignalRClient.NotifyCpuConnectionInfoAsync(cpuConnInfo);
                        logString += $" ClusterGroupId:{cpuConnInfo.GalaxyCpuInformation.ClusterGroupId}, Cluster #:{cpuConnInfo.GalaxyCpuInformation.ClusterNumber}, Panel #:{cpuConnInfo.GalaxyCpuInformation.PanelNumber}, Cpu #:{cpuConnInfo.GalaxyCpuInformation.CpuId} IsConnected:{cpuConnInfo.IsConnected}";
                    }
                }
                this.Log().InfoFormat(logString);
            }
        }


        private void SendNotificationEvent()
        {
        }
    }
}