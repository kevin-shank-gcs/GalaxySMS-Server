using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
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


		public PanelInqueryReply(PanelInqueryReply p) : base (p)
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
	
		[DataMember]
		public string SerialNumber { get; set; }

		[DataMember]
		public CpuModel ModelNumber { get; set; }

		[DataMember]
		public FirmwareVersion Version { get; set; }

		[DataMember]
		public CpuResetType LastRestartColdOrWarm { get; set; }

		[DataMember]
		public CrisisModeState CrisisModeActive { get; set; }

		[DataMember]
		public UInt32 UnacknowledgedActivityLogCount { get; set; }

		[DataMember]
		public ActivityLoggingEnabledState ActivityLoggingEnabled { get; set; }

        [DataMember]
        public CredentialDataSize CardCodeFormat { get; set; }

		[DataMember]
		public Byte OptionSwitches { get; set; }
		
		[DataMember]
		public Byte ZLinkConnected { get; set; }

	}
}
