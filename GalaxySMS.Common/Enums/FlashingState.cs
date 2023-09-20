﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\FlashingState.cs
//
// summary:	Implements the flashing state class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent flashing states. </summary>
    ///
    /// <remarks>   Kevin, 1/24/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum FlashingState { Idle, BeginFlashLoadSent, LoadingPackets, LoadingPaused, LoadingPacketsFinished, Validating, ValidatingAndBurning, ValidationFinished }
    public enum FlashValidationResult { Unknown, Passed, Failed }

}
