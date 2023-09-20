////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\DualSerialChannelMode.cs
//
// summary:	Implements the dual serial channel mode class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent dual serial channel modes. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum DualSerialChannelMode
    {
/// <summary>   . </summary>
        Unused = 0,
/// <summary>   . </summary>
        Shell = 1,
/// <summary>   . </summary>
        ElevatorRelays = 64,
        /// <summary>   An enum constant representing the cypress clock display option. </summary>
        CypressClockDisplay = 65,
        /// <summary>   An enum constant representing the output relays option. </summary>
        OutputRelays = 66,
        /// <summary>   An enum constant representing the allegion pim wiegand option. </summary>
        AllegionPimWiegand = 67,
        /// <summary>   An enum constant representing the allegion pim aba option. </summary>
        AllegionPimAba = 68,
        /// <summary>   An enum constant representing the LCD 4x 20 display option. </summary>
        LCD_4x20Display = 69,
        /// <summary>   An enum constant representing the RS 485 door module option. </summary>
        RS485DoorModule = 70,
        /// <summary>   An enum constant representing the assa abloy aperio option. </summary>
        AssaAbloyAperio = 71,
        /// <summary>   An enum constant representing the salto sallis option. </summary>
        SaltoSallis = 72,
        /// <summary>   An enum constant representing the RS 485 input module option. </summary>
        RS485InputModule = 73,
        /// <summary>   An enum constant representing the veridt cac option. </summary>
        VeridtCac = 239,
    }
}
