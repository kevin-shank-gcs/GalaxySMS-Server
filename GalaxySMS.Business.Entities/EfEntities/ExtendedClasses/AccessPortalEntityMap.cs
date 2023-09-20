using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessPortalEntityMap
    {
        public AccessPortalEntityMap()
        {
            Initialize();
        }

        public AccessPortalEntityMap(AccessPortalEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(AccessPortalEntityMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.AccessPortalEntityMapUid = e.AccessPortalEntityMapUid;
            this.AccessPortalUid = e.AccessPortalUid;
            this.EntityId = e.EntityId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public AccessPortalEntityMap Clone(AccessPortalEntityMap e)
        {
            return new AccessPortalEntityMap(e);
        }

        public bool Equals(AccessPortalEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalEntityMap other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalEntityMapUid != this.AccessPortalEntityMapUid)
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
