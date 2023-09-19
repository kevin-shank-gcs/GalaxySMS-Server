////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Splasher\Splasher.cs
//
// summary:	Implements the splasher class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GCS.Core.Common.UI
{    /// <summary>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Helper to show or close given splash window
    /// </summary>
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class Splasher
    {
        /// <summary>   The splash. </summary>
        private static Window mSplash;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get or set the splash screen window. </summary>
        ///
        /// <value> The splash. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Window Splash
        {
            get
            {
                return mSplash;
            }
            set
            {
                mSplash = value;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Show splash screen. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void ShowSplash()
        {
            if (mSplash != null)
            {
                mSplash.Show();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Close splash screen. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void CloseSplash()
        {
            if (mSplash != null)
            {
                mSplash.Close();

                if (mSplash is IDisposable)
                    (mSplash as IDisposable).Dispose();
            }
        }
    }
}
