using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls.Docking;

namespace GCS.Core.Common.UI.Interfaces
{
    public interface IPaneModel
    {
        DockState Position { get; set;}
    }
}
