using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.RequestModels
{
    public class CpuHardwareAddressReq : ClusterAddressReq
    {
        public CpuHardwareAddressReq() : base()
        {
        }

        public CpuHardwareAddressReq(CpuHardwareAddressReq o) : base(o)
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

        public CpuHardwareAddressReq(Int32 clusterNumber, Int32 panelNumber, Int16 cpuId, int clusterGroupId) : base(clusterNumber)
        {
            ClusterNumber = clusterNumber;
            PanelNumber = panelNumber;
            CpuId = cpuId;
            ClusterGroupId = clusterGroupId;
        }

        [Required]
        [Range(1, 65535)]
        public Int32 PanelNumber { get; set; }

        [Required]
        [Range(1,2)]
        public Int16 CpuId { get; set; }
       
        [Required]
        public CpuModel CpuModel { get; set; }

        public Guid CpuUid { get; set; }

        public Guid PanelUid { get; set; }
    }
}
