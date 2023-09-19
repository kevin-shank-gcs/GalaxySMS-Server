////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\Credential_ActivityEventData.cs
//
// summary:	Implements the credential activity event data class
////////////////////////////////////////////////////////////////////////////////////////////////////


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
    public class Credential_ActivityEventData : ObjectBase
    {
        #region Public Properties

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CredentialUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonCredentialUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ActivityEventText { get; set; }

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
        public string LegalName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string NickName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CardNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] CardBinaryData { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool PersonTrace { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Company { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityName { get; set; }

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
        public Guid PersonRecordTypeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string RecordType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CredentialDescription { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool CredentialTraceEnabled { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PersonExpirationModeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short UsageCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }

        #endregion
    }
}
