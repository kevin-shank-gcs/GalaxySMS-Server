////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyRemoteInputModuleLimits.cs
//
// summary:	Implements the galaxy remote input module limits class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy remote input module limits. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyRemoteInputModuleLimits
    {
        /// <summary>   The lowest definable module number. </summary>
        public const short LowestDefinableModuleNumber = 1;
        /// <summary>   The highest definable module number. </summary>
        public const short HighestDefinableModuleNumber = 16;
        /// <summary>   The maximum input modules per channel. </summary>
        public const short MaximumInputModulesPerChannel = 16;

        /// <summary>   The lowest definable input number. </summary>
        public const short LowestDefinableInputNumber = 1;
        /// <summary>   The highest definable input number. </summary>
        public const short HighestDefinableInputNumber = 18;
        /// <summary>   The maximum inputs per input module. </summary>
        public const short MaximumInputsPerInputModule = 18;

        /// <summary>   The input module low power input number. </summary>
        public const short InputModuleLowPowerInputNumber = 17;
        /// <summary>   The input module tamper input number. </summary>
        public const short InputModuleTamperInputNumber = 18;
    }
}
