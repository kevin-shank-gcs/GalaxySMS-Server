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
	public partial class SiteEntityMap
    {
        public SiteEntityMap()
        {
            Initialize();
        }

        public SiteEntityMap(SiteEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(SiteEntityMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.SiteEntityMapUid = e.SiteEntityMapUid;
            this.SiteUid = e.SiteUid;
            this.EntityId = e.EntityId;
            this.EntityMapPermissionLevelUid = e.EntityMapPermissionLevelUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public SiteEntityMap Clone(SiteEntityMap e)
        {
            return new SiteEntityMap(e);
        }

        public bool Equals(SiteEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(SiteEntityMap other)
        {
            if (other == null)
                return false;

            if (other.SiteEntityMapUid != this.SiteEntityMapUid)
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
