////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyHardwareModuleTypeIds.cs
//
// summary:	Implements the galaxy hardware module type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy hardware module type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyHardwareModuleTypeIds
    {
        /// <summary>   The galaxy hardware module type relay module 8. </summary>
        public static readonly Guid GalaxyHardwareModuleType_RelayModule8 = new Guid("00000000-0000-0000-0000-000000000042");
        /// <summary>   The galaxy hardware module type input module 16. </summary>
        public static readonly Guid GalaxyHardwareModuleType_InputModule16 = new Guid("00000000-0000-0000-0000-000000000049");
        /// <summary>   The galaxy hardware module type remote door module. </summary>
        public static readonly Guid GalaxyHardwareModuleType_RemoteDoorModule = new Guid("00000000-0000-0000-0000-000000000046");
        /// <summary>   The galaxy hardware module type cypress LCD. </summary>
        public static readonly Guid GalaxyHardwareModuleType_CypressLCD = new Guid("00000000-0000-0000-0000-000000000045");
        /// <summary>   The galaxy hardware module type allegion pim. </summary>
        public static readonly Guid GalaxyHardwareModuleType_AllegionPIM = new Guid("00000000-0000-0000-0000-000000000043");
        /// <summary>   The galaxy hardware module type salto sallis hub. </summary>
        public static readonly Guid GalaxyHardwareModuleType_SaltoSallisHub = new Guid("00000000-0000-0000-0000-000000000048");
        /// <summary>   The galaxy hardware module type assa abloy aperio hub. </summary>
        public static readonly Guid GalaxyHardwareModuleType_AssaAbloyAperioHub = new Guid("00000000-0000-0000-0000-000000000047");
        /// <summary>   The galaxy hardware module type reader port module. </summary>
        public static readonly Guid GalaxyHardwareModuleType_ReaderPortModule = new Guid("00000000-0000-0000-0000-000000000001");
        /// <summary>   The galaxy hardware module type digital input output input module. </summary>
        public static readonly Guid GalaxyHardwareModuleType_DigitalInputOutputInputModule = new Guid("00000000-0000-0000-0000-000000000002");
        /// <summary>   The galaxy hardware module type digital input output module. </summary>
        public static readonly Guid GalaxyHardwareModuleType_DigitalInputOutputOutputModule = new Guid("00000000-0000-0000-0000-000000000003");

    }
}
