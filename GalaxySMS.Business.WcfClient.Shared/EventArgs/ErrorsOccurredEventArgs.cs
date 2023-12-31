﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EventArgs\ErrorsOccurredEventArgs.cs
//
// summary:	Implements the errors occurred event arguments class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common;

namespace GalaxySMS.Client.SDK
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for errors occurred events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ErrorsOccurredEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="errors">   The errors. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ErrorsOccurredEventArgs(ReadOnlyCollection<CustomError> errors)
            : base()
        {
            Errors = errors;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the errors. </summary>
        ///
        /// <value> The errors. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<CustomError> Errors { get; internal set; }
    }
}
