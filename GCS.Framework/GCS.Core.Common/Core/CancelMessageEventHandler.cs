////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\CancelMessageEventHandler.cs
//
// summary:	Implements the cancel message event handler class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Represents the method that handles a cancelable event. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <param name="sender">   The source of the event. </param>
    /// <param name="e">        Cancel message event information. </param>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [HostProtection(SecurityAction.LinkDemand, SharedState = true)]
    public delegate void CancelMessageEventHandler(object sender, CancelMessageEventArgs e);
}
