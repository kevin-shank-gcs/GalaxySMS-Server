////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyDigitalInputOutputModuleLimits.cs
//
// summary:	Implements the galaxy digital input output module limits class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy digital input output module limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyDigitalInputOutputModuleLimits
    {
        /// <summary>   The lowest definable input number. </summary>
        public const short LowestDefinableInputNumber = 1;
        /// <summary>   The highest definable input number. </summary>
        public const short HighestDefinableInputNumber = 8;
        /// <summary>   The maximum inputs per input module. </summary>
        public const short MaximumInputsPerInputModule = 8;

        /// <summary>   The lowest definable outut number. </summary>
        public const short LowestDefinableOututNumber = 1;
        /// <summary>   The highest definable output number. </summary>
        public const short HighestDefinableOutputNumber = 4;
        /// <summary>   The maximum outputs per input module. </summary>
        public const short MaximumOutputsPerInputModule = 4;
    }
}
