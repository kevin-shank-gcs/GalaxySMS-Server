////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\gcsApplication.cs
//
// summary:	Implements the gcs application class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The gcs application. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class gcsApplication
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsApplication()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsApplication to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsApplication(gcsApplication e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsApplication. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            this.UserSettings = new HashSet<gcsUserSetting>();
            //this.gcsEntityApplications = new HashSet<gcsEntityApplication>();
            //this.AllRoles = new ObservableCollection<gcsRole>();
            this.PermissionCategories = new HashSet<gcsPermissionCategory>();
            //this.UnauthorizedRoles = new ObservableCollection<gcsRole>();
            //this.AuthorizedRoles = new ObservableCollection<gcsRole>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsApplication. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsApplication to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(gcsApplication e)
        {
            Initialize();
            if (e == null)
                return;
            this.ApplicationId = e.ApplicationId;
            this.LanguageId = e.LanguageId;
            //this.SystemRoleId = e.SystemRoleId;
            this.ApplicationName = e.ApplicationName;
            this.ApplicationDescription = e.ApplicationDescription;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.UserSettings = e.UserSettings.ToCollection();
            //this.gcsEntityApplications = e.gcsEntityApplications.ToCollection();
            this.PermissionCategories = e.PermissionCategories.ToCollection();
            //this.IncludedEntityApplicationRoles = e.IncludedEntityApplicationRoles.ToObservableCollection();
            //// Custom properties
            //foreach (var included in e.IncludedEntityApplicationRoles)
            //{
            //    IncludedEntityApplicationRoles.Add(included);
            //}

            //this.ExcludedEntityApplicationRoles = e.ExcludedEntityApplicationRoles.ToObservableCollection();
            //this.ExcludedEntityApplicationRoles = new List<gcsRole>();
            //foreach (var excluded in e.ExcludedEntityApplicationRoles)
            //{
            //    ExcludedEntityApplicationRoles.Add(excluded);
            //}
            this.IsAuthorized = e.IsAuthorized;
            //this.RoleCollectionsMode = e.RoleCollectionsMode;
            //this.AllRoles = e.AllRoles.ToObservableCollection();
            //this.AuthorizedRoles = e.AuthorizedRoles.ToObservableCollection();
            //this.UnauthorizedRoles = e.UnauthorizedRoles.ToObservableCollection();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this gcsApplication. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsApplication to process. </param>
        ///
        /// <returns>   A copy of this gcsApplication. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsApplication Clone(gcsApplication e)
        {
            return new gcsApplication(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this gcsApplication is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(gcsApplication other)
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

        public bool IsPrimaryKeyEqual(gcsApplication other)
        {
            if (other == null)
                return false;

            if (other.ApplicationId != this.ApplicationId)
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return ApplicationName;
        }

        // Custom Properties

        //private ObservableCollection<gcsRole> _IncludedEntityApplicationRoles = new ObservableCollection<gcsRole>();

        //[DataMember]
        //public ObservableCollection<gcsRole> IncludedEntityApplicationRoles
        //{
        //    get { return _IncludedEntityApplicationRoles; }
        //    set
        //    {
        //        if (_IncludedEntityApplicationRoles == null || _IncludedEntityApplicationRoles.Equals(value) == false)
        //        {
        //            _IncludedEntityApplicationRoles = value;
        //            OnPropertyChanged(() => IncludedEntityApplicationRoles);
        //        }
        //    }
        //}

        //private ObservableCollection<gcsRole> _ExcludedEntityApplicationRoles = new ObservableCollection<gcsRole>();

        //[DataMember]
        //public ObservableCollection<gcsRole> ExcludedEntityApplicationRoles
        //{
        //    get { return _ExcludedEntityApplicationRoles; }
        //    set
        //    {
        //        if (_ExcludedEntityApplicationRoles == null || _ExcludedEntityApplicationRoles.Equals(value) == false)
        //        {
        //            _ExcludedEntityApplicationRoles = value;
        //            OnPropertyChanged(() => ExcludedEntityApplicationRoles);
        //        }
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent role data collections modes. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public enum RoleDataCollectionsMode { ForApplication, ForEntity, ForUser }

        ///// <summary>   all roles. </summary>
        //private ObservableCollection<gcsRole> _allRoles = new ObservableCollection<gcsRole>();
        /// <summary>   The collections mode. </summary>
        //private RoleDataCollectionsMode _collectionsMode;
        /// <summary>   True if this gcsApplication is authorized. </summary>
        private bool _isAuthorized;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this gcsApplication is authorized. </summary>
        ///
        /// <value> True if this gcsApplication is authorized, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsAuthorized
        {
            get { return _isAuthorized; }
            set
            {
                if (_isAuthorized != value)
                {
                    _isAuthorized = value;
                    OnPropertyChanged(() => IsAuthorized);
                }
            }
        }

        //public object AllRoles { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the role collections mode. </summary>
        /////
        ///// <value> The role collections mode. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public RoleDataCollectionsMode RoleCollectionsMode
        //{
        //    get { return _collectionsMode; }
        //    set
        //    {
        //        if (_collectionsMode != value)
        //        {
        //            _collectionsMode = value;
        //            OnPropertyChanged(() => RoleCollectionsMode);
        //        }
        //    }
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets all roles. </summary>
        /////
        ///// <value> all roles. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public ObservableCollection<gcsRole> AllRoles
        //{
        //    get { return _allRoles; }
        //    set
        //    {
        //        if (_allRoles != value)
        //        {
        //            _allRoles = value;
        //            OnPropertyChanged(() => AllRoles);
        //        }
        //    }
        //}
    }
}
