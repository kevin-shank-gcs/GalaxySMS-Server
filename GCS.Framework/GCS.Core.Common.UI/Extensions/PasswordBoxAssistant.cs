////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\PasswordBoxAssistant.cs
//
// summary:	Implements the password box assistant class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GCS.Core.Common.UI.Controls
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Taken from http://blog.functionalfun.net/2008/06/wpf-passwordbox-and-data-binding.html.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class PasswordBoxAssistant
    {
        /// <summary>   The bound password. </summary>
        public static readonly DependencyProperty BoundPassword =
            DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxAssistant), new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

        /// <summary>   The bind password. </summary>
        public static readonly DependencyProperty BindPassword = DependencyProperty.RegisterAttached(
            "BindPassword", typeof(bool), typeof(PasswordBoxAssistant), new PropertyMetadata(false, OnBindPasswordChanged));

        /// <summary>   The updating password. </summary>
        private static readonly DependencyProperty UpdatingPassword =
            DependencyProperty.RegisterAttached("UpdatingPassword", typeof(bool), typeof(PasswordBoxAssistant), new PropertyMetadata(false));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the dependency property changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="d">    The DependencyObject to process. </param>
        /// <param name="e">    Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox box = d as PasswordBox;

            // only handle this event when the property is attached to a PasswordBox
            // and when the BindPassword attached property has been set to true
            if (d == null || !GetBindPassword(d))
            {
                return;
            }

            // avoid recursive updating by ignoring the box's changed event
            box.PasswordChanged -= HandlePasswordChanged;

            string newPassword = (string)e.NewValue;

            if (!GetUpdatingPassword(box))
            {
                box.Password = newPassword;
            }

            box.PasswordChanged += HandlePasswordChanged;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the dependency property changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dp">   The dp. </param>
        /// <param name="e">    Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void OnBindPasswordChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            // when the BindPassword attached property is set on a PasswordBox,
            // start listening to its PasswordChanged event

            PasswordBox box = dp as PasswordBox;

            if (box == null)
            {
                return;
            }

            bool wasBound = (bool)(e.OldValue);
            bool needToBind = (bool)(e.NewValue);

            if (wasBound)
            {
                box.PasswordChanged -= HandlePasswordChanged;
            }

            if (needToBind)
            {
                box.PasswordChanged += HandlePasswordChanged;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Handles the password changed. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Routed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void HandlePasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox box = sender as PasswordBox;

            // set a flag to indicate that we're updating the password
            SetUpdatingPassword(box, true);
            // push the new password into the BoundPassword property
            SetBoundPassword(box, box.Password);
            SetUpdatingPassword(box, false);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets bind password. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dp">       The dp. </param>
        /// <param name="value">    True to value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SetBindPassword(DependencyObject dp, bool value)
        {
            dp.SetValue(BindPassword, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets bind password. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dp">   The dp. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool GetBindPassword(DependencyObject dp)
        {
            return (bool)dp.GetValue(BindPassword);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets bound password. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dp">   The dp. </param>
        ///
        /// <returns>   The bound password. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetBoundPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(BoundPassword);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets bound password. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dp">       The dp. </param>
        /// <param name="value">    True to value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SetBoundPassword(DependencyObject dp, string value)
        {
            dp.SetValue(BoundPassword, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets updating password. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dp">   The dp. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static bool GetUpdatingPassword(DependencyObject dp)
        {
            return (bool)dp.GetValue(UpdatingPassword);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets updating password. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dp">       The dp. </param>
        /// <param name="value">    True to value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void SetUpdatingPassword(DependencyObject dp, bool value)
        {
            dp.SetValue(UpdatingPassword, value);
        }
    }
}
