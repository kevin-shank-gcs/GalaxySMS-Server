////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyInputVoltageThresholds.cs
//
// summary:	Implements the galaxy input voltage thresholds class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    //public class GalaxyInputVoltages
    //{
    //    public short TroubleOpen { get; set; }
    //    public short TroubleShort { get; set; }
    //    public short Normal { get; set; }
    //}

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy input voltage thresholds. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyInputVoltageThresholds
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A no supervision. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class NoSupervision
        {
            /// <summary>   The normal. </summary>
            public const short Normal = 128;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 255;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A no supervision alternate. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class NoSupervisionAlternate
        {
            /// <summary>   The normal. </summary>
            public const short Normal = 70;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 255;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 0;
        }

        #region In Line (Series Resistor)

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An in line 1000. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class InLine1000
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 1000;
            /// <summary>   The normal. </summary>
            public const short Normal = 128;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 255;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 15;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An in line 1000 alternate. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class InLine1000Alternate
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 1000;
            /// <summary>   The normal. </summary>
            public const short Normal = 100;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 255;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 15;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An in line 2000. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class InLine2000
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 2000;
            /// <summary>   The normal. </summary>
            public const short Normal = 128;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 255;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 25;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An in line 2000 alternate. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class InLine2000Alternate
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 2000;
            /// <summary>   The normal. </summary>
            public const short Normal = 100;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 255;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 25;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An in line 2200. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class InLine2200
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 2200;
            /// <summary>   The normal. </summary>
            public const short Normal = 128;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 255;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 25;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An in line 2200 alternate. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class InLine2200Alternate
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 2200;
            /// <summary>   The normal. </summary>
            public const short Normal = 100;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 255;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 25;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An in line 4700. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class InLine4700
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 4700;
            /// <summary>   The normal. </summary>
            public const short Normal = 128;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 255;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 25;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An in line 4700 alternate. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class InLine4700Alternate
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 4700;
            /// <summary>   The normal. </summary>
            public const short Normal = 100;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 255;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 25;
        }

        #endregion

        #region End Of Line (Parallel)

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line 1000. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLine1000
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 1000;
            /// <summary>   The normal. </summary>
            public const short Normal = 11;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 150;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line 1000 alternate. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLine1000Alternate
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 1000;
            /// <summary>   The normal. </summary>
            public const short Normal = 10;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 115;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line 2000. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLine2000
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 2000;
            /// <summary>   The normal. </summary>
            public const short Normal = 23;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 150;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line 2000 alternate. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLine2000Alternate
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 2000;
            /// <summary>   The normal. </summary>
            public const short Normal = 20;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 115;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line 2200. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLine2200
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 2200;
            /// <summary>   The normal. </summary>
            public const short Normal = 23;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 150;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line 2200 alternate. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLine2200Alternate
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 2200;
            /// <summary>   The normal. </summary>
            public const short Normal = 20;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 115;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line 4700. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLine4700
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 4700;
            /// <summary>   The normal. </summary>
            public const short Normal = 50;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 150;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line 4700 alternate. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLine4700Alternate
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 4700;
            /// <summary>   The normal. </summary>
            public const short Normal = 50;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 115;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 0;
        }

        #endregion

        #region End Of Line and In Line (Parallel & Series)

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line in line 1000. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLineInLine1000
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 1000;
            /// <summary>   The normal. </summary>
            public const short Normal = 34;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 150;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 10;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line in line 1000 alternate. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLineInLine1000Alternate
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 1000;
            /// <summary>   The normal. </summary>
            public const short Normal = 30;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 115;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 10;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line in line 2000. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLineInLine2000
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 2000;
            /// <summary>   The normal. </summary>
            public const short Normal = 60;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 150;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 10;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line in line 2000 alternate. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLineInLine2000Alternate
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 2000;
            /// <summary>   The normal. </summary>
            public const short Normal = 50;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 115;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 10;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line in line 2200. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLineInLine2200
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 2200;
            /// <summary>   The normal. </summary>
            public const short Normal = 60;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 150;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 10;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line in line 2200 alternate. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLineInLine2200Alternate
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 2200;
            /// <summary>   The normal. </summary>
            public const short Normal = 50;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 115;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 10;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line in line 4700. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLineInLine4700
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 4700;
            /// <summary>   The normal. </summary>
            public const short Normal = 100;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 150;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 25;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An end of line in line 4700 alternate. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class EndOfLineInLine4700Alternate
        {
            /// <summary>   The resistor value. </summary>
            public const short ResistorValue = 4700;
            /// <summary>   The normal. </summary>
            public const short Normal = 80;
            /// <summary>   The trouble open. </summary>
            public const short TroubleOpen = 115;
            /// <summary>   The trouble short. </summary>
            public const short TroubleShort = 25;
        }

        #endregion

    }
}