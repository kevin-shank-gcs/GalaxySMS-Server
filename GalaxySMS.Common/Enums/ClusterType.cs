////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\ClusterType.cs
//
// summary:	Implements the cluster type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent cluster types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum ClusterType
    {
        /// <summary>   An enum constant representing the hybrid 6xx option. </summary>
        Hybrid6xx,
        /// <summary>   An enum constant representing the only 600 option. </summary>
        Only600,
        /// <summary>   An enum constant representing the only 635 option. </summary>
        Only635,
    }
}
