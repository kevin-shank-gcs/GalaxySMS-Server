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
	public partial class GalaxyCpu
    {
        public GalaxyCpu()
        {
            Initialize();
        }

        public GalaxyCpu(GalaxyCpu e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyCpu e)
        {
            Initialize();
            if (e == null)
                return;
            this.CpuUid = e.CpuUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.CpuNumber = e.CpuNumber;
            this.SerialNumber = e.SerialNumber;
            this.IpAddress = e.IpAddress;
            this.Model = e.Model;
            this.PreventFlashLoading = e.PreventFlashLoading;
            this.PreventDataLoading = e.PreventDataLoading;
            this.DefaultEventLoggingOn = e.DefaultEventLoggingOn;
            this.IsActive = e.IsActive;
            this.IsDirty = e.IsDirty;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.GalaxyCpuModelUid = e.GalaxyCpuModelUid;
            this.LastLogIndex = e.LastLogIndex;
            this.Version = e.Version;
        }

        public bool IsAnythingDirty
        {
            get
            {
                return IsDirty;
            }
        }

        public GalaxyCpu Clone(GalaxyCpu e)
        {
            return new GalaxyCpu(e);
        }

        public bool Equals(GalaxyCpu other)
        {
            if (this.ClusterGroupId != other.ClusterGroupId ||
                this.ClusterNumber != other.ClusterNumber ||
                this.CpuNumber != other.CpuNumber ||
                this.CpuUid != other.CpuUid ||
                this.DefaultEventLoggingOn != other.DefaultEventLoggingOn ||
                this.GalaxyCpuModel != other.GalaxyCpuModel ||
                this.GalaxyCpuModelUid != other.GalaxyCpuModelUid ||
                this.GalaxyPanelUid != other.GalaxyPanelUid ||
                this.IpAddress != other.IpAddress ||
                this.IsActive != other.IsActive ||
                this.LastLogIndex != other.LastLogIndex ||
                this.Model != other.Model ||
                this.PreventDataLoading != other.PreventDataLoading ||
                this.PreventFlashLoading != other.PreventFlashLoading ||
                this.SerialNumber != this.SerialNumber)
                return false;
            return true;
            //return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyCpu other)
        {
            if (other == null)
                return false;

            if (other.CpuUid != this.CpuUid)
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
