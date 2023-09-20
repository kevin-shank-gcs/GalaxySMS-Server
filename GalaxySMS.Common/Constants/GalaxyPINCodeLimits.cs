////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyPINCodeLimits.cs
//
// summary:	Implements the galaxy pin code limits class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy pin code limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyPINCodeLimits
    {
        /// <summary>   The lowest definable pin. </summary>
        public const ushort LowestDefinablePIN = 0;
        /// <summary>   The hightest definable pin. </summary>
        public const ushort HightestDefinablePIN = 65535;
    }
}
