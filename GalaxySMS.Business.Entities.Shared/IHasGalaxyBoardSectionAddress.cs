////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	IHasGalaxyBoardSectionAddress.cs
//
// summary:	Declares the IHasGalaxyBoardSectionAddress interface
///=================================================================================================

using System;

namespace GalaxySMS.Business.Entities
{
    public interface IHasGalaxyBoardSectionAddress
    {
        int ClusterGroupId { get; set; }
        int ClusterNumber { get; set; }
        int PanelNumber { get; set; }
        short BoardNumber { get; set; }
        short SectionNumber { get; set; }

    }
}