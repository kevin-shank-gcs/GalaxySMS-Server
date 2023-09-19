using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
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

    public class OtisDecIpAddress : EntityBase
	{
#if NetCoreApi
#else
        [DataMember]
#endif
        public Byte Octet3 { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Byte Octet4 { get; set; }

		public override string ToString()
		{
			return string.Format("192.168.{0}.{1}", Octet3, Octet4);
		}
	}
}
