
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
	public partial class ClusterInputOutputGroup
    {
        public ClusterInputOutputGroup()
        {
            Initialize();
        }

        public ClusterInputOutputGroup(ClusterInputOutputGroup e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(ClusterInputOutputGroup e)
        {
            Initialize();
            if (e == null)
                return;
            this.ClusterInputOutputGroupUid = e.ClusterInputOutputGroupUid;
            this.ClusterUid = e.ClusterUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.Tag = e.Tag;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            
            // IHasDisplayResource & IHasDescriptionResource members
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;

        }

        public ClusterInputOutputGroup Clone(ClusterInputOutputGroup e)
        {
            return new ClusterInputOutputGroup(e);
        }

        public bool Equals(ClusterInputOutputGroup other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(ClusterInputOutputGroup other)
        {
            if (other == null)
                return false;

            if (other.ClusterInputOutputGroupUid != this.ClusterInputOutputGroupUid)
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
