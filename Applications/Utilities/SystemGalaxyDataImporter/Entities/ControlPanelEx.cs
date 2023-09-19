using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Entities;
using GCS.WebApi.SysGal.Entities;

namespace SystemGalaxyDataImporter.Entities
{
    public class ControlPanelEx : ControlPanel
    {
        public ControlPanelEx()
        {
            
        }

        public ControlPanelEx(ControlPanelEx o) : base(o)
        {
            if( o != null)
            {
                HasBeenImported = o.HasBeenImported;
                ClusterUid = o.ClusterUid;
                SmsPanel = o.SmsPanel;
            }
        }
        public ControlPanelEx(ControlPanel o) : base(o)
        {
        
        }
        public bool HasBeenImported { get; set; }
        public Guid ClusterUid { get; set; }
        public GalaxyPanel SmsPanel {get;set;}
    }

}
