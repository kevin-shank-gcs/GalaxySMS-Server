using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Interfaces
{
    //public interface IGalaxyClusterAddress
    //{
    //    int ClusterGroupId { get; set; }
    //    int ClusterNumber {get; set;}
    //}


    //public interface IHasGalaxyHardwareAddress
    //{
    //    int ClusterGroupId { get; set; }
    //    int ClusterNumber {get; set;}
    //    int PanelNumber {get;set;}
    //    int BoardNumber {get;set;}
    //    int SectionNumber {get;set;}
    //}

    public interface IClusterAddress
    {
        int ClusterGroupId {get;set;}
        Int32 ClusterNumber {get;set;}
    }

    public interface IPanelHardwareAddress : IClusterAddress
    {
        Int32 PanelNumber {get;set;}
    }

    public interface ICpuHardwareAddress : IPanelHardwareAddress
    {
        Int16 CpuId {get;set;}
    }

    public interface IBoardHardwareAddress : IPanelHardwareAddress
    {
        Int32 BoardNumber {get;set;}
    }

    public interface IBoardSectionHardwareAddress :IBoardHardwareAddress
    {
        Int32 SectionNumber {get;set;}

    }

    public interface IBoardSectionNodeHardwareAddress : IBoardSectionHardwareAddress
    {
        Int32 NodeNumber {get;set;}
    }
}
