using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    public class Credential_ActivityEventData : ObjectBase
    {
        #region Public Properties
        public Guid CredentialUid { get; set; }
        public Guid PersonUid { get; set; }
        public Guid PersonCredentialUid { get; set; }
        public Guid EntityId { get; set; }
        public string ActivityEventText { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public string LegalName { get; set; }
        public string NickName { get; set; }
        public string CardNumber { get; set; }
        public byte[] CardBinaryData { get; set; }
        public bool PersonTrace { get; set; }
        public string Company { get; set; }
        public string EntityName { get; set; }
        public Guid DepartmentUid { get; set; }
        public string DepartmentName { get; set; }
        public Guid PersonRecordTypeUid { get; set; }
        public string RecordType { get; set; }
        public string CredentialDescription { get; set; }
        public bool CredentialTraceEnabled { get; set; }
        #endregion
    }
}
