////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AccessProfileEditingData.cs
//
// summary:	Implements the access profile editing data class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A access profile editing data. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class ApplicationRoleEditingData
    {
        public ApplicationRoleEditingData()
        {
            PermissionCategories = new HashSet<gcsPermissionCategoryBasic>();
            FilterData = new ApplicationRoleFilterData();
        }

        [DataMember]
        public Guid ApplicationId { get; set; }

        [DataMember]
        public ICollection<gcsPermissionCategoryBasic> PermissionCategories { get; set; }

        [DataMember]
        public ApplicationRoleFilterData FilterData { get; set; }

    }
}
