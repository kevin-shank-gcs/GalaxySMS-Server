using GalaxySMS.Business.Entities;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Utils;
using GCS.PanelProtocols.Enums;
using GCS.PanelProtocols.Series6xx;
using GCS.PanelProtocols.Series6xx.Messages;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using TimeZone = GalaxySMS.Business.Entities.TimeZone;

namespace GCS.PanelProtocols.PanelPacketConverters
{
    public static class Packet6xxConverters
    {
        public static object ConvertFrom(IDataPacket6xx pkt, CpuModel cpuModel, int clusterGroupId, PanelInterfaceBoardSectionType bst, Guid operationUid, Guid deviceUid, Guid? clusterUid, Guid? galaxyPanelUid, Guid? cpuUid, string timeZoneId)
        {
            var replyBase = new PanelMessageBase
            {
                ClusterGroupId = clusterGroupId,
                ClusterNumber = pkt.ClusterId,
                PanelNumber = pkt.PanelId,
                CpuId = (short)pkt.Cpu,
                CpuModel = cpuModel,
                BoardNumber = pkt.BoardNumber,
                SectionNumber = pkt.Section,
                NodeNumber = pkt.Node,
                Distribute = (short)pkt.Distribute,
                Sequence = ByteConverters.ThreeBytesToInt(pkt.Sequence[2], pkt.Sequence[1], pkt.Sequence[0]),
                SecondsFromBeginningOfWeek = ByteConverters.ThreeBytesToInt(pkt.When[2], pkt.When[1], pkt.When[0]),
                RawData = pkt.Data,
                OperationUid = operationUid
            };

            if (clusterUid.HasValue)
                replyBase.ClusterUid = clusterUid.Value;

            if (galaxyPanelUid.HasValue)
                replyBase.PanelUid = galaxyPanelUid.Value;

            if (cpuUid.HasValue)
                replyBase.CpuUid = cpuUid.Value;

            switch ((PacketDataCodeFrom6xx)pkt.Data[0])
            {
                case PacketDataCodeFrom6xx.ResponseAck:
                case PacketDataCodeFrom6xx.ResponseNack:
                    if ((PacketDataCodeFrom6xx)pkt.Data[0] == PacketDataCodeFrom6xx.ResponseAck)
                        replyBase.AckNack = AckNack.Ack;
                    else if ((PacketDataCodeFrom6xx)pkt.Data[0] == PacketDataCodeFrom6xx.ResponseNack)
                        replyBase.AckNack = AckNack.Nack;

                    switch ((PacketDataCodeTo6xx)pkt.Data[1])
                    {
                        case PacketDataCodeTo6xx.EchoNack:
                            var echoReply = new EchoReply(replyBase);
                            var size = System.Array.IndexOf(pkt.Data, (byte)0);
                            echoReply.Response = Encoding.UTF8.GetString(pkt.Data, 2, size < 0 ? 14 : size - 2);
                            return echoReply;

                        case PacketDataCodeTo6xx.CommandPing:
                            var pingReply = new PingReply(replyBase);
                            return pingReply;

                        // Hardware Board/Section Reader, Input, Output, DSI, 
                        case PacketDataCodeTo6xx.CommandInitializeBoardSection:
                            var initPortData = new InitializeBoardSection(pkt.Data, 1);
                            var initBoardSectionReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.CommandInitializeBoardSection,
                                ItemNumber = initPortData.Type,
                            };
                            initBoardSectionReply.BoardSectionType = initPortData.GetDecodedSectionType();
                            switch (initBoardSectionReply.BoardSectionType)
                            {
                                case PanelInterfaceBoardSectionType.Unused:
                                    break;
                                case PanelInterfaceBoardSectionType.DrmSection:
                                    initBoardSectionReply.CredentialReaderDataFormat = (GalaxySMS.Common.Enums.CredentialReaderDataFormat)(pkt.Data[3] & 0x0F);
                                    break;
                                case PanelInterfaceBoardSectionType.Dio8X4Outputs:
                                    break;
                                case PanelInterfaceBoardSectionType.Dio8X4Inputs:
                                    break;
                                case PanelInterfaceBoardSectionType.ElevatorRelays:
                                    break;
                                case PanelInterfaceBoardSectionType.CypressClockDisplay:
                                    break;
                                case PanelInterfaceBoardSectionType.OutputRelays:
                                    break;
                                case PanelInterfaceBoardSectionType.AllegionPimWiegand:
                                    break;
                                case PanelInterfaceBoardSectionType.AllegionPimAba:
                                    break;
                                case PanelInterfaceBoardSectionType.LCD_4x20Display:
                                    break;
                                case PanelInterfaceBoardSectionType.RS485DoorModule:
                                    break;
                                case PanelInterfaceBoardSectionType.AssaAbloyAperio:
                                    break;
                                case PanelInterfaceBoardSectionType.SaltoSallis:
                                    break;
                                case PanelInterfaceBoardSectionType.RS485InputModule:
                                    break;
                                case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                                    break;
                                //case PanelInterfaceBoardSectionType.CardTourManagerCpu:
                                //    break;
                                case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                                    break;
                                case PanelInterfaceBoardSectionType.VeridtCpu:
                                    break;
                                case PanelInterfaceBoardSectionType.VeridtReader:
                                    break;
                            }
                            return initBoardSectionReply;

                        case PacketDataCodeTo6xx.CommandLoadBoardSectionNodeData:
                            var loadBoardSectionDataReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.CommandLoadBoardSectionNodeData,
                                BoardSectionType = bst,
                            };

                            switch (bst)
                            {
                                case PanelInterfaceBoardSectionType.DrmSection:
                                    loadBoardSectionDataReply.ItemNumber = pkt.Data[2];
                                    loadBoardSectionDataReply.CredentialReaderDataFormat = (GalaxySMS.Common.Enums.CredentialReaderDataFormat)(loadBoardSectionDataReply.ItemNumber & 0x0F);
                                    break;

                                case PanelInterfaceBoardSectionType.RS485DoorModule:
                                    loadBoardSectionDataReply.ItemNumber = pkt.Data[2];
                                    loadBoardSectionDataReply.CredentialReaderDataFormat = (GalaxySMS.Common.Enums.CredentialReaderDataFormat)(loadBoardSectionDataReply.ItemNumber & 0x0F);
                                    break;

                                case PanelInterfaceBoardSectionType.Dio8X4Outputs:
                                    break;
                                case PanelInterfaceBoardSectionType.Dio8X4Inputs:
                                    break;
                                case PanelInterfaceBoardSectionType.ElevatorRelays:
                                    break;
                                case PanelInterfaceBoardSectionType.CypressClockDisplay:
                                    break;
                                case PanelInterfaceBoardSectionType.OutputRelays:
                                    loadBoardSectionDataReply.ModuleNumber = (pkt.Data[3] / GalaxySMS.Common.Constants.GalaxyRemoteRelayModuleLimits.MaximumRelaysPerModule) + 1;
                                    loadBoardSectionDataReply.NodeNumber = pkt.Data[3];
                                    loadBoardSectionDataReply.ItemNumber = pkt.Data[3];
                                    break;
                                case PanelInterfaceBoardSectionType.AllegionPimWiegand:
                                    break;
                                case PanelInterfaceBoardSectionType.AllegionPimAba:
                                    break;
                                case PanelInterfaceBoardSectionType.LCD_4x20Display:
                                    break;

                                case PanelInterfaceBoardSectionType.AssaAbloyAperio:
                                    break;
                                case PanelInterfaceBoardSectionType.SaltoSallis:
                                    break;
                                case PanelInterfaceBoardSectionType.RS485InputModule:
                                    break;
                                case PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                                    break;
                                //case PanelInterfaceBoardSectionType.CardTourManagerCpu:
                                //    break;
                                case PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                                    break;
                                case PanelInterfaceBoardSectionType.VeridtCpu:
                                    break;
                                case PanelInterfaceBoardSectionType.VeridtReader:
                                    break;

                                case PanelInterfaceBoardSectionType.Unused:
                                default:
                                    break;

                            }
                            return loadBoardSectionDataReply;

                        case PacketDataCodeTo6xx.CommandLoadIOGroupArmSchedule:
                            var ioGroupLoadReply = new PanelLoadDataReply(replyBase);
                            ioGroupLoadReply.DataType = PanelLoadDataType.CommandLoadIOGroupArmSchedule;
                            ioGroupLoadReply.ItemNumber = pkt.Data[2];
                            return ioGroupLoadReply;

                        // Card Load Data
                        case PacketDataCodeTo6xx.CommandLoadExtendedCards:
                            var extendedCardData = new CredentialData256Bit(pkt.Data, 1);
                            var extendedCardDataReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.CommandLoadExtendedCards,
                            };
                            foreach (var cd in extendedCardData.CredentialData.Where(o => o.HasCredentialBits))
                            {
                                extendedCardDataReply.CredentialsLoaded.Add(new CredentialLoadedData()
                                {
                                    CardData = cd.AccessControlCredential.CredentialBits,
                                });
                            }
                            return extendedCardDataReply;

                        case PacketDataCodeTo6xx.CommandLoadStandardCards:
                            var standardCardData = new CredentialData48Bit(pkt.Data, 1);
                            var standardCardDataReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.CommandLoadStandardCards,
                            };
                            foreach (var cd in standardCardData.CredentialData.Where(o => o.HasCredentialBits))
                            {
                                standardCardDataReply.CredentialsLoaded.Add(new CredentialLoadedData()
                                {
                                    CardData = cd.AccessControlCredential.CredentialBits,
                                });
                            }
                            return standardCardDataReply;

