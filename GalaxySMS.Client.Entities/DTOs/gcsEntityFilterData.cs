using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Framework.Licensing;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class gcsEntityFilterData
    {
        public gcsEntityFilterData()
        {
            ChildEntities = new HashSet<gcsEntityFilterData>();
            Regions = new HashSet<RegionSelectionItemBasic>();
        }

        public gcsEntityFilterData(gcsEntity o)
        {
            EntityId = o.EntityId;
            EntityName = o.EntityName;
            EntityDescription = o.EntityDescription;
            ParentEntityId = o.ParentEntityId;  
            ParentEntityName = o.ParentEntityName;
            Photo = o.gcsBinaryResource?.BinaryResource;
            ChildEntities = new HashSet<gcsEntityFilterData>();
            Regions = new HashSet<RegionSelectionItemBasic>();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unique identifier of the entity. </summary>
        ///
        /// <value> The unique identifier of the entity. </value>
        ///=================================================================================================

        [DataMember]
        public System.Guid EntityId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the entity. </summary>
        ///
        /// <value> The name of the entity. </value>
        ///=================================================================================================

        [DataMember]
        public string EntityName { get; set; }

        [DataMember]
        public string EntityDescription { get; set; }

//        [DataMember]
//        public string EntityKey { get; set; }

//        [DataMember]
//        public bool IsDefault { get; set; }

//        [DataMember]
//        public bool IsActive { get; set; }

        [DataMember]
        public byte[] Photo { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the parent entity. </summary>
        ///
        /// <value> The identifier of the parent entity. </value>
        ///=================================================================================================

        [DataMember]
        public Nullable<System.Guid> ParentEntityId { get; set; }


        [DataMember]
        public string ParentEntityName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Collection of child entities. </summary>
        ///
        /// <value> The child entities. </value>
        ///=================================================================================================
        [DataMember]
        public ICollection<gcsEntityFilterData> ChildEntities { get; set; }

        [DataMember]

        public ICollection<RegionSelectionItemBasic> Regions { get; set; }

    }
}
