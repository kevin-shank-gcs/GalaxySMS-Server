using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    public class GalaxyTimePeriod_PanelLoadData
    {
        public GalaxyTimePeriod_PanelLoadData()
        {
            PanelLoadData = new List<GalaxyTimePeriod_GetPanelLoadData>();
        }
        public Guid GalaxyTimePeriodUid { get; set; }
        public Guid ClusterUid { get; set; }
        public IEnumerable<GalaxyTimePeriod_GetPanelLoadData> PanelLoadData { get; set; }

    }
}
