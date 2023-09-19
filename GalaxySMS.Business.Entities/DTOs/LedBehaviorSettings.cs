using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public partial class LedBehaviorSettings : ObjectBase
    {
		public LedBehaviorSettings()
		{
		}
		[DataMember]
		public LedMode BothOff;

	    [DataMember]
	    public LedMode GreenSolid;

	    [DataMember]
	    public LedMode RedSolid;

	    [DataMember]
	    public LedMode BothSolid;

	    [DataMember]
	    public LedMode GreenBlink;

	    [DataMember]
	    public LedMode GreenBlinkFast;

	    [DataMember]
	    public LedMode BothBlinkFast;

	    [DataMember]
	    public LedMode RedBlinkSlow;
	}
}
