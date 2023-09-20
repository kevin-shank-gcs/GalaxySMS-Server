////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	WPF\ConstrainingStackPanel.cs
//
// summary:	Implements the constraining stack panel class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GCS.Core.Common.UI.WPF
{  
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// This panel stacks children vertically and tries to constrain children so that the panel fits
    /// within the available size given by the parent. Only children which have the attached property
    /// 'Constrain' set to true are constrained.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ConstrainingStackPanel : Panel
    {
        /// <summary>   The constrainable children. </summary>
        private List<UIElement> _constrainableChildren = new List<UIElement>();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a constrain. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The object. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool GetConstrain(DependencyObject obj)
        {
            return (bool)obj.GetValue(ConstrainProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets a constrain. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">      The object. </param>
        /// <param name="value">    True to value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SetConstrain(DependencyObject obj, bool value)
        {
            obj.SetValue(ConstrainProperty, value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Using a DependencyProperty as the backing store for Constrain.  This enables animation,
        /// styling, binding, etc...
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static readonly DependencyProperty ConstrainProperty =
            DependencyProperty.RegisterAttached("Constrain", typeof(bool), typeof(ConstrainingStackPanel), new FrameworkPropertyMetadata(false, 
                                                                                         FrameworkPropertyMetadataOptions.AffectsParentMeasure ));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// When overridden in a derived class, measures the size in layout required for child elements
        /// and determines a size for the <see cref="T:System.Windows.FrameworkElement" />-derived class.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="availableSize">    The available size that this element can give to child
        ///                                 elements. Infinity can be specified as a value to indicate that
        ///                                 the element will size to whatever content is available. </param>
        ///
        /// <returns>
        /// The size that this element determines it needs during layout, based on its calculations of
        /// child element sizes.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override Size MeasureOverride(Size availableSize)
        {
            // Desired size for this panel to return to the parent
            double desiredHeight = 0;
            double desiredWidth = 0;

            // Desired heights the two 'types' of children
            double desiredHeightConstrainableChildren = 0;
            double desiredHeightRegularChildren = 0;            
            
            _constrainableChildren.Clear();

            foreach (UIElement child in InternalChildren)
            {
                // Let child figure out how much space it needs
                child.Measure(availableSize);

                if (GetConstrain(child))
                {
                    // Deal with  constrainable children later once we know if they
                    // need to be constrained or not
                    _constrainableChildren.Add(child);
                    desiredHeightConstrainableChildren += child.DesiredSize.Height;
                }
                else
                {
                    desiredHeightRegularChildren += child.DesiredSize.Height;
                    desiredHeight += child.DesiredSize.Height;
                    desiredWidth = Math.Max(desiredWidth, child.DesiredSize.Width);
                }
            }
            
            // If the desired height of all children exceeds the available height, set the 
            // constrain flag to true
            double desiredHeightAllChildren = desiredHeightConstrainableChildren + desiredHeightRegularChildren;
            bool constrain = desiredHeightAllChildren > availableSize.Height;

            // Holds the space available for the constrainable children to share
            double availableVerticalSpace = Math.Max(availableSize.Height - desiredHeightRegularChildren, 0);

            // Re-measure these children and contrain them proportionally, if necessary, so the
            // largest child gets the largest portion of the vertical space available
            foreach (UIElement child in _constrainableChildren)
            {
                if (constrain)
                {
                    double percent = child.DesiredSize.Height / desiredHeightConstrainableChildren;
                    double verticalSpace = percent * availableVerticalSpace;
                    child.Measure(new Size(availableSize.Width, verticalSpace));
                }
                desiredHeight += child.DesiredSize.Height;
                desiredWidth = Math.Max(desiredWidth, child.DesiredSize.Width);
            }
            
            return new Size(desiredWidth, desiredHeight);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// When overridden in a derived class, positions child elements and determines a size for a
        /// <see cref="T:System.Windows.FrameworkElement" /> derived class.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="finalSize">    The final area within the parent that this element should use to
        ///                             arrange itself and its children. </param>
        ///
        /// <returns>   The actual size used. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override Size ArrangeOverride(Size finalSize)
        {
            double yPosition = 0;
            foreach (UIElement child in InternalChildren)
            {
                child.Arrange(new Rect(0, yPosition, finalSize.Width, child.DesiredSize.Height));
                yPosition += child.DesiredSize.Height;
            }
            return finalSize;
        }
    }
}
