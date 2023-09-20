////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\SensitivityLevel.cs
//
// summary:	Implements the sensitivity level class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent sensitivity levels. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum SensitivityLevel
    { 
        /// <summary>   An enum constant representing the public option. </summary>
        Public = 0,
        /// <summary>   An enum constant representing the confidential option. </summary>
        Confidential
    }
}
