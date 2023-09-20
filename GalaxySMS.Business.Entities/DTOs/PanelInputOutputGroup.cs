using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public class PanelInputOutputGroup : InputOutputGroupNumber
    {
        public PanelInputOutputGroup() :base()
        {
            
        }


        [DataMember]
        public short ScheduleNumber { get; set; }
        [DataMember]
        public bool LocalToPanel { get; set; }
	}
}
