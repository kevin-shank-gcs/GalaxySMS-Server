using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
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
            AccessAndAlarmControlPermissionsEditingData = new AccessAndAlarmControlPermissionsEditingData();
        }

        public ICollection<Country> Countries { get; set; }
        public ICollection<PersonActiveStatusType> PersonActiveStatusTypes { get; set; }
        public ICollection<Gender> Genders { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<PersonRecordType> PersonRecordTypes { get; set; }
        public ICollection<Site> Sites { get; set; }
        public ICollection<AccessProfile> AccessProfiles { get; set; }
        public ICollection<BadgeTemplate> BadgeTemplates { get; set; }
        public ICollection<CellCarrier> CellCarriers { get; set; }
        public ICollection<CommandScript> CommandScripts { get; set; }

        public ICollection<PersonActivationMode> PersonActivationModes { get; set; }
        public ICollection<PersonExpirationMode> PersonExpirationModes { get; set; }

        public ICollection<CredentialFormat> CredentialFormats { get; set; }
        public ICollection<PersonCredentialRole> PersonCredentialRoles { get; set; }

        public ICollection<AccessPortalNoServerReplyBehavior> AccessPortalNoServerReplyBehaviors { get; set; }
        public ICollection<AccessPortalDeferToServerBehavior> AccessPortalDeferToServerBehaviors { get; set; }
        public AccessAndAlarmControlPermissionsEditingData AccessAndAlarmControlPermissionsEditingData { get;set;}

    }

}
