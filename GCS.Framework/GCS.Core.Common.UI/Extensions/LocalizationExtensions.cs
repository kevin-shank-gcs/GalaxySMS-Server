////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\LocalizationExtensions.cs
//
// summary:	Implements the localization extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Globalization;
using System.Windows;

namespace GCS.Core.Common.UI.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A localization extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class LocalizationExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A FrameworkElement extension method that sets flow direction. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="fe">   The fe to act on. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SetFlowDirection(this FrameworkElement fe)
        {
            if (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft)
                fe.FlowDirection = FlowDirection.RightToLeft;
            else
                fe.FlowDirection = FlowDirection.LeftToRight;
        }

        //public static void SetFlowDirection(this RadWindow win)
        //{
        //    if (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft)
        //        win.FlowDirection = FlowDirection.RightToLeft;
        //    else
        //        win.FlowDirection = FlowDirection.LeftToRight;
        //}

        //public static void SetFlowDirection(this Popup pop)
        //{
        //    if (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft)
        //        pop.FlowDirection = FlowDirection.RightToLeft;
        //    else
        //        pop.FlowDirection = FlowDirection.LeftToRight;
        //}
    }
}
