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

namespace GalaxySMS.Client.Entities
{

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal list item. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class OutputDeviceListItem : DeviceListItemBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public OutputDeviceListItem()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the alert event acknowledge. </summary>
        ///
        /// <value> Information describing the alert event acknowledge. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the identifier of the unique hardware. </summary>
        ///
        /// <value> The identifier of the unique hardware. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public new String UniqueHardwareId { get { return string.Format(UniqueHardwareAddressFormat.OutputDevice, ClusterGroupId, ClusterNumber, PanelNumber, BoardNumber, SectionNumber, NodeNumber); } }

        [DataMember]
        public bool IsBoundToHardware { get; set; }


    }

    [DataContract]
    public class OutputDeviceListItemCommands : ListItemBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public OutputDeviceListItemCommands()
        {
            Commands = new List<OutputCommand>();
        }


        [DataMember]
        public List<OutputCommand> Commands { get; set; }
    
        [DataMember]
        public bool IsBoundToHardware { get; set; }

    }


}
