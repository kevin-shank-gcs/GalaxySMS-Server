using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class ClusterTypeClusterCommand
    {
        public ClusterTypeClusterCommand()
        {
            Initialize();
        }

        public ClusterTypeClusterCommand(ClusterTypeClusterCommand e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(ClusterTypeClusterCommand e)
        {
            Initialize();
            if (e == null)
                return;
            this.ClusterTypeClusterCommandUid = e.ClusterTypeClusterCommandUid;
            this.ClusterTypeUid = e.ClusterTypeUid;
            this.ClusterCommandUid = e.ClusterCommandUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public ClusterTypeClusterCommand Clone(ClusterTypeClusterCommand e)
        {
            return new ClusterTypeClusterCommand(e);
        }

        public bool Equals(ClusterTypeClusterCommand other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(ClusterTypeClusterCommand other)
        {
            if (other == null)
                return false;

            if (other.ClusterTypeClusterCommandUid != this.ClusterTypeClusterCommandUid)
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
