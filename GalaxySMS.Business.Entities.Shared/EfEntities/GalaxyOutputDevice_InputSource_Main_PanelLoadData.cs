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

    public partial class GalaxyOutputDevice_InputSource_Main_PanelLoadData : ObjectBase
    {
        #region Public Properties
        public Guid OutputDeviceUid { get; set; }
        public Guid GalaxyOutputDeviceInputSourceUid { get; set; }
        public Guid GalaxyOutputInputSourceTriggerConditionUid { get; set; }
        public Guid GalaxyOutputInputSourceModeUid { get; set; }
        public Guid InputOutputGroupUid { get; set; }
        public short SourceNumber { get; set; }
        public bool InputOutputGroupMode { get; set; }
        public short TriggerConditionCode { get; set; }
        public string TriggerConditionDisplay { get; set; }
        public short SourceModeCode { get; set; }
        public string SourceModeDisplay { get; set; }
        public int IOGroupNumber { get; set; }
        public string IOGroupDisplay { get; set; }
        public ICollection<GalaxyOutputDevice_InputSource_Assignments_PanelLoadData> Assignments { get; set; }
        public ICollection<GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData> InputOutputGroups { get; set; }

        #endregion
    }
}
