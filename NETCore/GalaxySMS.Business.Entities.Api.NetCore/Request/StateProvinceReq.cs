using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Models.RequestModels
{
    public partial class StateProvinceReq
    {

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the state province UID. </summary>
        ///
        /// <value> The state province UID. </value>
        ///=================================================================================================
        public System.Guid StateProvinceUid { get; set; }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the country UID. </summary>
        ///
        /// <value> The country UID. </value>
        ///=================================================================================================
        [Required]
        public System.Guid CountryUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the state province code. </summary>
        ///
        /// <value> The state province code. </value>
        ///=================================================================================================
        [Required]
        [StringLength(20)]
        public string StateProvinceCode { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the state province. </summary>
        ///
        /// <value> The name of the state province. </value>
        ///=================================================================================================
        [Required]
        [StringLength(255)]
        public string StateProvinceName { get; set; }
    }
}
