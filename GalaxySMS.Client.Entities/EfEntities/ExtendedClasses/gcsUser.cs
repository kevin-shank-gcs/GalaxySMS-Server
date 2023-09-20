////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\gcsUser.cs
//
// summary:	Implements the gcs user class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The gcs user. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class gcsUser
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUser()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsUser to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUser(gcsUser e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsUser. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            this.UserSettings = new HashSet<gcsUserSetting>();
            this.UserOldPasswords = new HashSet<gcsUserOldPassword>();
            this.UserEntities = new HashSet<gcsUserEntity>();
            this.AllEntities = new ObservableCollection<gcsEntity>();
            //this.EntitiesAuthorizedForUser = new ObservableCollection<gcsEntity>();
            //this.EntitiesNotAuthorizedForUser = new ObservableCollection<gcsEntity>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsUser. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsUser to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(gcsUser e)
        {
            Initialize();
            if (e == null)
                return;
            this.UserId = e.UserId;
            this.LanguageId = e.LanguageId;
            this.LanguageName = e.LanguageName;
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
            this.UserSettings = e.UserSettings.ToCollection();
            this.UserOldPasswords = e.UserOldPasswords.ToCollection();
            this.UserEntities = e.UserEntities.ToCollection();

            ConfirmPassword = UserPassword;

            this.AllEntities = e.AllEntities.ToObservableCollection();
            this.TotalRowCount = e.TotalRowCount;
            //this.EntitiesAuthorizedForUser = e.EntitiesAuthorizedForUser.ToObservableCollection();
            //this.EntitiesNotAuthorizedForUser = e.EntitiesNotAuthorizedForUser.ToObservableCollection();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this gcsUser. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsUser to process. </param>
        ///
        /// <returns>   A copy of this gcsUser. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUser Clone(gcsUser e)
        {
            return new gcsUser(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this gcsUser is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(gcsUser other)
        {
            return base.Equals(other);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'other' is primary key equal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if primary key equal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsPrimaryKeyEqual(gcsUser other)
        {
            if (other == null)
                return false;

            if (other.UserId != this.UserId)
                return false;
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Serves as the default hash function. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A hash code for the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        /// <summary>   The confirm password. </summary>
        private string _confirmPassword;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the confirm password. </summary>
        ///
        /// <value> The confirm password. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                if (_confirmPassword != value)
                {
                    _confirmPassword = value;
                    OnPropertyChanged(() => ConfirmPassword);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user requirements. </summary>
        ///
        /// <value> The user requirements. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUserRequirement UserRequirements { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether this gcsUser is new. </summary>
        ///
        /// <value> True if this gcsUser is new, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsNew
        {
            get
            {
                if (UserId == Guid.Empty)
                    return true;
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets a value indicating whether this gcsUser is password validation required.
        /// </summary>
        ///
        /// <value> True if this gcsUser is password validation required, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsPasswordValidationRequired
        {
            get
            {
                if (IsNew == true)
                    return true;
                if (UserPassword != string.Empty)
                    return true;
                return false;
            }
        }


        /// <summary>   all entities. </summary>
        private ObservableCollection<gcsEntity> _allEntities = new ObservableCollection<gcsEntity>();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets all entities. </summary>
        ///
        /// <value> all entities. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual ObservableCollection<gcsEntity> AllEntities
        {
            get { return _allEntities; }
            set
            {
                if (_allEntities != value)
                {
                    _allEntities = value;
                    OnPropertyChanged(() => AllEntities);
                }
            }
        }

        public gcsUserBasic ToGcsUserBasic()
        {
            return new gcsUserBasic(this);
        }


        private int _TotalRowCount;

        [DataMember]
        public int TotalRowCount
        {
            get => _TotalRowCount;
            set
            {
                if (_TotalRowCount != value)
                {
                    _TotalRowCount = value;
                    OnPropertyChanged(() => TotalRowCount, false);
                }
            }
        }

        //private ObservableCollection<gcsEntity> _entitiesAuthorizedForUser = new ObservableCollection<gcsEntity>();
        //[DataMember]
        //public virtual ObservableCollection<gcsEntity> EntitiesAuthorizedForUser
        //{
        //    get { return _entitiesAuthorizedForUser; }
        //    set
        //    {
        //        if (_entitiesAuthorizedForUser != value)
        //        {
        //            _entitiesAuthorizedForUser = value;
        //            OnPropertyChanged(() => EntitiesAuthorizedForUser);
        //        }
        //    }
        //}

        //private ObservableCollection<gcsEntity> _entitiesNotAuthorizedForUser = new ObservableCollection<gcsEntity>();
        //[DataMember]
        //public virtual ObservableCollection<gcsEntity> EntitiesNotAuthorizedForUser
        //{
        //    get { return _entitiesNotAuthorizedForUser; }
        //    set
        //    {
        //        if (_entitiesNotAuthorizedForUser != value)
        //        {
        //            _entitiesNotAuthorizedForUser = value;
        //            OnPropertyChanged(() => EntitiesNotAuthorizedForUser);
        //        }
        //    }
        //}    
    }
}
