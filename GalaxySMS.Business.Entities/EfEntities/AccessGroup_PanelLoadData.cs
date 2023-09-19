using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessGroup_PanelLoadData : ObjectBase
    {
        #region Public Properties
        public Guid AccessGroupUid { get; set; }
        public Guid ClusterUid { get; set; }
        public string AccessGroupName { get; set; }
        public int ClusterGroupId { get; set; }
        public int ClusterNumber { get; set; }
        public int AccessGroupNumber { get; set; }
        public DateTimeOffset ActivationDate { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public bool? IsEnabled { get; set; }
        public Guid CrisisModeAccessGroupUid { get; set; }
        public string CrisisModeAccessGroupName { get; set; }
        public int CrisisModeAccessGroupNumber { get; set; }

        public ICollection<AccessGroupAccessPortal_PanelLoadData> AccessGroupData { get; set; }
        #endregion

    }
}
