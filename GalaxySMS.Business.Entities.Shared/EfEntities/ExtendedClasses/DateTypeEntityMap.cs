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
	public partial class DateTypeEntityMap
    {
        public DateTypeEntityMap()
        {
            Initialize();
        }

        public DateTypeEntityMap(DateTypeEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(DateTypeEntityMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.DateTypeEntityMapUid = e.DateTypeEntityMapUid;
            this.DateTypeUid = e.DateTypeUid;
            this.EntityId = e.EntityId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public DateTypeEntityMap Clone(DateTypeEntityMap e)
        {
            return new DateTypeEntityMap(e);
        }

        public bool Equals(DateTypeEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(DateTypeEntityMap other)
        {
            if (other == null)
                return false;

            if (other.DateTypeEntityMapUid != this.DateTypeEntityMapUid)
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
