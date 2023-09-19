////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\GalaxyCpuCommandActionCode.cs
//
// summary:	Implements the galaxy CPU command action code class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent galaxy CPU command action codes. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum GalaxyCpuCommandActionCode
    {
        /// <summary>   An enum constant representing the reset CPU warm option. </summary>
        ResetCpuWarm,
        /// <summary>   An enum constant representing the reset CPU cold option. </summary>
        ResetCpuCold,
        /// <summary>
        /// An enum constant representing the clear Automatic update flash timer option.
        /// </summary>
        EnableDaughterBoardFlashUpdate,
        /// <summary>   An enum constant representing the clear all credentials option. </summary>
        ClearAllCredentials,
        /// <summary>   An enum constant representing the ping option. </summary>
        Ping,
        /// <summary>   An enum constant representing the request controller information option. </summary>
        RequestControllerInformation,
        /// <summary>   An enum constant representing the request credential count option. </summary>
        RequestCredentialCount,
        /// <summary>   An enum constant representing the request logging information option. </summary>
        RequestLoggingInformation,
        /// <summary>   An enum constant representing the forgive passback for credential option. </summary>
        ForgivePassbackForCredential,
        /// <summary>
        /// An enum constant representing the forgive passback for all credentials option.
        /// </summary>
        ForgivePassbackForAllCredentials,
        /// <summary>   An enum constant representing the recalibrate inputs and outputs option. </summary>
        RecalibrateInputsAndOutputs,
        /// <summary>   An enum constant representing the activate crisis mode option. </summary>
        ActivateCrisisMode,
        /// <summary>   An enum constant representing the reset crisis mode option. </summary>
        ResetCrisisMode,
        /// <summary>   An enum constant representing the enable credential option. </summary>
        EnableCredential,
        /// <summary>   An enum constant representing the disable credential option. </summary>
        DisableCredential,
        /// <summary>
        /// An enum constant representing the request input output group counters option.
        /// </summary>
        RequestInputOutputGroupCounters,
        /// <summary>   An enum constant representing the request board information option. </summary>
        RequestBoardInformation,
        /// <summary>   An enum constant representing the clear logging buffer option. </summary>
        ClearLoggingBuffer,
        /// <summary>   An enum constant representing the retransmit logging buffer option. </summary>
        RetransmitLoggingBuffer,
        /// <summary>   An enum constant representing the start logging option. </summary>
        StartLogging,
        /// <summary>   An enum constant representing the stop logging option. </summary>
        StopLogging,
        /// <summary>   An enum constant representing the begin flash load option. </summary>
        BeginFlashLoad,
        /// <summary>   An enum constant representing the validate flash option. </summary>
        ValidateFlash,
        /// <summary>   An enum constant representing the validate and burn flash option. </summary>
        ValidateAndBurnFlash

    }


}
