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
	public partial class EntityMapPermissionLevel
    {
        public EntityMapPermissionLevel()
        {
            Initialize();
        }

        public EntityMapPermissionLevel(EntityMapPermissionLevel e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.RegionEntityMaps = new HashSet<RegionEntityMap>();
            this.SiteEntityMaps = new HashSet<SiteEntityMap>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(EntityMapPermissionLevel e)
        {
            Initialize();
            if (e == null)
                return;
            this.EntityMapPermissionLevelUid = e.EntityMapPermissionLevelUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Display = e.Display;
            this.Description = e.Description;
            this.CanView = e.CanView;
            this.CanEdit = e.CanEdit;
            this.CanAdd = e.CanAdd;
            this.CanDelete = e.CanDelete;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.RegionEntityMaps = e.RegionEntityMaps.ToCollection();
            this.SiteEntityMaps = e.SiteEntityMaps.ToCollection();

        }

        public EntityMapPermissionLevel Clone(EntityMapPermissionLevel e)
        {
            return new EntityMapPermissionLevel(e);
        }

        public bool Equals(EntityMapPermissionLevel other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(EntityMapPermissionLevel other)
        {
            if (other == null)
                return false;

            if (other.EntityMapPermissionLevelUid != this.EntityMapPermissionLevelUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
