using System;
using System.Collections.ObjectModel;
using System.Windows;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;
using Telerik.Windows.Controls;

namespace GalaxySMS.Schedule.Views
{
    /// <summary>
    /// Interaction logic for EditDayTypeView.xaml
    /// </summary>
    public partial class EditDayTypeView : UserControlViewBase, ISupportDataContext
    {
        public EditDayTypeView()
        {
            InitializeComponent();
            this.xColorPickerExpander.IsExpanded = true;
        }

        private void BtnCustomColor_OnClick(object sender, RoutedEventArgs e)
        {
            //this.xColorPicker.IsDropDownOpen = false;
            this.xColorPickerExpander.IsExpanded = false;
            this.xColorPickerExpander.Opacity = 0;
            this.xCustomColorExpander.Opacity = 1;
            this.xCustomColorExpander.IsExpanded = true;
        }

        private void BtnColorEditorOk_OnClick(object sender, RoutedEventArgs e)
        {
            this.xColorPicker.SelectedColor = this.xColorEditor.SelectedColor;
            this.xCustomColorExpander.IsExpanded = false;
            this.xCustomColorExpander.Opacity = 0;
            this.xColorPickerExpander.Opacity = 1;
            this.xColorPickerExpander.IsExpanded = true;
        }

        private void BtnColorEditorCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.xCustomColorExpander.IsExpanded = false;
            this.xCustomColorExpander.Opacity = 0;
            this.xColorPickerExpander.Opacity = 1;
            this.xColorPickerExpander.IsExpanded = true;
        }
    }
}
