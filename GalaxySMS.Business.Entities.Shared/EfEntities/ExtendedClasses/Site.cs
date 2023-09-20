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
    public partial class Site
    {
        public Site()
        {
            Initialize();
        }

        public Site(Site e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.Address = new Address();
            this.Region = new Region();
            this.EntityIds = new HashSet<Guid>();
            this.RoleIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            //this.Clusters = new HashSet<Cluster>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(Site e)
        {
            Initialize();
            if (e == null)
                return;
            this.SiteUid = e.SiteUid;
            this.RegionUid = e.RegionUid;
            this.SiteName = e.SiteName;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.SiteId = e.SiteId;
            this.EntityId = e.EntityId;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.AddressUid = e.AddressUid;
            this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            this.Address = new Address(e.Address);
            this.Region = new Region(e.Region);
            //this.Clusters = e.Clusters.ToCollection();

            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();

            if (e.RoleIds != null)
                this.RoleIds = e.RoleIds.ToCollection();

            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
        }

        public Site Clone(Site e)
        {
            return new Site(e);
        }

        public bool Equals(Site other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Site other)
        {
            if (other == null)
                return false;

            if (other.SiteUid != this.SiteUid)
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
                Uid = SiteUid,
                EntityId = EntityId,
                Name = SiteName,
                KeyValue = SiteId,
                Image = gcsBinaryResource?.BinaryResource
            };
        }

    }
}
