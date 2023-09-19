using System;
using System.Collections.Generic;
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
	public partial class Region
    {
        public Region()
        {
            Initialize();
        }

        public Region(Region e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.gcsBinaryResource = new gcsBinaryResource();
            this.EntityIds = new HashSet<Guid>();
            this.RoleIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(Region e)
        {
            Initialize();
            if (e == null)
                return;
            this.RegionUid = e.RegionUid;
            this.RegionName = e.RegionName;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.RegionId = e.RegionId;
            this.EntityId = e.EntityId;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.gcsBinaryResource = e.gcsBinaryResource;
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();

            if (e.RoleIds != null)
                this.RoleIds = e.RoleIds.ToCollection();

            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
        }

        public Region Clone(Region e)
        {
            return new Region(e);
        }

        public bool Equals(Region other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Region other)
        {
            if (other == null)
                return false;

            if (other.RegionUid != this.RegionUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public ListItemBase ToListItemBase()
        {
            return new ListItemBase()
            {
                Uid = RegionUid,
                EntityId = EntityId,
                Name = RegionName,
                KeyValue = RegionId,
                Image = gcsBinaryResource?.BinaryResource
            };
        }
    }
}
