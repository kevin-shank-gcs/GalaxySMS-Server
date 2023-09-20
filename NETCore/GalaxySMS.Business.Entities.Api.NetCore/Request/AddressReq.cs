////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Models\RequestModels\Address.cs
//
// summary:	Implements the address class
///=================================================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Models.RequestModels
{
    /// <summary>   The address request. </summary>
    public partial class AddressReq : RequestBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the address UID. </summary>
        ///
        /// <value> The address UID. </value>
        ///=================================================================================================

        public System.Guid AddressUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the street address. </summary>
        ///
        /// <value> The street address. </value>
        ///=================================================================================================

        [Required]
        [StringLength(256)]
        public string StreetAddress { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the postal code. </summary>
        ///
        /// <value> The postal code. </value>
        ///=================================================================================================
        [Required]
        [StringLength(20)]
        public string PostalCode { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the city. </summary>
        ///
        /// <value> The city. </value>
        ///=================================================================================================
        [Required]
        [StringLength(65)]
        public string City { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the state province UID. </summary>
        ///
        /// <value> The state province UID. </value>
        ///=================================================================================================
        [Required]
        public System.Guid StateProvinceUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the longitude. </summary>
        ///
        /// <value> The longitude. </value>
        ///=================================================================================================

        public Nullable<double> Longitude { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the latitude. </summary>
        ///
        /// <value> The latitude. </value>
        ///=================================================================================================

        public Nullable<double> Latitude { get; set; }

    }
}
