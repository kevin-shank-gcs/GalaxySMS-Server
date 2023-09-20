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
	public partial class AccessGroupEntityMap
    {
        public AccessGroupEntityMap()
        {
            Initialize();
        }

        public AccessGroupEntityMap(AccessGroupEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessGroupEntityMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.AccessGroupEntityMapUid = e.AccessGroupEntityMapUid;
            this.AccessGroupUid = e.AccessGroupUid;
            this.EntityId = e.EntityId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public AccessGroupEntityMap Clone(AccessGroupEntityMap e)
        {
            return new AccessGroupEntityMap(e);
        }

        public bool Equals(AccessGroupEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessGroupEntityMap other)
        {
            if (other == null)
                return false;

            if (other.AccessGroupEntityMapUid != this.AccessGroupEntityMapUid)
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