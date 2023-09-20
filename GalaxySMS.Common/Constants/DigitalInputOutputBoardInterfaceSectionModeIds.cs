////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\DigitalInputOutputBoardInterfaceSectionModeIds.cs
//
// summary:	Implements the digital input output board interface section mode identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A digital input output board interface section mode identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DigitalInputOutputBoardInterfaceSectionModeIds
    {
        /// <summary>   The dio section mode outputs. </summary>
        public static readonly Guid DIOSectionMode_Outputs = new Guid("00000000-0000-0000-0258-500000000001");
        /// <summary>   The dio section mode inputs. </summary>
        public static readonly Guid DIOSectionMode_Inputs = new Guid("00000000-0000-0000-0258-500000000002");
    }

}
