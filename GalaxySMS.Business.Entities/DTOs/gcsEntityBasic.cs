using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public partial class gcsEntityBasic 
    {
        public gcsEntityBasic()
        {

        }

        public gcsEntityBasic(gcsEntity e)
        {
            if( e == null)
                return;

            this.EntityId = e.EntityId;
            this.ParentEntityId = e.ParentEntityId;
            this.EntityName = e.EntityName;
            this.EntityDescription = e.EntityDescription;
            this.EntityKey = e.EntityKey;
            this.gcsBinaryResource = e.gcsBinaryResource;
            this.IsActive = e.IsActive;
            this.ParentEntityId = e.ParentEntityId;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityId { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the parent entity. </summary>
        ///
        /// <value> The identifier of the parent entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.Guid> ParentEntityId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the entity. </summary>
        ///
        /// <value> The name of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string EntityName { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the entity. </summary>
        ///
        /// <value> Information describing the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string EntityDescription { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the entity key. </summary>
        ///
        /// <value> The entity key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string EntityKey { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this gcsEntity is active. </summary>
        ///
        /// <value> True if this gcsEntity is active, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsActive { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gcs binary resource. </summary>
        ///
        /// <value> The gcs binary resource. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public gcsBinaryResource gcsBinaryResource {get; set;} 

    }

}
