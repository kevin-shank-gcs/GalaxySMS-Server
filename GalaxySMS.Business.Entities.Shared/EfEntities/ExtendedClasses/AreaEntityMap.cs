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
	public partial class AreaEntityMap
    {
        public AreaEntityMap()
        {
            Initialize();
        }

        public AreaEntityMap(AreaEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(AreaEntityMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.AreaEntityMapUid = e.AreaEntityMapUid;
            this.AreaUid = e.AreaUid;
            this.EntityId = e.EntityId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public AreaEntityMap Clone(AreaEntityMap e)
        {
            return new AreaEntityMap(e);
        }

        public bool Equals(AreaEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AreaEntityMap other)
        {
            if (other == null)
                return false;

            if (other.AreaEntityMapUid != this.AreaEntityMapUid)
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