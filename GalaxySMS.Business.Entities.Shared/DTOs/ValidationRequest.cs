using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
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
    public class ValidationRequestBase
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public ValidationRequestType ValidationRequestType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PropertyName { get; set; }


        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ValidationValueSource V1Source { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ValidationValueSource V2Source { get; set; }

    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public class GuidValidationRequestItem : ValidationRequestBase
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid ClusterUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid TimeScheduleUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool PreventSystemEntityMatches { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
    public class GuidValidationRequest
    {
        public GuidValidationRequest()
        {
            Items = new HashSet<GuidValidationRequestItem>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GuidValidationRequestItem> Items { get; set; }

    }


}
