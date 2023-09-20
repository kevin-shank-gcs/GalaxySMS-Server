using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GalaxySMS.Business.Entities
{
	public enum ActivityLoggingState { Off = 0, On = 1 }

	[DataContract]
    public class ActivityLoggingControl : EntityBase
	{


    }
}
