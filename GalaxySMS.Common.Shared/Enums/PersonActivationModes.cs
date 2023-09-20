////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Enums\PersonActivationModes.cs
//
// summary:	Implements the person activation modes class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Enums
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent person activation modes. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum PersonActivationModes
    {
        /// <summary>   An enum constant representing the immediately active option. </summary>
        ImmediatelyActive = 0,
        /// <summary>   An enum constant representing the activate by date option. </summary>
        ActivateByDate = 1,
        ActivateByDateAndTime = 2,
    }
}
