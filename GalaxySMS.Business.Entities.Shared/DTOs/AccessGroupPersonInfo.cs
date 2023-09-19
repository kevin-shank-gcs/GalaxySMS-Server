using GalaxySMS.Common.Enums;
using System;
using System.Runtime.Serialization;

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
    public class AccessGroupPersonInfo
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid Id { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FirstName { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string LastName { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DepartmentUid { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string DepartmentName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SmallPhotoURL { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ActiveStatusCodeString { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public PersonLastUsageData LastUsageData { get; set; }
    }
}
