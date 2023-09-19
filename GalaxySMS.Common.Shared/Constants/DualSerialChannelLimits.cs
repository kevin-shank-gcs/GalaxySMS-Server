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

    public class DualSerialChannel_DoorModuleLimits
    {
        public const short LowestDefinableModuleNumber = 1;
        public const short HighestDefinableModuleNumber = 1;
        public const short MaximumNodesPerModule = 16;
        public const short LowestNodeNumber = 1;
        public const short HighestNodeNumber = 16;
    }

    public class DualSerialChannel_InputModuleLimits
    {
        public const short LowestDefinableModuleNumber = 1;
        public const short HighestDefinableModuleNumber = 16;
        public const short MaximumNodesPerModule = 18;
    }

    public class DualSerialChannel_OutputModuleLimits
    {
        public const short LowestDefinableModuleNumber = 1;
        public const short HighestDefinableModuleNumber = 3;
        public const short MaximumNodesPerModule = 8;
    }
}
