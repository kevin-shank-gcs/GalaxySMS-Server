using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif

    public class PanelLoadDataReply : PanelMessageBase
    {
        public PanelLoadDataReply() : base()
        {
            CredentialsLoaded = new List<CredentialLoadedData>();
        }

        public PanelLoadDataReply(PanelMessageBase b)
            : base(b)
        {
            CredentialsLoaded = new List<CredentialLoadedData>();
        }

        public PanelLoadDataReply(PanelLoadDataReply o)
            : base(o)
        {
            if (o != null)
            {
                DataType = o.DataType;
                Description = o.Description;
                ItemNumber = o.ItemNumber;
                ItemString = o.ItemString;
                ItemGuid = o.ItemGuid;
                BoardSectionType = o.BoardSectionType;
                CredentialReaderDataFormat = o.CredentialReaderDataFormat;
                CredentialsLoaded = o.CredentialsLoaded;
            }

        }

        public PanelLoadDataReply(PanelLoadDataReply o, bool copyCredentialsLoaded)
            : base(o)
        {
            if (o != null)
            {
                DataType = o.DataType;
                Description = o.Description;
                ItemNumber = o.ItemNumber;
                ItemString = o.ItemString;
                ItemGuid = o.ItemGuid;
                BoardSectionType = o.BoardSectionType;
                CredentialReaderDataFormat = o.CredentialReaderDataFormat;
                if (copyCredentialsLoaded)
                    CredentialsLoaded = o.CredentialsLoaded.ToList();
                else
                {
                    CredentialsLoaded = new List<CredentialLoadedData>();
                }
            }

        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelLoadDataType DataType { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        public string DataTypeCode => DataType.ToString();

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LoadDataCategory
        {
            get
            {
                //return string.Empty;
                switch (DataType)
                {
                    case PanelLoadDataType.CommandLoadBoardSectionNodeData:
                    case PanelLoadDataType.CommandInitializeBoardSection:
                        return nameof(LoadDataToPanelSettings.AccessPortalsInputsOutputs);

                    case PanelLoadDataType.CommandLoadIOGroupArmSchedule:
                        return nameof(LoadDataToPanelSettings.InputOutputGroups);

                    case PanelLoadDataType.CommandLoadExtendedCards:
                    case PanelLoadDataType.CommandLoadStandardCards:
                    case PanelLoadDataType.CommandDeleteCard:
                    case PanelLoadDataType.CommandClearAllUsers:
                    case PanelLoadDataType.CommandLoadPersonalDoors:
                        return nameof(LoadDataToPanelSettings.AllCardData);

                    case PanelLoadDataType.CommandLoadAccessGroupSchedule:
                    case PanelLoadDataType.CommandLoadAccessGroupSchedulesForDoor:
                    case PanelLoadDataType.CommandClearAccessGroupRange:
                    case PanelLoadDataType.CommandLoadAccessGroupsCrisisGroups:
                    case PanelLoadDataType.LoadAccessGroupCrisisGroup:
                        return nameof(LoadDataToPanelSettings.AccessRules);

                    case PanelLoadDataType.CommandClearTimeSchedules:
                    case PanelLoadDataType.CommandLoadTimeSchedule15MinuteFormat:
                    case PanelLoadDataType.CommandLoad15MinuteScheduleHolidayTable:
                    case PanelLoadDataType.CommandLoad15MinuteScheduleHolidays:
                    case PanelLoadDataType.CommandLoadMinuteScheduleDayTypes:
                    case PanelLoadDataType.CommandLoadMinuteScheduleTimePeriod:
                    case PanelLoadDataType.CommandLoadMinuteScheduleTimePeriodsForDayType:
                        return nameof(LoadDataToPanelSettings.TimeSchedules);

                    case PanelLoadDataType.CommandLoadTamperAcFailureLowBattery:
                        return nameof(LoadDataToPanelSettings.PanelAlarms);

                    case PanelLoadDataType.CommandLoadABAOptions:
                    case PanelLoadDataType.CommandLoadLockoutOptions:
                    case PanelLoadDataType.CommandLoadLedOptions:
                    case PanelLoadDataType.CommandLoadCrisisModeIOGroup:
                    case PanelLoadDataType.CommandLoadWiegandStartStopSettings:
                    case PanelLoadDataType.CommandLoadCardaxStartStopSettings:
                    case PanelLoadDataType.CommandSetServerConsultationOptions:
                    case PanelLoadDataType.CommandCardRemoteAccessRuleOverrideReply:
                        return nameof(LoadDataToPanelSettings.ClusterSharedSettings);

                    case PanelLoadDataType.CommandSetDateTime:
                    case PanelLoadDataType.CommandPing:
                    case PanelLoadDataType.CommandPanelInquire:
                    case PanelLoadDataType.CommandRequestTotalCardCount:
                    case PanelLoadDataType.NotificationInternalPanelRecalibrate:
                    case PanelLoadDataType.PanelRecalibrateComplete:
                    case PanelLoadDataType.CommandLoggingSetOnOff:
                    case PanelLoadDataType.CommandLoggingResetPointers:
                    case PanelLoadDataType.CommandLoggingAcknowledgeToMessageIndex:
                    case PanelLoadDataType.CommandSignOnChallenge:
                    case PanelLoadDataType.CommandSignOnChallengeResponse:
                    case PanelLoadDataType.CommandRequestConnectedBoardInformation:
                    case PanelLoadDataType.CommandLoadTimeAdjustment:
                    case PanelLoadDataType.CommandSetCardLoadAcknowledgePanel:
                    case PanelLoadDataType.CommandRequestLoggingInformation:
                    case PanelLoadDataType.CommandForgivePassbackCard:
                    case PanelLoadDataType.CommandForgivePassbackEverybody:
                    case PanelLoadDataType.CommandRecalibrate:
                    case PanelLoadDataType.CommandCardEnable:
                    case PanelLoadDataType.CommandCardDisable:
                    case PanelLoadDataType.CommandSetUserAuthority:
                    case PanelLoadDataType.CommandResetCrisisMode:
                    case PanelLoadDataType.CommandSetCrisisMode:
                    case PanelLoadDataType.CommandGetIOGroupCounters:
                    default:
                        break;
                }

                return string.Empty;

            }
            set {  }
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ItemNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ItemString { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ItemGuid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Description { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelInterfaceBoardSectionType BoardSectionType { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxySMS.Common.Enums.CredentialReaderDataFormat CredentialReaderDataFormat { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public List<CredentialLoadedData> CredentialsLoaded { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif

    public class PanelLoadDataReplySignalR : PanelMessageBaseSimple
    {
        public PanelLoadDataReplySignalR() : base()
        {
            CredentialsLoaded = new List<CredentialLoadedData>();
        }

        public PanelLoadDataReplySignalR(PanelMessageBase b)
            : base(b)
        {
            CredentialsLoaded = new List<CredentialLoadedData>();
        }

        public PanelLoadDataReplySignalR(PanelLoadDataReply o)
            : base(o)
        {
            if (o != null)
            {
                DataType = o.DataType;
                Description = o.Description;
                ItemNumber = o.ItemNumber;
                ItemString = o.ItemString;
                ItemGuid = o.ItemGuid;
                BoardSectionType = o.BoardSectionType;
                CredentialReaderDataFormat = o.CredentialReaderDataFormat;
                CredentialsLoaded = o.CredentialsLoaded;
            }

        }

        public PanelLoadDataReplySignalR(PanelLoadDataReply o, bool copyCredentialsLoaded)
            : base(o)
        {
            if (o != null)
            {
                DataType = o.DataType;
                Description = o.Description;
                ItemNumber = o.ItemNumber;
                ItemString = o.ItemString;
                ItemGuid = o.ItemGuid;
                BoardSectionType = o.BoardSectionType;
                CredentialReaderDataFormat = o.CredentialReaderDataFormat;
                if (copyCredentialsLoaded)
                    CredentialsLoaded = o.CredentialsLoaded.ToList();
                else
                {
                    CredentialsLoaded = new List<CredentialLoadedData>();
                }
            }

        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelLoadDataType DataType { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        public string DataTypeCode => DataType.ToString();

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LoadDataCategory { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int ItemNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ItemString { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ItemGuid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Description { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelInterfaceBoardSectionType BoardSectionType { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxySMS.Common.Enums.CredentialReaderDataFormat CredentialReaderDataFormat { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public List<CredentialLoadedData> CredentialsLoaded { get; set; }
    }

}
