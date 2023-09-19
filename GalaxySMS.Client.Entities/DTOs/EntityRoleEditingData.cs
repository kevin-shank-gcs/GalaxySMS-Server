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
    public class EntityRoleEditingData
    {
        public EntityRoleEditingData()
        {
            ApplicationPermissions = new HashSet<gcsApplicationPermissionsMinimal>();
            FilterData = new gcsEntityFilterData();
        }

        [DataMember]
        public Guid EntityId { get; set; }

        [DataMember]
        public ICollection<gcsApplicationPermissionsMinimal> ApplicationPermissions { get; set; }

        [DataMember]
        public gcsEntityFilterData FilterData { get; set; }

    }
}
