using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Models.RequestModels
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
