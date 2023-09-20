////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\DualSerialChannelModeIds.cs
//
// summary:	Implements the dual serial channel mode identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A dual serial interface 600 channel mode identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DualSerialInterface600ChannelModeIds
    {
        /// <summary>   The dual serial channel mode unused. </summary>
        public static readonly Guid DualSerialChannelMode_Unused = new Guid("00000000-0000-0000-0258-000000000000");
        /// <summary>   The dual serial channel mode shell. </summary>
        public static readonly Guid DualSerialChannelMode_Shell = new Guid("00000000-0000-0000-0258-000000000001");
        /// <summary>   The dual serial channel mode elevator relays. </summary>
        public static readonly Guid DualSerialChannelMode_ElevatorRelays = new Guid("00000000-0000-0000-0258-000000000040");
        /// <summary>   The dual serial channel mode cypress clock display. </summary>
        public static readonly Guid DualSerialChannelMode_CypressClockDisplay = new Guid("00000000-0000-0000-0258-000000000041");
        /// <summary>   The dual serial channel mode output relays. </summary>
        public static readonly Guid DualSerialChannelMode_OutputRelays = new Guid("00000000-0000-0000-0258-000000000042");
        /// <summary>   The dual serial channel mode allegion pim wiegand. </summary>
        public static readonly Guid DualSerialChannelMode_AllegionPimWiegand = new Guid("00000000-0000-0000-0258-000000000043");
        /// <summary>   The dual serial channel mode allegion pim aba. </summary>
        public static readonly Guid DualSerialChannelMode_AllegionPimAba = new Guid("00000000-0000-0000-0258-000000000044");
        /// <summary>   The dual serial channel mode LCD 4x 20 display. </summary>
        public static readonly Guid DualSerialChannelMode_LCD_4x20Display = new Guid("00000000-0000-0000-0258-000000000045");
        /// <summary>   The dual serial channel mode assa abloy aperio. </summary>
        public static readonly Guid DualSerialChannelMode_AssaAbloyAperio = new Guid("00000000-0000-0000-0258-000000000047");
        /// <summary>   The dual serial channel mode salto sallis. </summary>
        public static readonly Guid DualSerialChannelMode_SaltoSallis = new Guid("00000000-0000-0000-0258-000000000048");
        /// <summary>   The dual serial channel mode veridt cac. </summary>
        public static readonly Guid DualSerialChannelMode_VeridtCac = new Guid("00000000-0000-0000-0258-0000000000EF");

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the values. </summary>
        ///
        /// <value> The values. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<Guid> Values
        {
            get
            {
                var r = new List<Guid>();
                r.Add(DualSerialChannelMode_Unused);
                r.Add(DualSerialChannelMode_Shell);
                r.Add(DualSerialChannelMode_ElevatorRelays);
                r.Add(DualSerialChannelMode_CypressClockDisplay);
                r.Add(DualSerialChannelMode_OutputRelays);
                r.Add(DualSerialChannelMode_AllegionPimWiegand);
                r.Add(DualSerialChannelMode_AllegionPimAba);
                r.Add(DualSerialChannelMode_LCD_4x20Display);
                r.Add(DualSerialChannelMode_AssaAbloyAperio);
                r.Add(DualSerialChannelMode_SaltoSallis);
                r.Add(DualSerialChannelMode_VeridtCac);
                return r;
            }
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A dual serial interface 635 channel mode identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DualSerialInterface635ChannelModeIds
    {
        /// <summary>   The dual serial channel mode unused. </summary>
        public static readonly Guid DualSerialChannelMode_Unused = new Guid("00000000-0000-0000-027B-000000000000");
        /// <summary>   The dual serial channel mode shell. </summary>
        public static readonly Guid DualSerialChannelMode_Shell = new Guid("00000000-0000-0000-027B-000000000001");
        /// <summary>   The dual serial channel mode elevator relays. </summary>
        public static readonly Guid DualSerialChannelMode_ElevatorRelays = new Guid("00000000-0000-0000-027B-000000000040");
        /// <summary>   The dual serial channel mode cypress clock display. </summary>
        public static readonly Guid DualSerialChannelMode_CypressClockDisplay = new Guid("00000000-0000-0000-027B-000000000041");
        /// <summary>   The dual serial channel mode output relays. </summary>
        public static readonly Guid DualSerialChannelMode_OutputRelays = new Guid("00000000-0000-0000-027B-000000000042");
        /// <summary>   The dual serial channel mode allegion pim wiegand. </summary>
        public static readonly Guid DualSerialChannelMode_AllegionPimWiegand = new Guid("00000000-0000-0000-027B-000000000043");
        /// <summary>   The dual serial channel mode allegion pim aba. </summary>
        public static readonly Guid DualSerialChannelMode_AllegionPimAba = new Guid("00000000-0000-0000-027B-000000000044");
        /// <summary>   The dual serial channel mode LCD 4x 20 display. </summary>
        public static readonly Guid DualSerialChannelMode_LCD_4x20Display = new Guid("00000000-0000-0000-027B-000000000045");
        /// <summary>   The dual serial channel mode assa abloy aperio. </summary>
        public static readonly Guid DualSerialChannelMode_AssaAbloyAperio = new Guid("00000000-0000-0000-027B-000000000047");
        /// <summary>   The dual serial channel mode salto sallis. </summary>
        public static readonly Guid DualSerialChannelMode_SaltoSallis = new Guid("00000000-0000-0000-027B-000000000048");
        /// <summary>   The dual serial channel mode RS 485 input module. </summary>
        public static readonly Guid DualSerialChannelMode_RS485InputModule = new Guid("00000000-0000-0000-027B-000000000049");
        /// <summary>   The dual serial channel mode RS 485 door module. </summary>
        public static readonly Guid DualSerialChannelMode_RS485DoorModule = new Guid("00000000-0000-0000-027B-000000000046");
        /// <summary>   The dual serial channel mode veridt cac. </summary>
        public static readonly Guid DualSerialChannelMode_VeridtCac = new Guid("00000000-0000-0000-027B-0000000000EF");

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the values. </summary>
        ///
        /// <value> The values. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<Guid> Values
        {
            get
            {
                var r = new List<Guid>();
                r.Add(DualSerialChannelMode_Unused);
                r.Add(DualSerialChannelMode_Shell);
                r.Add(DualSerialChannelMode_ElevatorRelays);
                r.Add(DualSerialChannelMode_CypressClockDisplay);
                r.Add(DualSerialChannelMode_OutputRelays);
                r.Add(DualSerialChannelMode_AllegionPimWiegand);
                r.Add(DualSerialChannelMode_AllegionPimAba);
                r.Add(DualSerialChannelMode_LCD_4x20Display);
                r.Add(DualSerialChannelMode_AssaAbloyAperio);
                r.Add(DualSerialChannelMode_SaltoSallis);
                r.Add(DualSerialChannelMode_RS485InputModule);
                r.Add(DualSerialChannelMode_RS485DoorModule);
                r.Add(DualSerialChannelMode_VeridtCac);
                return r;
            }
        }
    }
}
