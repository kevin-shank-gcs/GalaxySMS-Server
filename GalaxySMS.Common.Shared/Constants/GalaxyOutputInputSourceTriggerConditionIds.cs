////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyInputModeIds.cs
//
// summary:	Implements the galaxy input mode identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy input mode identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyOutputInputSourceTriggerConditionIds
    {
        public static readonly Guid Nothing = new Guid("00000000-0000-0000-0000-000000000001");
        public static readonly Guid Trouble = new Guid("00000000-0000-0000-0000-000000000002");
        public static readonly Guid Disarmed = new Guid("00000000-0000-0000-0000-000000000003");
        public static readonly Guid Armed = new Guid("00000000-0000-0000-0000-000000000004");
        public static readonly Guid On = new Guid("00000000-0000-0000-0000-000000000005");
        public static readonly Guid Alarm = new Guid("00000000-0000-0000-0000-000000000006");
        public static readonly Guid OnOrAlarm = new Guid("00000000-0000-0000-0000-000000000007");
        public static readonly Guid TroubleOrAlarm = new Guid("00000000-0000-0000-0000-000000000008");
    }
}

