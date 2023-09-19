////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\GalaxyHardwareModuleType.cs
//
// summary:	Implements the galaxy hardware module type class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent galaxy hardware module types. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum GalaxyHardwareModuleType
    {
        /// <summary>   An enum constant representing the relay module 8 option. </summary>
        RelayModule8,
        /// <summary>   An enum constant representing the input module 16 option. </summary>
        InputModule16,
        /// <summary>   An enum constant representing the remote door module option. </summary>
        RemoteDoorModule,
        /// <summary>   An enum constant representing the cypress LCD option. </summary>
        CypressLCD,
        /// <summary>   An enum constant representing the allegion pim option. </summary>
        AllegionPIM,
        /// <summary>   An enum constant representing the salto sallis hub option. </summary>
        SaltoSallisHub,
        /// <summary>   An enum constant representing the assa abloy aperio hub option. </summary>
        AssaAbloyAperioHub,
        /// <summary>   An enum constant representing the reader port module option. </summary>
        ReaderPortModule,
        /// <summary>
        /// An enum constant representing the digital input output input module option.
        /// </summary>
        DigitalInputOutputInputModule,
        /// <summary>   An enum constant representing the digital input output module option. </summary>
        DigitalInputOutputOutputModule
    }
}
