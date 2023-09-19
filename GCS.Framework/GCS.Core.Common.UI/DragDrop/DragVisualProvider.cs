////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DragDrop\DragVisualProvider.cs
//
// summary:	Implements the drag visual provider class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.DragDrop;
using Telerik.Windows.DragDrop.Behaviors;

namespace GCS.Core.Common.UI.DragDrop
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A drag visual provider. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DragVisualProvider : DependencyObject, IDragVisualProvider
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the dragged item template. </summary>
        ///
        /// <value> The dragged item template. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTemplate DraggedItemTemplate
        {
            get
            {
                return (DataTemplate)GetValue(DraggedItemTemplateProperty);
            }
            set
            {
                SetValue(DraggedItemTemplateProperty, value);
            }
        }

        /// <summary>   The dragged item template property. </summary>
        public static readonly DependencyProperty DraggedItemTemplateProperty =
        DependencyProperty.Register("DraggedItemTemplate", typeof(DataTemplate), typeof(DragVisualProvider), new PropertyMetadata(null));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// When overridden in a derived class allows customization of the drag visual. If the returned
        /// element implements IEffectsPresenter, its Effects property will be automatically set during
        /// the drag-drop operation.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="state">    The state. </param>
        ///
        /// <returns>   The new drag visual. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FrameworkElement CreateDragVisual(DragVisualProviderState state)
        {
            var visual = new DragVisual();

            var theme = StyleManager.GetTheme(state.Host);
            if (theme != null)
            {
                StyleManager.SetTheme(visual, theme);
            }

            visual.Content = state.DraggedItems.OfType<object>().FirstOrDefault();
            visual.ContentTemplate = this.DraggedItemTemplate;

            return visual;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// When overridden in a derived class allows customization of the drag visual offset relatively
        /// to the mouse pointer.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="state">    The state. </param>
        ///
        /// <returns>   The drag visual offset. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Point GetDragVisualOffset(DragVisualProviderState state)
        {
            return state.RelativeStartPoint;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Specifies whether the drag-drop effects will change the mouse cursor or not. Return true if
        /// the cursor should change depending the drag-drop effects, otherwise false.
        /// </summary>
        ///
        /// <value> True if use default cursors, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool UseDefaultCursors { get; set; }
    }
}
