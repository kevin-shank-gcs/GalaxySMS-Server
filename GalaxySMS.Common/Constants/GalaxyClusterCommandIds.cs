////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyClusterCommandIds.cs
//
// summary:	Implements the galaxy cluster command identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy cluster command identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyClusterCommandIds
    {
        /// <summary>   The galaxy cluster command ping. </summary>
        public static readonly Guid GalaxyClusterCommand_Ping = new Guid("00000000-0000-0000-0000-000000000018");
        /// <summary>   Information describing the galaxy cluster command get. </summary>
        public static readonly Guid GalaxyClusterCommand_GetInfo = new Guid("00000000-0000-0000-0000-00000000001A");
        /// <summary>   Number of galaxy cluster command get cards. </summary>
        public static readonly Guid GalaxyClusterCommand_GetCardCount = new Guid("00000000-0000-0000-0000-00000000001C");
        /// <summary>   The galaxy cluster command start logging. </summary>
        public static readonly Guid GalaxyClusterCommand_StartLogging = new Guid("00000000-0000-0000-0001-000000000061");
        /// <summary>   The galaxy cluster command stop logging. </summary>
        public static readonly Guid GalaxyClusterCommand_StopLogging = new Guid("00000000-0000-0000-0000-000000000061");
        /// <summary>   The galaxy cluster command delete all credentials. </summary>
        public static readonly Guid GalaxyClusterCommand_DeleteAllCredentials = new Guid("00000000-0000-0000-0000-000000000011");
        /// <summary>   The galaxy cluster command reset controller warm. </summary>
        public static readonly Guid GalaxyClusterCommand_ResetControllerWarm = new Guid("00000000-0000-0000-0000-000000000006");
        /// <summary>   The galaxy cluster command reset controller cold. </summary>
        public static readonly Guid GalaxyClusterCommand_ResetControllerCold = new Guid("00000000-0000-0000-0001-000000000006");
        /// <summary>   Buffer for galaxy cluster command clear logging data. </summary>
        public static readonly Guid GalaxyClusterCommand_ClearLoggingBuffer = new Guid("00000000-0000-0000-0000-000000000062");
        /// <summary>   Buffer for galaxy cluster command retransmit logging data. </summary>
        public static readonly Guid GalaxyClusterCommand_RetransmitLoggingBuffer = new Guid("00000000-0000-0000-0001-000000000062");
        /// <summary>   The galaxy cluster command forgive passback. </summary>
        public static readonly Guid GalaxyClusterCommand_ForgivePassback = new Guid("00000000-0000-0000-0000-000000000074");
        /// <summary>   The galaxy cluster command forgive all passback. </summary>
        public static readonly Guid GalaxyClusterCommand_ForgiveAllPassback = new Guid("00000000-0000-0000-0000-000000000075");
        /// <summary>   The galaxy cluster command recalibrate input output. </summary>
        public static readonly Guid GalaxyClusterCommand_RecalibrateInputOutput = new Guid("00000000-0000-0000-0000-000000000076");

        /// <summary>   The galaxy cluster command enable credential. </summary>
        public static readonly Guid GalaxyClusterCommand_EnableCredential = new Guid("00000000-0000-0000-0000-000000000077");

        /// <summary>   The galaxy cluster command disable credential. </summary>
        public static readonly Guid GalaxyClusterCommand_DisableCredential = new Guid("00000000-0000-0000-0000-000000000078");
        /// <summary>   The galaxy cluster command activate crisis mode. </summary>
        public static readonly Guid GalaxyClusterCommand_ActivateCrisisMode = new Guid("00000000-0000-0000-0000-00000000007E");
        /// <summary>   The galaxy cluster command reset crisis mode. </summary>
        public static readonly Guid GalaxyClusterCommand_ResetCrisisMode = new Guid("00000000-0000-0000-0000-00000000007D");
        /// <summary>   Information describing the galaxy cluster command get logging. </summary>
        public static readonly Guid GalaxyClusterCommand_GetLoggingInfo = new Guid("00000000-0000-0000-0000-00000000006E");
        /// <summary>   The galaxy cluster command enable daughter board flash update. </summary>
        public static readonly Guid GalaxyClusterCommand_EnableDaughterBoardFlashUpdate = new Guid("00000000-0000-0000-0000-000000000009");

        /// <summary>   The galaxy cluster command begin flash load. </summary>
        public static readonly Guid GalaxyClusterCommand_BeginFlashLoad = new Guid("00000000-0000-0000-0000-0000000000B6");

        /// <summary>   The galaxy cluster command validate flash. </summary>
        public static readonly Guid GalaxyClusterCommand_ValidateFlash = new Guid("00000000-0000-0000-0000-0000000000B8");

        /// <summary>   The galaxy cluster command validate and burn flash. </summary>
        public static readonly Guid GalaxyClusterCommand_ValidateAndBurnFlash = new Guid("00000000-0000-0000-0000-0000000000B9");


    }
}
