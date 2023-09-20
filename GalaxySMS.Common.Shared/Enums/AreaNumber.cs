////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\AreaNumber.cs
//
// summary:	Implements the area number class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent area numbers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum AreaNumber
    {
        /// <summary>   An enum constant representing the no area option. </summary>
        NoArea = 0,
        /// <summary>   An enum constant representing the in option. </summary>
        In = 1,
        /// <summary>   An enum constant representing the out option. </summary>
        Out = 2,
        /// <summary>   An enum constant representing the no change option. </summary>
        NoChange = 255
    }
}
