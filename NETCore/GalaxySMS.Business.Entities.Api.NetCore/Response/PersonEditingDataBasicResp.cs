using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{
	public class PersonEditingDataBasicResp 
    {
        public PersonEditingDataBasicResp()
        {
            PersonActiveStatusTypes = new HashSet<PersonActiveStatusTypeBasicResp>();
            Genders = new HashSet<GenderBasicResp>();
            Departments = new HashSet<DepartmentBasicResp>();
            PersonRecordTypes = new HashSet<PersonRecordTypeBasicResp>();

            AccessProfiles = new HashSet<AccessProfileBasicResp>();
 //           Sites = new HashSet<SiteBasic>();
            BadgeTemplates = new HashSet<BadgeTemplateBasicResp>();
            PersonActivationModes = new HashSet<PersonActivationModeBasicResp>();
            PersonExpirationModes = new HashSet<PersonExpirationModeBasicResp>();

            CredentialFormats = new HashSet<CredentialFormatBasicResp>();
            PersonCredentialRoles = new HashSet<PersonCredentialRoleBasicResp>();
            AccessPortalDeferToServerBehaviors = new HashSet<AccessPortalDeferToServerBehaviorBasicResp>();
            AccessPortalNoServerReplyBehaviors = new HashSet<AccessPortalNoServerReplyBehaviorBasicResp>();
            AccessAndAlarmControlPermissionsEditingData = new AccessAndAlarmControlPermissionsEditingDataBasicResp();
            Countries = new HashSet<CountryBasicResp>();
            CellCarriers = new HashSet<CellCarrierBasicResp>();
            CommandScripts = new HashSet<CommandScriptBasicResp>();
        }

        public ICollection<CountryBasicResp> Countries { get; set; }
        public ICollection<PersonActiveStatusTypeBasicResp> PersonActiveStatusTypes { get; set; }
        public ICollection<GenderBasicResp> Genders { get; set; }
        public ICollection<DepartmentBasicResp> Departments { get; set; }
        public ICollection<PersonRecordTypeBasicResp> PersonRecordTypes { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<SiteBasic> Sites { get; set; }
        public ICollection<AccessProfileBasicResp> AccessProfiles { get; set; }
        public ICollection<BadgeTemplateBasicResp> BadgeTemplates { get; set; }
        public ICollection<CellCarrierBasicResp> CellCarriers { get; set; }
        public ICollection<CommandScriptBasicResp> CommandScripts { get; set; }
        public ICollection<PersonActivationModeBasicResp> PersonActivationModes { get; set; }
        public ICollection<PersonExpirationModeBasicResp> PersonExpirationModes { get; set; }
        public ICollection<CredentialFormatBasicResp> CredentialFormats { get; set; }
        public ICollection<PersonCredentialRoleBasicResp> PersonCredentialRoles { get; set; }
        public ICollection<AccessPortalNoServerReplyBehaviorBasicResp> AccessPortalNoServerReplyBehaviors { get; set; }
        public ICollection<AccessPortalDeferToServerBehaviorBasicResp> AccessPortalDeferToServerBehaviors { get; set; }
        public AccessAndAlarmControlPermissionsEditingDataBasicResp AccessAndAlarmControlPermissionsEditingData { get;set;}

    }

}
