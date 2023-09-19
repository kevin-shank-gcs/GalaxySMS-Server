using System;
using Telerik.Windows.Controls.Docking;

namespace GalaxySMS.TelerikWPF.Infrastructure
{
    public interface IPaneViewModel
    {
        string PrismRegionName { get; set; }
        string Header { get; set; }
        DockState DockPosition { get; set; }
        bool IsActive { get; set; }
        bool IsHidden { get; set; }
        bool IsDocument { get; set; }
        Type ContentType { get; }
        string TypeName { get; set; }
        object Content { get; set; }
    }
}