////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Localization\Localizer.cs
//
// summary:	Implements the localizer class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCS.Core.Common.Localization
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A localizer. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class Localizer
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets a culture. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="culture">      The culture. </param>
        /// <param name="uiCulture">    The culture. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SetCulture(string culture, string uiCulture)
        {
            if (!string.IsNullOrEmpty(culture))
            {
                CultureInfo ci = new CultureInfo(culture);
                Thread.CurrentThread.CurrentCulture = ci;
                CultureInfo.DefaultThreadCurrentCulture = ci;

                if (culture != uiCulture && !string.IsNullOrEmpty(uiCulture))
                {
                    CultureInfo ciUi = new CultureInfo(uiCulture);
                    Thread.CurrentThread.CurrentUICulture = ciUi;
                    CultureInfo.DefaultThreadCurrentUICulture = ci;
                
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = ci;
                    CultureInfo.DefaultThreadCurrentUICulture = ci;
                }
            }
        }
    }
}
