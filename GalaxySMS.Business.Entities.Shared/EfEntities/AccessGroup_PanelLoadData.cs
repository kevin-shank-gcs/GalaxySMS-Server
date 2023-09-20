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
    public partial class AccessGroup_PanelLoadData : ObjectBase
    {
        #region Public Properties
        public Guid AccessGroupUid { get; set; }
        public Guid ClusterUid { get; set; }
        public string AccessGroupName { get; set; }
        public int ClusterGroupId { get; set; }
        public int ClusterNumber { get; set; }
        public int AccessGroupNumber { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool? IsEnabled { get; set; }
        public Guid CrisisModeAccessGroupUid { get; set; }
        public string CrisisModeAccessGroupName { get; set; }
        public int CrisisModeAccessGroupNumber { get; set; }
        public DateTimeOffset CurrentTimeForCluster { get; set; }

        public ICollection<AccessGroupAccessPortal_PanelLoadData> AccessGroupData { get; set; }
        #endregion

    }
}
