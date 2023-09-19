using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;


#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData : ObjectBase
    {
        #region Public Properties
        public Guid GalaxyOutputDeviceInputSourceInputOutputGroupUid { get; set; }
        public Guid GalaxyOutputDeviceInputSourceUid { get; set; }
        public int IOGroupNumber { get; set; }
        public string IOGroupName { get; set; }
        #endregion

    }
}
