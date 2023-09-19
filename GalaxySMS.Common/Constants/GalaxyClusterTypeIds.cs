////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyClusterTypeIds.cs
//
// summary:	Implements the galaxy cluster type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy cluster type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyClusterTypeIds
    {
        /// <summary>   The galaxy cluster type only 600. </summary>
        public static readonly Guid GalaxyClusterType_Only600 = new Guid("D42A3A9A-9374-4F65-9A67-39E4EE867D56");
        /// <summary>   The fifth galaxy cluster type only 63. </summary>
        public static readonly Guid GalaxyClusterType_Only635 = new Guid("80C28BC8-1601-4F3E-9698-832C7874B841");
        /// <summary>   The galaxy cluster type hybrid 6xx. </summary>
        public static readonly Guid GalaxyClusterType_Hybrid6xx = new Guid("fb675377-9e73-4ba4-ae90-209c02918405");
    }
}
