using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class BackgroundJobStateChangeInfo //: ObjectBase
    {

        public BackgroundJobStateChangeInfo()
        {
        }

        [DataMember]
        public DateTimeOffset ChangeDateTime { get; set; }

        [DataMember]
        public BackgroundJobState State { get; set; }

        [DataMember]
        public string Info { get; set; }
    }
}
