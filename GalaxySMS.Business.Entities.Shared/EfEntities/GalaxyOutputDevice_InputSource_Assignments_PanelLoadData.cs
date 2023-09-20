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

    public partial class GalaxyOutputDevice_InputSource_Assignments_PanelLoadData : ObjectBase
    {
        #region Public Properties
        public Guid GalaxyOutputDeviceInputSourceAssignmentUid { get; set; }
        public Guid GalaxyOutputDeviceInputSourceUid { get; set; }
        public Guid InputOutputGroupAssignmentUid { get; set; }
        public short OffsetIndex { get; set; }
        public string DeviceName { get; set; }
        public string EventType { get; set; }
    }
    #endregion
}
