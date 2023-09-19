using System;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel;

#if NetCoreApi
using GCS.Core.Common.ServiceModel.Api;
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
//#if NetCoreApi
//#else
//[DataContract]
//#endif
    public class SaveJobParameters<T> where T : class, new()
    {
//#if NetCoreApi
//#else
//        [DataMember]
//#endif
        public Guid JobId { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
        public SaveParameters<T> SaveParameters { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
        public ApplicationUserSessionHeader UserSessionData { get; set; }
    }

}
