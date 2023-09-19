////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AccessPortalListItem.cs
//
// summary:	Implements the access portal list item class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using System.Collections.ObjectModel;

namespace GalaxySMS.Client.Entities
{

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal list item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class ClusterTimeScheduleItem
    {
        public ClusterTimeScheduleItem()
        {
            Id = Guid.Empty;
            Name = string.Empty;
        }

        [DataMember]
        public System.Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Number { get; set; }

    }


}
