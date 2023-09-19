using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.WebApi.SysGal.Entities;

namespace SystemGalaxyDataImporter.Entities
{
    public class ClusterDataEx : ClusterData
    {
        public ClusterDataEx(ClusterData d) :base(d)
        {
            ControllersEx = new List<ControlPanelEx>();
            foreach( var c in Controllers)
            {
                ControllersEx.Add(new ControlPanelEx(c));
            }
        }

        public List<ControlPanelEx> ControllersEx { get; set; }
    }
}
