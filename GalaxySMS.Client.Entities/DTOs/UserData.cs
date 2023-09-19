////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserData.cs
//
// summary:	Implements the user data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Contains user data. </summary>
    ///
    /// <remarks>   This class includes properties about the user as well as collections of UserEntity objects. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class UserData : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserData()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this UserData. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            UserId = Guid.Empty;
            LanguageId = Guid.Empty;
            LanguageCulture = string.Empty;
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

            UserSettings = new HashSet<gcsUserSetting>();
            UserEntities = new HashSet<UserEntity>();
        }

        /// <summary>   Identifier for the user. </summary>
        private System.Guid _userId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unique identifier of the user. </summary>
        ///
        /// <value> The unique identifier of the user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.Guid UserId
        {
            get { return _userId; }
            private set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged(() => UserId);
                }
            }
        }

        /// <summary>   Identifier for the language. </summary>
        private Nullable<System.Guid> _languageId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the language. </summary>
        ///
        /// <value> The identifier of the preferred language for the user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.Guid> LanguageId
        {
            get { return _languageId; }
            private set
            {
                if (_languageId != value)
                {
                    _languageId = value;
                    OnPropertyChanged(() => LanguageId);
                }
            }
        }


        private string _languageCulture;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the language code. </summary>
        ///
        /// <value> The language code. </value>
        ///=================================================================================================
        [DataMember]

        public string LanguageCulture
        {
            get { return _languageCulture; }
            set
            {
                if (_languageCulture != value)
                {
                    _languageCulture = value;
                    OnPropertyChanged(() => LanguageCulture);
                }
            }
        }


        /// <summary>   Identifier for the primary entity. </summary>
        private System.Guid _primaryEntityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the primary entity. </summary>
        ///
        /// <value> The identifier of the primary entity associated with the user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.Guid PrimaryEntityId
        {
            get { return _primaryEntityId; }
            private set
            {
                if (_primaryEntityId != value)
                {
                    _primaryEntityId = value;
                    OnPropertyChanged(() => PrimaryEntityId);
                }
            }
        }

        /// <summary>   The person's first name. </summary>
        private string _firstName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's first name. </summary>
        ///
        /// <value> The user's first name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string FirstName
        {
            get { return _firstName; }
            private set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }

        /// <summary>   The person's last name. </summary>
        private string _lastName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's last name. </summary>
        ///
        /// <value> The user's last name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string LastName
        {
            get { return _lastName; }
            private set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }

        /// <summary>   The user initials. </summary>
        private string _userInitials;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user initials. </summary>
        ///
        /// <value> The user's initials. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string UserInitials
        {
            get { return _userInitials; }
            private set
            {
                if (_userInitials != value)
                {
                    _userInitials = value;
                    OnPropertyChanged(() => UserInitials);
                }
            }
        }

        /// <summary>   The email. </summary>
        private string _email;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the email. </summary>
        ///
        /// <value> The user's email address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Email
        {
            get { return _email; }
            private set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }

        /// <summary>   Name of the user. </summary>
        private string _userName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the user. </summary>
        ///
        /// <value> The user's official username. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string UserName
        {
            get { return _userName; }
            private set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(() => UserName);
                }
            }
        }

        /// <summary>   Name of the display. </summary>
        private string _displayName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the display. </summary>
        ///
        /// <value> The user's perferred display name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string DisplayName
        {
            get { return _displayName; }
            private set
            {
                if (_displayName != value)
                {
                    _displayName = value;
                    OnPropertyChanged(() => DisplayName);
                }
            }
        }


        /// <summary>   The last login date. </summary>
        private Nullable<System.DateTimeOffset> _lastLoginDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the last login date. </summary>
        ///
        /// <value> The last login date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.DateTimeOffset> LastLoginDate
        {
            get { return _lastLoginDate; }
            private set
            {
                if (_lastLoginDate != value)
                {
                    _lastLoginDate = value;
                    OnPropertyChanged(() => LastLoginDate);
                }
            }
        }

        /// <summary>   The user theme. </summary>
        private string _userTheme;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user theme. </summary>
        ///
        /// <value> The user theme. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string UserTheme
        {
            get { return _userTheme; }
            private set
            {
                if (_userTheme != value)
                {
                    _userTheme = value;
                    OnPropertyChanged(() => UserTheme);
                }
            }
        }

        /// <summary>   True if this UserData is locked out. </summary>
        private bool _isLockedOut;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this UserData is locked out. </summary>
        ///
        /// <value> True if this UserData is locked out, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsLockedOut
        {
            get { return _isLockedOut; }
            private set
            {
                if (_isLockedOut != value)
                {
                    _isLockedOut = value;
                    OnPropertyChanged(() => IsLockedOut);
                }
            }
        }

        /// <summary>   True if this UserData is active. </summary>
        private bool _isActive;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this UserData is active. </summary>
        ///
        /// <value> True if this UserData is active, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsActive
        {
            get { return _isActive; }
            private set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    OnPropertyChanged(() => IsActive);
                }
            }
        }

        /// <summary>   True to reset password flag. </summary>
        private bool _resetPasswordFlag;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the reset password flag. </summary>
        ///
        /// <value> True if the password must be reset or changed, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool ResetPasswordFlag
        {
            get { return _resetPasswordFlag; }
            private set
            {
                if (_resetPasswordFlag != value)
                {
                    _resetPasswordFlag = value;
                    OnPropertyChanged(() => ResetPasswordFlag);
                }
            }
        }

        /// <summary>   The last password reset date. </summary>
        private Nullable<System.DateTimeOffset> _lastPasswordResetDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the last password reset date. </summary>
        ///
        /// <value> The date and time when the password was last changed. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.DateTimeOffset> LastPasswordResetDate
        {
            get { return _lastPasswordResetDate; }
            private set
            {
                if (_lastPasswordResetDate != value)
                {
                    _lastPasswordResetDate = value;
                    OnPropertyChanged(() => LastPasswordResetDate);
                }
            }
        }

        /// <summary>   The user activation date. </summary>
        private Nullable<System.DateTimeOffset> _userActivationDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user activation date. </summary>
        ///
        /// <value> The user's activation date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.DateTimeOffset> UserActivationDate
        {
            get { return _userActivationDate; }
            private set
            {
                if (_userActivationDate != value)
                {
                    _userActivationDate = value;
                    OnPropertyChanged(() => UserActivationDate);
                }
            }
        }

        /// <summary>   The user expiration date. </summary>
        private Nullable<System.DateTimeOffset> _userExpirationDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user expiration date. </summary>
        ///
        /// <value> The user's expiration date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.DateTimeOffset> UserExpirationDate
        {
            get { return _userExpirationDate; }
            private set
            {
                if (_userExpirationDate != value)
                {
                    _userExpirationDate = value;
                    OnPropertyChanged(() => UserExpirationDate);
                }
            }
        }

        /// <summary>   True to imported from active directory. </summary>
        private bool _importedFromActiveDirectory;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the imported from active directory.
        /// </summary>
        ///
        /// <value> True if imported from active directory, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool ImportedFromActiveDirectory
        {
            get { return _importedFromActiveDirectory; }
            private set
            {
                if (_importedFromActiveDirectory != value)
                {
                    _importedFromActiveDirectory = value;
                    OnPropertyChanged(() => ImportedFromActiveDirectory);
                }
            }
        }

        /// <summary>   Unique identifier for the active directory object. </summary>
        private Nullable<System.Guid> _activeDirectoryObjectGuid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the active directory object. </summary>
        ///
        /// <value> Unique identifier of the active directory object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.Guid> ActiveDirectoryObjectGuid
        {
            get { return _activeDirectoryObjectGuid; }
            private set
            {
                if (_activeDirectoryObjectGuid != value)
                {
                    _activeDirectoryObjectGuid = value;
                    OnPropertyChanged(() => ActiveDirectoryObjectGuid);
                }
            }
        }

        /// <summary>   The security image. </summary>
        private byte[] _securityImage;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the security image. </summary>
        ///
        /// <value> The security image for the user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public byte[] SecurityImage
        {
            get { return _securityImage; }
            private set
            {
                if (_securityImage != value)
                {
                    _securityImage = value;
                    OnPropertyChanged(() => SecurityImage);
                }
            }
        }

        /// <summary>   The user image. </summary>
        private byte[] _userImage;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user image. </summary>
        ///
        /// <value> The photo of the user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public byte[] UserImage
        {
            get { return _userImage; }
            private set
            {
                if (_userImage != value)
                {
                    _userImage = value;
                    OnPropertyChanged(() => UserImage);
                }
            }
        }

        /// <summary>   Name of the insert. </summary>
        private string _insertName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the insert. </summary>
        ///
        /// <value> The name of the insert. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string InsertName
        {
            get { return _insertName; }
            set
            {
                if (_insertName != value)
                {
                    _insertName = value;
                    OnPropertyChanged(() => InsertName);
                }
            }
        }

        /// <summary>   The insert date. </summary>
        private System.DateTimeOffset _insertDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the insert date. </summary>
        ///
        /// <value> The insert date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.DateTimeOffset InsertDate
        {
            get { return _insertDate; }
            set
            {
                if (_insertDate != value)
                {
                    _insertDate = value;
                    OnPropertyChanged(() => InsertDate);
                }
            }
        }

        /// <summary>   Name of the update. </summary>
        private string _updateName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the update. </summary>
        ///
        /// <value> The name of the update. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string UpdateName
        {
            get { return _updateName; }
            set
            {
                if (_updateName != value)
                {
                    _updateName = value;
                    OnPropertyChanged(() => UpdateName);
                }
            }
        }

        /// <summary>   The update. </summary>
        private Nullable<System.DateTimeOffset> _updateDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the update. </summary>
        ///
        /// <value> The update date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.DateTimeOffset> UpdateDate
        {
            get { return _updateDate; }
            set
            {
                if (_updateDate != value)
                {
                    _updateDate = value;
                    OnPropertyChanged(() => UpdateDate);
                }
            }
        }

        /// <summary>   The concurrency value. </summary>
        private Nullable<short> _concurrencyValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the concurrency value. </summary>
        ///
        /// <value> The concurrency value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<short> ConcurrencyValue
        {
            get { return _concurrencyValue; }
            set
            {
                if (_concurrencyValue != value)
                {
                    _concurrencyValue = value;
                    OnPropertyChanged(() => ConcurrencyValue);
                }
            }
        }


        /// <summary>   Number of access failed. </summary>
        private int _accessFailedCount;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of access failed. </summary>
        ///
        /// <value> The number of access failed attempts. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int AccessFailedCount
        {
            get { return _accessFailedCount; }
            private set
            {
                if (_accessFailedCount != value)
                {
                    _accessFailedCount = value;
                    OnPropertyChanged(() => AccessFailedCount);
                }
            }
        }

        /// <summary>   The concurrency stamp. </summary>
        private string _concurrencyStamp;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the concurrency stamp. </summary>
        ///
        /// <value> The concurrency stamp. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string ConcurrencyStamp
        {
            get { return _concurrencyStamp; }
            private set
            {
                if (_concurrencyStamp != value)
                {
                    _concurrencyStamp = value;
                    OnPropertyChanged(() => ConcurrencyStamp);
                }
            }
        }

        /// <summary>   True if email confirmed. </summary>
        private bool _emailConfirmed;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the email confirmed. </summary>
        ///
        /// <value> True if email confirmed, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool EmailConfirmed
        {
            get { return _emailConfirmed; }
            private set
            {
                if (_emailConfirmed != value)
                {
                    _emailConfirmed = value;
                    OnPropertyChanged(() => EmailConfirmed);
                }
            }
        }

        /// <summary>   True to enable, false to disable the lockout. </summary>
        private bool _lockoutEnabled;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the lockout is enabled. </summary>
        ///
        /// <value> True if lockout enabled, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool LockoutEnabled
        {
            get { return _lockoutEnabled; }
            private set
            {
                if (_lockoutEnabled != value)
                {
                    _lockoutEnabled = value;
                    OnPropertyChanged(() => LockoutEnabled);
                }
            }
        }

        /// <summary>   The lockout end. </summary>
        private Nullable<System.DateTimeOffset> _lockoutEnd;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the lockout end. </summary>
        ///
        /// <value> The lockout end. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.DateTimeOffset> LockoutEnd
        {
            get { return _lockoutEnd; }
            private set
            {
                if (_lockoutEnd != value)
                {
                    _lockoutEnd = value;
                    OnPropertyChanged(() => LockoutEnd);
                }
            }
        }

        /// <summary>   The normalized email. </summary>
        private string _normalizedEmail;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the normalized email. </summary>
        ///
        /// <value> The normalized email. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string NormalizedEmail
        {
            get { return _normalizedEmail; }
            private set
            {
                if (_normalizedEmail != value)
                {
                    _normalizedEmail = value;
                    OnPropertyChanged(() => NormalizedEmail);
                }
            }
        }

        /// <summary>   Name of the normalized user. </summary>
        private string _normalizedUserName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the normalized user. </summary>
        ///
        /// <value> The name of the normalized user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string NormalizedUserName
        {
            get { return _normalizedUserName; }
            private set
            {
                if (_normalizedUserName != value)
                {
                    _normalizedUserName = value;
                    OnPropertyChanged(() => NormalizedUserName);
                }
            }
        }

        /// <summary>   The phone number. </summary>
        private string _phoneNumber;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the phone number. </summary>
        ///
        /// <value> The phone number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            private set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged(() => PhoneNumber);
                }
            }
        }

        /// <summary>   True if phone number confirmed. </summary>
        private bool _phoneNumberConfirmed;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the phone number confirmed. </summary>
        ///
        /// <value> True if phone number confirmed, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool PhoneNumberConfirmed
        {
            get { return _phoneNumberConfirmed; }
            private set
            {
                if (_phoneNumberConfirmed != value)
                {
                    _phoneNumberConfirmed = value;
                    OnPropertyChanged(() => PhoneNumberConfirmed);
                }
            }
        }

        /// <summary>   The security stamp. </summary>
        private string _securityStamp;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the security stamp. </summary>
        ///
        /// <value> The security stamp. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string SecurityStamp
        {
            get { return _securityStamp; }
            private set
            {
                if (_securityStamp != value)
                {
                    _securityStamp = value;
                    OnPropertyChanged(() => SecurityStamp);
                }
            }
        }

        /// <summary>   True to enable, false to disable the two factor. </summary>
        private bool _twoFactorEnabled;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the two factor is enabled. </summary>
        ///
        /// <value> True if two factor enabled, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool TwoFactorEnabled
        {
            get { return _twoFactorEnabled; }
            private set
            {
                if (_twoFactorEnabled != value)
                {
                    _twoFactorEnabled = value;
                    OnPropertyChanged(() => TwoFactorEnabled);
                }
            }
        }

        /// <summary>   The password hash. </summary>
        private string _passwordHash;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the password hash. </summary>
        ///
        /// <value> The password hash. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string PasswordHash
        {
            get { return _passwordHash; }
            private set
            {
                if (_passwordHash != value)
                {
                    _passwordHash = value;
                    OnPropertyChanged(() => PasswordHash);
                }
            }
        }

        /// <summary>   The gcs user settings. </summary>
        private ICollection<gcsUserSetting> _gcsUserSettings;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gcs user settings. </summary>
        ///
        /// <value> A collection of user settings. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<gcsUserSetting> UserSettings
        {
            get { return _gcsUserSettings; }
            private set
            {
                if (_gcsUserSettings != value)
                {
                    _gcsUserSettings = value;
                    OnPropertyChanged(() => UserSettings);
                }
            }
        }


        /// <summary>   The user entities. </summary>
        private ICollection<UserEntity> _userEntities;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Keep this list private so the client cannot inject security data. This collection is exposed
        /// as readonly via the EntityApplicationRolesPermissions properties.
        /// </summary>
        ///
        /// <value> The user entities. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ICollection<UserEntity> UserEntities
        {
            get
            {
                return _userEntities;
            }
            set
            {
                if (_userEntities != value)
                {
                    _userEntities = value;
                    _entities = new ReadOnlyCollection<UserEntity>(_userEntities.ToList());
                    var ue = new List<SelectListItem>();
                    foreach (var e in _userEntities)
                    {
                        var item = new SelectListItem();
                        item.Selected = false;
                        item.Text = e.EntityName;
                        item.Value = e.EntityId.ToString();
                        ue.Add(item);
                    }
                    _entitiesForUser = new ReadOnlyCollection<SelectListItem>(ue.ToList());
                    OnPropertyChanged(() => Entities);
                }
            }
        }

        /// <summary>   The entities. </summary>
        private ReadOnlyCollection<UserEntity> _entities;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the entities. </summary>
        /// <remarks>   This is a read-only list of UserEntity objects for the user</remarks>
        /// <value> The entities. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<UserEntity> Entities
        {
            get { return _entities; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the selected user entity. </summary>
        ///
        /// <value> The selected user entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserEntity SelectedUserEntity { get; set; }


        /// <summary>   The entities for user. </summary>
        private ReadOnlyCollection<SelectListItem> _entitiesForUser;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the entities for user. </summary>
        ///
        /// <value> The entities for user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<SelectListItem> EntitiesForUser
        {
            get { return _entitiesForUser; }

        }
    }
}
