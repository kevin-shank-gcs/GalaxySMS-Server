
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class Cluster
    {
        public Cluster()
        {
            Initialize();
        }

        public Cluster(Cluster e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(Cluster e)
        {
            Initialize();
            if (e == null)
                return;
            this.ClusterUid = e.ClusterUid;
            this.SiteUid = e.SiteUid;
            this.ClusterNumber = e.ClusterNumber;
            this.ClusterName = e.ClusterName;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public Cluster Clone(Cluster e)
        {
            return new Cluster(e);
        }

        public bool Equals(Cluster other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Cluster other)
        {
            if (other == null)
                return false;

            if (other.ClusterUid != this.ClusterUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
