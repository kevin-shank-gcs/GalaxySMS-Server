using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    [DataContract]

    public class gcsUserEditingData
    {
        public gcsUserEditingData()
        {
            AllowedEntities = new HashSet<gcsUserEditingEntityData>();
            Languages = new HashSet<gcsLanguageBasic>();
        }


        [DataMember]

        public ICollection<gcsUserEditingEntityData> AllowedEntities { get; set; }

        [DataMember]

        public ICollection<gcsLanguageBasic> Languages {get;set;}
    }



    [DataContract]

    public class gcsUserEditingEntityData
    {
        public gcsUserEditingEntityData()
        {
            ChildEntities = new HashSet<gcsUserEditingEntityData>();
            //Applications = new HashSet<gcsUserEditingApplicationData>();
            this.Roles = new HashSet<UserEditingRoleData>();
        }
        public gcsUserEditingEntityData(gcsUserEditingEntityData e)
        {
            ChildEntities = new HashSet<gcsUserEditingEntityData>();
            //Applications = new HashSet<gcsUserEditingApplicationData>();
            this.Roles = new HashSet<UserEditingRoleData>();

            this.EntityId = e.EntityId;
            this.ParentEntityId = e.ParentEntityId;
            this.EntityName = e.EntityName;
            this.EntityDescription = e.EntityDescription;
            this.EntityKey = e.EntityKey;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.UserRequirements = e.UserRequirements;
            //if (e.Applications != null)
            //    Applications = e.Applications.ToCollection();
            if (e.ChildEntities != null)
                ChildEntities = e.ChildEntities.ToCollection();
            //this.gcsUserEntities = e.gcsUserEntities.ToCollection();
            //this.gcsEntityApplications = e.gcsEntityApplications.ToCollection();
            //if( e.gcsBinaryResource != null)
            //    this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            //if (e.ParentEntity != null)
            //    this.ParentEntity = new gcsEntity(e.ParentEntity);
            //if (e.ChildEntities != null)
            //    this.ChildEntities = e.ChildEntities.ToCollection();
            //if( e.gcsSettings != null)
            //    this.gcsSettings = e.gcsSettings.ToCollection();
        }

        public gcsUserEditingEntityData(gcsEntity e)
        {
            ChildEntities = new HashSet<gcsUserEditingEntityData>();
            //Applications = new HashSet<gcsUserEditingApplicationData>();
            this.Roles = new HashSet<UserEditingRoleData>();
            this.EntityId = e.EntityId;
            this.ParentEntityId = e.ParentEntityId;
            this.EntityName = e.EntityName;
            this.EntityDescription = e.EntityDescription;
            this.EntityKey = e.EntityKey;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.UserRequirements = new gcsUserEditingUserRequirementData(e.UserRequirements);
            //foreach( var a in e.AllApplications)
            //{
            //    Applications.Add(new gcsUserEditingApplicationData(a));
            //}

            foreach (var a in e.AllRoles)
            {
                Roles.Add(new UserEditingRoleData(a));
            }
        }


        [DataMember]

        public System.Guid EntityId { get; set; }


        [DataMember]

        public string EntityName { get; set; }


        [DataMember]
        public string EntityDescription { get; set; }


        [DataMember]
        public string EntityKey { get; set; }


        [DataMember]

        public bool IsDefault { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public byte[] Photo { get; set; }

        [DataMember]
        public Nullable<System.Guid> ParentEntityId { get; set; }


        [DataMember]
        public string ParentEntityName { get; set; }


        [DataMember]
        public gcsUserEditingUserRequirementData UserRequirements { get; set; }

        [DataMember]
        public ICollection<gcsUserEditingEntityData> ChildEntities { get; set; }

        [DataMember]
        public ICollection<UserEditingRoleData> Roles { get; set; }

    }



    [DataContract]

    public partial class gcsUserEditingApplicationData
    {
        public gcsUserEditingApplicationData()
        {
            //this.Roles = new HashSet<UserEditingRoleData>();
        }

        public gcsUserEditingApplicationData(gcsUserEditingApplicationData e)
        {
            //this.Roles = new HashSet<UserEditingRoleData>();
            this.ApplicationId = e.ApplicationId;
            this.ApplicationName = e.ApplicationName;
            this.ApplicationDescription = e.ApplicationDescription;
            //if (e.Roles != null)
            //    this.Roles = e.Roles.ToCollection();
        }

        public gcsUserEditingApplicationData(gcsApplication e)
        {
            //this.Roles = new HashSet<UserEditingRoleData>();
            this.ApplicationId = e.ApplicationId;
            this.ApplicationName = e.ApplicationName;
            this.ApplicationDescription = e.ApplicationDescription;
            //if( e.AllRoles != null)
            //{
            //    foreach( var r in e.AllRoles)
            //    {
            //        this.Roles.Add(new UserEditingRoleData(r));
            //    }
            //}
        }

        [DataMember]
        public System.Guid ApplicationId { get; set; }
 
        [DataMember]
        public string ApplicationName { get; set; }

        [DataMember]
        public string ApplicationDescription { get; set; }
    }


    [DataContract]
    public partial class UserEditingRoleData
    {
        public UserEditingRoleData()
        {

        }

        public UserEditingRoleData(UserEditingRoleData e)
        {
            this.RoleId = e.RoleId;
            this.RoleName = e.RoleName;
            this.RoleDescription = e.RoleDescription;
            this.IsActive = e.IsActive;
            this.IsAdministratorRole = e.IsAdministratorRole;
            this.IsAuthorized = e.IsAuthorized;
            //this.EntityApplicationRoleId = e.EntityApplicationRoleId;
        }

        public UserEditingRoleData(gcsRole e)
        {
            this.RoleId = e.RoleId;
            this.RoleName = e.RoleName;
            this.RoleDescription = e.RoleDescription;
            this.IsActive = e.IsActive;
            this.IsAdministratorRole = e.IsAdministratorRole;
            //this.IsAuthorized = e.IsAuthorized;
        }

        [DataMember]
        public System.Guid RoleId { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public string RoleDescription { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDefault { get; set; }

        [DataMember]
        public bool IsAdministratorRole { get; set; }



        //
        //
        //        [DataMember]
        //
        //        public ICollection<gcsRolePermission> gcsRolePermissions { get; set; }


        [DataMember]
        public bool IsAuthorized { get; set; }


        //
        //
        //        [DataMember]
        //
        //        public Guid EntityApplicationRoleId { get; set; }

    }


    [DataContract]
    public partial class gcsUserEditingUserRequirementData
    {
        public gcsUserEditingUserRequirementData()
        {

        }

        public gcsUserEditingUserRequirementData(gcsUserEditingUserRequirementData e)
        {
            this.PasswordCannotContainName = e.PasswordCannotContainName;
            this.PasswordMinimumLength = e.PasswordMinimumLength;
            this.PasswordMaximumLength = e.PasswordMaximumLength;
            this.PasswordMinimumChangeCharacters = e.PasswordMinimumChangeCharacters;
            this.MinimumPasswordAge = e.MinimumPasswordAge;
            this.MaximumPasswordAge = e.MaximumPasswordAge;
            this.MaintainPasswordHistoryCount = e.MaintainPasswordHistoryCount;
            this.DefaultExpirationDays = e.DefaultExpirationDays;
            this.LockoutUserIfInactiveForDays = e.LockoutUserIfInactiveForDays;
            this.AllowPasswordChangeAttempt = e.AllowPasswordChangeAttempt;
            this.RequireLowerCaseLetterCount = e.RequireLowerCaseLetterCount;
            this.RequireUpperCaseLetterCount = e.RequireUpperCaseLetterCount;
            this.RequireNumericDigitCount = e.RequireNumericDigitCount;
            this.RequireSpecialCharacterCount = e.RequireSpecialCharacterCount;
            this.UseCustomRegEx = e.UseCustomRegEx;
            this.PasswordCustomRegEx = e.PasswordCustomRegEx;
            this.RegularExpressionDescription = e.RegularExpressionDescription;

        }

        public gcsUserEditingUserRequirementData(gcsUserRequirement e)
        {
            this.PasswordCannotContainName = e.PasswordCannotContainName;
            this.PasswordMinimumLength = e.PasswordMinimumLength;
            this.PasswordMaximumLength = e.PasswordMaximumLength;
            this.PasswordMinimumChangeCharacters = e.PasswordMinimumChangeCharacters;
            this.MinimumPasswordAge = e.MinimumPasswordAge;
            this.MaximumPasswordAge = e.MaximumPasswordAge;
            this.MaintainPasswordHistoryCount = e.MaintainPasswordHistoryCount;
            this.DefaultExpirationDays = e.DefaultExpirationDays;
            this.LockoutUserIfInactiveForDays = e.LockoutUserIfInactiveForDays;
            this.AllowPasswordChangeAttempt = e.AllowPasswordChangeAttempt;
            this.RequireLowerCaseLetterCount = e.RequireLowerCaseLetterCount;
            this.RequireUpperCaseLetterCount = e.RequireUpperCaseLetterCount;
            this.RequireNumericDigitCount = e.RequireNumericDigitCount;
            this.RequireSpecialCharacterCount = e.RequireSpecialCharacterCount;
            this.UseCustomRegEx = e.UseCustomRegEx;
            this.PasswordCustomRegEx = e.PasswordCustomRegEx;
            this.RegularExpressionDescription = e.RegularExpressionDescription;
        }


        [DataMember]
        public bool PasswordCannotContainName { get; set; }


        [DataMember]
        public short PasswordMinimumLength { get; set; }


        [DataMember]
        public short PasswordMaximumLength { get; set; }

        [DataMember]
        public short PasswordMinimumChangeCharacters { get; set; }



        [DataMember]

        public short MinimumPasswordAge { get; set; }



        [DataMember]

        public short MaximumPasswordAge { get; set; }



        [DataMember]

        public short MaintainPasswordHistoryCount { get; set; }

        [DataMember]
        public short DefaultExpirationDays { get; set; }

        [DataMember]
        public short LockoutUserIfInactiveForDays { get; set; }

        [DataMember]
        public bool AllowPasswordChangeAttempt { get; set; }

        [DataMember]
        public short RequireLowerCaseLetterCount { get; set; }

        [DataMember]
        public short RequireUpperCaseLetterCount { get; set; }

        [DataMember]
        public short RequireNumericDigitCount { get; set; }

        [DataMember]
        public short RequireSpecialCharacterCount { get; set; }

        [DataMember]
        public bool UseCustomRegEx { get; set; }

        [DataMember]
        public string PasswordCustomRegEx { get; set; }

        [DataMember]
        public string RegularExpressionDescription { get; set; }

        [DataMember]
        public bool RequireTwoFactorAuthentication { get; set; }

    }

}
