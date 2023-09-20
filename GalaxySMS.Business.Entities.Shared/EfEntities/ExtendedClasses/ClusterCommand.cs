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
	public partial class ClusterCommand
    {
        public ClusterCommand()
        {
            Initialize();
        }

        public ClusterCommand(ClusterCommand e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ClusterTypeClusterCommands = new HashSet<ClusterTypeClusterCommand>();
            this.ClusterTypeIds = new HashSet<Guid>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(ClusterCommand e)
        {
            Initialize();
            if (e == null)
                return;
            this.ClusterCommandUid = e.ClusterCommandUid;
            this.CommandCode = e.CommandCode;
            this.IsActive = e.IsActive;
            this.IsFlashingCommand = e.IsFlashingCommand;

            if (e.ClusterTypeClusterCommands != null)
                this.ClusterTypeClusterCommands = e.ClusterTypeClusterCommands.ToCollection();
            if (e.ClusterTypeIds != null)
                this.ClusterTypeIds = e.ClusterTypeIds.ToCollection();

            // Common table properties
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

        public ClusterCommand Clone(ClusterCommand e)
        {
            return new ClusterCommand(e);
        }

        public bool Equals(ClusterCommand other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(ClusterCommand other)
        {
            if (other == null)
                return false;

            if (other.ClusterCommandUid != this.ClusterCommandUid)
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

