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
            this.UserEntities = new HashSet<gcsUserEntity>();
            this.EntityApplications = new HashSet<gcsEntityApplication>();
            this.UserRequirements = new gcsUserRequirement();
            this.gcsBinaryResource = new gcsBinaryResource();
        }

        public void Initialize(gcsEntity e)
        {
            Initialize();
            if (e == null)
                return;
            this.EntityId = e.EntityId;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.EntityName = e.EntityName;
            this.EntityDescription = e.EntityDescription;
            this.EntityKey = e.EntityKey;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.License = e.License;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.UserEntities = e.UserEntities.ToCollection();
            this.EntityApplications = e.EntityApplications.ToCollection();
            this.gcsBinaryResource = e.gcsBinaryResource;

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