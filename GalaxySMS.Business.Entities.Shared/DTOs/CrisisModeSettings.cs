using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif

    public partial class CrisisModeSettings : ObjectBase
    {
		public CrisisModeSettings()
		{
		    ActivateInputOutputGroupNumber = new InputOutputGroupNumber();
		    ResetInputOutputGroupNumber = new InputOutputGroupNumber();
			AutoReset = false;
		}
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupNumber ActivateInputOutputGroupNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public InputOutputGroupNumber ResetInputOutputGroupNumber { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public bool AutoReset { get; set; }
	}
}
