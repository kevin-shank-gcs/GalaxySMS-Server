using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public partial class DaylightSavingsTimeAdjustment : ObjectBase
    {
		public DaylightSavingsTimeAdjustment()
		{

		}
		[DataMember]
		public DateTimeOffset WhenToChange { get; set; }

		[DataMember]
		public DateTimeOffset NewDateTime { get; set; }
	}

    [DataContract]
    public partial class DaylightSavingsTimeAdjustmentSettings : ObjectBase
    {
        public DaylightSavingsTimeAdjustmentSettings()
        {
            DaylightSavingsTimeAdjustments = new DaylightSavingsTimeAdjustment[2];
        }
        [DataMember]
        public DaylightSavingsTimeAdjustment[] DaylightSavingsTimeAdjustments { get; set; }
    }
}
