using System;
using System.Reflection;
using GalaxySMS.Business.Entities;
using GalaxySMS.Business.SignalR;
using GalaxySMS.Data;
using GalaxySMS.MessageQueue.Integration.Workflows.Spec;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;

namespace GalaxySMS.MessageQueue.Integration.Workflows
{
    public class PanelMessageRecorderWorkflow : IPanelMessageWorkflow
    {
        #region Implementation of IPanelMessageWorkflow

        //[Import] IDataRepositoryFactory _DataRepositoryFactory;
        public SignalRClient SignalRClient { get; set; }
        public object Data { get; set; }
        public void Run()
        {
            //var msg = $"ClusterGroupId: {Data.ClusterGroupId}, Cluster #:{Data.ClusterNumber}, Panel #:{Data.PanelNumber}, CPU #:{Data.CpuNumber}";
            var msg = string.Empty;
            if (Data != null)
            {
                var t = Data.GetType();
                msg = t.ToString();

                if (t == typeof(PanelActivityLogMessage))
                {
                    if (Data is PanelActivityLogMessage activityLogMessage)
                    {
                        if( activityLogMessage.DateTimeOffset < DateTimeOffset.Now.MinSqlDateTime())
                            activityLogMessage.DateTimeOffset = DateTimeOffset.Now.MinSqlDateTime();

                        var galaxyRawActivityEvent = new GalaxyRawActivityEvent
                        {
                            CpuUid = activityLogMessage.CpuUid,
                            InsertDate = DateTimeOffset.Now,
                            ClusterGroupId = activityLogMessage.ClusterGroupId,
                            ClusterNumber = activityLogMessage.ClusterNumber,
                            PanelNumber = activityLogMessage.PanelNumber,
                            CpuNumber = activityLogMessage.CpuId,
                            EventDateTime = activityLogMessage.DateTimeOffset,
                            EventType = activityLogMessage.PanelActivityType.ToString(),
                            BufferIndex = (int)activityLogMessage.BufferIndex,
                            BoardNumber = (short)activityLogMessage.BoardNumber,
                            SectionNumber = (short)activityLogMessage.SectionNumber,
                            ModuleNumber = (short)activityLogMessage.ModuleNumber,
                            NodeNumber = (short)activityLogMessage.NodeNumber,
                            RawData = activityLogMessage.RawData,
                            InputOutputGroupNumber = activityLogMessage.InputOutputGroupNumber
                        };

                        try
                        {
                            var mgr = new GalaxyRawActivityEventInsertRepository();
                            mgr.Insert(galaxyRawActivityEvent);
                        }
                        catch (Exception e)
                        {
                            this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow PanelActivityLogMessage error: {e}");
                        }


                        var field = typeof(GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds).GetField(activityLogMessage.PanelActivityType.ToString(), BindingFlags.Public | BindingFlags.Static);

                        var activityTypeUid = (Guid)field.GetValue(null);

                        switch (activityLogMessage.Category)
                        {
                            case Common.Enums.PanelActivityEventCategory.Door:
                                try
                                {
                                    var accessPortalActivityEvent = new AccessPortalActivityEvent()
                                    {
                                        AccessPortalActivityEventUid = activityLogMessage.ActivityEventUid,//GuidUtilities.GenerateComb(),
                                        GalaxyActivityEventTypeUid = activityTypeUid,
                                        AccessPortalUid = activityLogMessage.DeviceUid,
                                        CpuUid = activityLogMessage.CpuUid,
                                        CpuNumber = activityLogMessage.CpuId,
                                        ActivityDateTime = galaxyRawActivityEvent.EventDateTime,
                                        BufferIndex = galaxyRawActivityEvent.BufferIndex,
                                        InsertDate = DateTimeOffset.Now,
                                        EventType = galaxyRawActivityEvent.EventType,
                                        IsAlarmEvent = activityLogMessage.IsAlarmEvent,
                                        AlarmPriority = activityLogMessage.AlarmPriority,
                                        NoteUid = activityLogMessage.InstructionsNoteUid,
                                        BinaryResourceUid = activityLogMessage.AudioBinaryResourceUid,
                                    };

                                    var mgr = new AccessPortalActivityEventInsertRepository();
                                    mgr.Insert(accessPortalActivityEvent);
                                }
                                catch (Exception e)
                                {
                                    this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow AccessPortalActivityEventInsertRepository error: {e}");
                                }
                                break;

                            case Common.Enums.PanelActivityEventCategory.Panel:
                            case Common.Enums.PanelActivityEventCategory.PanelBoard:
                            case Common.Enums.PanelActivityEventCategory.InputOutputGroup:
                            case Common.Enums.PanelActivityEventCategory.DsiChannel:
                                try
                                {
                                    var galaxyPanelActivityEvent = new GalaxyPanelActivityEvent()
                                    {
                                        GalaxyPanelActivityEventUid = activityLogMessage.ActivityEventUid,//GuidUtilities.GenerateComb(),
                                        GalaxyActivityEventTypeUid = activityTypeUid,
                                        GalaxyPanelUid = activityLogMessage.DeviceUid,
                                        CpuUid = activityLogMessage.CpuUid,
                                        CpuNumber = activityLogMessage.CpuId,
                                        ActivityDateTime = galaxyRawActivityEvent.EventDateTime,
                                        BufferIndex = galaxyRawActivityEvent.BufferIndex,
                                        BoardNumber = activityLogMessage.BoardNumber,
                                        InputOutputGroupNumber = activityLogMessage.InputOutputGroupNumber,
                                        InputOutputGroupUid = activityLogMessage.InputOutputGroupUid,
                                        GalaxyInterfaceBoardUid = activityLogMessage.GalaxyInterfaceBoardUid,
                                        GalaxyInterfaceBoardSectionUid = activityLogMessage.GalaxyInterfaceBoardSectionUid,
                                        GalaxyHardwareModuleUid = activityLogMessage.GalaxyHardwareModuleUid,
                                        GalaxyInterfaceBoardSectionNodeUid = activityLogMessage.GalaxyInterfaceBoardSectionNodeUid,
                                        InsertDate = DateTimeOffset.Now,
                                        EventType = galaxyRawActivityEvent.EventType,
                                        IsAlarmEvent = activityLogMessage.IsAlarmEvent,
                                        AlarmPriority = activityLogMessage.AlarmPriority,
                                        NoteUid = activityLogMessage.InstructionsNoteUid,
                                        BinaryResourceUid = activityLogMessage.AudioBinaryResourceUid,
                                        SectionNumber = activityLogMessage.SectionNumber,
                                        ModuleNumber = activityLogMessage.ModuleNumber,
                                        NodeNumber = activityLogMessage.NodeNumber,
                                    };

                                    var mgr = new GalaxyPanelActivityEventInsertRepository();
                                    mgr.Insert(galaxyPanelActivityEvent);
                                }
                                catch (Exception ex)
                                {
                                    var exString = ex.ToString();
                                    if(!exString.Contains("duplicate"))
                                    {
                                        int x = 1;
                                    }
                                    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                                }
                                break;

                            case Common.Enums.PanelActivityEventCategory.Input:
                                try
                                {
                                    var inputDeviceActivityEvent = new InputDeviceActivityEvent()
                                    {
                                        InputDeviceActivityEventUid = activityLogMessage.ActivityEventUid,//GuidUtilities.GenerateComb(),
                                        GalaxyActivityEventTypeUid = activityTypeUid,
                                        InputDeviceUid = activityLogMessage.DeviceUid,
                                        CpuUid = activityLogMessage.CpuUid,
                                        CpuNumber = activityLogMessage.CpuId,
                                        ActivityDateTime = galaxyRawActivityEvent.EventDateTime,
                                        BufferIndex = galaxyRawActivityEvent.BufferIndex,
                                        InsertDate = DateTimeOffset.Now,
                                        EventType = galaxyRawActivityEvent.EventType,
                                        IsAlarmEvent = activityLogMessage.IsAlarmEvent,
                                        AlarmPriority = activityLogMessage.AlarmPriority,
                                        NoteUid = activityLogMessage.InstructionsNoteUid,
                                        BinaryResourceUid = activityLogMessage.AudioBinaryResourceUid,
                                    };

                                    var mgr = new InputDeviceActivityEventInsertRepository();
                                    mgr.Insert(inputDeviceActivityEvent);
                                }
                                catch (Exception e)
                                {
                                    this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow InputDeviceActivityEventInsertRepository error: {e}");
                                }
                                break;
                            case Common.Enums.PanelActivityEventCategory.Output:
                                try
                                {
                                    var outputDeviceActivityEvent = new OutputDeviceActivityEvent()
                                    {
                                        OutputDeviceActivityEventUid = activityLogMessage.ActivityEventUid,//GuidUtilities.GenerateComb(),
                                        GalaxyActivityEventTypeUid = activityTypeUid,
                                        OutputDeviceUid = activityLogMessage.DeviceUid,
                                        CpuUid = activityLogMessage.CpuUid,
                                        CpuNumber = activityLogMessage.CpuId,
                                        ActivityDateTime = galaxyRawActivityEvent.EventDateTime,
                                        BufferIndex = galaxyRawActivityEvent.BufferIndex,
                                        InsertDate = DateTimeOffset.Now,
                                        EventType = galaxyRawActivityEvent.EventType,
                                    };

                                    var mgr = new OutputDeviceActivityEventInsertRepository();
                                    mgr.Insert(outputDeviceActivityEvent);
                                }
                                catch (Exception e)
                                {
                                    this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow OutputDeviceActivityEventInsertRepository error: {e}");
                                }
                                break;
                            case Common.Enums.PanelActivityEventCategory.Unknown:
                                break;
                            case Common.Enums.PanelActivityEventCategory.GalaxyElevator:
                                break;
                            case Common.Enums.PanelActivityEventCategory.OtisElevator:
                                break;
                            case Common.Enums.PanelActivityEventCategory.CardTour:
                                break;
                            case Common.Enums.PanelActivityEventCategory.Person:
                                break;
                            case Common.Enums.PanelActivityEventCategory.PersonInputOutputGroup:
                                break;
                            case Common.Enums.PanelActivityEventCategory.DoorGroup:
                                break;
                        }

                    }
                }
                if (t == typeof(PanelCredentialActivityLogMessage))
                {
                    if (Data is PanelCredentialActivityLogMessage activityLogMessage)
                    {
                        if( activityLogMessage.DateTimeOffset < DateTimeOffset.Now.MinSqlDateTime())
                            activityLogMessage.DateTimeOffset = DateTimeOffset.Now.MinSqlDateTime();
                        var galaxyRawActivityEvent = new GalaxyRawActivityEvent
                        {
                            CpuUid = activityLogMessage.CpuUid,
                            InsertDate = DateTimeOffset.Now,
                            ClusterGroupId = activityLogMessage.ClusterGroupId,
                            ClusterNumber = activityLogMessage.ClusterNumber,
                            PanelNumber = activityLogMessage.PanelNumber,
                            CpuNumber = activityLogMessage.CpuId,
                            EventDateTime = activityLogMessage.DateTimeOffset,
                            EventType = activityLogMessage.PanelActivityType.ToString(),
                            BufferIndex = (int)activityLogMessage.BufferIndex,
                            BoardNumber = (short)activityLogMessage.BoardNumber,
                            SectionNumber = (short)activityLogMessage.SectionNumber,
                            ModuleNumber = (short)activityLogMessage.ModuleNumber,
                            NodeNumber = (short)activityLogMessage.NodeNumber,
                            RawData = activityLogMessage.RawData,
                            InputOutputGroupNumber = activityLogMessage.InputOutputGroupNumber,
                            CredentialBytes = activityLogMessage.CredentialBytes,
                            Pin = (int)activityLogMessage.Pin,
                            BitCount = (short)activityLogMessage.BitCount
                        };

                        try
                        {
                            var mgr = new GalaxyRawActivityEventInsertRepository();
                            mgr.Insert(galaxyRawActivityEvent);
                        }
                        catch (Exception e)
                        {
                            this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow GalaxyRawActivityEventInsertRepository PanelActivityLogMessageCredential error: {e}");
                        }

                        var field = typeof(GalaxySMS.Common.Constants.PanelActivityLogMessageCodeIds).GetField(activityLogMessage.PanelActivityType.ToString(), BindingFlags.Public | BindingFlags.Static);

                        var activityTypeUid = (Guid)field.GetValue(null);

                        try
                        {
                            var accessPortalActivityEvent = new AccessPortalActivityEvent()
                            {
                                AccessPortalActivityEventUid = activityLogMessage.ActivityEventUid,//GuidUtilities.GenerateComb(),
                                GalaxyActivityEventTypeUid = activityTypeUid,
                                AccessPortalUid = activityLogMessage.DeviceUid,
                                CpuUid = activityLogMessage.CpuUid,
                                CpuNumber = activityLogMessage.CpuId,
                                ActivityDateTime = galaxyRawActivityEvent.EventDateTime,
                                BufferIndex = galaxyRawActivityEvent.BufferIndex,
                                InsertDate = DateTimeOffset.Now,
                                EventType = galaxyRawActivityEvent.EventType,
                                PersonUid = activityLogMessage.PersonUid,
                                CredentialUid = activityLogMessage.CredentialUid,
                                CredentialBytes = activityLogMessage.CredentialBytes,
                                IsAlarmEvent = activityLogMessage.IsAlarmEvent,
                                AlarmPriority = activityLogMessage.AlarmPriority,
                                NoteUid = activityLogMessage.InstructionsNoteUid,
                                BinaryResourceUid = activityLogMessage.AudioBinaryResourceUid,
                                PersonCredentialUid = activityLogMessage.PersonCredentialUid,
                                PersonExpirationModeUid = activityLogMessage.PersonExpirationModeUid,
                                UsageCount = activityLogMessage.UsageCount,
                                IsActive = activityLogMessage.IsActive,
                            };

                            var mgr1 = new AccessPortalActivityEventInsertRepository();
                            mgr1.Insert(accessPortalActivityEvent);
                        }
                        catch (Exception e)
                        {
                            this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow PanelActivityLogMessage error: {e}");
                        }

                    }
                }
                else if (t == typeof(PanelBoardInformationCollection))
                {
                    if (Data is PanelBoardInformationCollection pbic)
                    {
                        //SignalRClient.NotifyPanelBoardInformationCollectionAsync(pbic);
                    }
                }
                else if (t == typeof(PanelLoadDataReply))
                {
                    if (Data is PanelLoadDataReply o)
                    {
                        //SignalRClient.NotifyPanelLoadDataReplyAsync(o);
                        //this.Log().InfoFormat($"{DateTimeOffset.Now.TimeOfDay} PanelLoadDataReply: {o.DataType} => {o.AckNack}");
                        switch (o.DataType)
                        {
                            case Common.Enums.PanelLoadDataType.CommandLoadExtendedCards:
                            case Common.Enums.PanelLoadDataType.CommandLoadStandardCards:
                                try
                                {
                                    var mgr = new CredentialToLoadToCpuRepository();
                                    foreach (var c in o.CredentialsLoaded)
                                    {
                                        if (c.CardData.Length != GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Extended256Bits)
                                            c.CardData = GCS.Core.Common.Utils.HexEncoding.PadByteArray(c.CardData, GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Extended256Bits, false);
                                        //this.Log().InfoFormat($"calling SaveLastCredentialLoadedDate({o.CpuUid}, {c.CardData}, {o.CreatedDateTime}");
                                        mgr.SaveLastCredentialLoadedDate(o.CpuUid, c.CardData, o.CreatedDateTime);
                                    }
                                }
                                catch (Exception e)
                                {
                                    this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow CredentialToLoadToCpuRepository SaveLastCredentialLoadedDate error: {e}");
                                }
                                break;
                            case Common.Enums.PanelLoadDataType.CommandDeleteCard:
                                try
                                {
                                    var mgr = new CredentialToDeleteFromCpuRepository();
                                    foreach (var c in o.CredentialsLoaded)
                                    {
                                        if (c.CardData.Length != GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Extended256Bits)
                                            c.CardData = GCS.Core.Common.Utils.HexEncoding.PadByteArray(c.CardData, GalaxySMS.Common.Constants.CredentialDataByteArrayLength.Extended256Bits, false);
                                        mgr.SaveDeletedFromCpuDate(new CredentialToDeleteFromCpu() { CpuUid = o.CpuUid, CardBinaryData = c.CardData, DeletedFromCpuDate = o.CreatedDateTime });
                                    }
                                }
                                catch (Exception e)
                                {
                                    this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow CredentialToLoadToCpuRepository SaveLastCredentialLoadedDate error: {e}");
                                }
                                break;

                            case Common.Enums.PanelLoadDataType.CpuHeartbeat:
                                break;
                            case Common.Enums.PanelLoadDataType.RecalibrateIoCommand1:
                                break;
                            case Common.Enums.PanelLoadDataType.RecalibrateIoCommand2:
                                break;
                            case Common.Enums.PanelLoadDataType.NotificationCardAreaChange:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandResetCpu:
                                break;
                            case Common.Enums.PanelLoadDataType.RecalibrateIoCommand7:
                                break;
                            case Common.Enums.PanelLoadDataType.RecalibrateIoCommand8:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandClearAutoTimer:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadBoardSectionNodeData:
                                switch (o.BoardSectionType)
                                {
                                    case Common.Enums.PanelInterfaceBoardSectionType.None:
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.VeridtReader:
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.DrmSection:
                                    case Common.Enums.PanelInterfaceBoardSectionType.DsiRs485DoorModule:
                                        try
                                        {
                                            var mgr = new AccessPortalRepository();
                                            mgr.UpdateGalaxyAccessPortalLastLoadedDate(o.CpuUid, o.ItemGuid);
                                        }
                                        catch (Exception e)
                                        {
                                            this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow AccessGroupRepository UpdateAccessPortalLastLoadedDate error: {e}");
                                        }
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Outputs:
                                        try
                                        {
                                            var mgr = new OutputDeviceRepository();
                                            mgr.UpdateGalaxyOutputDeviceLastLoadedDate(o.CpuUid, o.ItemGuid);
                                        }
                                        catch (Exception e)
                                        {
                                            this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow InputDeviceRepository UpdateAccessPortalLastLoadedDate error: {e}");
                                        }
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.Dio8X4Inputs:
                                        try
                                        {
                                            var mgr = new InputDeviceRepository();
                                            mgr.UpdateGalaxyInputDeviceLastLoadedDate(o.CpuUid, o.ItemGuid);
                                        }
                                        catch (Exception e)
                                        {
                                            this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow InputDeviceRepository UpdateAccessPortalLastLoadedDate error: {e}");
                                        }
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.DsiElevatorControlRelays:
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.DsiCypressClockDisplay:
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.DsiOutputControlRelays:
                                        try
                                        {
                                            var mgr = new OutputDeviceRepository();
                                            mgr.UpdateGalaxyOutputDeviceLastLoadedDate(o.CpuUid, o.ItemGuid);
                                        }
                                        catch (Exception e)
                                        {
                                            this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow InputDeviceRepository UpdateAccessPortalLastLoadedDate error: {e}");
                                        }
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.DsiIngersolRandPimWiegand:
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.DsiIngersolRandPimClockData:
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.DsiLcd4x20Display:
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.DsiAssaAbloyAperio:
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.DsiSalto:
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.DsiRs485InputModule:
                                        try
                                        {
                                            var mgr = new InputDeviceRepository();
                                            mgr.UpdateGalaxyInputDeviceLastLoadedDate(o.CpuUid, o.ItemGuid);
                                        }
                                        catch (Exception e)
                                        {
                                            this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow InputDeviceRepository UpdateAccessPortalLastLoadedDate error: {e}");
                                        }
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.OtisElevatorInterfaceCpu:
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.KoneElevatorInterfaceCpu:
                                        break;
                                    case Common.Enums.PanelInterfaceBoardSectionType.VeridtCpu:
                                        break;
                                }
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadAccessGroupSchedulesForDoor:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadTimeSchedule15MinuteFormat:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadAccessGroupSchedule:
                                try
                                {
                                    var mgr = new AccessGroupRepository();
                                    mgr.UpdateAccessPortalLastLoadedDate(o.CpuUid, o.ItemNumber, o.BoardNumber, o.SectionNumber, o.NodeNumber);
                                }
                                catch (Exception e)
                                {
                                    this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow AccessGroupRepository UpdateAccessPortalLastLoadedDate error: {e}");
                                }
                                break;
                            case Common.Enums.PanelLoadDataType.CommandClearTimeSchedules:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandClearAllUsers:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandClearAccessGroupRange:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadAccessGroupsCrisisGroups:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandSetDateTime:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandPing:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoad15MinuteScheduleHolidayTable:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandPanelInquire:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandRequestTotalCardCount:
                                break;
                            case Common.Enums.PanelLoadDataType.NotificationInternalPanelRecalibrate:
                                break;
                            case Common.Enums.PanelLoadDataType.PanelRecalibrateComplete:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadPersonalDoors:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoggingSetOnOff:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoggingResetPointers:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoggingAcknowledgeToMessageIndex:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandSignOnChallenge:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandSignOnChallengeResponse:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandRequestConnectedBoardInformation:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadTimeAdjustment:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandSetCardLoadAcknowledgePanel:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandRequestLoggingInformation:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadTamperAcFailureLowBattery:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadABAOptions:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadLockoutOptions:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandForgivePassbackCard:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandForgivePassbackEverybody:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandRecalibrate:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandCardEnable:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandCardDisable:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandSetUserAuthority:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadLedOptions:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadCrisisModeIOGroup:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandResetCrisisMode:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandSetCrisisMode:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadWiegandStartStopSettings:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoad15MinuteScheduleHolidays:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadCardaxStartStopSettings:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandGetIOGroupCounters:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadIOGroupArmSchedule:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandInitializeBoardSection:
                                break;
                            case Common.Enums.PanelLoadDataType.LoadAccessGroupCrisisGroup:
                                try
                                {
                                    var mgr = new AccessGroupRepository();
                                    mgr.UpdateLastLoadedDate(o.CpuUid, o.ItemNumber);
                                }
                                catch (Exception e)
                                {
                                    this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow AccessGroupRepository UpdateLastLoadedDate error: {e}");
                                }
                                break;
                            case Common.Enums.PanelLoadDataType.CommandSetServerConsultationOptions:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadMinuteScheduleDayTypes:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadMinuteScheduleTimePeriod:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandLoadMinuteScheduleTimePeriodsForDayType:
                                break;
                            case Common.Enums.PanelLoadDataType.CommandCardRemoteAccessRuleOverrideReply:
                                break;
                        }
                    }
                }
                else if (t == typeof(PanelInqueryReply))
                {
                    if (Data is PanelInqueryReply o)
                    {
                        // If the CpuUid is not Guid.Empty, then the CPU is already defined in the database, then it is safe to update the SN & IPAddress
                        if (o.CpuUid != Guid.Empty)
                        {
                            try
                            {
                                if( string.IsNullOrEmpty(o.IpAddress))
                                    o.IpAddress = ":";
                                var ipParts = o.IpAddress.Split(':');
                                var mgr = new GalaxyCpuRepository();
                                mgr.UpdateCpuInformation(new GalaxyCpuSaveInformationData()
                                {
                                    CpuUid = o.CpuUid,
                                    SerialNumber = o.SerialNumber,
                                    IpAddress = ipParts[0],
                                    Model = (int)o.ModelNumber
                                });
                            }
                            catch (Exception e)
                            {
                                this.Log().ErrorFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow AccessGroupRepository UpdateLastLoadedDate error: {e}");
                            }

                        }
                        //this.Log().InfoFormat($"{DateTimeOffset.Now.TimeOfDay} PanelInqueryReply: IPAddress:{o.IpAddress}, SN:{o.SerialNumber}");
                    }
                }
            }
            this.Log().InfoFormat($"{DateTimeOffset.Now.TimeOfDay} PanelMessageRecorderWorkflow processing message: {msg}");
        }

        #endregion
    }
}