                        case PacketDataCodeTo6xx.CommandDeleteCard:
                            var deleteCardDataReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.CommandDeleteCard,
                            };
                            if (pkt.Length == 0x40)
                            {   // Extended card
                                var cardData = new CardCommand256Bit(pkt.Data, 1);
                                deleteCardDataReply.CredentialsLoaded.Add(new CredentialLoadedData()
                                {
                                    CardData = cardData.CredentialBits,
                                });
                            }
                            else
                            {
                                var cardData = new CardCommand48Bit(pkt.Data, 1);
                                deleteCardDataReply.CredentialsLoaded.Add(new CredentialLoadedData()
                                {
                                    CardData = cardData.CredentialBits,
                                });
                            }
                            //foreach (var cd in deleteCardDataReply.CredentialData.Where(o => o.HasCredentialBits))
                            //{
                            //    deleteCardDataReply.CredentialsLoaded.Add(new CredentialLoadedData()
                            //    {
                            //        CardData = cd.AccessControlCredential.CredentialBits,
                            //    });
                            //}
                            return deleteCardDataReply;
                            break;

                        case PacketDataCodeTo6xx.CommandLoadPersonalDoors:
                            if (pkt.Soh == SohCode.UInt16ClusterAndPanelIds)
                            {
                                var personalDoorData = new PersonalAccessGroupData(pkt.Data, 1);
                                var commandLoadPersonalDoorsReply = new PanelLoadDataReply(replyBase);
                                commandLoadPersonalDoorsReply.DataType = PanelLoadDataType.CommandLoadPersonalDoors;
                                commandLoadPersonalDoorsReply.ItemNumber = personalDoorData.PersonalAccessGroupNumber;
                                return commandLoadPersonalDoorsReply;
                            }
                            else if (pkt.Soh == SohCode.UInt8ClusterAndPanelIds)
                            {
                                var personalDoorData_PreV11 = new PersonalAccessGroupData_PreV11(pkt.Data, 1);
                                var commandLoadPersonalDoorsReply_PreV11 = new PanelLoadDataReply(replyBase);
                                commandLoadPersonalDoorsReply_PreV11.DataType = PanelLoadDataType.CommandLoadPersonalDoors;
                                commandLoadPersonalDoorsReply_PreV11.ItemNumber = personalDoorData_PreV11.PersonalAccessGroupNumber;
                                return commandLoadPersonalDoorsReply_PreV11;
                            }
                            break;

                        // Time Schedule Commands
                        case PacketDataCodeTo6xx.CommandClearTimeSchedules:
                            break;

                        case PacketDataCodeTo6xx.CommandLoadMinuteScheduleDayTypes:
                            var minuteScheduleDayTypesReply = new PanelLoadDataReply(replyBase);
                            minuteScheduleDayTypesReply.DataType = PanelLoadDataType.CommandLoadMinuteScheduleDayTypes;
                            return minuteScheduleDayTypesReply;

                        case PacketDataCodeTo6xx.CommandLoadMinuteScheduleTimePeriod:
                            var minuteScheduleTimePeriodReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.CommandLoadMinuteScheduleTimePeriod,
                                ItemNumber = (int)pkt.Data[2]
                            };
                            return minuteScheduleTimePeriodReply;

                        case PacketDataCodeTo6xx.CommandLoadMinuteScheduleTimePeriodsForDayType:
                            var minuteScheduleTimePeriodsForDayTypeReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.CommandLoadMinuteScheduleTimePeriodsForDayType,
                                ItemNumber = (int)pkt.Data[2]
                            };
                            return minuteScheduleTimePeriodsForDayTypeReply;

                        case PacketDataCodeTo6xx.CommandLoadTimeSchedule15MinuteFormat:
                            var minute15ScheduleReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.CommandLoadTimeSchedule15MinuteFormat,
                                ItemNumber = (int)pkt.Data[2]
                            };
                            return minute15ScheduleReply;

                        case PacketDataCodeTo6xx.CommandLoad15MinuteScheduleHolidays:
                            var minute15ScheduleHolidaysReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.CommandLoad15MinuteScheduleHolidays,
                                ItemNumber = (int)pkt.Data[2]
                            };
                            return minute15ScheduleHolidaysReply;

                        case PacketDataCodeTo6xx.CommandLoad15MinuteScheduleHolidayTable:
                            var minute15HolidaysReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.CommandLoad15MinuteScheduleHolidayTable,
                                ItemNumber = (int)pkt.Data[2]
                            };
                            return minute15HolidaysReply;

                        // Access Group/Rules

                        case PacketDataCodeTo6xx.CommandLoadAccessGroupSchedulesForDoor:
                            var agdoor = new AccessGroupSchedules(pkt.Data, 1);
                            var loadAccessGroupScheduleForDoorReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.CommandLoadAccessGroupSchedulesForDoor,
                                ItemString = $"{agdoor.StartingAccessGroupNumber}",
                                ItemNumber = agdoor.StartingAccessGroupNumber
                            };
                            return loadAccessGroupScheduleForDoorReply;

                        case PacketDataCodeTo6xx.CommandLoadAccessGroupSchedule:
                            var loadAccessGroupScheduleReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.CommandLoadAccessGroupSchedule,
                                ItemNumber = (int)BitConverter.ToUInt16(pkt.Data, 3)
                            };
                            return loadAccessGroupScheduleReply;


                        case PacketDataCodeTo6xx.LoadAccessGroupCrisisGroup:
                            var loadAccessGroupCrisisGroupReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.LoadAccessGroupCrisisGroup,
                                ItemNumber = BitConverter.ToUInt16(pkt.Data, 2)//(int)pkt.Data[2]
                            };
                            return loadAccessGroupCrisisGroupReply;

                        case PacketDataCodeTo6xx.CommandClearAccessGroupRange:
                            var range = new AccessGroupClearRange(pkt.Data, 1);
                            var clearAccessGroupRangeReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.CommandClearAccessGroupRange,
                                ItemString = $"{range.StartingAccessGroupNumber} - {range.EndingAccessGroupNumber}",
                                ItemNumber = range.StartingAccessGroupNumber
                            };
                            return clearAccessGroupRangeReply;

                        case PacketDataCodeTo6xx.CommandLoadAccessGroupsCrisisGroups:
                            break;

                        case PacketDataCodeTo6xx.CommandLoadTamperAcFailureLowBattery:
                            var loadTamperAcFailLowBatteryReply = new PanelLoadDataReply(replyBase)
                            {
                                DataType = PanelLoadDataType.CommandLoadTamperAcFailureLowBattery,
                            };
                            return loadTamperAcFailLowBatteryReply;

                        // Global Settings
                        case PacketDataCodeTo6xx.CommandLoadABAOptions:
                            var abaReply = new PanelLoadDataReply(replyBase);
                            abaReply.DataType = PanelLoadDataType.CommandLoadABAOptions;
                            return abaReply;

                        case PacketDataCodeTo6xx.CommandLoadLockoutOptions:
                            var lockOutReply = new PanelLoadDataReply(replyBase);
                            lockOutReply.DataType = PanelLoadDataType.CommandLoadLockoutOptions;
                            return lockOutReply;

                        case PacketDataCodeTo6xx.CommandLoadLedOptions:
                            var ledOptionsReply = new PanelLoadDataReply(replyBase);
                            ledOptionsReply.DataType = PanelLoadDataType.CommandLoadLedOptions;
                            return ledOptionsReply;

                        case PacketDataCodeTo6xx.CommandLoadCrisisModeIOGroup:
                            var crisisModeReply = new PanelLoadDataReply(replyBase);
                            crisisModeReply.DataType = PanelLoadDataType.CommandLoadCrisisModeIOGroup;
                            return crisisModeReply;

                        case PacketDataCodeTo6xx.CommandLoadWiegandStartStopSettings:
                            var wiegandOptionsReply = new PanelLoadDataReply(replyBase);
                            wiegandOptionsReply.DataType = PanelLoadDataType.CommandLoadWiegandStartStopSettings;
                            return wiegandOptionsReply;

                        case PacketDataCodeTo6xx.CommandLoadCardaxStartStopSettings:
                            var cardaxOptionsReply = new PanelLoadDataReply(replyBase);
                            cardaxOptionsReply.DataType = PanelLoadDataType.CommandLoadCardaxStartStopSettings;
                            return cardaxOptionsReply;

                        case PacketDataCodeTo6xx.CommandSetServerConsultationOptions:
                            var serverConsultationOptionsReply = new PanelLoadDataReply(replyBase);
                            serverConsultationOptionsReply.DataType = PanelLoadDataType.CommandSetServerConsultationOptions;
                            return serverConsultationOptionsReply;

                        case PacketDataCodeTo6xx.CommandSetDateTime:
                            break;

                        // Flashing commands
                        //case PacketDataCodeTo6xx.CommandClearAutoTimer:
                        //    break;

                        case PacketDataCodeTo6xx.CommandBeginFlashLoad635:
                            // Fire Begin Flash Load
                            // Send the first packet in the flash
                            break;

                        case PacketDataCodeTo6xx.CommandLoadFlashPacket635:
                            // Load the next packet
                            break;

                        case PacketDataCodeTo6xx.CommandValidateFlash635:
                        case PacketDataCodeTo6xx.CommandValidateThenBurnFlash635:
                            break;

                        case PacketDataCodeTo6xx.CommandCardEnable:
                        case PacketDataCodeTo6xx.CommandCardDisable:
                        case PacketDataCodeTo6xx.CommandForgivePassbackCard:
                        case PacketDataCodeTo6xx.CommandSetCrisisMode:
                        case PacketDataCodeTo6xx.CommandResetCrisisMode:
                        case PacketDataCodeTo6xx.CommandForgivePassbackEverybody:
                        case PacketDataCodeTo6xx.CommandClearAllUsers:
                        case PacketDataCodeTo6xx.CommandClearAutoTimer:
                        case PacketDataCodeTo6xx.CommandRecalibrate:
                        case PacketDataCodeTo6xx.CommandLoggingResetPointers:
                            var cpuCommandReply = new GalaxyCpuCommandReply(replyBase)
                            {

                            };
                            switch ((PacketDataCodeTo6xx)pkt.Data[1])
                            {
                                case PacketDataCodeTo6xx.CommandSetCrisisMode:
                                    cpuCommandReply.Command = GalaxyCpuCommandActionCode.ActivateCrisisMode;
                                    break;
                                case PacketDataCodeTo6xx.CommandResetCrisisMode:
                                    cpuCommandReply.Command = GalaxyCpuCommandActionCode.ResetCrisisMode;
                                    break;
                                case PacketDataCodeTo6xx.CommandForgivePassbackEverybody:
                                    cpuCommandReply.Command = GalaxyCpuCommandActionCode.ForgivePassbackForAllCredentials;
                                    break;

                                case PacketDataCodeTo6xx.CommandClearAllUsers:
                                    cpuCommandReply.Command = GalaxyCpuCommandActionCode.ClearAllCredentials;
                                    break;

                                case PacketDataCodeTo6xx.CommandClearAutoTimer:
                                    cpuCommandReply.Command = GalaxyCpuCommandActionCode.EnableDaughterBoardFlashUpdate;
                                    break;
                                case PacketDataCodeTo6xx.CommandRecalibrate:
                                    cpuCommandReply.Command = GalaxyCpuCommandActionCode.RecalibrateInputsAndOutputs;
                                    break;
                                case PacketDataCodeTo6xx.CommandLoggingResetPointers:
                                    if (pkt.Data[2] == 0)
                                    {
                                        cpuCommandReply.Command = GalaxyCpuCommandActionCode.ClearLoggingBuffer;
                                    }
                                    else if (pkt.Data[2] == 1)
                                    {
                                        cpuCommandReply.Command = GalaxyCpuCommandActionCode.RetransmitLoggingBuffer;
                                    }
                                    else
                                    {
                                        cpuCommandReply.Command = GalaxyCpuCommandActionCode.None;
                                    }
                                    break;

                                case PacketDataCodeTo6xx.CommandCardEnable:
                                case PacketDataCodeTo6xx.CommandCardDisable:
                                case PacketDataCodeTo6xx.CommandForgivePassbackCard:
                                    cpuCommandReply.CredentialBytes = new byte[GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Extended256Bits];
                                    if (pkt.Length == 0x20)
                                        cpuCommandReply.CredentialBytes = ByteArrayUtilities.GetBytesFromArray(pkt.Data, GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Standard48Bit, 2);
                                    else
                                        cpuCommandReply.CredentialBytes = ByteArrayUtilities.GetBytesFromArray(pkt.Data, GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Extended256Bits, 2);

                                    switch ((PacketDataCodeTo6xx)pkt.Data[1])
                                    {
                                        case PacketDataCodeTo6xx.CommandCardEnable:
                                            cpuCommandReply.Command = GalaxyCpuCommandActionCode.EnableCredential;
                                            break;
                                        case PacketDataCodeTo6xx.CommandCardDisable:
                                            cpuCommandReply.Command = GalaxyCpuCommandActionCode.DisableCredential;
                                            break;
                                        case PacketDataCodeTo6xx.CommandForgivePassbackCard:
                                            cpuCommandReply.Command =
                                                GalaxyCpuCommandActionCode.ForgivePassbackForCredential;
                                            break;
                                    }

                                    break;
                            }
                            return cpuCommandReply;

                        // Door/Access Portal Commands
                        case PacketDataCodeTo6xx.CommandUnlockDoor:
                        case PacketDataCodeTo6xx.CommandLockDoor:
                        case PacketDataCodeTo6xx.CommandDisableDoor:
                        case PacketDataCodeTo6xx.CommandEnableDoor:
                        case PacketDataCodeTo6xx.CommandPulseDoor:
                        case PacketDataCodeTo6xx.CommandRelay2Off:
                        case PacketDataCodeTo6xx.CommandRelay2On:
                        case PacketDataCodeTo6xx.CommandRequestReaderPortStatus:
                        case PacketDataCodeTo6xx.CommandSetLedTemporaryState:
                            var apCommandReply = new AccessPortalCommandReply(replyBase)
                            {
                                AccessPortalUid = deviceUid
                            };
                            switch ((PacketDataCodeTo6xx)pkt.Data[1])
                            {
                                case PacketDataCodeTo6xx.CommandUnlockDoor:
                                    apCommandReply.Command = AccessPortalCommandActionCode.Unlock;
                                    break;
                                case PacketDataCodeTo6xx.CommandLockDoor:
                                    apCommandReply.Command = AccessPortalCommandActionCode.Lock;
                                    break;
                                case PacketDataCodeTo6xx.CommandDisableDoor:
                                    apCommandReply.Command = AccessPortalCommandActionCode.Disable;
                                    break;
                                case PacketDataCodeTo6xx.CommandEnableDoor:
                                    apCommandReply.Command = AccessPortalCommandActionCode.Enable;
                                    break;
                                case PacketDataCodeTo6xx.CommandPulseDoor:
                                    apCommandReply.Command = AccessPortalCommandActionCode.Pulse;
                                    break;
                                case PacketDataCodeTo6xx.CommandRelay2Off:
                                    apCommandReply.Command = AccessPortalCommandActionCode.AuxRelayOff;
                                    break;
                                case PacketDataCodeTo6xx.CommandRelay2On:
                                    apCommandReply.Command = AccessPortalCommandActionCode.AuxRelayOn;
                                    break;
                                case PacketDataCodeTo6xx.CommandRequestReaderPortStatus:
                                    apCommandReply.Command = AccessPortalCommandActionCode.RequestStatus;
                                    break;
                                case PacketDataCodeTo6xx.CommandSetLedTemporaryState:
                                    apCommandReply.Command = AccessPortalCommandActionCode.SetLedTemporaryState;
                                    break;
                            }
                            return apCommandReply;

                        // Door Group Commands
                        case PacketDataCodeTo6xx.CommandUnlockDoorGroup:
                        case PacketDataCodeTo6xx.CommandLockDoorGroup:
                        case PacketDataCodeTo6xx.CommandDisableDoorGroup:
                        case PacketDataCodeTo6xx.CommandEnableDoorGroup:
                            var apGroupCommandReply = new AccessPortalGroupCommandReply(replyBase);
                            switch ((PacketDataCodeTo6xx)pkt.Data[1])
                            {
                                case PacketDataCodeTo6xx.CommandUnlockDoorGroup:
                                    apGroupCommandReply.Command = AccessPortalGroupCommandActionCode.Unlock;
                                    break;
                                case PacketDataCodeTo6xx.CommandLockDoorGroup:
                                    apGroupCommandReply.Command = AccessPortalGroupCommandActionCode.Lock;
                                    break;
                                case PacketDataCodeTo6xx.CommandDisableDoorGroup:
                                    apGroupCommandReply.Command = AccessPortalGroupCommandActionCode.Disable;
                                    break;
                                case PacketDataCodeTo6xx.CommandEnableDoorGroup:
                                    apGroupCommandReply.Command = AccessPortalGroupCommandActionCode.Enable;
                                    break;
                            }
                            return apGroupCommandReply;

                        // IO Group Commands
                        case PacketDataCodeTo6xx.CommandShuntIOGroup:
                        case PacketDataCodeTo6xx.CommandUnshuntIOGroup:
                        case PacketDataCodeTo6xx.CommandArmIOGroup:
                        case PacketDataCodeTo6xx.CommandDisarmIOGroup:
                            var ioGroupCommandReply = new InputOutputGroupCommandReply(replyBase);
                            switch ((PacketDataCodeTo6xx)pkt.Data[1])
                            {
                                case PacketDataCodeTo6xx.CommandShuntIOGroup:
                                    ioGroupCommandReply.Command = InputOutputGroupCommandReply.CommandCode.Shunt;
                                    break;
                                case PacketDataCodeTo6xx.CommandUnshuntIOGroup:
                                    ioGroupCommandReply.Command = InputOutputGroupCommandReply.CommandCode.Unshunt;
                                    break;
                                case PacketDataCodeTo6xx.CommandArmIOGroup:
                                    ioGroupCommandReply.Command = InputOutputGroupCommandReply.CommandCode.Arm;
                                    break;
                                case PacketDataCodeTo6xx.CommandDisarmIOGroup:
                                    ioGroupCommandReply.Command = InputOutputGroupCommandReply.CommandCode.Disarm;
                                    break;
                            }
                            return ioGroupCommandReply;

                        // Input device Commands
                        case PacketDataCodeTo6xx.CommandDisableInput:
                        case PacketDataCodeTo6xx.CommandEnableInput:
                        case PacketDataCodeTo6xx.CommandShuntInput:
                        case PacketDataCodeTo6xx.CommandUnshuntInput:
                        case PacketDataCodeTo6xx.CommandRequestInputStatus:
                            var inputDeviceCommandReply = new InputDeviceCommandReply(replyBase);
                            switch ((PacketDataCodeTo6xx)pkt.Data[1])
                            {
                                case PacketDataCodeTo6xx.CommandDisableInput:
                                    inputDeviceCommandReply.Command = InputDeviceCommandReply.CommandCode.Disable;
                                    break;
                                case PacketDataCodeTo6xx.CommandEnableInput:
                                    inputDeviceCommandReply.Command = InputDeviceCommandReply.CommandCode.Enable;
                                    break;
                                case PacketDataCodeTo6xx.CommandShuntInput:
                                    inputDeviceCommandReply.Command = InputDeviceCommandReply.CommandCode.Shunt;
                                    break;
                                case PacketDataCodeTo6xx.CommandUnshuntInput:
                                    inputDeviceCommandReply.Command = InputDeviceCommandReply.CommandCode.Unshunt;
                                    break;
                                case PacketDataCodeTo6xx.CommandRequestInputStatus:
                                    inputDeviceCommandReply.Command = InputDeviceCommandReply.CommandCode.RequestStatus;
                                    break;
                            }
                            return inputDeviceCommandReply;

                        // Output device Commands
                        case PacketDataCodeTo6xx.CommandOutputOn:
                        case PacketDataCodeTo6xx.CommandOutputOff:
                        case PacketDataCodeTo6xx.CommandOutputEnable:
                        case PacketDataCodeTo6xx.CommandOutputDisable:
                        case PacketDataCodeTo6xx.CommandRequestOutputStatus:
                            var outputDeviceCommandReply = new OutputDeviceCommandReply(replyBase);
                            switch ((PacketDataCodeTo6xx)pkt.Data[1])
                            {
                                case PacketDataCodeTo6xx.CommandOutputOn:
                                    outputDeviceCommandReply.Command = OutputDeviceCommandReply.CommandCode.On;
                                    break;
                                case PacketDataCodeTo6xx.CommandOutputOff:
                                    outputDeviceCommandReply.Command = OutputDeviceCommandReply.CommandCode.Off;
                                    break;
                                case PacketDataCodeTo6xx.CommandOutputEnable:
                                    outputDeviceCommandReply.Command = OutputDeviceCommandReply.CommandCode.Enable;
                                    break;
                                case PacketDataCodeTo6xx.CommandOutputDisable:
                                    outputDeviceCommandReply.Command = OutputDeviceCommandReply.CommandCode.Disable;
                                    break;
                                case PacketDataCodeTo6xx.CommandRequestOutputStatus:
                                    outputDeviceCommandReply.Command = OutputDeviceCommandReply.CommandCode.RequestStatus;
                                    break;
                            }
                            return outputDeviceCommandReply;

                        // Elevator Commands
                        case PacketDataCodeTo6xx.CommandElevatorPulse:
                        case PacketDataCodeTo6xx.CommandElevatorEarlyOn:
                        case PacketDataCodeTo6xx.CommandElevatorEarlyOff:
                        case PacketDataCodeTo6xx.CommandElevatorCancelEarlyOn:
                        case PacketDataCodeTo6xx.CommandElevatorCancelEarlyOff:
                            var elevatorOutputDeviceCommandReply = new ElevatorOutputDeviceCommandReply(replyBase);
                            switch ((PacketDataCodeTo6xx)pkt.Data[1])
                            {
                                case PacketDataCodeTo6xx.CommandElevatorPulse:
                                    elevatorOutputDeviceCommandReply.Command = ElevatorOutputDeviceCommandReply.CommandCode.Pulse;
                                    break;
                                case PacketDataCodeTo6xx.CommandElevatorEarlyOn:
                                    elevatorOutputDeviceCommandReply.Command = ElevatorOutputDeviceCommandReply.CommandCode.EarlyOn;
                                    break;
                                case PacketDataCodeTo6xx.CommandElevatorEarlyOff:
                                    elevatorOutputDeviceCommandReply.Command = ElevatorOutputDeviceCommandReply.CommandCode.EarlyOff;
                                    break;
                                case PacketDataCodeTo6xx.CommandElevatorCancelEarlyOn:
                                    elevatorOutputDeviceCommandReply.Command = ElevatorOutputDeviceCommandReply.CommandCode.CancelEarlyOn;
                                    break;
                                case PacketDataCodeTo6xx.CommandElevatorCancelEarlyOff:
                                    elevatorOutputDeviceCommandReply.Command = ElevatorOutputDeviceCommandReply.CommandCode.CancelEarlyOff;
                                    break;
                            }
                            return elevatorOutputDeviceCommandReply;

                        // 500i/EZ80 flash load commands
                        //case PacketDataCodeTo6xx.CommandBeginFlashLoadEz80:
                        //case PacketDataCodeTo6xx.CommandLoadFlashPacketEz80:
                        //case PacketDataCodeTo6xx.CommandValidateThenBurnFlashEz80:
                        //case PacketDataCodeTo6xx.CommandValidateFlashEz80:
                        default:
                            break;
                    }
                    return replyBase;

                case PacketDataCodeFrom6xx.ResponsePanelInquire:
                    var cpuInformationReply = new CpuInformationReply(pkt.Data);
                    var panelInqueryReply = new PanelInqueryReply(replyBase);
                    switch (cpuInformationReply.ModelNumber)
                    {
                        case 500:
                            panelInqueryReply.CpuModel = CpuModel.Cpu5xx;
                            break;

                        case 600:
                            panelInqueryReply.CpuModel = CpuModel.Cpu600;
                            break;

                        case 635:
                            panelInqueryReply.CpuModel = CpuModel.Cpu635;
                            break;

                        case 708:
                            panelInqueryReply.CpuModel = CpuModel.Cpu708;
                            break;

                        default:
                            panelInqueryReply.CpuModel = CpuModel.Unknown;
                            break;
                    }
                    panelInqueryReply.AckNack = AckNack.Ack;

                    if (cpuInformationReply.ActivityLoggingEnabled == 0)
                        panelInqueryReply.ActivityLoggingEnabled = ActivityLoggingEnabledState.ActivityLoggingNotEnabled;
                    else
                        panelInqueryReply.ActivityLoggingEnabled = ActivityLoggingEnabledState.ActivityLoggingEnabled;

                    if (cpuInformationReply.CardCodeFormat == 0)
                        panelInqueryReply.CardCodeFormat = CredentialDataSize.Standard48Bits;
                    else
                        panelInqueryReply.CardCodeFormat = CredentialDataSize.Extended256Bits;

                    if (cpuInformationReply.CrisisModeActive != 0)
                        panelInqueryReply.CrisisModeActive = CrisisModeState.Active;
                    else
                        panelInqueryReply.CrisisModeActive = CrisisModeState.Inactive;

                    if (cpuInformationReply.LastRestartColdOrWarm != 0)
                        panelInqueryReply.LastRestartColdOrWarm = CpuResetType.ColdReset;
                    else
                        panelInqueryReply.LastRestartColdOrWarm = CpuResetType.WarmReset;

                    panelInqueryReply.ModelNumber = GCS.Framework.Utilities.GenericEnums.GetOne<CpuModel>(cpuInformationReply.ModelNumber);
                    panelInqueryReply.SerialNumber = System.Text.Encoding.ASCII.GetString(cpuInformationReply.SerialNumber);
                    panelInqueryReply.UnacknowledgedActivityLogCount = cpuInformationReply.UnacknowledgedActivityLogCount;
                    panelInqueryReply.Version.Major = cpuInformationReply.Version.Major;
                    panelInqueryReply.Version.Minor = cpuInformationReply.Version.Minor;
                    panelInqueryReply.Version.LetterCode = cpuInformationReply.Version.LetterCode;
                    return panelInqueryReply;

                case PacketDataCodeFrom6xx.ResponseRequestLoggingInformation:
                    var cpuActivityLoggingInformationReply = new CpuActivityLoggingInformationReply(pkt.Data);
                    var loggingStatusReply = new LoggingStatusReply(replyBase);
                    loggingStatusReply.AckNack = AckNack.Ack;
                    loggingStatusReply.BufferedActivityLogCount = cpuActivityLoggingInformationReply.BufferedActivityLogCount;

                    if (cpuActivityLoggingInformationReply.ActivityLoggingEnabled == 0)
                        loggingStatusReply.EnabledState = ActivityLoggingEnabledState.ActivityLoggingNotEnabled;
                    else
                        loggingStatusReply.EnabledState = ActivityLoggingEnabledState.ActivityLoggingEnabled;

                    loggingStatusReply.UnacknowledgedActivityLogCount = cpuActivityLoggingInformationReply.UnacknowledgedActivityLogCount;
                    return loggingStatusReply;

                case PacketDataCodeFrom6xx.ResponseTotalCardCount:
                    var cpuTotalCardCountReply = new CpuTotalCardCountReply(pkt.Data);
                    var cardCountReply = new CredentialCountReply(replyBase);
                    cardCountReply.AckNack = AckNack.Ack;
                    cardCountReply.Value = cpuTotalCardCountReply.TotalCardCount;
                    return cardCountReply;

                case PacketDataCodeFrom6xx.ResponseConnectedBoardInformation:
                    var boardInformationWithBootResponse = new BoardInformationWithBootResponse(pkt.Data, pkt.Length);
                    var boardsInformation = new PanelBoardInformationCollection(replyBase);
                    short boardNumber = 1;
                    foreach (var b in boardInformationWithBootResponse.Boards)
                    {
                        if (b.Status != 0)
                        {
                            var bi = new PanelBoardInformation()
                            {
                                BoardNumber = boardNumber,
                                Status = (GalaxySMS.Common.Enums.PanelBoardStatus)b.Status,
                                FlashResult = (GalaxySMS.Common.Enums.PanelBoardFlashResult)b.FlashResult,
                                FlashPackage = (GalaxySMS.Common.Enums.GalaxyInterfaceBoardType)b.FlashPackage,
                                Version = new FirmwareVersion()
                                {
                                    Major = b.MajorVersion,
                                    Minor = b.MinorVersion,
                                    LetterCode = b.VersionLetter
                                },
                                BootVersion = new FirmwareVersion()
                                {
                                    Major = b.BootMajorVersion,
                                    Minor = b.BootMinorVersion,
                                    LetterCode = b.BootLetterVersion
                                },
                                SelectedCpuNumber = b.SelectedCpuNumber,
                                HeartbeatAge = b.HeartbeatAge
                            };
                            boardsInformation.Boards.Add(bi);
                        }
                        boardNumber++;
                    }
                    return boardsInformation;

                case PacketDataCodeFrom6xx.ResponseSerialChannelRS485DeviceInfo:
                    switch (bst)
                    {
                        case PanelInterfaceBoardSectionType.RS485DoorModule:
                            var doorModuleData = new RS485ChannelGalaxyDoorModuleStatusResponse(pkt.Data);
                            var serialChannelDoorModuleData = new SerialChannelGalaxyDoorModuleDataCollection(replyBase);
                            short nodeNumber = 1;
                            foreach (var md in doorModuleData.Modules)
                            {
                                var module = new SerialChannelGalaxyDoorModuleData()
                                {
                                    NodeNumber = nodeNumber++,
                                    RemoteModuleSectionNumber = md.RemoteDrmSectionNumber,
                                    SerialNumber = $"{md.SerialNumber}",
                                };
                                module.Version.Major = md.VersionMajor;
                                module.Version.Minor = md.VersionMinor;
                                module.Version.LetterCode = md.VersionLetter;

                                module.BootVersion.Major = md.BootVersionMajor;
                                module.BootVersion.Minor = md.BootVersionMinor;
                                module.BootVersion.LetterCode = md.BootVersionLetter;

                                serialChannelDoorModuleData.Modules.Add(module);
                            }
                            return serialChannelDoorModuleData;

                        case PanelInterfaceBoardSectionType.RS485InputModule:
                            var inputModuleData = new RS485ChannelGalaxyInputModuleStatusResponse(pkt.Data);
                            var serialChannelInputModuleData = new SerialChannelGalaxyInputModuleDataCollection(replyBase);
                            ushort x = 1;
                            foreach (var md in inputModuleData.Modules)
                            {
                                var module = new SerialChannelGalaxyInputModuleData()
                                {
                                    ModuleNumber = x++,
                                    ModulePresent = md.ModulePresent != 0
                                };

                                serialChannelInputModuleData.Modules.Add(module);
                            }
                            return serialChannelInputModuleData;

                        default:
                            return replyBase;
                    }


                case PacketDataCodeFrom6xx.ActivityLogMessage:
                    switch ((PanelActivityLogMessageCode)pkt.Data[3])
                    {
                        case PanelActivityLogMessageCode.ExtendedCardCodeHighestBytes:
                        case PanelActivityLogMessageCode.ExtendedCardCodeMiddleBytes:
                            var extendedCardLogData = new ExtendedCardDataActivityLogMessageFromCpu(pkt.Data);
                            return extendedCardLogData;

                        case PanelActivityLogMessageCode.NotInPanelMemory:
                        case PanelActivityLogMessageCode.NotInPanelMemoryReverse:
                        case PanelActivityLogMessageCode.AccessDenied:
                        case PanelActivityLogMessageCode.AccessGranted:
                        case PanelActivityLogMessageCode.Duress:
                        case PanelActivityLogMessageCode.PassbackViolation:
                        case PanelActivityLogMessageCode.IncorrectPinEntered:
                        case PanelActivityLogMessageCode.AccessGrantedWithPinData:
                        case PanelActivityLogMessageCode.AccessDeniedAttemptPivCardExpired:
                        case PanelActivityLogMessageCode.IoGroupArmByCard:
                        case PanelActivityLogMessageCode.IoGroupDisarmByCard:
                        case PanelActivityLogMessageCode.AccessGrantedDoorNotOpened:
                        case PanelActivityLogMessageCode.AutoUnlockActivatedByAccessGranted:
                        case PanelActivityLogMessageCode.CredentialDoublePresentDoorLocked:
                        case PanelActivityLogMessageCode.CredentialDoublePresentDoorUnlocked:
                            var standardCardLogData = new StandardCardDataActivityLogMessageFromCpu(pkt.Data);
                            return standardCardLogData;


                        case PanelActivityLogMessageCode.OtisElevatorAudit:
                            var otisActivityLogData = new OtisElevatorActivityLogMessageFromCpu(pkt.Data);
                            return otisActivityLogData;

                        case PanelActivityLogMessageCode.CardTourStarting:
                        case PanelActivityLogMessageCode.CardTourContinuing:
                        case PanelActivityLogMessageCode.CardTourCompleted:
                        case PanelActivityLogMessageCode.CardTourIncorrectStartReader:
                        case PanelActivityLogMessageCode.CardTourOverdue:
                        case PanelActivityLogMessageCode.CardTourNonExistentTour:
                            var cardTourActivityLogData = new CardTourActivityLogMessageFromCpu(pkt.Data);
                            return cardTourActivityLogData;

                        case PanelActivityLogMessageCode.CardCommand:
                            var standardCardCommandLogData = new StandardCardDataActivityLogMessageFromCpu(pkt.Data);
                            return standardCardCommandLogData;

                        default:
                            var logData = new ActivityLogMessageFromCpu(pkt.Data);
                            return Packet6xxConverters.ConvertFrom(pkt, ref logData, cpuModel, clusterGroupId, timeZoneId);
                    }

                case PacketDataCodeFrom6xx.ResponseReaderPortStatus:
                    var readerPortStatusResponse = new ReaderPortStatusResponse(pkt.Data);
                    var accessPortalStatusReply = new AccessPortalStatusReply(replyBase)
                    {

                    };

                    switch ((ReaderPortStatusResponse.StatusCode)readerPortStatusResponse.ReaderState)
                    {
                        case ReaderPortStatusResponse.StatusCode.Unknown:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.Unknown;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.Unknown;
                            break;

                        case ReaderPortStatusResponse.StatusCode.Idle:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.Idle;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadyToRead;
                            break;

                        case ReaderPortStatusResponse.StatusCode.PinBlink:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.PinBlink;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadyToRead;
                            break;
                        case ReaderPortStatusResponse.StatusCode.Pin:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.Pin;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.Reading;
                            break;
                        case ReaderPortStatusResponse.StatusCode.ReadingCardForward:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.ReadingCardForward;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.Reading;
                            break;
                        case ReaderPortStatusResponse.StatusCode.ReadingCardReverse:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.ReadingCardReverse;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.Reading;
                            break;
                        case ReaderPortStatusResponse.StatusCode.RedStep:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.RedStep;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadingDisabled;
                            break;
                        case ReaderPortStatusResponse.StatusCode.AlarmDisarmed:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.AlarmDisarmed;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadyToRead;
                            break;
                        case ReaderPortStatusResponse.StatusCode.DelayedUnlock:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.DelayedUnlock;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadyToRead;
                            break;
                        case ReaderPortStatusResponse.StatusCode.Open:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.Open;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadyToRead;
                            break;
                        case ReaderPortStatusResponse.StatusCode.OpenTooLong:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.OpenTooLong;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadyToRead;
                            break;
                        case ReaderPortStatusResponse.StatusCode.Unlock:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.Unlock;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadyToRead;
                            break;
                        case ReaderPortStatusResponse.StatusCode.Shunted:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.Shunted;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadyToRead;
                            break;
                        case ReaderPortStatusResponse.StatusCode.Scheduled:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.Scheduled;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadyToRead;
                            break;
                        case ReaderPortStatusResponse.StatusCode.PrivacyMode:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.PrivacyMode;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadingDisabled;
                            break;
                        case ReaderPortStatusResponse.StatusCode.OfficeMode:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.OfficeMode;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadyToRead;
                            break;
                        case ReaderPortStatusResponse.StatusCode.Dead:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.Dead;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadingDisabled;
                            break;
                        case ReaderPortStatusResponse.StatusCode.Interlocked:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.Interlocked;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadingDisabled;
                            break;
                        case ReaderPortStatusResponse.StatusCode.AlarmArmed:
                            accessPortalStatusReply.AccessPortalStatus = AccessPortalStatus.AlarmArmed;
                            accessPortalStatusReply.CredentialReaderStatus = CredentialReaderStatus.ReadyToRead;
                            break;
                    }

                    switch ((ReaderPortStatusResponse.DoorContactStateCode)readerPortStatusResponse.DoorContactState)
                    {
                        case ReaderPortStatusResponse.DoorContactStateCode.TroubleShort:
                            accessPortalStatusReply.ContactStatus = AccessPortalContactStatus.TroubleShort;
                            break;
                        case ReaderPortStatusResponse.DoorContactStateCode.Closed:
                            accessPortalStatusReply.ContactStatus = AccessPortalContactStatus.Closed;
                            break;
                        case ReaderPortStatusResponse.DoorContactStateCode.TroubleOpen:
                            accessPortalStatusReply.ContactStatus = AccessPortalContactStatus.TroubleOpen;
                            break;
                        case ReaderPortStatusResponse.DoorContactStateCode.Open:
                            accessPortalStatusReply.ContactStatus = AccessPortalContactStatus.Open;
                            break;
                        case ReaderPortStatusResponse.DoorContactStateCode.Unknown:
                        default:
                            accessPortalStatusReply.ContactStatus = AccessPortalContactStatus.Unknown;
                            break;
                    }

                    if ((readerPortStatusResponse.Relays & 1) != 0)
                        accessPortalStatusReply.LockStatus = AccessPortalLockStatus.Unlocked;
                    else
                        accessPortalStatusReply.LockStatus = AccessPortalLockStatus.Locked;

                    return accessPortalStatusReply;

                case PacketDataCodeFrom6xx.ResponseInputDeviceStatus:
                    var inputDeviceStatusResponse = new InputDeviceStatusResponse(pkt.Data);
                    // If the NodeNumber is 0, then the input is a DIO input, hardcode the module # as 1
                    if (replyBase.NodeNumber == 0)
                        replyBase.ModuleNumber = 1;
                    else
                    {
                        replyBase.ModuleNumber = replyBase.NodeNumber;
                    }

                    var inputDeviceStatusReply = new InputDeviceStatusReply(replyBase)
                    {
                        NodeNumber = inputDeviceStatusResponse.InputNumber,
                    };

                    switch ((InputDeviceStatusResponse.InputStates)inputDeviceStatusResponse.CurrentContactState)
                    {
                        case InputDeviceStatusResponse.InputStates.TroubleOpen:
                            inputDeviceStatusReply.ContactStatus = InputDeviceContactStatus.TroubleOpen;
                            break;
                        case InputDeviceStatusResponse.InputStates.TroubleShort:
                            inputDeviceStatusReply.ContactStatus = InputDeviceContactStatus.TroubleShort;
                            break;
                        case InputDeviceStatusResponse.InputStates.DisarmedOff:
                            inputDeviceStatusReply.ContactStatus = InputDeviceContactStatus.Off;
                            break;
                        case InputDeviceStatusResponse.InputStates.DisarmedOn:
                            inputDeviceStatusReply.ContactStatus = InputDeviceContactStatus.On;
                            break;
                        case InputDeviceStatusResponse.InputStates.ArmedSecure:
                            inputDeviceStatusReply.ContactStatus = InputDeviceContactStatus.ArmedSecure;
                            break;
                        case InputDeviceStatusResponse.InputStates.ArmedAlarm:
                            inputDeviceStatusReply.ContactStatus = InputDeviceContactStatus.ArmedAlarm;
                            break;
                        case InputDeviceStatusResponse.InputStates.Unknown:
                        default:
                            inputDeviceStatusReply.ContactStatus = InputDeviceContactStatus.Unknown;
                            break;
                    }

                    switch ((InputDeviceStatusResponse.MonitoringState)inputDeviceStatusResponse.CurrentMonitoringState)
                    {
                        case InputDeviceStatusResponse.MonitoringState.Isolated:
                            inputDeviceStatusReply.MonitoringStatus = InputDeviceMonitoringStatus.Isolated;
                            break;
                        case InputDeviceStatusResponse.MonitoringState.Shunted:
                            inputDeviceStatusReply.MonitoringStatus = InputDeviceMonitoringStatus.Shunted;
                            break;
                        case InputDeviceStatusResponse.MonitoringState.Normal:
                            inputDeviceStatusReply.MonitoringStatus = InputDeviceMonitoringStatus.Normal;
                            break;
                        case InputDeviceStatusResponse.MonitoringState.EntryDelay:
                            inputDeviceStatusReply.MonitoringStatus = InputDeviceMonitoringStatus.EntryDelay;
                            break;
                        case InputDeviceStatusResponse.MonitoringState.DwellDelay:
                            inputDeviceStatusReply.MonitoringStatus = InputDeviceMonitoringStatus.DwellDelay;
                            break;
                        case InputDeviceStatusResponse.MonitoringState.ArmingInputIdle:
                            inputDeviceStatusReply.MonitoringStatus = InputDeviceMonitoringStatus.ArmedInputIdle;
                            break;
                        case InputDeviceStatusResponse.MonitoringState.ArmingInputTiming:
                            inputDeviceStatusReply.MonitoringStatus = InputDeviceMonitoringStatus.ArmedInputTiming;
                            break;

                        default:
                            inputDeviceStatusReply.MonitoringStatus = InputDeviceMonitoringStatus.Unknown;
                            break;
                    }

                    inputDeviceStatusReply.ArmedStatus = InputDeviceIoGroupArmedStatus.Disarmed;// start with disarmed
                    if ((inputDeviceStatusResponse.IOGroupState & (byte)InputDeviceStatusResponse.InputOutputGroupState.LocalIoGroup) != 0)
                        inputDeviceStatusReply.IoGroupIsLocal = true;

                    if ((inputDeviceStatusResponse.IOGroupState & (byte)InputDeviceStatusResponse.InputOutputGroupState.Armed) != 0)
                        inputDeviceStatusReply.ArmedStatus = InputDeviceIoGroupArmedStatus.Armed;

                    if ((inputDeviceStatusResponse.IOGroupState & (byte)InputDeviceStatusResponse.InputOutputGroupState.ManuallyArmed) != 0)
                        inputDeviceStatusReply.ArmedManuallyStatus |= InputDeviceIoGroupArmedManuallyStatus.ManuallyArmed;

                    if ((inputDeviceStatusResponse.IOGroupState & (byte)InputDeviceStatusResponse.InputOutputGroupState.ManuallyDisarmed) != 0)
                        inputDeviceStatusReply.ArmedManuallyStatus |= InputDeviceIoGroupArmedManuallyStatus.ManuallyDisarmed;


                    if ((inputDeviceStatusResponse.Flags & (byte)InputDeviceStatusResponse.InputFlags.BoardNotPresent) != 0)
                        inputDeviceStatusReply.BoardStatus = CircuitBoardStatus.NotPresent;
                    else
                        inputDeviceStatusReply.BoardStatus = CircuitBoardStatus.Present;

                    return inputDeviceStatusReply;

                case PacketDataCodeFrom6xx.ResponseInputVoltages:
                    var inputVoltagesReply = new InputDeviceVoltagesReply(replyBase)
                    {
                        ModuleNumber = 1,   // hardcoded module #. This message only comes from DIO inputs, which is hardcoded as module # 1
                        NodeNumber = pkt.Data[1],
                        NormalVoltage = pkt.Data[2],
                        AlternateVoltage = pkt.Data[3]
                    };
                    return inputVoltagesReply;

                case PacketDataCodeFrom6xx.CpuHeartbeat:
                case PacketDataCodeFrom6xx.ResponseSignOnChallenge:
                case PacketDataCodeFrom6xx.RecalibrateIoCommand1:
                case PacketDataCodeFrom6xx.RecalibrateIoCommand2:
                case PacketDataCodeFrom6xx.RecalibrateIoCommand7:
                case PacketDataCodeFrom6xx.RecalibrateIoCommand8:
                case PacketDataCodeFrom6xx.NotificationCardAreaChange:
                //case PacketDataCodeFrom6xx.ResponseResetCpu:


                case PacketDataCodeFrom6xx.ResponseCardCommand:
                //case PacketDataCodeFrom6xx.NotificationInternalPanelRecalibrate:
                //case PacketDataCodeFrom6xx.PanelRecalibrateComplete:

                case PacketDataCodeFrom6xx.ResponseReaderPortOutputStatus:
                case PacketDataCodeFrom6xx.ResponseOutputRelayModuleOutputStatus:
                case PacketDataCodeFrom6xx.ResponseAlarmMonitoringModuleGeneralPurposeIOOutputStatus:
                case PacketDataCodeFrom6xx.ResponseElevatorModuleOutputStatus:

                case PacketDataCodeFrom6xx.ResponseElevatorCommand:
                case PacketDataCodeFrom6xx.ResponseIOGroupCounters:
                case PacketDataCodeFrom6xx.NotificationCounterBelowZero:

                case PacketDataCodeFrom6xx.NotificationEventPreviousStateInvalid:
                case PacketDataCodeFrom6xx.NotificationEventNewStateInvalid:

                case PacketDataCodeFrom6xx.NotificationEventIOLevel:
                case PacketDataCodeFrom6xx.NotificationInputOutputGroupBitsRepaired:
                case PacketDataCodeFrom6xx.NotificationEventIOPulse:
                case PacketDataCodeFrom6xx.NotificationEventRecalibrate:


                case PacketDataCodeFrom6xx.NotificationCardNotInPanelMemory:
                case PacketDataCodeFrom6xx.NotificationCardHasBeenRead:
                case PacketDataCodeFrom6xx.NotificationCardRemoteAccessRuleOverride:

                default:
                    break;
            }
            return replyBase;
        }

        public static object ConvertFrom(IDataPacket6xx pkt, ref ActivityLogMessageFromCpu activityLog, CpuModel cpuModel, int clusterGroupId, string timeZoneId)
        {
            var logData = new PanelActivityLogMessage();
            logData.ClusterGroupId = clusterGroupId;
            logData.ClusterNumber = pkt.ClusterId;
            logData.PanelNumber = pkt.PanelId;
            logData.CpuId = (short)pkt.Cpu;
            logData.CpuModel = cpuModel;
            logData.BoardNumber = activityLog.BoardNumber;
            logData.SectionNumber = activityLog.SectionNumber;
            logData.ModuleNumber = activityLog.NodeNumber;
            logData.NodeNumber = activityLog.NodeNumber;
            logData.RawData = pkt.Data;

            logData.BufferIndex = activityLog.BufferIndex;
            var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            if (activityLog.DateTime.Year < 2000)
                Trace.WriteLine($"activityLog.DateTime:{activityLog.DateTime}");
            //var utcOffset = tz.BaseUtcOffset;
            var utcOffset = tz.GetUtcOffset(activityLog.DateTime);
            logData.DateTime = new DateTimeOffset(activityLog.DateTime, utcOffset);
            switch ((PanelActivityLogMessageCode)activityLog.LogType)
            {
                case PanelActivityLogMessageCode.BoardCommunicationStarted:
                    logData.PanelActivityType = PanelActivityEventCode.BoardCommunicationStarted;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.BoardCommunicationStarted;
                    break;

                case PanelActivityLogMessageCode.BoardCommunicationStopped:
                    logData.PanelActivityType = PanelActivityEventCode.BoardCommunicationStopped;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.BoardCommunicationStopped;
                    break;

                case PanelActivityLogMessageCode.CpuColdReset:
                    logData.PanelActivityType = PanelActivityEventCode.CpuColdReset;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CpuColdReset;
                    break;

                case PanelActivityLogMessageCode.CpuWarmReset:
                    logData.PanelActivityType = PanelActivityEventCode.CpuWarmReset;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CpuWarmReset;
                    break;

                case PanelActivityLogMessageCode.CrisisModeActivated:
                    logData.PanelActivityType = PanelActivityEventCode.CrisisModeActivated;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CrisisModeActivated;
                    break;

                case PanelActivityLogMessageCode.ClusterCrisisModeReset:
                    logData.PanelActivityType = PanelActivityEventCode.CrisisModeDeActivated;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CrisisModeDeActivated;
                    break;

                case PanelActivityLogMessageCode.DeviceOffline:
                    logData.PanelActivityType = PanelActivityEventCode.DeviceOffline;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DeviceOffline;
                    break;

                case PanelActivityLogMessageCode.DeviceOnline:
                    logData.PanelActivityType = PanelActivityEventCode.DeviceOnline;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DeviceOnline;
                    break;

                case PanelActivityLogMessageCode.DoorContactShunted:
                    logData.PanelActivityType = PanelActivityEventCode.DoorContactShunted;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorContactShunted;
                    break;

                case PanelActivityLogMessageCode.DoorContactTroubleCleared:
                    logData.PanelActivityType = PanelActivityEventCode.DoorContactTroubleCleared;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorContactTroubleCleared;
                    break;

                case PanelActivityLogMessageCode.DoorContactTroubleOpenCircuit:
                    logData.PanelActivityType = PanelActivityEventCode.DoorContactTroubleOpenCircuit;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorContactTroubleOpenCircuit;
                    break;

                case PanelActivityLogMessageCode.DoorContactTroubleShortCircuit:
                    logData.PanelActivityType = PanelActivityEventCode.DoorContactTroubleShortCircuit;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorContactTroubleShortCircuit;
                    break;

                case PanelActivityLogMessageCode.DoorDelayedUnlock:
                    logData.PanelActivityType = PanelActivityEventCode.DoorDelayedUnlock;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorDelayedUnlock;
                    break;

                case PanelActivityLogMessageCode.DoorForcedOpen:
                    logData.PanelActivityType = PanelActivityEventCode.DoorForcedOpen;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorForcedOpen;
                    break;

                case PanelActivityLogMessageCode.DoorLeftOpen:
                    logData.PanelActivityType = PanelActivityEventCode.DoorLeftOpen;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorLeftOpen;
                    break;

                case PanelActivityLogMessageCode.DoorClosed:
                    logData.PanelActivityType = PanelActivityEventCode.DoorClosed;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorClosed;
                    break;

                case PanelActivityLogMessageCode.DoorRequestToExit:
                    logData.PanelActivityType = PanelActivityEventCode.DoorRequestToExit;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorRequestToExit;
                    break;

                case PanelActivityLogMessageCode.DoorHeartbeartAlarm:
                    logData.PanelActivityType = PanelActivityEventCode.DoorHeartbeartAlarm;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorHeartbeartAlarm;
                    break;

                case PanelActivityLogMessageCode.DoorHeartbeatRestored:
                    logData.PanelActivityType = PanelActivityEventCode.DoorHeartbeatRestored;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorHeartbeatRestored;
                    break;

                case PanelActivityLogMessageCode.DoorLockBySchedule:
                    logData.PanelActivityType = PanelActivityEventCode.DoorLockBySchedule;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorLockBySchedule;
                    break;

                case PanelActivityLogMessageCode.DoorUnlockBySchedule:
                    logData.PanelActivityType = PanelActivityEventCode.DoorUnlockBySchedule;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorUnlockBySchedule;
                    break;

                case PanelActivityLogMessageCode.DualSerialInterfaceDoorModuleOffline:
                    logData.PanelActivityType = PanelActivityEventCode.DualSerialInterfaceDoorModuleOffline;
                    logData.ModuleNumber = pkt.Data[11];
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DualSerialInterfaceDoorModuleOffline;
                    break;

                case PanelActivityLogMessageCode.DualSerialInterfaceDoorModuleOnline:
                    logData.PanelActivityType = PanelActivityEventCode.DualSerialInterfaceDoorModuleOnline;
                    logData.ModuleNumber = pkt.Data[11];
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DualSerialInterfaceDoorModuleOnline;
                    break;

                case PanelActivityLogMessageCode.DualSerialInterfaceInputModuleOffline:
                    logData.PanelActivityType = PanelActivityEventCode.DualSerialInterfaceInputModuleOffline;
                    logData.ModuleNumber = pkt.Data[11];
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DualSerialInterfaceInputModuleOffline;
                    break;

                case PanelActivityLogMessageCode.DualSerialInterfaceInputModuleOnline:
                    logData.PanelActivityType = PanelActivityEventCode.DualSerialInterfaceInputModuleOnline;
                    logData.ModuleNumber = pkt.Data[11];
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DualSerialInterfaceInputModuleOnline;
                    break;

                case PanelActivityLogMessageCode.DualSerialInterfaceRelayBoardOffline:
                    logData.PanelActivityType = PanelActivityEventCode.DualSerialInterfaceRelayBoardOffline;
                    logData.ModuleNumber = pkt.Data[11];
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DualSerialInterfaceRelayBoardOffline;
                    break;

                case PanelActivityLogMessageCode.DualSerialInterfaceRelayBoardOnline:
                    logData.PanelActivityType = PanelActivityEventCode.DualSerialInterfaceRelayBoardOnline;
                    logData.ModuleNumber = pkt.Data[11];
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DualSerialInterfaceRelayBoardOnline;
                    break;

                case PanelActivityLogMessageCode.EmergencyUnlockActive:
                    logData.PanelActivityType = PanelActivityEventCode.EmergencyUnlockActive;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.EmergencyUnlockActive;
                    break;

                case PanelActivityLogMessageCode.EmergencyUnlockInactive:
                    logData.PanelActivityType = PanelActivityEventCode.EmergencyUnlockInactive;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.EmergencyUnlockInactive;
                    break;

                case PanelActivityLogMessageCode.IoGroupArmedByCommand:
                    logData.PanelActivityType = PanelActivityEventCode.IoGroupArmedByCommand;
                    logData.InputOutputGroupNumber = activityLog.BoardNumber;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.IoGroupArmedByCommand;
                    break;

                case PanelActivityLogMessageCode.IoGroupArmedBySchedule:
                    logData.PanelActivityType = PanelActivityEventCode.IoGroupArmedBySchedule;
                    logData.InputOutputGroupNumber = activityLog.BoardNumber;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.IoGroupArmedBySchedule;
                    break;

                case PanelActivityLogMessageCode.IoGroupDisarmedByCommand:
                    logData.PanelActivityType = PanelActivityEventCode.IoGroupDisarmedByCommand;
                    logData.InputOutputGroupNumber = activityLog.BoardNumber;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.IoGroupDisarmedByCommand;
                    break;

                case PanelActivityLogMessageCode.IoGroupDisarmedBySchedule:
                    logData.PanelActivityType = PanelActivityEventCode.IoGroupDisarmedBySchedule;
                    logData.InputOutputGroupNumber = activityLog.BoardNumber;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.IoGroupDisarmedBySchedule;
                    break;

                case PanelActivityLogMessageCode.OutputOffBySchedule:
                    logData.PanelActivityType = PanelActivityEventCode.OutputOffBySchedule;
                    logData.NodeNumber = pkt.Data[11];
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.OutputOffBySchedule;
                    break;

                case PanelActivityLogMessageCode.OutputOnBySchedule:
                    logData.PanelActivityType = PanelActivityEventCode.OutputOnBySchedule;
                    logData.NodeNumber = pkt.Data[11];
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.OutputOnBySchedule;
                    break;

                case PanelActivityLogMessageCode.PanelAcFailureAlarm:
                    logData.PanelActivityType = PanelActivityEventCode.CpuAcFailureAlarm;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CpuAcFailureAlarm;
                    break;

                case PanelActivityLogMessageCode.PanelAcFailureRestored:
                    logData.PanelActivityType = PanelActivityEventCode.CpuAcFailureRestored;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CpuAcFailureRestored;
                    break;

                case PanelActivityLogMessageCode.PanelLowBatteryAlarm:
                    logData.PanelActivityType = PanelActivityEventCode.CpuLowBatteryAlarm;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CpuLowBatteryAlarm;
                    break;

                case PanelActivityLogMessageCode.PanelLowBatteryRestored:
                    logData.PanelActivityType = PanelActivityEventCode.CpuLowBatteryRestored;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CpuLowBatteryRestored;
                    break;

                case PanelActivityLogMessageCode.PanelTamperAlarm:
                    logData.PanelActivityType = PanelActivityEventCode.CpuTamperAlarm;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CpuTamperAlarm;
                    break;

                case PanelActivityLogMessageCode.PanelTamperRestored:
                    logData.PanelActivityType = PanelActivityEventCode.CpuTamperRestored;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CpuTamperRestored;
                    break;

                case PanelActivityLogMessageCode.PointAlarmArmed:
                    logData.PanelActivityType = PanelActivityEventCode.PointAlarmArmed;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.PointAlarmArmed;
                    logData.NodeNumber = pkt.Data[11];
                    if (logData.ModuleNumber == 0)
                        logData.ModuleNumber = 1;
                    break;

                case PanelActivityLogMessageCode.PointAlarmUnarmed:
                    logData.PanelActivityType = PanelActivityEventCode.PointAlarmUnarmed;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.PointAlarmUnarmed;
                    logData.NodeNumber = pkt.Data[11];
                    if (logData.ModuleNumber == 0)
                        logData.ModuleNumber = 1;
                    break;

                case PanelActivityLogMessageCode.PointInTrouble:
                    logData.PanelActivityType = PanelActivityEventCode.PointInTrouble;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.PointInTrouble;
                    logData.NodeNumber = pkt.Data[11];
                    if (logData.ModuleNumber == 0)
                        logData.ModuleNumber = 1;
                    break;

                case PanelActivityLogMessageCode.PointSecureArmed:
                    logData.PanelActivityType = PanelActivityEventCode.PointSecureArmed;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.PointSecureArmed;
                    logData.NodeNumber = pkt.Data[11];
                    if (logData.ModuleNumber == 0)
                        logData.ModuleNumber = 1;
                    break;

                case PanelActivityLogMessageCode.PointSecureUnarmed:
                    logData.PanelActivityType = PanelActivityEventCode.PointSecureUnarmed;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.PointSecureUnarmed;
                    logData.NodeNumber = pkt.Data[11];
                    if (logData.ModuleNumber == 0)
                        logData.ModuleNumber = 1;
                    break;

                case PanelActivityLogMessageCode.PointTroubleShortCircuit:
                    logData.PanelActivityType = PanelActivityEventCode.PointTroubleShortCircuit;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.PointTroubleShortCircuit;
                    logData.NodeNumber = pkt.Data[11];
                    if (logData.ModuleNumber == 0)
                        logData.ModuleNumber = 1;
                    break;

                case PanelActivityLogMessageCode.ReaderBatteryFlat:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderBatteryFlat;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderBatteryFlat;
                    break;

                case PanelActivityLogMessageCode.ReaderBatteryOk:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderBatteryOk;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderBatteryOk;
                    break;

                case PanelActivityLogMessageCode.ReaderHeartbeatStarted:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderHeartbeatStarted;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderHeartbeatStarted;
                    break;

                case PanelActivityLogMessageCode.ReaderHeartbeatStopped:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderHeartbeatStopped;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderHeartbeatStopped;
                    break;

                case PanelActivityLogMessageCode.ReaderLowBattery:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderLowBattery;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderLowBattery;
                    break;

                case PanelActivityLogMessageCode.ReaderRadioInterferenceCleared:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderRadioInterferenceCleared;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderRadioInterferenceCleared;
                    break;

                case PanelActivityLogMessageCode.ReaderRadioInterferenceDetected:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderRadioInterferenceDetected;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderRadioInterferenceDetected;
                    break;

                case PanelActivityLogMessageCode.ReadError:
                    logData.PanelActivityType = PanelActivityEventCode.ReadError;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReadError;
                    break;

                case PanelActivityLogMessageCode.ReaderTamperAlarm:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderTamperAlarm;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderTamperAlarm;
                    break;

                case PanelActivityLogMessageCode.ReaderTamperRestored:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderTamperRestored;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderTamperRestored;
                    break;

                case PanelActivityLogMessageCode.DoorModuleAdapterTamperAlarm:
                    logData.PanelActivityType = PanelActivityEventCode.DoorModuleAdapterTamperAlarm;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorModuleAdapterTamperAlarm;
                    break;

                case PanelActivityLogMessageCode.DoorModuleAdapterTamperSafe:
                    logData.PanelActivityType = PanelActivityEventCode.DoorModuleAdapterTamperSafe;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorModuleAdapterTamperSafe;
                    break;

                case PanelActivityLogMessageCode.Relay2OffBySchedule:
                    logData.PanelActivityType = PanelActivityEventCode.Relay2OffBySchedule;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.Relay2OffBySchedule;
                    break;

                case PanelActivityLogMessageCode.Relay2OnBySchedule:
                    logData.PanelActivityType = PanelActivityEventCode.Relay2OnBySchedule;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.Relay2OnBySchedule;
                    break;

                case PanelActivityLogMessageCode.ReaderPrivacyModeEntered:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderPrivacyModeEntered;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderPrivacyModeEntered;
                    break;

                case PanelActivityLogMessageCode.ReaderPrivacyModeExited:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderPrivacyModeExited;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderPrivacyModeExited;
                    break;

                case PanelActivityLogMessageCode.ReaderOfficeModeEntered:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderOfficeModeEntered;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderOfficeModeEntered;
                    break;

                case PanelActivityLogMessageCode.ReaderOfficeModeExited:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderOfficeModeExited;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderOfficeModeExited;
                    break;

                case PanelActivityLogMessageCode.ReaderNdeMagnetAlertNeedsCalibrated:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderNdeMagnetAlertNeedsCalibrated;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderNdeMagnetAlertNeedsCalibrated;
                    break;

                case PanelActivityLogMessageCode.ReaderNdeMagnetSafeCalibrated:
                    logData.PanelActivityType = PanelActivityEventCode.ReaderNdeMagnetSafeCalibrated;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.ReaderNdeMagnetSafeCalibrated;
                    break;

                case PanelActivityLogMessageCode.DoorContactChange:
                    logData.PanelActivityType = PanelActivityEventCode.DoorContactChange;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DoorContactChange;
                    switch ((Series6xx.Messages.ReaderPortStatusResponse.DoorContactStateCode)activityLog.Data[0])
                    {
                        case ReaderPortStatusResponse.DoorContactStateCode.TroubleShort:
                            logData.AccessPortalContactStatus = AccessPortalContactStatus.TroubleShort;
                            break;
                        case ReaderPortStatusResponse.DoorContactStateCode.Closed:
                            logData.AccessPortalContactStatus = AccessPortalContactStatus.Closed;
                            break;
                        case ReaderPortStatusResponse.DoorContactStateCode.TroubleOpen:
                            logData.AccessPortalContactStatus = AccessPortalContactStatus.TroubleOpen;
                            break;
                        case ReaderPortStatusResponse.DoorContactStateCode.Open:
                            logData.AccessPortalContactStatus = AccessPortalContactStatus.Open;
                            break;
                        case ReaderPortStatusResponse.DoorContactStateCode.Unknown:
                        default:
                            logData.AccessPortalContactStatus = AccessPortalContactStatus.Unknown;
                            break;
                    }
                    break;

                case PanelActivityLogMessageCode.VeridtReaderTamperAlarm:
                    logData.PanelActivityType = PanelActivityEventCode.VeridtReaderTamperAlarm;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.VeridtReaderTamperAlarm;
                    break;

                case PanelActivityLogMessageCode.VeridtReaderTamperSafe:
                    logData.PanelActivityType = PanelActivityEventCode.VeridtReaderTamperSafe;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.VeridtReaderTamperSafe;
                    break;

                case PanelActivityLogMessageCode.VeridtCardCertificateProblem:
                    logData.PanelActivityType = PanelActivityEventCode.VeridtCardCertificateProblem;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.VeridtCardCertificateProblem;
                    break;

                case PanelActivityLogMessageCode.VeridtReaderFactorModeSet:
                    logData.PanelActivityType = PanelActivityEventCode.VeridtReaderFactorModeSet;
                    logData.MultiFactorMode = (AccessPortalMultiFactorModeCode)activityLog.Data[0];
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.VeridtReaderFactorModeSet;
                    break;

                case PanelActivityLogMessageCode.DoorCommand:
                    switch ((PacketDataCodeTo6xx)activityLog.Data[0])
                    {
                        case PacketDataCodeTo6xx.CommandPulseDoor:
                            logData.PanelActivityType = PanelActivityEventCode.CommandPulseDoor;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandPulseDoor;
                            break;

                        case PacketDataCodeTo6xx.CommandLockDoor:
                            logData.PanelActivityType = PanelActivityEventCode.CommandLockDoor;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandLockDoor;
                            break;

                        case PacketDataCodeTo6xx.CommandUnlockDoor:
                            logData.PanelActivityType = PanelActivityEventCode.CommandUnlockDoor;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandUnlockDoor;
                            break;

                        case PacketDataCodeTo6xx.CommandDisableDoor:
                            logData.PanelActivityType = PanelActivityEventCode.CommandDisableDoor;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandDisableDoor;
                            break;

                        case PacketDataCodeTo6xx.CommandEnableDoor:
                            logData.PanelActivityType = PanelActivityEventCode.CommandEnableDoor;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandEnableDoor;
                            break;

                        case PacketDataCodeTo6xx.CommandRelay2Off:
                            logData.PanelActivityType = PanelActivityEventCode.CommandRelay2Off;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandRelay2Off;
                            break;

                        case PacketDataCodeTo6xx.CommandRelay2On:
                            logData.PanelActivityType = PanelActivityEventCode.CommandRelay2On;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandRelay2On;
                            break;
                    }

                    break;

                case PanelActivityLogMessageCode.DoorGroupCommand:
                    switch ((PacketDataCodeTo6xx)activityLog.Data[0])
                    {
                        case PacketDataCodeTo6xx.CommandDisableDoorGroup:
                            logData.PanelActivityType = PanelActivityEventCode.CommandDisableDoorGroup;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandDisableDoorGroup;
                            logData.InputOutputGroupNumber = activityLog.BoardNumber;
                            break;

                        case PacketDataCodeTo6xx.CommandEnableDoorGroup:
                            logData.PanelActivityType = PanelActivityEventCode.CommandEnableDoorGroup;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandEnableDoorGroup;
                            logData.InputOutputGroupNumber = activityLog.BoardNumber;
                            break;

                        case PacketDataCodeTo6xx.CommandUnlockDoorGroup:
                            logData.PanelActivityType = PanelActivityEventCode.CommandUnlockDoorGroup;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandUnlockDoorGroup;
                            logData.InputOutputGroupNumber = activityLog.BoardNumber;
                            break;

                        case PacketDataCodeTo6xx.CommandLockDoorGroup:
                            logData.PanelActivityType = PanelActivityEventCode.CommandLockDoorGroup;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandLockDoorGroup;
                            logData.InputOutputGroupNumber = activityLog.BoardNumber;
                            break;
                    }
                    break;

                case PanelActivityLogMessageCode.IoGroupCommand:
                    switch ((PacketDataCodeTo6xx)activityLog.Data[0])
                    {
                        case PacketDataCodeTo6xx.CommandArmIOGroup:
                            logData.PanelActivityType = PanelActivityEventCode.CommandArmIOGroup;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandArmIOGroup;
                            logData.InputOutputGroupNumber = activityLog.Data[1];//activityLog.BoardNumber;
                            break;

                        case PacketDataCodeTo6xx.CommandDisarmIOGroup:
                            logData.PanelActivityType = PanelActivityEventCode.CommandDisarmIOGroup;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandDisarmIOGroup;
                            logData.InputOutputGroupNumber = activityLog.Data[1];//activityLog.BoardNumber;
                            break;

                        case PacketDataCodeTo6xx.CommandShuntIOGroup:
                            logData.PanelActivityType = PanelActivityEventCode.CommandShuntIOGroup;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandShuntIOGroup;
                            logData.InputOutputGroupNumber = activityLog.Data[1];//activityLog.BoardNumber;
                            break;

                        case PacketDataCodeTo6xx.CommandUnshuntIOGroup:
                            logData.PanelActivityType = PanelActivityEventCode.CommandUnshuntIOGroup;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandUnshuntIOGroup;
                            logData.InputOutputGroupNumber = activityLog.Data[1];//activityLog.BoardNumber;
                            break;
                    }
                    break;

                case PanelActivityLogMessageCode.InputCommand:
                    switch ((PacketDataCodeTo6xx)activityLog.Data[0])
                    {
                        case PacketDataCodeTo6xx.CommandUnshuntInput:
                            logData.PanelActivityType = PanelActivityEventCode.CommandUnshuntInput;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandUnshuntInput;
                            break;

                        case PacketDataCodeTo6xx.CommandShuntInput:
                            logData.PanelActivityType = PanelActivityEventCode.CommandShuntInput;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandShuntInput;
                            break;

                        case PacketDataCodeTo6xx.CommandDisableInput:
                            logData.PanelActivityType = PanelActivityEventCode.CommandDisableInput;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandDisableInput;
                            break;

                        case PacketDataCodeTo6xx.CommandEnableInput:
                            logData.PanelActivityType = PanelActivityEventCode.CommandEnableInput;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandEnableInput;
                            break;
                    }
                    logData.NodeNumber = pkt.Data[12];
                    if (logData.ModuleNumber == 0)
                        logData.ModuleNumber = 1;

                    break;

                case PanelActivityLogMessageCode.OutputCommand:
                    switch ((PacketDataCodeTo6xx)activityLog.Data[0])
                    {
                        case PacketDataCodeTo6xx.CommandOutputOn:
                            logData.PanelActivityType = PanelActivityEventCode.CommandOutputOn;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandOutputOn;
                            break;

                        case PacketDataCodeTo6xx.CommandOutputOff:
                            logData.PanelActivityType = PanelActivityEventCode.CommandOutputOff;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandOutputOff;
                            break;

                        case PacketDataCodeTo6xx.CommandOutputEnable:
                            logData.PanelActivityType = PanelActivityEventCode.CommandOutputEnable;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandOutputEnable;
                            break;

                        case PacketDataCodeTo6xx.CommandOutputDisable:
                            logData.PanelActivityType = PanelActivityEventCode.CommandOutputDisable;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CommandOutputDisable;
                            break;
                    }
                    logData.NodeNumber = pkt.Data[12];
                    break;

                case PanelActivityLogMessageCode.CardCommand:
                    switch ((PacketDataCodeTo6xx)activityLog.Data[0])
                    {
                        case PacketDataCodeTo6xx.CommandCardEnable:
                            logData.PanelActivityType = PanelActivityEventCode.CredentialActivated;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CredentialActivated;
                            break;

                        case PacketDataCodeTo6xx.CommandCardDisable:
                            logData.PanelActivityType = PanelActivityEventCode.CredentialDeactivated;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CredentialDeactivated;
                            break;

                        case PacketDataCodeTo6xx.CommandForgivePassbackCard:
                            logData.PanelActivityType = PanelActivityEventCode.PassbackForgivenForUser;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.PassbackForgivenForUser;
                            break;
                    }
                    break;


                case PanelActivityLogMessageCode.PanelCommand:
                    switch ((PacketDataCodeTo6xx)activityLog.Data[0])
                    {
                        case PacketDataCodeTo6xx.CommandForgivePassbackEverybody:
                            logData.PanelActivityType = PanelActivityEventCode.PassbackForgivenForAllUsers;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.PassbackForgivenForAllUsers;
                            break;

                        case PacketDataCodeTo6xx.CommandSetCrisisMode:
                            logData.PanelActivityType = PanelActivityEventCode.CrisisModeActivatedByCommand;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CrisisModeActivatedByCommand;
                            break;

                        case PacketDataCodeTo6xx.CommandResetCrisisMode:
                            logData.PanelActivityType = PanelActivityEventCode.CrisisModeDeActivatedByCommand;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CrisisModeDeActivatedByCommand;
                            break;

                        case PacketDataCodeTo6xx.CommandLoggingSetOnOff:
                            if (activityLog.Data[1] == 0)
                            {
                                logData.PanelActivityType = PanelActivityEventCode.CpuTurnLoggingOff;
                                logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CpuTurnLoggingOff;
                            }
                            else
                            {
                                logData.PanelActivityType = PanelActivityEventCode.CpuTurnLoggingOn;
                                logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CpuTurnLoggingOn;
                            }
                            break;
                    }
                    break;


            }
            return logData;
        }

        public static object ConvertFrom(ref ActivityLogMessageCardHelper cardActivityLogHelper, CpuModel cpuModel, int clusterGroupId, string timeZoneId)
        {
            var logData = new PanelCredentialActivityLogMessage
            {
                ClusterGroupId = clusterGroupId,
                ClusterNumber = cardActivityLogHelper.BasePacket.ClusterId,
                PanelNumber = cardActivityLogHelper.BasePacket.PanelId,
                CpuId = (short)cardActivityLogHelper.BasePacket.Cpu,
                CpuModel = cpuModel,
                BoardNumber = cardActivityLogHelper.BoardNumber,
                SectionNumber = cardActivityLogHelper.SectionNumber,
                ModuleNumber = 0,//cardActivityLogHelper.ModuleNumber;
                NodeNumber = cardActivityLogHelper.NodeNumber,

                BufferIndex = cardActivityLogHelper.BufferIndex,
                BitCount = cardActivityLogHelper.BaseRecord.BitCount,
                CredentialBytes = cardActivityLogHelper.CardData,
                RawData = cardActivityLogHelper.BasePacket.Data,
            };
            var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            //var utcOffset = tz.BaseUtcOffset;
            var utcOffset = tz.GetUtcOffset(cardActivityLogHelper.BaseRecord.DateTime);


            logData.DateTime = new DateTimeOffset(cardActivityLogHelper.BaseRecord.DateTime, utcOffset);
            logData.CredentialNumber = HexEncoding.ToString(logData.CredentialBytes, true, "x", true, 48);
            logData.CredentialNumberHex = HexEncoding.ToString(logData.CredentialBytes, true, "x", false, 48);
            switch ((PanelActivityLogMessageCode)cardActivityLogHelper.LogType)
            {
                case PanelActivityLogMessageCode.AccessDenied:
                    logData.PanelActivityType = PanelActivityEventCode.AccessDenied;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AccessDenied;
                    break;

                case PanelActivityLogMessageCode.AccessDeniedAttemptPivCardExpired:
                    logData.PanelActivityType = PanelActivityEventCode.AccessDeniedAttemptPivCardExpired;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AccessDeniedAttemptPivCardExpired;
                    break;

                case PanelActivityLogMessageCode.AccessGranted:
                    logData.PanelActivityType = PanelActivityEventCode.AccessGranted;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AccessGranted;
                    break;

                case PanelActivityLogMessageCode.AccessGrantedDoorNotOpened:
                    logData.PanelActivityType = PanelActivityEventCode.AccessGrantedDoorNotOpened;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AccessGrantedDoorNotOpened;
                    break;

                case PanelActivityLogMessageCode.AutoUnlockActivatedByAccessGranted:
                    logData.PanelActivityType = PanelActivityEventCode.AutoUnlockActivatedByAccessGranted;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AutoUnlockActivatedByAccessGranted;
                    break;

                case PanelActivityLogMessageCode.CredentialDoublePresentDoorUnlocked:
                    logData.PanelActivityType = PanelActivityEventCode.CredentialDoublePresentDoorUnlocked;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CredentialDoublePresentDoorUnlocked;
                    break;

                case PanelActivityLogMessageCode.CredentialDoublePresentDoorLocked:
                    logData.PanelActivityType = PanelActivityEventCode.CredentialDoublePresentDoorLocked;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CredentialDoublePresentDoorLocked;
                    break;

                case PanelActivityLogMessageCode.AccessGrantedNoCardCodeLookup:
                    logData.PanelActivityType = PanelActivityEventCode.AccessGrantedNoCardCodeLookup;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AccessGrantedNoCardCodeLookup;
                    break;

                case PanelActivityLogMessageCode.AccessGrantedWithPinData:
                    logData.PanelActivityType = PanelActivityEventCode.AccessGrantedWithPinData;
                    logData.Pin = cardActivityLogHelper.BaseRecord.PinNumberEntered;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.AccessGrantedWithPinData;
                    break;

                case PanelActivityLogMessageCode.NotInPanelMemory:
                    logData.PanelActivityType = PanelActivityEventCode.CredentialNotInPanelMemory;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CredentialNotInPanelMemory;
                    break;

                case PanelActivityLogMessageCode.NotInPanelMemoryReverse:
                    logData.PanelActivityType = PanelActivityEventCode.CredentialNotInPanelMemoryReverse;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CredentialNotInPanelMemoryReverse;
                    break;

                case PanelActivityLogMessageCode.Duress:
                    logData.PanelActivityType = PanelActivityEventCode.DuressAuxiliaryFunction;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.DuressAuxiliaryFunction;
                    break;

                case PanelActivityLogMessageCode.PassbackViolation:
                    logData.PanelActivityType = PanelActivityEventCode.PassbackViolation;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.PassbackViolation;
                    break;

                case PanelActivityLogMessageCode.IncorrectPinEntered:
                    logData.PanelActivityType = PanelActivityEventCode.IncorrectPinEntered;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.IncorrectPinEntered;
                    break;

                case PanelActivityLogMessageCode.IoGroupArmByCard:
                    logData.PanelActivityType = PanelActivityEventCode.IoGroupArmByCard;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.IoGroupArmByCard;
                    break;

                case PanelActivityLogMessageCode.IoGroupDisarmByCard:
                    logData.PanelActivityType = PanelActivityEventCode.IoGroupDisarmByCard;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.IoGroupDisarmByCard;
                    break;

                case PanelActivityLogMessageCode.OtisElevatorAudit:
                    logData.PanelActivityType = PanelActivityEventCode.OtisElevatorAudit;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.OtisElevatorAudit;
                    break;

                case PanelActivityLogMessageCode.CardTourStarting:
                    logData.PanelActivityType = PanelActivityEventCode.CardTourStarting;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CardTourStarting;
                    break;

                case PanelActivityLogMessageCode.CardTourContinuing:
                    logData.PanelActivityType = PanelActivityEventCode.CardTourContinuing;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CardTourContinuing;
                    break;

                case PanelActivityLogMessageCode.CardTourCompleted:
                    logData.PanelActivityType = PanelActivityEventCode.CardTourCompleted;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CardTourCompleted;
                    break;

                case PanelActivityLogMessageCode.CardTourIncorrectStartReader:
                    logData.PanelActivityType = PanelActivityEventCode.CardTourIncorrectStartReader;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CardTourIncorrectStartReader;
                    break;

                case PanelActivityLogMessageCode.CardTourOverdue:
                    logData.PanelActivityType = PanelActivityEventCode.CardTourOverdue;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CardTourOverdue;
                    break;

                case PanelActivityLogMessageCode.CardTourNonExistentTour:
                    logData.PanelActivityType = PanelActivityEventCode.CardTourNonExistantTour;
                    logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CardTourNonExistantTour;
                    break;

                case PanelActivityLogMessageCode.CardCommand:
                    switch ((PacketDataCodeTo6xx)cardActivityLogHelper.BaseRecord.CardCommand)
                    {
                        case PacketDataCodeTo6xx.CommandCardDisable:
                            logData.PanelActivityType = PanelActivityEventCode.CredentialDeactivated;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CredentialDeactivated;
                            break;

                        case PacketDataCodeTo6xx.CommandCardEnable:
                            logData.PanelActivityType = PanelActivityEventCode.CredentialActivated;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.CredentialActivated;
                            break;

                        case PacketDataCodeTo6xx.CommandForgivePassbackCard:
                            logData.PanelActivityType = PanelActivityEventCode.PassbackForgivenForUser;
                            logData.EventTypeUid = GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds.PassbackForgivenForUser;
                            break;
                    }
                    break;
            }


            return logData;
        }
    }
}