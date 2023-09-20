using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

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
    public class gcsUserEditingData
    {
        public gcsUserEditingData()
        {
            AllowedEntities = new HashSet<gcsUserEditingEntityData>();
            Languages = new HashSet<gcsLanguageBasic>();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<gcsUserEditingEntityData> AllowedEntities { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<gcsLanguageBasic> Languages {get;set;}
    }


#if NetCoreApi
#else
    [DataContract]
#endif
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


#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityDescription { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityKey { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsDefault { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] Photo { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> ParentEntityId { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string ParentEntityName { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public gcsUserEditingUserRequirementData UserRequirements { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<gcsUserEditingEntityData> ChildEntities { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<gcsUserEditingApplicationData> Applications { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<UserEditingRoleData> Roles { get; set; }

    }


#if NetCoreApi
#else
    [DataContract]
#endif
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid ApplicationId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ApplicationName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ApplicationDescription { get; set; }


//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<UserEditingRoleData> Roles { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid RoleId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string RoleName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string RoleDescription { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsDefault { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAdministratorRole { get; set; }



        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public ICollection<gcsRolePermission> gcsRolePermissions { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAuthorized { get; set; }


        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public Guid EntityApplicationRoleId { get; set; }

    }


#if NetCoreApi
#else
    [DataContract]
#endif
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

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool PasswordCannotContainName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short PasswordMinimumLength { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short PasswordMaximumLength { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short PasswordMinimumChangeCharacters { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short MinimumPasswordAge { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short MaximumPasswordAge { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short MaintainPasswordHistoryCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short DefaultExpirationDays { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short LockoutUserIfInactiveForDays { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool AllowPasswordChangeAttempt { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short RequireLowerCaseLetterCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short RequireUpperCaseLetterCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short RequireNumericDigitCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public short RequireSpecialCharacterCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool UseCustomRegEx { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PasswordCustomRegEx { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string RegularExpressionDescription { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool RequireTwoFactorAuthentication { get; set; }

    }

}
