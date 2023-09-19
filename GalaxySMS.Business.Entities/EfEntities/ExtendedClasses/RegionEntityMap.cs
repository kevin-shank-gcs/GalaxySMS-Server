using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class RegionEntityMap
    {
        public RegionEntityMap()
        {
            Initialize();
        }

        public RegionEntityMap(RegionEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(RegionEntityMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.RegionEntityMapUid = e.RegionEntityMapUid;
            this.RegionUid = e.RegionUid;
            this.EntityId = e.EntityId;
            this.EntityMapPermissionLevelUid = e.EntityMapPermissionLevelUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public RegionEntityMap Clone(RegionEntityMap e)
        {
            return new RegionEntityMap(e);
        }

        public bool Equals(RegionEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RegionEntityMap other)
        {
            if (other == null)
                return false;

            if (other.RegionEntityMapUid != this.RegionEntityMapUid)
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
