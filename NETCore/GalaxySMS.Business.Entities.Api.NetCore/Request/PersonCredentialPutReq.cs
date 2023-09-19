//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class PersonCredentialPutReq // : PutRequestBase
    {
        public System.Guid PersonCredentialUid { get; set; }
        public System.Guid CredentialUid { get; set; }
        //public System.Guid PersonUid { get; set; }
        public System.Guid PersonCredentialRoleUid { get; set; }
        public System.Guid PersonActivationModeUid { get; set; }
        public System.Guid PersonExpirationModeUid { get; set; }
        public System.Guid BadgeTemplateUid { get; set; }
        public System.Guid DossierBadgeTemplateUid { get; set; }
        public System.Guid AccessPortalNoServerReplyBehaviorUid { get; set; }
        public System.Guid AccessPortalDeferToServerBehaviorUid { get; set; }
        
//        [Required]
        [StringLength(65)]
        public string CredentialDescription { get; set; }
        public Nullable<System.DateTimeOffset> ActivationDateTime { get; set; }
        public Nullable<System.DateTimeOffset> ExpirationDateTime { get; set; }
        public short UsageCount { get; set; }
        public bool TraceEnabled { get; set; }
        public bool DuressEnabled { get; set; }
        public bool ReverseBits { get; set; }
        public bool IsActive { get; set; }
        public Nullable<short> BiometricEnrollmentStatus { get; set; }
        public Nullable<int> BadgePrintLimit { get; set; }
        public Nullable<int> BadgePrintCount { get; set; }
        public Nullable<System.DateTimeOffset> BadgeLastPrinted { get; set; }
        public Nullable<int> DossierPrintLimit { get; set; }
        public Nullable<int> DossierPrintCount { get; set; }
        public Nullable<System.DateTimeOffset> DossierLastPrinted { get; set; }
        public Nullable<short> SysGalCardId { get; set; }
        //public string InsertName { get; set; }
        //public System.DateTimeOffset InsertDate { get; set; }
        //public string UpdateName { get; set; }
        //public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        //public Nullable<short> ConcurrencyValue { get; set; }
        public ICollection<PersonClusterPermissionPutReq> PersonClusterPermissions { get; set; }
        public ICollection<PersonCredentialCommandScriptPutReq> PersonCredentialCommandScripts { get; set; }

        [Required]
        public CredentialPutReq Credential { get; set; }


        [RequiredIfGuidNotEmpty(nameof(PersonCredentialUid))]
        public Nullable<short> ConcurrencyValue { get; set; }


    }
}
