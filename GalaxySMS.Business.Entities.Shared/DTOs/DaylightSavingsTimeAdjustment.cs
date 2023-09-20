using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
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

    public partial class DaylightSavingsTimeAdjustment : ObjectBase
    {
		public DaylightSavingsTimeAdjustment()
		{

		}
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset WhenToChange { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset NewDateTime { get; set; }
	}

    [DataContract]
    public partial class DaylightSavingsTimeAdjustmentSettings : ObjectBase
    {
        public DaylightSavingsTimeAdjustmentSettings()
        {
            DaylightSavingsTimeAdjustments = new DaylightSavingsTimeAdjustment[2];
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DaylightSavingsTimeAdjustment[] DaylightSavingsTimeAdjustments { get; set; }
    }
}
