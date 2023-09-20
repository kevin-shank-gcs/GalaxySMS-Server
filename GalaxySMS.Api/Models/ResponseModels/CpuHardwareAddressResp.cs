using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{
    public class CpuHardwareAddressResp : ClusterAddressResp
    {
        public enum CpuNumber { None = 0, One = 1, Two = 2, Both = 3 }
        public enum SystemPanelAddress { None = 0, AllPanels = 255 }

        public CpuHardwareAddressResp() : base()
        {
        }

        public CpuHardwareAddressResp(CpuHardwareAddressResp o) : base(o)
        {
            if (o != null)
            {
                PanelNumber = o.PanelNumber;
                CpuId = o.CpuId;
                CpuModel = o.CpuModel;
                ClusterGroupId = o.ClusterGroupId;
                CpuUid = o.CpuUid;
                PanelUid = o.PanelUid;
            }
        }

        public CpuHardwareAddressResp(Int32 clusterNumber, Int32 panelNumber, Int16 cpuId, int clusterGroupId) : base(clusterNumber)
        {
            ClusterNumber = clusterNumber;
            PanelNumber = panelNumber;
            CpuId = cpuId;
            ClusterGroupId = clusterGroupId;
        }

        public new String UniqueId { get { return string.Format("{0}:{1:D5}:{2:D5}:{3:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId); } }

        public Int32 PanelNumber { get; set; }

        public Int16 CpuId { get; set; }

        public CpuModel CpuModel { get; set; }
        public Guid CpuUid { get; set; }
        public Guid PanelUid { get; set; }

        public CpuHardwareAddressResp CpuAddress { get { return this; } set { } }

        public override string ToString()
        {
            return UniqueId;
        }
    }
}
