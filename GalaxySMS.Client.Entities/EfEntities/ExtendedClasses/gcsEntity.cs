////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\gcsEntity.cs
//
// summary:	Implements the gcs entity class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Constants;
using GCS.Core.Common.Extensions;
using GCS.Framework.Licensing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The gcs entity. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class gcsEntity
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsEntity()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsEntity to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsEntity(gcsEntity e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsEntity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            //this.gcsUserEntities = new HashSet<gcsUserEntity>();
            //this.gcsEntityApplications = new HashSet<gcsEntityApplication>();
            //this.AllApplications = new ObservableCollection<gcsApplication>();
            this.gcsBinaryResource = new gcsBinaryResource();
            this.EntityName = string.Empty;
            this.EntityDescription = string.Empty;
            this.EntityKey = string.Empty;
            this.License = string.Empty;
            this.PublicKey = string.Empty;
            this.Settings = new ObservableCollection<gcsSetting>();
            this.AllRoles = new ObservableCollection<gcsRole>();
            this.EntityType = string.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsEntity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsEntity to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(gcsEntity e)
        {
            Initialize();
            if (e == null)
                return;
            this.EntityId = e.EntityId;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.ParentEntityId = e.ParentEntityId;
            this.EntityName = e.EntityName;
            this.EntityDescription = e.EntityDescription;
            this.EntityKey = e.EntityKey;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.EntityType = e.EntityType;
            this.AutoMapTimeSchedules = e.AutoMapTimeSchedules;
            this.ClusterGroupId = e.ClusterGroupId;
            this.TimeZoneId = e.TimeZoneId;
            this.License = e.License;
            this.PublicKey = e.PublicKey;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //this.gcsUserEntities = e.gcsUserEntities.ToCollection();
            //this.gcsEntityApplications = e.gcsEntityApplications.ToCollection();
            if (e.gcsBinaryResource != null)
                this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            this.UserRequirements = new gcsUserRequirement(e.UserRequirements);
            if (e.ParentEntity != null)
                this.ParentEntity = new gcsEntity(e.ParentEntity);

            // Custom properties
            this.IsAuthorized = e.IsAuthorized;
            this.CollectionsMode = e.CollectionsMode;
            //this.AllApplications = e.AllApplications.ToObservableCollection();
            if (e.Settings != null)
                this.Settings = e.Settings.ToObservableCollection();
            if (e.AllRoles != null)
                this.AllRoles = e.AllRoles.ToObservableCollection();

            this.TotalRowCount = e.TotalRowCount;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this gcsEntity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The Region to process. </param>
        ///
        /// <returns>   A copy of this gcsEntity. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsEntity Clone(gcsEntity e)
        {
            return new gcsEntity(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this Region is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(gcsEntity other)
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

        public bool IsPrimaryKeyEqual(gcsEntity other)
        {
            if (other == null)
                return false;

            if (other.EntityId != this.EntityId)
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

        /// <summary>   The user requirements. </summary>
        private gcsUserRequirement _userRequirements = new gcsUserRequirement();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user requirements. </summary>
        ///
        /// <value> The user requirements. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public gcsUserRequirement UserRequirements
        {
            get { return _userRequirements; }
            set
            {
                if (_userRequirements != value)
                {
                    _userRequirements = value;
                    OnPropertyChanged(() => UserRequirements);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Custom properties. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum DataCollectionsMode { ForEntity, ForUser }

        /// <summary>   all applications. </summary>
        private ObservableCollection<gcsApplication> _allApplications = new ObservableCollection<gcsApplication>();
        /// <summary>   The unauthorized applications. </summary>
        private ObservableCollection<gcsApplication> _unauthorizedApplications = new ObservableCollection<gcsApplication>();
        /// <summary>   The authorized applications. </summary>
        private ObservableCollection<gcsApplication> _authorizedApplications = new ObservableCollection<gcsApplication>();
        /// <summary>   True if this gcsEntity is authorized. </summary>
        private bool _isAuthorized;
        /// <summary>   The collections mode. </summary>
        private DataCollectionsMode _collectionsMode;

        /// <summary>   The entity license. </summary>
        private LicenseData _entityLicense;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this gcsEntity is authorized. </summary>
        ///
        /// <value> True if this gcsEntity is authorized, false if not. </value>
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

        private bool _UserIsAdministrator;

        public bool UserIsAdministrator
        {
            get { return _UserIsAdministrator; }
            set
            {
                if (_UserIsAdministrator != value)
                {
                    _UserIsAdministrator = value;
                    OnPropertyChanged(() => UserIsAdministrator, true);
                }
            }
        }

        private bool _UserInheritParentRoles;

        public bool InheritParentRoles
        {
            get { return _UserInheritParentRoles; }
            set
            {
                if (_UserInheritParentRoles != value)
                {
                    _UserInheritParentRoles = value;
                    OnPropertyChanged(() => InheritParentRoles, true);
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the collections mode. </summary>
        ///
        /// <value> The collections mode. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public DataCollectionsMode CollectionsMode
        {
            get { return _collectionsMode; }
            set
            {
                if (_collectionsMode != value)
                {
                    _collectionsMode = value;
                    OnPropertyChanged(() => CollectionsMode);
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets all applications. </summary>
        /////
        ///// <value> all applications. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public ObservableCollection<gcsApplication> AllApplications
        //{
        //    get { return _allApplications; }
        //    set
        //    {
        //        if (_allApplications != value)
        //        {
        //            _allApplications = value;
        //            OnPropertyChanged(() => AllApplications);
        //        }
        //    }
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Not a DataMember. </summary>
        ///
        /// <value> The photo. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public byte[] Photo
        {
            get
            {
                if (gcsBinaryResource != null)
                    return gcsBinaryResource.BinaryResource;
                return null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the photo base 64 string. </summary>
        ///
        /// <value> The photo base 64 string. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PhotoBase64String
        {
            get
            {
                if (gcsBinaryResource != null)
                    return Convert.ToBase64String(gcsBinaryResource.BinaryResource);
                return string.Empty;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the name of the parent entity. </summary>
        ///
        /// <value> The name of the parent entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ParentEntityName
        {
            get { return ParentEntity?.EntityName; }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the entity license. </summary>
        ///
        /// <value> The entity license. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public LicenseData EntityLicense
        {
            get { return _entityLicense; }
            set
            {
                if (_entityLicense != value)
                {
                    _entityLicense = value;
                    OnPropertyChanged(() => EntityLicense, true);
                }
            }
        }

        private void InitEntityLicenseFromString()
        {
            EntityLicense = new LicenseData();
            if (!string.IsNullOrEmpty(PublicKey) && !string.IsNullOrEmpty(License))
                EntityLicense.InitializeFromXmlString(PublicKey, License);
        }

        public bool AccessProfileControlsAG1
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup1);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup1);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsAccessGroup1
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
                OnPropertyChanged(() => AccessProfileControlsAG1, true);
            }
        }

        public bool AccessProfileControlsAG2
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup2);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup2);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsAccessGroup2
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
                OnPropertyChanged(() => AccessProfileControlsAG2, true);
            }
        }

        public bool AccessProfileControlsAG3
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup3);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup3);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsAccessGroup3
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
                OnPropertyChanged(() => AccessProfileControlsAG3, true);
            }
        }

        public bool AccessProfileControlsAG4
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup4);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsAccessGroup4);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsAccessGroup4
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
                OnPropertyChanged(() => AccessProfileControlsAG4, true);
            }
        }

        public bool AccessProfileControlsIO1
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup1);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup1);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsIOGroup1
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
                OnPropertyChanged(() => AccessProfileControlsIO1, true);
            }
        }

        public bool AccessProfileControlsIO2
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup2);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup2);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsIOGroup2
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
                OnPropertyChanged(() => AccessProfileControlsIO2, true);
            }
        }

        public bool AccessProfileControlsIO3
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup3);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup3);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsIOGroup3
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
                OnPropertyChanged(() => AccessProfileControlsIO3, true);
            }
        }

        public bool AccessProfileControlsIO4
        {
            get
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup4);
                if (setting == null)
                    return false;
                return setting.Value.ConvertTo<bool>(false);
            }
            set
            {
                var setting = Settings.FirstOrDefault(s => s.SettingGroup == gcsSettingGroup.gcsEntity &&
                s.SettingSubGroup == gcsSettingSubGroup.AccessProfile &&
                s.SettingKey == gcsSettingKey.ControlsIOGroup4);
                if (setting == null)
                {
                    setting = new gcsSetting()
                    {
                        SettingGroup = gcsSettingGroup.gcsEntity,
                        SettingSubGroup = gcsSettingSubGroup.AccessProfile,
                        SettingKey = gcsSettingKey.ControlsIOGroup4
                    };
                    Settings.Add(setting);
                }
                setting.Value = value.ToString();
                OnPropertyChanged(() => AccessProfileControlsIO4, true);
            }
        }


        private int _totalRowCount;

        [DataMember]
        public int TotalRowCount
        {
            get { return _totalRowCount; }
            set
            {
                if (_totalRowCount != value)
                {
                    _totalRowCount = value;
                    OnPropertyChanged(() => TotalRowCount, true);
                }
            }
        }

    }
}
