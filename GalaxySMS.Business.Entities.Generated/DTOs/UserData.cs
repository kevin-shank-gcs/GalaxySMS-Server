using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public class UserData
    {
        public UserData()
        {
            Init();
        }
        public UserData(gcsUser user)
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
                SecurityImage = user.SecurityImage;
                UserImage = user.UserImage;

                InsertName = user.InsertName;
                InsertDate = user.InsertDate;
                UpdateName = user.UpdateName;
                UpdateDate = user.UpdateDate;
                ConcurrencyValue = user.ConcurrencyValue;
                if (user.gcsUserSettings != null)
                    gcsUserSettings = user.gcsUserSettings.ToCollection();

                AccessFailedCount= user.AccessFailedCount;
                ConcurrencyStamp= user.ConcurrencyStamp;
                EmailConfirmed= user.EmailConfirmed;
                LockoutEnabled= user.LockoutEnabled;
                LockoutEnd= user.LockoutEnd;
                NormalizedEmail= user.NormalizedEmail;
                NormalizedUserName= user.NormalizedUserName;
                PhoneNumber= user.PhoneNumber;
                PhoneNumberConfirmed= user.PhoneNumberConfirmed;
                SecurityStamp= user.SecurityStamp;
                TwoFactorEnabled= user.TwoFactorEnabled;
                PasswordHash= user.PasswordHash;
                //Entities = new HashSet<UserEntity>();
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

            gcsUserSettings = new HashSet<gcsUserSetting>();
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
        }

        public System.Guid UserId { get; set; }
        public Nullable<System.Guid> LanguageId { get; set; }
        public System.Guid PrimaryEntityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserInitials { get; set; }
        public string DisplayName { get; set; }
        public Nullable<System.DateTimeOffset> LastLoginDate { get; set; }
        public string UserTheme { get; set; }
        public bool IsLockedOut { get; set; }
        public bool IsActive { get; set; }
        public bool ResetPasswordFlag { get; set; }
        public Nullable<System.DateTimeOffset> LastPasswordResetDate { get; set; }
        public Nullable<System.DateTimeOffset> UserActivationDate { get; set; }
        public Nullable<System.DateTimeOffset> UserExpirationDate { get; set; }
        public bool ImportedFromActiveDirectory { get; set; }
        public Nullable<System.Guid> ActiveDirectoryObjectGuid { get; set; }
        public byte[] SecurityImage { get; set; }
        public byte[] UserImage { get; set; }
        public string InsertName { get; set; }
        public System.DateTimeOffset InsertDate { get; set; }
        public string UpdateName { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public Nullable<short> ConcurrencyValue { get; set; }
        public ICollection<gcsUserSetting> gcsUserSettings { get; set; }
        public ICollection<UserEntity> UserEntities { get; set; }
        public string UserPassword { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public Nullable<System.DateTimeOffset> LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string PasswordHash { get; set; }


    }
}
