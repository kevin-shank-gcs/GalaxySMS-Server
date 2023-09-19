using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls.GridView;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using System.Reflection;
using GCS.Core.Common.UI.Core;


namespace GalaxySMS.Admin.UserControls
{
    /// <summary>
    /// Interaction logic for ComboColumnFilteringControl.xaml
    /// </summary>
    public partial class ComboColumnFilteringControl : UserControlViewBase, IFilteringControl
    {
        private GridViewComboBoxColumn column;
        private CompositeFilterDescriptor compositeFilterDescriptor;

        public ComboColumnFilteringControl()
        {
            InitializeComponent();
        }

        #region IFilteringControl Members

        /// <summary>
        /// Gets or sets a value indicating whether the filtering is active.
        /// </summary>
        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="IsActive"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register(
                "IsActive",
                typeof(bool),
                typeof(ComboColumnFilteringControl),
                new System.Windows.PropertyMetadata(false));


        public void Prepare(Telerik.Windows.Controls.GridViewColumn column)
        {
            this.compositeFilterDescriptor = new CompositeFilterDescriptor() { LogicalOperator = FilterCompositionLogicalOperator.Or };
            this.column = column as GridViewComboBoxColumn;
            this.listBoxDistinctValues.ItemsSource = this.column.ItemsSource;
            this.listBoxDistinctValues.DisplayMemberPath = this.column.DisplayMemberPath;
            this.column.DataControl.FilterDescriptors.Add(compositeFilterDescriptor);
        }

        #endregion

        private void listBoxDistinctValues_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            compositeFilterDescriptor.FilterDescriptors.Clear();

            foreach (var item in this.listBoxDistinctValues.SelectedItems)
            {
                PropertyInfo propertyInfo = item.GetType().GetProperty((this.column).SelectedValueMemberPath);
                object itemValue = propertyInfo.GetValue(item, null);
                compositeFilterDescriptor.FilterDescriptors.Add(new FilterDescriptor(this.column.DataMemberBinding.Path.Path, FilterOperator.IsEqualTo, itemValue));
            }

            if (this.compositeFilterDescriptor.FilterDescriptors.Count > 0)
                this.SetValue(IsActiveProperty, true);
            else
                this.SetValue(IsActiveProperty, false);
        }

    }
}
