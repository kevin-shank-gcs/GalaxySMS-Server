using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{

    [DataContract]
    public class LoadDataToPanelSettings : ObjectBase
    {
        [DataMember]
        public bool ClusterSharedSettings { get; set; }

        [DataMember]
        public bool TimeSchedules { get; set; }

        [DataMember]
        public bool AllCardData { get; set; }

        [DataMember]
        public bool CardChanges { get; set; }

        [DataMember]
        public bool LoadIOGroups { get; set; }

        [DataMember]
        public bool AccessPortals { get; set; }

        [DataMember]
        public bool AccessRules { get; set; }

        [DataMember]
        public bool InputOutputDevices { get; set; }

        [DataMember]
        public bool PanelAlarms { get; set; }
    }
}
