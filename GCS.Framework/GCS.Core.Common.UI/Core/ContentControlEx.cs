////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\ContentControlEx.cs
//
// summary:	Implements the content control ex class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Windows;
using System.Windows.Controls;

namespace GCS.Core.Common.UI.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A content control ex. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ContentControlEx : ContentControl
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the template selector. </summary>
        ///
        /// <value> The template selector. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTemplateSelector TemplateSelector
        {
            get { return (DataTemplateSelector) GetValue(TemplateSelectorProperty); }
            set { SetValue(TemplateSelectorProperty, value); }
        }

        /// <summary>   The template selector property. </summary>
        public static readonly DependencyProperty TemplateSelectorProperty =
            DependencyProperty.Register("TemplateSelector", typeof(DataTemplateSelector), typeof(ContentControlEx), new PropertyMetadata(null));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Called when the <see cref="P:System.Windows.Controls.ContentControl.Content" /> property
        /// changes.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="oldContent">   The old value of the
        ///                             <see cref="P:System.Windows.Controls.ContentControl.Content" />
        ///                             property. </param>
        /// <param name="newContent">   The new value of the
        ///                             <see cref="P:System.Windows.Controls.ContentControl.Content" />
        ///                             property. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            if (this.TemplateSelector != null)
            {
                this.ContentTemplate = this.TemplateSelector.SelectTemplate(newContent, this);
            }
        }
    }
}
