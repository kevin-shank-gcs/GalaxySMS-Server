using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls.Docking;

namespace GalaxySMS.TelerikWPF.Infrastructure
{
    public interface IPaneModel
    {
        DockState DockPosition { get; set;}
    }
}
