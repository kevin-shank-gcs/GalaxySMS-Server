////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\UniqueHardwareAddressFormat.cs
//
// summary:	Implements the unique hardware address format class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A unique hardware address format. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class UniqueHardwareAddressFormat
    {
        /// <summary>   The default account cluster panel board section node. </summary>
        public static readonly string DefaultAccountClusterPanelBoardSectionNode = "{0}:{1:D5}:{2:D5}:{3:D}:{4:D}:{5:D}";

        /// <summary>   The access portal. </summary>
        public static readonly string AccessPortal = "{0}:{1:D5}:{2:D5}:{3:D}:{4:D}:{5:D}";
        /// <summary>   The input device. </summary>
        public static readonly string InputDevice = "{0}:{1:D5}:{2:D5}:{3:D}:{4:D}:{5:D}:{6:D}";
        /// <summary>   The output device. </summary>
        public static readonly string OutputDevice = "{0}:{1:D5}:{2:D5}:{3:D}:{4:D}:{5:D}";
        /// <summary>   The galaxy CPU. </summary>
        public static readonly string GalaxyCpu = "{0}:{1:D5}:{2:D5}:{3:D}";
        public static readonly string GalaxyPanel = "{0}:{1:D5}:{2:D5}";

        /// <summary>   Input Output Group. </summary>
        public static readonly string InputOutputGroup = "{0}:{1:D5}:{2:D}";
        public static readonly string DsiChannelModule = "{0}:{1:D5}:{2:D5}:{3:D}:{4:D}:{5:D}";
        public static readonly string InterfaceBoard = "{0}:{1:D5}:{2:D5}:{3:D}";
        public static readonly string InterfaceBoardSection = "{0}:{1}";
        public static readonly string InterfaceBoardSectionModule = "{0}:{1:D5}:{2:D5}:{3:D}:{4:D}:{5:D}";
        public static readonly string InterfaceBoardSectionNode = "{0}:{1}:{2}:{3}";

    }
}
