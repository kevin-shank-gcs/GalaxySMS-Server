using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
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
        }

        public void Initialize(GalaxyCpu e)
        {
            Initialize();
            if (e == null)
                return;
            this.CpuUid = e.CpuUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
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
            if (this.ClusterNumber != other.ClusterNumber ||
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
