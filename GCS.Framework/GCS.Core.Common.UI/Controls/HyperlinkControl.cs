////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Controls\HyperlinkControl.cs
//
// summary:	Implements the hyperlink control class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GCS.Core.Common.UI.Controls
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A hyperlink control. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class HyperlinkControl : ContentControl
    {
        /// <summary>   The URI property. </summary>
        public static readonly DependencyProperty UriProperty =
            DependencyProperty.Register("Uri", typeof(System.Uri), typeof(HyperlinkControl), new PropertyMetadata(OnPropertyChanged));

        /// <summary>   The text property. </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(HyperlinkControl), new PropertyMetadata(string.Empty, OnPropertyChanged));

        /// <summary>   The command property. </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(HyperlinkControl), new PropertyMetadata(OnPropertyChanged));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets URI of the document. </summary>
        ///
        /// <value> The URI. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public System.Uri Uri
        {
            get { return (System.Uri)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the text. </summary>
        ///
        /// <value> The text. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command. </summary>
        ///
        /// <value> The command. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the dependency property changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="d">    The DependencyObject to process. </param>
        /// <param name="e">    Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var hyperlink = d as HyperlinkControl;

            hyperlink.BuildContent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Builds the content. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void BuildContent()
        {
			var hyperlink = new System.Windows.Documents.Hyperlink
			{
				NavigateUri = this.Uri,
				Command = this.Command,
			};
			hyperlink.Inlines.Add(this.Text);

			var text = new TextBlock();
			text.Inlines.Add(hyperlink);
			this.Content = text;
        }
    }
}
