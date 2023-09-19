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
	public partial class ClusterType
    {
        public ClusterType()
        {
            Initialize();
        }

        public ClusterType(ClusterType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            //this.Clusters = new HashSet<Cluster>();
            //this.ClusterTypeClusterCommands = new HashSet<ClusterTypeClusterCommand>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(ClusterType e)
        {
            Initialize();
            if (e == null)
                return;
            this.ClusterTypeUid = e.ClusterTypeUid;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.TypeCode = e.TypeCode;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            //this.Clusters = e.Clusters.ToCollection();
            //this.ClusterTypeClusterCommands = e.ClusterTypeClusterCommands.ToCollection();
   
            // Common table properties
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

            // IHasDisplayResource & IHasDescriptionResource members
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
        }

        public ClusterType Clone(ClusterType e)
        {
            return new ClusterType(e);
        }

        public bool Equals(ClusterType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(ClusterType other)
        {
            if (other == null)
                return false;

            if (other.ClusterTypeUid != this.ClusterTypeUid)
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

