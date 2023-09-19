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
    using GCS.Core.Common.Contracts;
    using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A badge template. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class BadgeTemplate : DbObjectBase, ITableEntityBase, IHasEntityMappingList
    {

        /// <summary>   The badge template UID. </summary>
        private System.Guid _badgeTemplateUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the badge template UID. </summary>
        ///
        /// <value> The badge template UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.Guid BadgeTemplateUid
        {
            get { return _badgeTemplateUid; }
            set
            {
                if (_badgeTemplateUid != value)
                {
                    _badgeTemplateUid = value;
                    OnPropertyChanged(() => BadgeTemplateUid);
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

        /// <summary>   The badge system type UID. </summary>
        private Guid _BadgeSystemTypeUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the badge system type UID. </summary>
        ///
        /// <value> The badge system type UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid BadgeSystemTypeUid
        {
            get { return _BadgeSystemTypeUid; }
            set
            {
                if (_BadgeSystemTypeUid != value)
                {
                    _BadgeSystemTypeUid = value;
                    OnPropertyChanged(() => BadgeSystemTypeUid);
                }
            }
        }


        /// <summary>   Name of the template. </summary>
        private string _templateName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the template. </summary>
        ///
        /// <value> The name of the template. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string TemplateName
        {
            get { return _templateName; }
            set
            {
                if (_templateName != value)
                {
                    _templateName = value;
                    OnPropertyChanged(() => TemplateName);
                }
            }
        }

        /// <summary>   The description. </summary>
        private string _description;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(() => Description);
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

        /// <summary>   Identifier for the template. </summary>
        private string _templateId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the template. </summary>
        ///
        /// <value> The identifier of the template. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string TemplateId
        {
            get { return _templateId; }
            set
            {
                if (_templateId != value)
                {
                    _templateId = value;
                    OnPropertyChanged(() => TemplateId);
                }
            }
        }


        /// <summary>   The gcs entity. </summary>
        private gcsEntity _gcsEntity;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gcs entity. </summary>
        ///
        /// <value> The gcs entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual gcsEntity gcsEntity
        {
            get { return _gcsEntity; }
            set
            {
                if (_gcsEntity != value)
                {
                    _gcsEntity = value;
                    OnPropertyChanged(() => gcsEntity);
                }
            }
        }


        #region Implementation of IHasEntityMappingList

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
        #endregion

    }

}
