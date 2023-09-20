using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class gcsEntityFilterDataMinimal
    {
        public gcsEntityFilterDataMinimal()
        {
            ChildEntities = new HashSet<gcsEntityFilterDataMinimal>();
            Regions = new HashSet<RegionSelectionItemMinimal>();
        }

        public gcsEntityFilterDataMinimal(gcsEntity o)
        {
            EntityId = o.EntityId;
            EntityName = o.EntityName;
            EntityDescription = o.EntityDescription;
            ParentEntityId = o.ParentEntityId;  
            ParentEntityName = o.ParentEntityName;
            Photo = o.gcsBinaryResource?.BinaryResource;
            ChildEntities = new HashSet<gcsEntityFilterDataMinimal>();
            Regions = new HashSet<RegionSelectionItemMinimal>();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the unique identifier of the entity. </summary>
        ///
        /// <value> The unique identifier of the entity. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid EntityId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the entity. </summary>
        ///
        /// <value> The name of the entity. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string EntityDescription { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string EntityKey { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public bool IsDefault { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public bool IsActive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] Photo { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the parent entity. </summary>
        ///
        /// <value> The identifier of the parent entity. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> ParentEntityId { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public string ParentEntityName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Collection of child entities. </summary>
        ///
        /// <value> The child entities. </value>
        ///=================================================================================================
#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<gcsEntityFilterDataMinimal> ChildEntities { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif

        public ICollection<RegionSelectionItemMinimal> Regions { get; set; }

    }
}
