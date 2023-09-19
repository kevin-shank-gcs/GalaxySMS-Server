using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

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
    public partial class BackgroundJobStateChangeInfo //: ObjectBase
    {

		public BackgroundJobStateChangeInfo()
		{
		}

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset ChangeDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public BackgroundJobState State { get; set; }

        public string StateCode { get=>State.ToString(); }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Info { get; set; }
    }
}
