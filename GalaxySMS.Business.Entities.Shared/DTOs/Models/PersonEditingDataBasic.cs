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
	public class PersonEditingDataBasic : EntityBaseSimple
    {
        public PersonEditingDataBasic()
        {
            PersonActiveStatusTypes = new HashSet<PersonActiveStatusTypeBasic>();
            Genders = new HashSet<GenderBasic>();
            Departments = new HashSet<DepartmentBasic>();
            PersonRecordTypes = new HashSet<PersonRecordTypeBasicResp>();

            AccessProfiles = new HashSet<AccessProfileBasic>();
 //           Sites = new HashSet<SiteBasic>();
            BadgeTemplates = new HashSet<BadgeTemplateBasic>();
            PersonActivationModes = new HashSet<PersonActivationModeBasic>();
            PersonExpirationModes = new HashSet<PersonExpirationModeBasic>();

            CredentialFormats = new HashSet<CredentialFormatBasic>();
            PersonCredentialRoles = new HashSet<PersonCredentialRoleBasic>();
            AccessPortalDeferToServerBehaviors = new HashSet<AccessPortalDeferToServerBehaviorBasic>();
            AccessPortalNoServerReplyBehaviors = new HashSet<AccessPortalNoServerReplyBehaviorBasic>();
            AccessAndAlarmControlPermissionsEditingData = new AccessAndAlarmControlPermissionsEditingDataBasic();
            Countries = new HashSet<CountryBasic>();
            CellCarriers = new HashSet<CellCarrierBasic>();
            CommandScripts = new HashSet<CommandScriptBasic>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CountryBasic> Countries { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonActiveStatusTypeBasic> PersonActiveStatusTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<GenderBasic> Genders { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<DepartmentBasic> Departments { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonRecordTypeBasicResp> PersonRecordTypes { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<SiteBasic> Sites { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessProfileBasic> AccessProfiles { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<BadgeTemplateBasic> BadgeTemplates { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CellCarrierBasic> CellCarriers { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CommandScriptBasic> CommandScripts { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonActivationModeBasic> PersonActivationModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonExpirationModeBasic> PersonExpirationModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CredentialFormatBasic> CredentialFormats { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonCredentialRoleBasic> PersonCredentialRoles { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalNoServerReplyBehaviorBasic> AccessPortalNoServerReplyBehaviors { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalDeferToServerBehaviorBasic> AccessPortalDeferToServerBehaviors { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessAndAlarmControlPermissionsEditingDataBasic AccessAndAlarmControlPermissionsEditingData { get;set;}

    }

}
