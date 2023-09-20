using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
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
    public partial class gcsUserSave
    {
        public gcsUserSave()
        {
            Initialize();
        }

        public gcsUserSave(gcsUserSave e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            //this.gcsUserSettings = new HashSet<gcsUserSetting>();
            //this.gcsUserOldPasswords = new HashSet<gcsUserOldPassword>();
            this.UserEntities = new HashSet<gcsUserEntitySave>();
            this.AllEntities = new HashSet<gcsEntity>();
            //this.EntitiesAuthorizedForUser = new HashSet<gcsEntity>();
            //this.EntitiesNotAuthorizedForUser = new HashSet<gcsEntity>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsUserSave e)
        {
            Initialize();
            if (e == null)
                return;
            this.UserId = e.UserId;
            this.LanguageId = e.LanguageId;
            this.PrimaryEntityId = e.PrimaryEntityId;
            this.FirstName = e.FirstName;
            this.LastName = e.LastName;
            this.UserInitials = e.UserInitials;
            this.DisplayName = e.DisplayName;
            this.UserPassword = e.UserPassword;
            this.LastLoginDate = e.LastLoginDate;
            this.UserTheme = e.UserTheme;
            this.IsLockedOut = e.IsLockedOut;
            this.IsActive = e.IsActive;
            this.ResetPasswordFlag = e.ResetPasswordFlag;
            this.LastPasswordResetDate = e.LastPasswordResetDate;
            this.UserActivationDate = e.UserActivationDate;
            this.UserExpirationDate = e.UserExpirationDate;
            this.ImportedFromActiveDirectory = e.ImportedFromActiveDirectory;
            this.ActiveDirectoryObjectGuid = e.ActiveDirectoryObjectGuid;
            this.SecurityImage = e.SecurityImage;
            this.UserImage = e.UserImage;
            //this.InsertName = e.InsertName;
            //this.InsertDate = e.InsertDate;
            //this.UpdateName = e.UpdateName;
            //this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.Email = e.Email;
            this.UserName = e.UserName;
            this.AccessFailedCount = e.AccessFailedCount;
            this.ConcurrencyStamp = e.ConcurrencyStamp;
            this.EmailConfirmed = e.EmailConfirmed;
            this.LockoutEnabled = e.LockoutEnabled;
            this.LockoutEnd = e.LockoutEnd;
            //this.NormalizedEmail = e.NormalizedEmail;
            //this.NormalizedUserName = e.NormalizedUserName;
            this.PhoneNumber = e.PhoneNumber;
            this.PhoneNumberConfirmed = e.PhoneNumberConfirmed;
            this.SecurityStamp = e.SecurityStamp;
            this.TwoFactorEnabled = e.TwoFactorEnabled;
            this.PasswordHash = e.PasswordHash;
            //this.gcsUserSettings = e.gcsUserSettings.ToCollection();
            //this.gcsUserOldPasswords = e.gcsUserOldPasswords.ToCollection();
            this.UserEntities = e.UserEntities.ToCollection();

            this.AllEntities = e.AllEntities.ToCollection();
            //this.EntitiesAuthorizedForUser = e.EntitiesAuthorizedForUser.ToCollection();
            //this.EntitiesNotAuthorizedForUser = e.EntitiesNotAuthorizedForUser.ToCollection();
        }

        public gcsUserSave Clone(gcsUserSave e)
        {
            return new gcsUserSave(e);
        }

        public bool Equals(gcsUserSave other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUserSave other)
        {
            if (other == null)
                return false;

            if (other.UserId != this.UserId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string ConfirmPassword { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public virtual ICollection<gcsEntity> AllEntities { get; set; }

    }

}
