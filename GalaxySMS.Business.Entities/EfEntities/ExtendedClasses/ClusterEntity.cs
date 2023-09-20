using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class ClusterEntityMap
    {
        public ClusterEntityMap()
        {
            Initialize();
        }

        public ClusterEntityMap(ClusterEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(ClusterEntityMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.ClusterEntityMapUid = e.ClusterEntityMapUid;
            this.ClusterUid = e.ClusterUid;
            this.EntityId = e.EntityId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public ClusterEntityMap Clone(ClusterEntityMap e)
        {
            return new ClusterEntityMap(e);
        }

        public bool Equals(ClusterEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(ClusterEntityMap other)
        {
            if (other == null)
                return false;

            if (other.ClusterEntityMapUid != this.ClusterEntityMapUid)
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
