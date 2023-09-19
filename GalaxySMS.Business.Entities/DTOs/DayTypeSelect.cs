using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    public class DayTypeSelect : DayType
    {
        public DayTypeSelect() :base()
        {
            Initialize();
        }

        public DayTypeSelect(DayType e) :base(e)
        {
            Initialize();
        }


        public DayTypeSelect(DayTypeSelect e) : base(e)
        {
            Initialize();
            Selected = e.Selected;
            ClusterDayTypeMap = e.ClusterDayTypeMap;
        }

        protected void Initialize()
        {
            base.Initialize();
            this.ClusterDayTypeMap = new GalaxyClusterDayTypeMap();
        }

        public bool Selected { get; set; }
        public GalaxyClusterDayTypeMap ClusterDayTypeMap { get; set; }
    }
}
