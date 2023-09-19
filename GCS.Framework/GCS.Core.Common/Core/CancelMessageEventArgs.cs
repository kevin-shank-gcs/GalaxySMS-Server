﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\CancelMessageEventArgs.cs
//
// summary:	Implements the cancel message event arguments class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for cancel message events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CancelMessageEventArgs : CancelEventArgs
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CancelMessageEventArgs() : base()
        {
            Message = string.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="messsage"> The messsage. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CancelMessageEventArgs(string messsage) :base()
        {
            Message = messsage;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the message. </summary>
        ///
        /// <value> The message. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Message { get; internal set; }
    }
}
