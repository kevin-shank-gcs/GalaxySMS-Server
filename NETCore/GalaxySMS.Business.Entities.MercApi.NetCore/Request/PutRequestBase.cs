using System;
using System.ComponentModel.DataAnnotations;

namespace GalaxySMS.MercApi.Models.RequestModels
{
    public class PutRequestBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the concurrency value. </summary>
        /// <remarks>   Used to prevent update conflicts.</remarks>
        /// <value> The concurrency value. </value>
        ///=================================================================================================
        [Required]
        public Nullable<short> ConcurrencyValue { get; set; }

    }
}
