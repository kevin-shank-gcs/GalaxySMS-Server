using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

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
    public partial class AccessGroup_PanelLoadDataChanges : AccessGroup_PanelLoadData
    {
        #region Public Properties
        public int PanelNumber { get; set; }
        public Guid GalaxyPanelUid {get; set;}
        public short CpuNumber { get; set; }
        public Guid CpuUid { get; set; }
        public Guid AccessGroupLoadToCpuUid { get; set; }

        #endregion

    }
}
