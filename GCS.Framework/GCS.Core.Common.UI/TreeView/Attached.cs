////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	TreeView\Attached.cs
//
// summary:	Implements the attached class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Windows;
using System.Windows.Controls;

namespace GCS.Core.Common.UI
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An attached. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Attached
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets tree view selected item. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The object. </param>
        ///
        /// <returns>   The tree view selected item. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static object GetTreeViewSelectedItem(DependencyObject obj)
        {
            return (object) obj.GetValue(TreeViewSelectedItemProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets tree view selected item. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">      The object. </param>
        /// <param name="value">    The value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SetTreeViewSelectedItem(DependencyObject obj, object value)
        {
            obj.SetValue(TreeViewSelectedItemProperty, value);
        }

        /// <summary>   The tree view selected item property. </summary>
        public static readonly DependencyProperty TreeViewSelectedItemProperty =
            DependencyProperty.RegisterAttached("TreeViewSelectedItem", typeof(object), typeof(Attached), new PropertyMetadata(new object(), TreeViewSelectedItemChanged));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tree view selected item changed. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Dependency property changed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static void TreeViewSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            TreeView treeView = sender as TreeView;
            if (treeView == null)
            {
                return;
            }

            treeView.SelectedItemChanged -= new RoutedPropertyChangedEventHandler<object>(treeView_SelectedItemChanged);
            treeView.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(treeView_SelectedItemChanged);

            TreeViewItem thisItem = treeView.ItemContainerGenerator.ContainerFromItem(e.NewValue) as TreeViewItem;
            if (thisItem != null)
            {
                thisItem.IsSelected = true;
                return;
            }

            for (int i = 0; i < treeView.Items.Count; i++)
                SelectItem(e.NewValue, treeView.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by treeView for selected item changed events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        The RoutedPropertyChangedEventArgs&lt;object&gt; to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView treeView = sender as TreeView;
            SetTreeViewSelectedItem(treeView, e.NewValue);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Select item. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">            The object to process. </param>
        /// <param name="parentItem">   The parent item. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static bool SelectItem(object o, TreeViewItem parentItem)
        {
            if (parentItem == null)
                return false;

            bool isExpanded = parentItem.IsExpanded;
            if (!isExpanded)
            {
                parentItem.IsExpanded = true;
                parentItem.UpdateLayout();
            }

            TreeViewItem item = parentItem.ItemContainerGenerator.ContainerFromItem(o) as TreeViewItem;
            if (item != null)
            {
                item.IsSelected = true;
                return true;
            }

            bool wasFound = false;
            for (int i = 0; i < parentItem.Items.Count; i++)
            {
                TreeViewItem itm = parentItem.ItemContainerGenerator.ContainerFromIndex(i) as TreeViewItem;
                var found = SelectItem(o, itm);
                if (!found)
                    itm.IsExpanded = false;
                else
                    wasFound = true;
            }

            return wasFound;
        }
    }

}
