using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using GalaxySMS.Common.Enums;

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

    public class OneMinuteTimePeriodInterval : EntityBase
	{
		public OneMinuteTimePeriodInterval()
		{
            StartTime = DateTimeOffset.Now;
            Duration = new TimeSpan(0);
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset StartTime { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public TimeSpan Duration { get; set; }
	}
}
