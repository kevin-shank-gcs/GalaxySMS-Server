////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\DigitalInputOutputBoardInterfaceSectionMode.cs
//
// summary:	Implements the digital input output board interface section mode class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Values that represent digital input output board interface section modes.
    /// </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum DigitalInputOutputBoardInterfaceSectionMode
    {
        /// <summary>   An enum constant representing the outputs option. </summary>
        Outputs = 0x20,
        /// <summary>   An enum constant representing the inputs option. </summary>
        Inputs = 0x30
    }
}
