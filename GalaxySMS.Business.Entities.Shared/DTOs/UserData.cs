////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserData.cs
//
// summary:	Implements the user data class
///=================================================================================================

using GCS.Core.Common.Extensions;
using System;
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
    public class UserData
    {
        public UserData()
        {
            Init();
        }
        public UserData(gcsUser user, bool bIncludeUserImages)
        {
            Init();
            if (user != null)
            {
                UserId = user.UserId;
                LanguageId = user.LanguageId;
                PrimaryEntityId = user.PrimaryEntityId;
                FirstName = user.FirstName;
                LastName = user.LastName;
                UserInitials = user.UserInitials;
                Email = user.Email;
                UserName = user.UserName;
                DisplayName = user.DisplayName;
                LastLoginDate = user.LastLoginDate;
                UserTheme = user.UserTheme;
                IsLockedOut = user.IsLockedOut;
                IsActive = user.IsActive;
                ResetPasswordFlag = user.ResetPasswordFlag;
                LastPasswordResetDate = user.LastPasswordResetDate;
                UserActivationDate = user.UserActivationDate;
                UserExpirationDate = user.UserExpirationDate;
                ImportedFromActiveDirectory = user.ImportedFromActiveDirectory;
                ActiveDirectoryObjectGuid = user.ActiveDirectoryObjectGuid;
                if (bIncludeUserImages)
                {
                    SecurityImage = user.SecurityImage;
                    UserImage = user.UserImage;
                }
                else
                {
                    SecurityImage = null;
                    UserImage = null;
                }
                InsertName = user.InsertName;
                InsertDate = user.InsertDate;
                UpdateName = user.UpdateName;
                UpdateDate = user.UpdateDate;
                ConcurrencyValue = user.ConcurrencyValue;
                //if (user.gcsUserSettings != null)
                //    gcsUserSettings = user.gcsUserSettings.ToCollection();

                AccessFailedCount = user.AccessFailedCount;
                ConcurrencyStamp = user.ConcurrencyStamp;
                EmailConfirmed = user.EmailConfirmed;
                LockoutEnabled = user.LockoutEnabled;
                LockoutEnd = user.LockoutEnd;
                NormalizedEmail = user.NormalizedEmail;
                NormalizedUserName = user.NormalizedUserName;
                PhoneNumber = user.PhoneNumber;
                PhoneNumberConfirmed = user.PhoneNumberConfirmed;
                SecurityStamp = user.SecurityStamp;
                TwoFactorEnabled = user.TwoFactorEnabled;
                PasswordHash = user.PasswordHash;
                //Entities = new HashSet<UserEntity>();
            }
        }

        public UserData(UserData o)
        {
            Init();
            if (o != null)
            {
                this.AccessFailedCount = o.AccessFailedCount;
                this.ActiveDirectoryObjectGuid = o.ActiveDirectoryObjectGuid;
                this.ConcurrencyStamp = o.ConcurrencyStamp;
                this.ConcurrencyValue = o.ConcurrencyValue;
                this.DisplayName = o.DisplayName;
                this.Email = o.Email;
                this.EmailConfirmed = o.EmailConfirmed;
                this.FirstName = o.FirstName;
                if (o.UserSettings != null)
                    this.UserSettings = o.UserSettings.ToCollection();
                this.ImportedFromActiveDirectory = o.ImportedFromActiveDirectory;
                this.InsertDate = o.InsertDate;
                this.InsertName = o.InsertName;
                this.IsActive = o.IsActive;
                this.IsLockedOut = o.IsLockedOut;
                this.LanguageId = o.LanguageId;
                this.LanguageCulture = o.LanguageCulture;
                this.LastLoginDate = o.LastLoginDate;
                this.LastName = o.LastName;
                this.LastPasswordResetDate = o.LastPasswordResetDate;
                this.LockoutEnabled = o.LockoutEnabled;
                this.LockoutEnd = o.LockoutEnd;
                this.NormalizedEmail = o.NormalizedEmail;
                this.NormalizedUserName = o.NormalizedUserName;
                this.PasswordHash = o.PasswordHash;
                this.PhoneNumber = o.PhoneNumber;
                this.PhoneNumberConfirmed = o.PhoneNumberConfirmed;
                this.PrimaryEntityId = o.PrimaryEntityId;
                this.ResetPasswordFlag = o.ResetPasswordFlag;
                this.SecurityImage = o.SecurityImage;
                this.SecurityStamp = o.SecurityStamp;
                this.TwoFactorEnabled = o.TwoFactorEnabled;
                this.UpdateDate = o.UpdateDate;
                this.UpdateName = o.UpdateName;
                this.UserActivationDate = o.UserActivationDate;
                if (o.UserEntities != null)
                    this.UserEntities = o.UserEntities.ToCollection();
                this.UserExpirationDate = o.UserExpirationDate;
                this.UserId = o.UserId;
                this.UserImage = o.UserImage;
                this.UserInitials = o.UserInitials;
                this.UserName = o.UserName;
                this.UserPassword = o.UserPassword;
                this.UserTheme = o.UserTheme;
                this.CurrentEntityName = o.CurrentEntityName;
                this.CurrentEntityType = o.CurrentEntityType;
                this.CurrentEntityId = o.CurrentEntityId;
            }
        }
        private void Init()
        {
            UserId = Guid.Empty;
            LanguageId = Guid.Empty;
            PrimaryEntityId = Guid.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            UserInitials = string.Empty;
            Email = string.Empty;
            UserName = string.Empty;
            DisplayName = string.Empty;
            LastLoginDate = null;
            UserTheme = string.Empty;
            IsLockedOut = true;
            IsActive = false;
            ResetPasswordFlag = false;
            LastPasswordResetDate = null;
            UserActivationDate = null;
            UserExpirationDate = null;
            ImportedFromActiveDirectory = false;
            ActiveDirectoryObjectGuid = Guid.Empty;
            SecurityImage = null;
            UserImage = null;
            InsertName = string.Empty;
            InsertDate = DateTimeOffset.MinValue;
            UpdateName = string.Empty;
            UpdateDate = null;
            ConcurrencyValue = 0;

            UserSettings = new HashSet<gcsUserSetting>();
            UserEntities = new HashSet<UserEntity>();
            AccessFailedCount = 0;
            ConcurrencyStamp = string.Empty;
            EmailConfirmed = false;
            LockoutEnabled = false;
            LockoutEnd = null;
            NormalizedEmail = string.Empty;
            NormalizedUserName = string.Empty;
            PhoneNumber = string.Empty;
            PhoneNumberConfirmed = false;
            SecurityStamp = string.Empty;
            TwoFactorEnabled = false;
            PasswordHash = string.Empty;
            CurrentEntityName = string.Empty;
            CurrentEntityType = string.Empty;
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid UserId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> LanguageId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LanguageCulture { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid PrimaryEntityId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string FirstName { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string LastName { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserInitials { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string DisplayName { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> LastLoginDate { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserTheme { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsLockedOut { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ResetPasswordFlag { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> LastPasswordResetDate { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> UserActivationDate { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> UserExpirationDate { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ImportedFromActiveDirectory { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> ActiveDirectoryObjectGuid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] SecurityImage { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] UserImage { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string InsertName { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset InsertDate { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string UpdateName { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<short> ConcurrencyValue { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<gcsUserSetting> UserSettings { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<UserEntity> UserEntities { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserPassword { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string Email { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserName { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessFailedCount { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string ConcurrencyStamp { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool EmailConfirmed { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool LockoutEnabled { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> LockoutEnd { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string NormalizedEmail { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string NormalizedUserName { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string PhoneNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool PhoneNumberConfirmed { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string SecurityStamp { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool TwoFactorEnabled { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string PasswordHash { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CurrentEntityId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public string CurrentEntityName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CurrentEntityType { get; set; }

    }
}
