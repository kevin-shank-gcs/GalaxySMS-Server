////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\DispatchHelper.cs
//
// summary:	Implements the dispatch helper class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace GCS.Core.Common.UI.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A dispatcher helper. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class DispatcherHelper
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Simulate Application.DoEvents function of <see cref=" System.Windows.Forms.Application"/>
        /// class.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [SecurityPermissionAttribute ( SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode )]
        public static void DoEvents ( )
        {
            DispatcherFrame frame = new DispatcherFrame ( );
            Dispatcher.CurrentDispatcher.BeginInvoke ( DispatcherPriority.Background,
                new DispatcherOperationCallback ( ExitFrames ), frame );

            try
            {
                Dispatcher.PushFrame ( frame );
            }
            catch ( InvalidOperationException )
            {
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Exit frames. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="frame">    . </param>
        ///
        /// <returns>   An object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static object ExitFrames ( object frame )
        {
            ( ( DispatcherFrame ) frame ).Continue = false;

            return null;
        }
    }
}

