//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Client.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using GCS.Core.Common.Core;
    using FluentValidation;
    using GCS.Core.Common.Contracts;
    using System.Collections.ObjectModel;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A region. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class Region : DbObjectBase, IHasBinaryResource, IHasEntityMappingList
    {
        /// <summary>   The region UID. </summary>
        private System.Guid _regionUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the region UID. </summary>
        ///
        /// <value> The region UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.Guid RegionUid
        {
            get { return _regionUid; }
            set
            {
                if (_regionUid != value)
                {
                    _regionUid = value;
                    OnPropertyChanged(() => RegionUid);
                }
            }
        }

        /// <summary>   Name of the region. </summary>
        private string _regionName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the region. </summary>
        ///
        /// <value> The name of the region. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string RegionName
        {
            get { return _regionName; }
            set
            {
                if (_regionName != value)
                {
                    _regionName = value;
                    OnPropertyChanged(() => RegionName);
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
            get { return RegionName; }
            set
            {
                if( Name != value)
                {
                    RegionName = value;
                    OnPropertyChanged(() => Name);
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

        /// <summary>   Identifier for the region. </summary>
        private string _regionId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the region. </summary>
        ///
        /// <value> The identifier of the region. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string RegionId
        {
            get { return _regionId; }
            set
            {
                if (_regionId != value)
                {
                    _regionId = value;
                    OnPropertyChanged(() => RegionId);
                }
            }
        }
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

        /// <summary>   List of identifiers for the entities. </summary>
        private ICollection<Guid> _entityIds;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a list of identifiers of the entities. </summary>
        ///
        /// <value> A list of identifiers of the entities. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual ICollection<Guid> EntityIds
        {
            get { return _entityIds; }
            set
            {
                if (_entityIds != value)
                {
                    _entityIds = value;
                    OnPropertyChanged(() => EntityIds);
                }
            }
        }

        /// <summary>   The mapped entities permission levels. </summary>
        private ICollection<EntityIdEntityMapPermissionLevel> _MappedEntitiesPermissionLevels;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the mapped entities permission levels. </summary>
        ///
        /// <value> The mapped entities permission levels. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels
        {
            get { return _MappedEntitiesPermissionLevels; }
            set
            {
                if (_MappedEntitiesPermissionLevels != value)
                {
                    _MappedEntitiesPermissionLevels = value;
                    OnPropertyChanged(() => MappedEntitiesPermissionLevels);
                }
            }
        }

    }

}
