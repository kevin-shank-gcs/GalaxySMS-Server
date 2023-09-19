using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public class ReaderLedSettings : EntityBase
	{
		public ReaderLedSettings()
		{
			NoLeds = LedMode.AllOff;
			GreenSolid = LedMode.GreenOnlySolid;
			RedSolid = LedMode.RedOnlySolid;
			BothSolid = LedMode.BothSolid;
			GreenBlink6TimesPerSecond = LedMode.GreenBlink6TimesPerSecond;
			GreenBlink12TimesPerSecond = LedMode.GreenBlink12TimesPerSecond;
			BothBlink12TimesPerSecond = LedMode.BothBlink12TimesPerSecond;
			RedBlink2TimesPerSecond = LedMode.RedBlink2TimesPerSecond;
		}

		[DataMember]
		public LedMode NoLeds { get; set; }

		[DataMember]
		public LedMode GreenSolid { get; set; }

		[DataMember]
		public LedMode RedSolid { get; set; }

		[DataMember]
		public LedMode BothSolid { get; set; }

		[DataMember]
		public LedMode GreenBlink6TimesPerSecond { get; set; }

		[DataMember]
		public LedMode GreenBlink12TimesPerSecond { get; set; }

		[DataMember]
		public LedMode BothBlink12TimesPerSecond { get; set; }

		[DataMember]
		public LedMode RedBlink2TimesPerSecond { get; set; }
	}
}
