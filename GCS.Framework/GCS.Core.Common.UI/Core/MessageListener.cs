////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\MessageListener.cs
//
// summary:	Implements the message listener class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GCS.Core.Common.UI.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Message listener, singleton pattern. Inherit from DependencyObject to implement DataBinding.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class MessageListener : DependencyObject
    {
        /// <summary>   The instance. </summary>
        private static MessageListener mInstance;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Constructor that prevents a default instance of this class from being created.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private MessageListener()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get MessageListener instance. </summary>
        ///
        /// <value> The instance. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static MessageListener Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new MessageListener();
                return mInstance;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Receive message. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">  . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ReceiveMessage(string message)
        {
            Message = message;
            Debug.WriteLine(Message);
            DispatcherHelper.DoEvents();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get or set received message. </summary>
        ///
        /// <value> The message. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        /// <summary>   The message property. </summary>
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(MessageListener), new UIPropertyMetadata(null));

    }
}
