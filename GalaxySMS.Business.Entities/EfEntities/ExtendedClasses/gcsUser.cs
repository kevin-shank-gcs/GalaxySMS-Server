using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsUser
    {
        public gcsUser()
        {
            Initialize();
        }

        public gcsUser(gcsUser e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.gcsUserSettings = new HashSet<gcsUserSetting>();
            this.gcsUserOldPasswords = new HashSet<gcsUserOldPassword>();
            this.gcsUserEntities = new HashSet<gcsUserEntity>();
            this.AllEntities = new HashSet<gcsEntity>();
            //this.EntitiesAuthorizedForUser = new HashSet<gcsEntity>();
            //this.EntitiesNotAuthorizedForUser = new HashSet<gcsEntity>();
        }

        public void Initialize(gcsUser e)
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
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.Email = e.Email;
            this.UserName = e.UserName;
            this.AccessFailedCount = e.AccessFailedCount;
            this.ConcurrencyStamp = e.ConcurrencyStamp;
            this.EmailConfirmed = e.EmailConfirmed;
            this.LockoutEnabled = e.LockoutEnabled;
            this.LockoutEnd = e.LockoutEnd;
            this.NormalizedEmail = e.NormalizedEmail;
            this.NormalizedUserName = e.NormalizedUserName;
            this.PhoneNumber = e.PhoneNumber;
            this.PhoneNumberConfirmed = e.PhoneNumberConfirmed;
            this.SecurityStamp = e.SecurityStamp;
            this.TwoFactorEnabled = e.TwoFactorEnabled;
            this.PasswordHash = e.PasswordHash;
            this.gcsUserSettings = e.gcsUserSettings.ToCollection();
            this.gcsUserOldPasswords = e.gcsUserOldPasswords.ToCollection();
            this.gcsUserEntities = e.gcsUserEntities.ToCollection();
      
            this.AllEntities = e.AllEntities.ToCollection();
            //this.EntitiesAuthorizedForUser = e.EntitiesAuthorizedForUser.ToCollection();
            //this.EntitiesNotAuthorizedForUser = e.EntitiesNotAuthorizedForUser.ToCollection();
        }

        public gcsUser Clone(gcsUser e)
        {
            return new gcsUser(e);
        }

        public bool Equals(gcsUser other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsUser other)
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

        public virtual ICollection<gcsEntity> AllEntities { get; set; }
        //public virtual ICollection<gcsEntity> EntitiesAuthorizedForUser { get; set; }
        //public virtual ICollection<gcsEntity> EntitiesNotAuthorizedForUser { get; set; }
    
    }
}
