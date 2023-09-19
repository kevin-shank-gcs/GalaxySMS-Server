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
    public class PersonSummary
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid PersonUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PersonId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FirstName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string MiddleName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LastName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string NickName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LegalName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FullName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PreferredName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Company { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool Trace { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool VeryImportantPerson { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool HasPhysicalDisability { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DepartmentName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ActiveStatus { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string RecordType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> ActivationDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> ExpirationDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InsertName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset InsertDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UpdateName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<int> SysGalEmployeeId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public PersonPhoto Photo { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public PhotoLinks PhotoUrls { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SmallPhotoURL { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsPersonActive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public PersonLastUsageData LastUsageData { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public PersonActiveStatusSummaryCodes ActiveStatusCode { get; set; }
    }
}
