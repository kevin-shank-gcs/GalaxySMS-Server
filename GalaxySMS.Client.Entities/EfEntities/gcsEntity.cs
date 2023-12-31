//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GCS.Framework.Licensing;

namespace GalaxySMS.Client.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using GCS.Core.Common.Core;
    using FluentValidation;
    using System.Collections.ObjectModel;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The gcs entity. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class gcsEntity : DbObjectBase, IHasBinaryResource
    {
        /// <summary>   Identifier for the entity. </summary>
        private System.Guid _entityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.Guid EntityId
        {
            get { return _entityId; }
            set
            {
                if (_entityId != value)
                {
                    _entityId = value;
                    OnPropertyChanged(() => EntityId);
                }
            }
        }

        /// <summary>   The binary resource UID. </summary>
        private Nullable<System.Guid> _binaryResourceUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the binary resource UID. </summary>
        ///
        /// <value> The binary resource UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.Guid> BinaryResourceUid
        {
            get { return _binaryResourceUid; }
            set
            {
                if (_binaryResourceUid != value)
                {
                    _binaryResourceUid = value;
                    OnPropertyChanged(() => BinaryResourceUid);
                }
            }
        }

        /// <summary>   Identifier for the parent entity. </summary>
        private Nullable<System.Guid> _parentEntityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the parent entity. </summary>
        ///
        /// <value> The identifier of the parent entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.Guid> ParentEntityId
        {
            get { return _parentEntityId; }
            set
            {
                if (_parentEntityId != value)
                {
                    _parentEntityId = value;
                    OnPropertyChanged(() => ParentEntityId);
                }
            }
        }


        /// <summary>   Name of the entity. </summary>
        private string _entityName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the entity. </summary>
        ///
        /// <value> The name of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string EntityName
        {
            get { return _entityName; }
            set
            {
                if (_entityName != value)
                {
                    _entityName = value;
                    OnPropertyChanged(() => EntityName);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Name
        {
            get { return EntityName; }
            set
            {
                if (Name != value)
                {
                    EntityName = value;
                    OnPropertyChanged(() => EntityName);
                }
            }
        }

        /// <summary>   Information describing the entity. </summary>
        private string _entityDescription;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the entity. </summary>
        ///
        /// <value> Information describing the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string EntityDescription
        {
            get { return _entityDescription; }
            set
            {
                if (_entityDescription != value)
                {
                    _entityDescription = value;
                    OnPropertyChanged(() => EntityDescription);
                }
            }
        }

        /// <summary>   The entity key. </summary>
        private string _entityKey;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the entity key. </summary>
        ///
        /// <value> The entity key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string EntityKey
        {
            get { return _entityKey; }
            set
            {
                if (_entityKey != value)
                {
                    _entityKey = value;
                    OnPropertyChanged(() => EntityKey);
                }
            }
        }

        /// <summary>   True if this gcsEntity is default. </summary>
        private bool _isDefault;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this gcsEntity is default. </summary>
        ///
        /// <value> True if this gcsEntity is default, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsDefault
        {
            get { return _isDefault; }
            set
            {
                if (_isDefault != value)
                {
                    _isDefault = value;
                    OnPropertyChanged(() => IsDefault);
                }
            }
        }

        /// <summary>   True if this gcsEntity is active. </summary>
        private bool _isActive;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this gcsEntity is active. </summary>
        ///
        /// <value> True if this gcsEntity is active, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    OnPropertyChanged(() => IsActive);
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

        /// <summary>   The license. </summary>
        private string _license;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the license. </summary>
        ///
        /// <value> The license. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string License
        {
            get { return _license; }
            set
            {
                if (_license != value)
                {
                    _license = value;
                    OnPropertyChanged(() => License);
                    if( !string.IsNullOrEmpty(PublicKey))
                    {
                        InitEntityLicenseFromString();
                    }
                }
            }
        }

        /// <summary>   The public key. </summary>
        private string _publicKey;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the public key. </summary>
        ///
        /// <value> The public key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string PublicKey
        {
            get { return _publicKey; }
            set
            {
                if (_publicKey != value)
                {
                    _publicKey = value;
                    OnPropertyChanged(() => PublicKey);
                    if( !string.IsNullOrEmpty(License))
                    {
                        InitEntityLicenseFromString();
                    }

                }
            }
        }


        /// <summary>   Type of the entity. </summary>
        private string _entityType;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type of the entity. </summary>
        ///
        /// <value> The type of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string EntityType
        {
            get { return _entityType; }
            set
            {
                if (_entityType != value)
                {
                    _entityType = value;
                    OnPropertyChanged(() => EntityType);
                }
            }
        }

        private bool _autoMapTimeSchedules;

        [DataMember]
        public bool AutoMapTimeSchedules
        {
            get { return _autoMapTimeSchedules; }
            set
            {
                if (_autoMapTimeSchedules != value)
                {
                    _autoMapTimeSchedules = value;
                    OnPropertyChanged(() => AutoMapTimeSchedules);
                }
            }
        }

        private int _clusterGroupId;

        [DataMember]
        public int ClusterGroupId
        {
            get { return _clusterGroupId; }
            set
            {
                if (_clusterGroupId != value)
                {
                    _clusterGroupId = value;
                    OnPropertyChanged(() => ClusterGroupId);
                }
            }
        }


        private string _timeZoneId;

        [DataMember]
        public string TimeZoneId
        {
            get { return _timeZoneId; }
            set
            {
                if (_timeZoneId != value)
                {
                    _timeZoneId = value;
                    OnPropertyChanged(() => TimeZoneId);
                }
            }
        }

        ///// <summary>   The gcs user entities. </summary>
        //private ICollection<gcsUserEntity> _gcsUserEntities;

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the gcs user entities. </summary>
        /////
        ///// <value> The gcs user entities. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public virtual ICollection<gcsUserEntity> gcsUserEntities
        //{
        //    get { return _gcsUserEntities; }
        //    set
        //    {
        //        if (_gcsUserEntities != value)
        //        {
        //            _gcsUserEntities = value;
        //            OnPropertyChanged(() => gcsUserEntities);
        //        }
        //    }
        //}

        ///// <summary>   The gcs entity applications. </summary>
        //private ICollection<gcsEntityApplication> _gcsEntityApplications;

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the gcs entity applications. </summary>
        /////
        ///// <value> The gcs entity applications. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //[DataMember]
        //public virtual ICollection<gcsEntityApplication> gcsEntityApplications
        //{
        //    get { return _gcsEntityApplications; }
        //    set
        //    {
        //        if (_gcsEntityApplications != value)
        //        {
        //            _gcsEntityApplications = value;
        //            OnPropertyChanged(() => gcsEntityApplications);
        //        }
        //    }
        //}

        /// <summary>   The gcs binary resource. </summary>
        private gcsBinaryResource _gcsBinaryResource;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gcs binary resource. </summary>
        ///
        /// <value> The gcs binary resource. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual gcsBinaryResource gcsBinaryResource
        {
            get { return _gcsBinaryResource; }
            set
            {
                if (_gcsBinaryResource != value)
                {
                    _gcsBinaryResource = value;
                    OnPropertyChanged(() => gcsBinaryResource);
                }
            }
        }

        /// <summary>   The parent entity. </summary>
        private gcsEntity _ParentEntity;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the parent entity. </summary>
        ///
        /// <value> The parent entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public gcsEntity ParentEntity
        {
            get { return _ParentEntity; }
            set
            {
                if (_ParentEntity != value)
                {
                    _ParentEntity = value;
                    OnPropertyChanged(() => ParentEntity, false);
                }
            }
        }

        /// <summary>   The child entities. </summary>
        private ICollection<gcsEntity> _childEntities;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the child entities. </summary>
        ///
        /// <value> The child entities. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual ICollection<gcsEntity> ChildEntities
        {
            get { return _childEntities; }
            set
            {
                if (_childEntities != value)
                {
                    _childEntities = value;
                    OnPropertyChanged(() => ChildEntities);
                }
            }
        }

        /// <summary>   True if this gcsEntity is selected. </summary>
        private bool isSelected;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this gcsEntity is selected. </summary>
        ///
        /// <value> True if this gcsEntity is selected, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                if (value != this.isSelected)
                {
                    this.isSelected = value;
                    OnPropertyChanged(() => IsSelected);
                }
            }
        }

        /// <summary>   True if this gcsEntity is expanded. </summary>
        private bool isExpanded;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this gcsEntity is expanded. </summary>
        ///
        /// <value> True if this gcsEntity is expanded, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsExpanded
        {
            get { return this.isExpanded; }
            set
            {
                if (value != this.isExpanded)
                {
                    this.isExpanded = value;
                    OnPropertyChanged(() => IsExpanded);
                }
            }
        }

        private License _theLicense;
        [DataMember]

        public License TheLicense
        {
            get { return _theLicense; }
            set
            {
                if (_theLicense != value)
                {
                    _theLicense = value;
                    OnPropertyChanged(() => TheLicense, true);
                }
            }
        }

        private ObservableCollection<gcsSetting> _gcsSettings;

        [DataMember]
        public ObservableCollection<gcsSetting> Settings
        {
            get { return _gcsSettings; }
            set
            {
                if (_gcsSettings != value)
                {
                    _gcsSettings = value;
                    OnPropertyChanged(() => Settings, true);
                }
            }
        }

        private ObservableCollection<gcsRole> _allRoles;

        [DataMember]
        public ObservableCollection<gcsRole> AllRoles
        {
            get { return _allRoles; }
            set
            {
                if (_allRoles != value)
                {
                    _allRoles = value;
                    OnPropertyChanged(() => AllRoles);
                }
            }
        }

    }

}
