using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{
	
	public class PanelInqueryReplyResp : PanelMessageBaseResp
	{
		public PanelInqueryReplyResp()
		{
			Version = new FirmwareVersionResp();
		}

        public PanelInqueryReplyResp(PanelMessageBaseResp b) : base(b)
        {
            Version = new FirmwareVersionResp();
        }


		public PanelInqueryReplyResp(PanelInqueryReplyResp p) : base (p)
		{
			Version = new FirmwareVersionResp();
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
        public string SerialNumber { get; set; }
        public CpuModel ModelNumber { get; set; }
        public FirmwareVersionResp Version { get; set; }
        public CpuResetType LastRestartColdOrWarm { get; set; }
        public CrisisModeState CrisisModeActive { get; set; }
        public UInt32 UnacknowledgedActivityLogCount { get; set; }
        public ActivityLoggingEnabledState ActivityLoggingEnabled { get; set; }
        public CredentialDataSize CardCodeFormat { get; set; }
        public Byte OptionSwitches { get; set; }
        public Byte ZLinkConnected { get; set; }

	}
    
    public class PanelInqueryReplyBasicResp
    {
        public PanelInqueryReplyBasicResp()
        {
            Version = new FirmwareVersionResp();
        }

        public PanelInqueryReplyBasicResp(PanelInqueryReplyResp p)
        {
            Version = new FirmwareVersionResp();
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

        public PanelInqueryReplyBasicResp(PanelInqueryReplyBasicResp p)
        {
            Version = new FirmwareVersionResp();
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
        public string SerialNumber { get; set; }
        public CpuModel ModelNumber { get; set; }
        public FirmwareVersionResp Version { get; set; }
        public CpuResetType LastRestartColdOrWarm { get; set; }
        public string LastRestartColdOrWarmFriendly => LastRestartColdOrWarm.ToString();
        public CrisisModeState CrisisModeActive { get; set; }
        public string CrisisModeActiveFriendly => CrisisModeActive.ToString();
        public UInt32 UnacknowledgedActivityLogCount { get; set; }
        public ActivityLoggingEnabledState ActivityLoggingEnabled { get; set; }
        public string ActivityLoggingEnabledFriendly => ActivityLoggingEnabled.ToString();
        public CredentialDataSize CardCodeFormat { get; set; }
        public string CardCodeFormatFriendly => CardCodeFormat.ToString();

        // Only applies to 5xx panels, which are not supported in SMS
        //public Byte OptionSwitches { get; set; }
        //public Byte ZLinkConnected { get; set; }

    }

}
