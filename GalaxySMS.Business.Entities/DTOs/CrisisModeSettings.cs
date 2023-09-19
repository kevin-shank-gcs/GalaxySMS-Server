using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GalaxySMS.Business.Entities
{
	[DataContract]
    public partial class CrisisModeSettings : ObjectBase
    {
		public CrisisModeSettings()
		{
		    ActivateInputOutputGroupNumber = new InputOutputGroupNumber();
		    ResetInputOutputGroupNumber = new InputOutputGroupNumber();
			AutoReset = false;
		}

		[DataMember]
		public InputOutputGroupNumber ActivateInputOutputGroupNumber { get; set; }

        [DataMember]
	    public InputOutputGroupNumber ResetInputOutputGroupNumber { get; set; }

        [DataMember]
		public bool AutoReset { get; set; }
	}
}
