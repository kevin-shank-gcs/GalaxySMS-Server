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
	public partial class ClusterLedBehaviorMode
    {
        public ClusterLedBehaviorMode()
        {
            Initialize();
        }

        public ClusterLedBehaviorMode(ClusterLedBehaviorMode e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(ClusterLedBehaviorMode e)
        {
            Initialize();
            if (e == null)
                return;
            this.ClusterLedBehaviorModeUid = e.ClusterLedBehaviorModeUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.LedBehaviorCode = e.LedBehaviorCode;
            this.Display = e.Display;
            this.Description = e.Description;
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public ClusterLedBehaviorMode Clone(ClusterLedBehaviorMode e)
        {
            return new ClusterLedBehaviorMode(e);
        }

        public bool Equals(ClusterLedBehaviorMode other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(ClusterLedBehaviorMode other)
        {
            if (other == null)
                return false;

            if (other.ClusterLedBehaviorModeUid != this.ClusterLedBehaviorModeUid)
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
