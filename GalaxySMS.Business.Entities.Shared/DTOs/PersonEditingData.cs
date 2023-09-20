using GCS.Core.Common.Core;
using System.Collections.Generic;
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
    public class PersonEditingData : EntityBase
    {
        public PersonEditingData()
        {
            Countries = new HashSet<Country>();
            PersonActiveStatusTypes = new HashSet<PersonActiveStatusType>();
            Genders = new HashSet<Gender>();
            Departments = new HashSet<Department>();
            PersonRecordTypes = new HashSet<PersonRecordType>();

            AccessProfiles = new HashSet<AccessProfile>();
            //Sites = new HashSet<Site>();
            BadgeTemplates = new HashSet<BadgeTemplate>();
            CellCarriers = new HashSet<CellCarrier>();
            CommandScripts = new HashSet<CommandScript>();
            PersonActivationModes = new HashSet<PersonActivationMode>();
            PersonExpirationModes = new HashSet<PersonExpirationMode>();

            CredentialFormats = new HashSet<CredentialFormat>();
            PersonCredentialRoles = new HashSet<PersonCredentialRole>();
            AccessPortalNoServerReplyBehaviors = new HashSet<AccessPortalNoServerReplyBehavior>();
            AccessPortalDeferToServerBehaviors = new HashSet<AccessPortalDeferToServerBehavior>();
            AccessAndAlarmControlPermissionsEditingData = new AccessAndAlarmControlPermissionsEditingData();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Country> Countries { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonActiveStatusType> PersonActiveStatusTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Gender> Genders { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Department> Departments { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonRecordType> PersonRecordTypes { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<Site> Sites { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessProfile> AccessProfiles { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<BadgeTemplate> BadgeTemplates { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CellCarrier> CellCarriers { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CommandScript> CommandScripts { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonActivationMode> PersonActivationModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonExpirationMode> PersonExpirationModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CredentialFormat> CredentialFormats { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonCredentialRole> PersonCredentialRoles { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalNoServerReplyBehavior> AccessPortalNoServerReplyBehaviors { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalDeferToServerBehavior> AccessPortalDeferToServerBehaviors { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessAndAlarmControlPermissionsEditingData AccessAndAlarmControlPermissionsEditingData { get; set; }

    }
#if NetCoreApi
#else
    [DataContract]
#endif
    public class PersonEditingDataWpf : EntityBase
    {
        public PersonEditingDataWpf()
        {
            Countries = new HashSet<Country>();
            PersonActiveStatusTypes = new HashSet<PersonActiveStatusType>();
            Genders = new HashSet<Gender>();
            Departments = new HashSet<Department>();
            PersonRecordTypes = new HashSet<PersonRecordType>();

            AccessProfiles = new HashSet<AccessProfile>();
            Sites = new HashSet<Site>();
            BadgeTemplates = new HashSet<BadgeTemplate>();
            CellCarriers = new HashSet<CellCarrier>();
            CommandScripts = new HashSet<CommandScript>();
            PersonActivationModes = new HashSet<PersonActivationMode>();
            PersonExpirationModes = new HashSet<PersonExpirationMode>();

            CredentialFormats = new HashSet<CredentialFormat>();
            PersonCredentialRoles = new HashSet<PersonCredentialRole>();
            AccessPortalNoServerReplyBehaviors = new HashSet<AccessPortalNoServerReplyBehavior>();
            AccessPortalDeferToServerBehaviors = new HashSet<AccessPortalDeferToServerBehavior>();
            AccessAndAlarmControlPermissionsEditingData = new AccessAndAlarmControlPermissionsEditingDataWpf();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Country> Countries { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonActiveStatusType> PersonActiveStatusTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Gender> Genders { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Department> Departments { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonRecordType> PersonRecordTypes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<Site> Sites { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessProfile> AccessProfiles { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<BadgeTemplate> BadgeTemplates { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CellCarrier> CellCarriers { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CommandScript> CommandScripts { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonActivationMode> PersonActivationModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonExpirationMode> PersonExpirationModes { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<CredentialFormat> CredentialFormats { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PersonCredentialRole> PersonCredentialRoles { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalNoServerReplyBehavior> AccessPortalNoServerReplyBehaviors { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<AccessPortalDeferToServerBehavior> AccessPortalDeferToServerBehaviors { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public AccessAndAlarmControlPermissionsEditingDataWpf AccessAndAlarmControlPermissionsEditingData { get; set; }

    }


}
