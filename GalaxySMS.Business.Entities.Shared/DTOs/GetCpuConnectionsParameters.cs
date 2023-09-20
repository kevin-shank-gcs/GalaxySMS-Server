using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
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

    public class GetCpuConnectionsParameters 
	{
		public GetCpuConnectionsParameters()
		{
		}

#if NetCoreApi
#else
        [DataMember]
#endif
        public GetCpuConnectionParams GetOption {get;set;}
	}
}
