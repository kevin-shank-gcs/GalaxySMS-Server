using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class CountryReq
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the country UID. </summary>
        ///
        /// <value> The country UID. </value>
        ///=================================================================================================
        public System.Guid CountryUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the country 2 character ISO. </summary>
        ///
        /// <value> The country ISO. </value>
        ///=================================================================================================
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string CountryIso { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the country. </summary>
        ///
        /// <value> The name of the country. </value>
        ///=================================================================================================
        [Required]
        [StringLength(100)]
        public string CountryName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the long country. </summary>
        ///
        /// <value> The name of the long country. </value>
        ///=================================================================================================
        [Required]
        [StringLength(100)]
        public string LongCountryName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the ISO 3 character code. </summary>
        ///
        /// <value> The ISO 3. </value>
        ///=================================================================================================
        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Iso3 { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of codes. </summary>
        ///
        /// <value> The total number of code. </value>
        ///=================================================================================================
        [Required]
        [StringLength(6)]
        public string NumberCode { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether the united nations member state.
        /// </summary>
        ///
        /// <value> True if united nations member state, false if not. </value>
        ///=================================================================================================
        public bool UnitedNationsMemberState { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the calling code. </summary>
        ///
        /// <value> The calling code. </value>
        ///=================================================================================================
        [StringLength(10)]
        public string CallingCode { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cctld. </summary>
        ///
        /// <value> The cctld. </value>
        ///=================================================================================================

        [StringLength(5)]
        public string CCTLD { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the flag image. </summary>
        ///
        /// <value> The flag image. </value>
        ///=================================================================================================

        public byte[] FlagImage { get; set; }


    }
}
