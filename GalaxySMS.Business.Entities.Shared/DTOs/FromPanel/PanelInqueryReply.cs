using GalaxySMS.Common.Enums;
using System;
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

    public class PanelInqueryReply : PanelMessageBase
    {
        public PanelInqueryReply()
        {
            Version = new FirmwareVersion();
        }

        public PanelInqueryReply(PanelMessageBase b) : base(b)
        {
            Version = new FirmwareVersion();
        }


        public PanelInqueryReply(PanelInqueryReply p) : base(p)
        {
            Version = new FirmwareVersion();
            if (p != null)
            {
                SerialNumber = p.SerialNumber;
                ModelNumber = p.ModelNumber;
                Version.Major = p.Version.Major;
                Version.Minor = p.Version.Minor;
                Version.LetterCode = p.Version.LetterCode;

                LastRestartColdOrWarm = p.LastRestartColdOrWarm;
                CrisisModeActive = p.CrisisModeActive;
                UnacknowledgedActivityLogCount = p.UnacknowledgedActivityLogCount;
                ActivityLoggingEnabled = p.ActivityLoggingEnabled;
                CardCodeFormat = p.CardCodeFormat;
                OptionSwitches = p.OptionSwitches;
                ZLinkConnected = p.ZLinkConnected;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string SerialNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CpuModel ModelNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public FirmwareVersion Version { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CpuResetType LastRestartColdOrWarm { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CrisisModeState CrisisModeActive { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 UnacknowledgedActivityLogCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ActivityLoggingEnabledState ActivityLoggingEnabled { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialDataSize CardCodeFormat { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Byte OptionSwitches { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Byte ZLinkConnected { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class PanelInqueryReplyBasic
    {
        public PanelInqueryReplyBasic()
        {
            Version = new FirmwareVersion();
        }


        public PanelInqueryReplyBasic(PanelInqueryReply p)
        {
            Version = new FirmwareVersion();
            if (p != null)
            {
                SerialNumber = p.SerialNumber;
                ModelNumber = p.ModelNumber;
                Version.Major = p.Version.Major;
                Version.Minor = p.Version.Minor;
                Version.LetterCode = p.Version.LetterCode;

                LastRestartColdOrWarm = p.LastRestartColdOrWarm;
                CrisisModeActive = p.CrisisModeActive;
                UnacknowledgedActivityLogCount = p.UnacknowledgedActivityLogCount;
                ActivityLoggingEnabled = p.ActivityLoggingEnabled;
                CardCodeFormat = p.CardCodeFormat;
                OptionSwitches = p.OptionSwitches;
                ZLinkConnected = p.ZLinkConnected;
            }
        }

        public PanelInqueryReplyBasic(PanelInqueryReplyBasic p)
        {
            Version = new FirmwareVersion();
            if (p != null)
            {
                SerialNumber = p.SerialNumber;
                ModelNumber = p.ModelNumber;
                Version.Major = p.Version.Major;
                Version.Minor = p.Version.Minor;
                Version.LetterCode = p.Version.LetterCode;

                LastRestartColdOrWarm = p.LastRestartColdOrWarm;
                CrisisModeActive = p.CrisisModeActive;
                UnacknowledgedActivityLogCount = p.UnacknowledgedActivityLogCount;
                ActivityLoggingEnabled = p.ActivityLoggingEnabled;
                CardCodeFormat = p.CardCodeFormat;
                OptionSwitches = p.OptionSwitches;
                ZLinkConnected = p.ZLinkConnected;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string SerialNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CpuModel ModelNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public FirmwareVersion Version { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CpuResetType LastRestartColdOrWarm { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CrisisModeState CrisisModeActive { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 UnacknowledgedActivityLogCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ActivityLoggingEnabledState ActivityLoggingEnabled { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialDataSize CardCodeFormat { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Byte OptionSwitches { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Byte ZLinkConnected { get; set; }

    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class PanelInqueryReplySignalR : PanelMessageBaseSimple
    {
        public PanelInqueryReplySignalR()
        {
            Version = new FirmwareVersion();
        }

        public PanelInqueryReplySignalR(PanelMessageBase b) : base(b)
        {
            Version = new FirmwareVersion();
        }


        public PanelInqueryReplySignalR(PanelInqueryReply p) : base(p)
        {
            Version = new FirmwareVersion();
            if (p != null)
            {
                SerialNumber = p.SerialNumber;
                ModelNumber = p.ModelNumber;
                Version.Major = p.Version.Major;
                Version.Minor = p.Version.Minor;
                Version.LetterCode = p.Version.LetterCode;

                LastRestartColdOrWarm = p.LastRestartColdOrWarm;
                CrisisModeActive = p.CrisisModeActive;
                UnacknowledgedActivityLogCount = p.UnacknowledgedActivityLogCount;
                ActivityLoggingEnabled = p.ActivityLoggingEnabled;
                CardCodeFormat = p.CardCodeFormat;
                //OptionSwitches = p.OptionSwitches;
                //ZLinkConnected = p.ZLinkConnected;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string SerialNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CpuModel ModelNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public FirmwareVersion Version { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CpuResetType LastRestartColdOrWarm { get; set; }

        public string LastRestartType => LastRestartColdOrWarm.ToString();

#if NetCoreApi
#else
        [DataMember]
#endif
        public CrisisModeState CrisisModeActive { get; set; }

        public string CrisisModeState => CrisisModeActive.ToString();
#if NetCoreApi
#else
        [DataMember]
#endif
        public UInt32 UnacknowledgedActivityLogCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ActivityLoggingEnabledState ActivityLoggingEnabled { get; set; }

        public string ActivityLoggingState => ActivityLoggingEnabled.ToString();

#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialDataSize CardCodeFormat { get; set; }

        public string CredentialDataSize => CardCodeFormat.ToString();

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Byte OptionSwitches { get; set; }
//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public Byte ZLinkConnected { get; set; }

    }
}
