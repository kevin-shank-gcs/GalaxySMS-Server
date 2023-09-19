////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils\PrincipalIdentity.cs
//
// summary:	Implements the principal identity class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCS.Core.Common.Utils
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A principal identity. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class PrincipalIdentity
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the current windows user name. </summary>
        ///
        /// <value> The name of the current windows user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string CurrentWindowsUserName
        {
            get
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                if (identity != null)
                    return identity.Name;
                return string.Empty;
                //return WindowsIdentity.GetCurrent().Name;
                //if (Thread.CurrentPrincipal.Identity.Name == string.Empty)
                //    Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            }
        }
 
    }
}
