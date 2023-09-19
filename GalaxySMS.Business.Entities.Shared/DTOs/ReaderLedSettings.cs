using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

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
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode NoLeds { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode GreenSolid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode RedSolid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode BothSolid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode GreenBlink6TimesPerSecond { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode GreenBlink12TimesPerSecond { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode BothBlink12TimesPerSecond { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public LedMode RedBlink2TimesPerSecond { get; set; }
	}
}
