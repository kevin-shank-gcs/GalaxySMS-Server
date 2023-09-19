using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class InputOutputGroup_PanelLoadData : ObjectBase
    {
        public Guid InputOutputGroupUid { get; set; }
        public string InputOutputGroupName { get; set; }
        public int IOGroupNumber { get; set; }
        public int PanelScheduleNumber { get; set; }
        public bool LocalIOGroup { get; set; }
        public string TimeScheduleName { get; set; }
        public string EntityName { get; set; }
        public Guid EntityId { get; set; }
        public Guid ClusterUid { get; set; }
        public int ClusterGroupId { get; set; }
        public int ClusterNumber { get; set; }
        public string ClusterName { get; set; }
    }
}
