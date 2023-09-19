using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
#if NETFRAMEWORK
#if SignalRCore
using GalaxySMS.MessageQueue.Integration2;
using GCS.Core.Common.Utils;
using BusinessEntitiesStd = GalaxySMS.Business.Entities.NetStd2;
using AutoMapper;
#else
using GalaxySMS.Business.SignalR;
#endif
#elif NETCOREAPP
#endif
using GalaxySMS.Common.Enums;

using GalaxySMS.MessageQueue.Integration.Workflows.Spec;
using GCS.Core.Common.Logger;

namespace GalaxySMS.MessageQueue.Integration.Workflows
{
    public class PanelMessageReceivedWorkflow : IPanelMessageWorkflow
    {
#if NETFRAMEWORK
#if SignalRCore
        public SignalRCore.SignalRClient SignalRClient { get; set; }
        public IMapper Mapper { get; internal set; }

        public PanelMessageReceivedWorkflow()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            Mapper = configuration.CreateMapper();
        }

#else
        public SignalRClient SignalRClient { get; set; }
#endif
#elif NETCOREAPP
#endif
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
#if NETFRAMEWORK
                try
                {
                    if (t == typeof(PanelCredentialActivityLogMessage))
                    {
                        if (Data is PanelCredentialActivityLogMessage activityLogMessage)
                        {
                            if (SignalRClient != null)
                            {
#if SignalRCore
                                    SignalRClient.NotifyPanelCredentialActivityMessageAsync(
                                        Mapper.Map<BusinessEntitiesStd.PanelCredentialActivityLogMessage>(
                                            activityLogMessage));
#else
                                SignalRClient.NotifyPanelCredentialActivityMessageAsync(activityLogMessage);
#endif
                            }

                            logString +=
                                $"{Environment.NewLine}{activityLogMessage.DateTime}, {activityLogMessage.DeviceDescription}, {activityLogMessage.PanelActivityType}, {activityLogMessage.PersonDescription}";
                        }
                    }
                    else if (t == typeof(PanelActivityLogMessage))
                    {
                        if (Data is PanelActivityLogMessage activityLogMessage)
                        {
#if SignalRCore
                                SignalRClient.NotifyPanelActivityMessageAsync(
                                    Mapper.Map<BusinessEntitiesStd.PanelActivityLogMessage>(activityLogMessage));
#else
                            SignalRClient.NotifyPanelActivityMessageAsync(activityLogMessage);
#endif
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
                                    logString +=
                                        $"{Environment.NewLine}{activityLogMessage.DateTime}, {activityLogMessage.DeviceDescription}, {activityLogMessage.PanelActivityType} IOGroup:{activityLogMessage.InputOutputGroupNumber}, {activityLogMessage.InputOutputGroupName}";
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
                                case PanelActivityEventCode.DuressAuxiliaryFunction:
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
                                case PanelActivityEventCode.DoorModuleAdapterTamperAlarm:
                                case PanelActivityEventCode.DoorModuleAdapterTamperSafe:
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
                                    logString +=
                                        $"{Environment.NewLine}{activityLogMessage.DateTime}, {activityLogMessage.DeviceDescription}, {activityLogMessage.PanelActivityType}";
                                    break;
                            }
                        }
                    }
                    else if (t == typeof(AccessPortalStatusReply))
                    {
                        if (Data is AccessPortalStatusReply apsr)
                        {
#if SignalRCore
                                SignalRClient.NotifyAccessPortalStatusReplyAsync(
                                    Mapper.Map<BusinessEntitiesStd.AccessPortalStatusReply>(apsr));
#else
                            SignalRClient.NotifyAccessPortalStatusReplyAsync(apsr);
#endif
                            logString += $" {apsr.UniqueId}";
                        }
                    }
                    else if (t == typeof(InputDeviceStatusReply))
                    {
                        if (Data is InputDeviceStatusReply idsr)
                        {
#if SignalRCore
                                SignalRClient.NotifyInputDeviceStatusReplyAsync(
                                    Mapper.Map<BusinessEntitiesStd.InputDeviceStatusReply>(idsr));
#else
                            SignalRClient.NotifyInputDeviceStatusReplyAsync(idsr);
#endif
                            logString += $" {idsr.UniqueId}";
                        }
                    }
                    else if (t == typeof(PanelBoardInformationCollection))
                    {
                        if (Data is PanelBoardInformationCollection pbic)
                        {
#if SignalRCore
                                SignalRClient.NotifyPanelBoardInformationCollectionAsync(
                                    Mapper.Map<BusinessEntitiesStd.PanelBoardInformationCollectionSignalR>(pbic));
#else
                            SignalRClient.NotifyPanelBoardInformationCollectionAsync(pbic);
#endif
                            logString += $" {pbic.UniqueId}";
                        }
                    }
                    else if (t == typeof(PanelInqueryReply))
                    {
                        if (Data is PanelInqueryReply o)
                        {
#if SignalRCore
                                SignalRClient.NotifyPanelInqueryReplyAsync(
                                    Mapper.Map<BusinessEntitiesStd.PanelInqueryReplySignalR>(o));

#else
                            SignalRClient.NotifyPanelInqueryReplyAsync(o);
#endif
                            logString += $" {o.UniqueId}";
                        }
                    }
                    else if (t == typeof(CredentialCountReply))
                    {
                        if (Data is CredentialCountReply o)
                        {
#if SignalRCore
                                SignalRClient.NotifyCardCountReplyAsync(
                                    Mapper.Map<BusinessEntitiesStd.CredentialCountReplySignalR>(o));
#else
                            SignalRClient.NotifyCardCountReplyAsync(o);
#endif
                            logString += $" {o.UniqueId}";
                        }
                    }
                    else if (t == typeof(LoggingStatusReply))
                    {
                        if (Data is LoggingStatusReply o)
                        {
#if SignalRCore
                                SignalRClient.NotifyLoggingStatusReplyAsync(
                                    Mapper.Map<BusinessEntitiesStd.LoggingStatusReplySignalR>(o));
#else
                            SignalRClient.NotifyLoggingStatusReplyAsync(o);
#endif
                            logString += $" {o.UniqueId}";
                        }
                    }
                    else if (t == typeof(FlashProgressMessage))
                    {
                        if (Data is FlashProgressMessage o)
                        {
#if SignalRCore
                                SignalRClient.NotifyFlashProgressMessageAsync(
                                    Mapper.Map<BusinessEntitiesStd.FlashProgressMessage>(o));
#else
                            SignalRClient.NotifyFlashProgressMessageAsync(o);
#endif
                            logString += $" {o.UniqueCpuId}";
                        }
                    }
                    else if (t == typeof(PanelLoadDataReply))
                    {
                        if (Data is PanelLoadDataReply o)
                        {
#if SignalRCore
                                var x = Mapper.Map<BusinessEntitiesStd.PanelLoadDataReplySignalR>(o);
                                SignalRClient.NotifyPanelLoadDataReplyAsync(x);
#else
                            SignalRClient.NotifyPanelLoadDataReplyAsync(o);
#endif
                            logString +=
                                $"{Environment.NewLine}{o.UniqueId} {DateTimeOffset.Now.TimeOfDay} PanelLoadDataReply: {o}, {o.DataType} => {o.AckNack}";
                        }
                    }
                    else if (t == typeof(SerialChannelGalaxyDoorModuleDataCollection))
                    {
                        if (Data is SerialChannelGalaxyDoorModuleDataCollection mdc)
                        {
#if SignalRCore
                                SignalRClient.NotifySerialChannelGalaxyDoorModuleDataCollectionAsync(
                                    Mapper.Map<BusinessEntitiesStd.SerialChannelGalaxyDoorModuleDataCollection>(mdc));
#else
                            SignalRClient.NotifySerialChannelGalaxyDoorModuleDataCollectionAsync(mdc);
#endif
                            logString += $" {mdc.UniqueId}";
                        }
                    }
                    else if (t == typeof(SerialChannelGalaxyInputModuleDataCollection))
                    {
                        if (Data is SerialChannelGalaxyInputModuleDataCollection mdc)
                        {
#if SignalRCore
                                SignalRClient.NotifySerialChannelGalaxyInputModuleDataCollectionAsync(
                                    Mapper.Map<BusinessEntitiesStd.SerialChannelGalaxyInputModuleDataCollection>(mdc));
#else
                            SignalRClient.NotifySerialChannelGalaxyInputModuleDataCollectionAsync(mdc);
#endif
                            logString += $" {mdc.UniqueId}";
                        }
                    }
                    else if (t == typeof(PanelMessageBase))
                    {
                        if (Data is PanelMessageBase panelMessageBase)
                        {
                            logString +=
                                $"{Environment.NewLine}{panelMessageBase.UniqueId} {panelMessageBase.RawData[0]:x02} {panelMessageBase.RawData[1]:x02} {panelMessageBase.RawData[2]:x02} {panelMessageBase.RawData[3]:x02}";

                        }
                    }
                    else if (t == typeof(AcknowledgedAlarmBasicData))
                    {
                        if (Data is AcknowledgedAlarmBasicData o)
                        {
#if SignalRCore
                                SignalRClient.NotifyAcknowledgedAlarmBasicDataAsync(
                                    Mapper.Map<BusinessEntitiesStd.AcknowledgedAlarmBasicData>(o));
#else
                            SignalRClient.NotifyAcknowledgedAlarmBasicDataAsync(o);
#endif
                            logString +=
                                $"{Environment.NewLine}{o.AckedUpdatedDateTime}: {o.AckedByUserDisplayName} - {o.Response}";

                        }
                    }
                    else if (t == typeof(InputDeviceVoltagesReply))
                    {
                        if (Data is InputDeviceVoltagesReply idvr)
                        {
#if SignalRCore
                                SignalRClient.NotifyInputDeviceVoltagesReplyAsync(
                                    Mapper.Map<BusinessEntitiesStd.InputDeviceVoltagesReply>(idvr));
#else
                            SignalRClient.NotifyInputDeviceVoltagesReplyAsync(idvr);
#endif
                            logString += $" {idvr.UniqueId}";
                        }
                    }
                    else if (t == typeof(CpuConnectionInfo))
                    {
                        if (Data is CpuConnectionInfo cpuConnInfo)
                        {
#if SignalRCore
                            SignalRClient.NotifyCpuConnectionInfoAsync(
                                Mapper.Map<BusinessEntitiesStd.CpuConnectionInfo>(cpuConnInfo));
#else
                            SignalRClient.NotifyCpuConnectionInfoAsync(cpuConnInfo);
#endif
                            logString +=
                                $" ClusterGroupId:{cpuConnInfo.GalaxyCpuInformation.ClusterGroupId}, Cluster #:{cpuConnInfo.GalaxyCpuInformation.ClusterNumber}, Panel #:{cpuConnInfo.GalaxyCpuInformation.PanelNumber}, Cpu #:{cpuConnInfo.GalaxyCpuInformation.CpuId} IsConnected:{cpuConnInfo.IsConnected}";
                        }
                    }
                    else if (t == typeof(SignalREnvelope<OperationStatusInfo>))
                    {
                        if (Data is SignalREnvelope<OperationStatusInfo> signalRPayload)
                        {
#if SignalRCore
                            SignalRClient.NotifyOperationStatusInfoAsync(
                                Mapper.Map<BusinessEntitiesStd.SignalREnvelope<BusinessEntitiesStd.OperationStatusInfo>>(signalRPayload));
#else
                            SignalRClient.NotifyOperationStatusInfoAsync(signalRPayload);
#endif
                            logString +=
                                $" OperationUid:{signalRPayload.Payload.OperationUid}, Successful:{signalRPayload.Payload.Successful}";
                        }
                    }
                    else if (t == typeof(PingReply))
                    {
                        if (Data is PingReply pingReply)
                        {
#if SignalRCore
                            SignalRClient.NotifyPingReplyAsync(
                                Mapper.Map<BusinessEntitiesStd.PingReplySignalR>(pingReply));
#else
                            SignalRClient.NotifyPingReplyAsync(pingReply);
#endif
                            logString += $" {pingReply.PanelNumber}";
                        }
                    }
                    else if (t == typeof(AccessPortalCommandReply))
                    {
                        if (Data is AccessPortalCommandReply o)
                        {
#if SignalRCore
                            SignalRClient.NotifyOperationStatusInfoAsync( new BusinessEntitiesStd.SignalREnvelope<BusinessEntitiesStd.OperationStatusInfo>()
                                {
                                    Payload = new BusinessEntitiesStd.OperationStatusInfo()
                                    {
                                        OperationUid = o.OperationUid,
                                        Successful = o.AckNack == AckNack.Ack,
                                        CpuUid = o.CpuUid,
                                        PanelUid = o.PanelUid,
                                        CommandActionCode = o.Command.ToString()
                                    },
                                    SignalRGroupUids = o.SessionIdsToSendTo
                                }
                            );
#else
                            SignalRClient.NotifyOperationStatusInfoAsync(new SignalREnvelope<OperationStatusInfo>()
                            {
                                Payload = new OperationStatusInfo()
                                {
                                    OperationUid = o.OperationUid,
                                    Successful = o.AckNack == AckNack.Ack,
                                    CpuUid = o.CpuUid,
                                    PanelUid = o.PanelUid
                                },
                                SignalRGroupUids = o.SessionIdsToSendTo
                            } );
#endif
                            logString += $" {o.UniqueId}";
                        }

                    }
                    else if (t == typeof(GalaxyCpuCommandReply))
                    {
                        if (Data is GalaxyCpuCommandReply o)
                        {
#if SignalRCore
                            SignalRClient.NotifyOperationStatusInfoAsync( new BusinessEntitiesStd.SignalREnvelope<BusinessEntitiesStd.OperationStatusInfo>()
                                {
                                    Payload = new BusinessEntitiesStd.OperationStatusInfo()
                                    {
                                        OperationUid = o.OperationUid,
                                        Successful = o.AckNack == AckNack.Ack,
                                        CpuUid = o.CpuUid,
                                        PanelUid = o.PanelUid,
                                        CommandActionCode = o.Command.ToString(),
                                        CredentialUid = o.CredentialUid
                                    },
                                    SignalRGroupUids = o.SessionIdsToSendTo
                                }
                            );
#else
                            SignalRClient.NotifyOperationStatusInfoAsync(new SignalREnvelope<OperationStatusInfo>()
                            {
                                Payload = new OperationStatusInfo()
                                {
                                    OperationUid = o.OperationUid,
                                    Successful = o.AckNack == AckNack.Ack,
                                    CpuUid = o.CpuUid,
                                    PanelUid = o.PanelUid
                                },
                                SignalRGroupUids = o.SessionIdsToSendTo
                            });
#endif
                            logString += $" {o.UniqueId}";
                        }
                    }
                    else if (t == typeof(EchoReply))
                    {
                        if (Data is EchoReply o)
                        {
#if SignalRCore
                            SignalRClient.NotifyOperationStatusInfoAsync( new BusinessEntitiesStd.SignalREnvelope<BusinessEntitiesStd.OperationStatusInfo>()
                                {
                                    Payload = new BusinessEntitiesStd.OperationStatusInfo()
                                    {
                                        OperationUid = o.OperationUid,
                                        Successful = o.AckNack == AckNack.Nack,
                                        CpuUid = o.CpuUid,
                                        PanelUid = o.PanelUid,
                                        CommandActionCode = o.Response,
                                        //CredentialUid = o.CredentialUid
                                    },
                                    SignalRGroupUids = o.SessionIdsToSendTo
                                }
                            );
#else
                            SignalRClient.NotifyOperationStatusInfoAsync(new SignalREnvelope<OperationStatusInfo>()
                            {
                                Payload = new OperationStatusInfo()
                                {
                                    OperationUid = o.OperationUid,
                                    Successful = o.AckNack == AckNack.Nack,
                                    CpuUid = o.CpuUid,
                                    PanelUid = o.PanelUid,
                                    CommandActionCode = o.Response
                                },
                                SignalRGroupUids = o.SessionIdsToSendTo
                            });
#endif
                            logString += $" {o.UniqueId}";
                        }
                    }
                    this.Log().InfoFormat(logString);
                }
                catch (Exception e)
                {
                    this.Log().ErrorFormat(
                        $"{DateTimeOffset.Now.TimeOfDay} PanelMessageReceivedWorkflow {Data.GetType()} error: {e}");
                }

#elif NETCOREAPP

#endif
            }
        }



        private void SendNotificationEvent()
        {
        }
    }
}