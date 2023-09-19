using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class gcsEntityBasic
    {
        public gcsEntityBasic()
        {
            Initialize();
        }

        public gcsEntityBasic(gcsEntity e)
        {
            Initialize(e);
        }
        public gcsEntityBasic(gcsEntityBasic e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ChildEntities = new HashSet<gcsEntityBasic>();
        }

        public void Initialize(gcsEntity e)
        {
            Initialize();
            if (e == null)
                return;
            this.EntityId = e.EntityId;
            this.ParentEntityId = e.ParentEntityId;
            this.EntityName = e.EntityName;
            this.EntityDescription = e.EntityDescription;
            this.EntityKey = e.EntityKey;
            this.EntityType = e.EntityType;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.ClusterGroupId = e.ClusterGroupId;
            this.TimeZoneId = e.TimeZoneId;
            this.ParentEntityName = e.ParentEntityName;
            if (e.gcsBinaryResource != null)
                this.Photo = e.gcsBinaryResource.BinaryResource;
            if (e.ParentEntity != null)
                this.ParentEntityName = e.ParentEntity.EntityName;
            if (e.ChildEntities != null)
            {
                foreach (var ce in e.ChildEntities)
                {
                    this.ChildEntities.Add(new gcsEntityBasic(ce));
                }
            }
        }
        public void Initialize(gcsEntityBasic e)
        {
            Initialize();
            if (e == null)
                return;
            this.EntityId = e.EntityId;
            this.ParentEntityId = e.ParentEntityId;
            this.EntityName = e.EntityName;
            this.EntityDescription = e.EntityDescription;
            this.EntityKey = e.EntityKey;
            this.EntityType = e.EntityType;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.Photo = e.Photo;
            this.ParentEntityName = e.ParentEntityName;
            if (e.ChildEntities != null)
                this.ChildEntities = e.ChildEntities.ToCollection();
        }

        public gcsEntityBasic Clone(gcsEntityBasic e)
        {
            return new gcsEntityBasic(e);
        }

        public bool Equals(gcsEntityBasic other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsEntityBasic other)
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
    }
}