using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
	public class SearchCriteria
    {
        public SearchCriteria()
        {
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public TextSearchType TextSearchType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SearchPropertyName { get; set; }
    }
}
