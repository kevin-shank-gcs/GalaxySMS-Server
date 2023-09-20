using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
	public partial class GalaxyPanelResetCommand : ObjectBase
    {
        [DataMember]
        public CpuResetType ResetType { get; set; }
    }
}
