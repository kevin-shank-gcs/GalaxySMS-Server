using GalaxySMS.Common.Enums;
using System;
using System.Runtime.Serialization;


#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif

    public class CpuHardwareAddress : ClusterAddress
    {
        public enum CpuNumber { None = 0, One = 1, Two = 2, Both = 3 }
        public enum SystemPanelAddress { None = 0, AllPanels = 255 }

        public CpuHardwareAddress() : base()
        {
        }

        public CpuHardwareAddress(CpuHardwareAddress o) : base(o)
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

        public CpuHardwareAddress(Int32 clusterNumber, Int32 panelNumber, Int16 cpuId, int clusterGroupId) : base(clusterNumber)
        {
            ClusterNumber = clusterNumber;
            PanelNumber = panelNumber;
            CpuId = cpuId;
            ClusterGroupId = clusterGroupId;
        }

        public new String UniqueId { get { return string.Format("{0}:{1:D5}:{2:D5}:{3:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId); } }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Int32 PanelNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Int16 CpuId { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CpuModel CpuModel { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CpuUid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PanelUid { get; set; }

        //public CpuHardwareAddress CpuAddress { get { return this; } set { } }

        public override string ToString()
        {
            return UniqueId;
        }
    }

#if NetCoreApi
#else
    [DataContract]
#endif

    public class CpuHardwareAddressSimple : ClusterAddressSimple
    {
        public enum CpuNumber { None = 0, One = 1, Two = 2, Both = 3 }
        public enum SystemPanelAddress { None = 0, AllPanels = 255 }

        public CpuHardwareAddressSimple() : base()
        {
        }
        public CpuHardwareAddressSimple(CpuHardwareAddress o) : base(o)
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


        public CpuHardwareAddressSimple(CpuHardwareAddressSimple o) : base(o)
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

        public CpuHardwareAddressSimple(Int32 clusterNumber, Int32 panelNumber, Int16 cpuId, int clusterGroupId) : base(clusterNumber)
        {
            ClusterNumber = clusterNumber;
            PanelNumber = panelNumber;
            CpuId = cpuId;
            ClusterGroupId = clusterGroupId;
        }

        //public new String UniqueId { get { return string.Format("{0}:{1:D5}:{2:D5}:{3:D}", ClusterGroupId, ClusterNumber, PanelNumber, CpuId); } }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Int32 PanelNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Int16 CpuId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public CpuModel CpuModel { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PanelUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CpuUid { get; set; }
        //public CpuHardwareAddress CpuAddress { get { return this; } set { } }
        // 
    }
}
