//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GalaxySMS.Business.Entities
//{
//    public partial class gcsEntity
//    {
//        public gcsUserRequirement UserRequirements { get; set; }
//    }
//}
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class gcsEntity
    {        
        public gcsEntity()
        {
            Initialize();
        }

        public gcsEntity(gcsEntity e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.gcsUserEntities = new HashSet<gcsUserEntity>();
            this.gcsEntityApplications = new HashSet<gcsEntityApplication>();
            this.UserRequirements = new gcsUserRequirement();
            this.gcsBinaryResource = new gcsBinaryResource();
            this.ChildEntities = new HashSet<gcsEntity>();
        }

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
            this.License = e.License;
            this.PublicKey = e.PublicKey;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.gcsUserEntities = e.gcsUserEntities.ToCollection();
            this.gcsEntityApplications = e.gcsEntityApplications.ToCollection();
            if( e.gcsBinaryResource != null)
                this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            if (e.ParentEntity != null)
                this.ParentEntity = new gcsEntity(e.ParentEntity);
            if (e.ChildEntities != null)
                this.ChildEntities = e.ChildEntities.ToCollection();
        }

        public gcsEntity Clone(gcsEntity e)
        {
            return new gcsEntity(e);
        }

        public bool Equals(gcsEntity other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsEntity other)
        {
            if (other == null)
                return false;

            if (other.EntityId != this.EntityId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.EntityName;
        }

        public gcsUserRequirement UserRequirements { get; set; }


    // Custom properties   
        public enum DataCollectionsMode { ForEntity, ForUser }

        private ICollection<gcsApplication> _allApplications = new HashSet<gcsApplication>();
        public bool IsAuthorized { get; set; }
        
        public DataCollectionsMode CollectionsMode { get; set; }

        public ICollection<gcsApplication> AllApplications
        {
            get { return _allApplications; }
            set { _allApplications = value; }
        }
       
    }
}