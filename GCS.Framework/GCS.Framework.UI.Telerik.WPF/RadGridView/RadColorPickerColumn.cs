using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using GridViewColumn = Telerik.Windows.Controls.GridViewColumn;

namespace GCS.Framework.UI.Telerik.WPF.RadGridView
{
    public class RadColorPickerColumn : GridViewBoundColumnBase
    {
        public override FrameworkElement CreateCellElement(GridViewCell cell, object dataItem)
        {
            Border cellElement = new Border();
            var valueBinding = new System.Windows.Data.Binding(this.DataMemberBinding.Path.Path)
            {
                Mode = BindingMode.OneTime,
                Converter = new ColorToBrushConverter()
            };
            cellElement.SetBinding(Border.BackgroundProperty, valueBinding);
            cellElement.Width = 45;
            cellElement.Height = 20;
            cellElement.CornerRadius = new CornerRadius(5);
            return cellElement;
        }
        public override FrameworkElement CreateCellEditElement(GridViewCell cell, object dataItem)
        {
            var cellEditElement = new RadColorPicker();
            this.BindingTarget = RadColorPicker.SelectedColorProperty;
            cellEditElement.MainPalette = this.MainPalette;
            System.Windows.Data.Binding valueBinding = this.CreateValueBinding();
            cellEditElement.SetBinding(RadColorPicker.SelectedColorProperty, valueBinding);
            return cellEditElement as FrameworkElement;
        }
        private System.Windows.Data.Binding CreateValueBinding()
        {
            System.Windows.Data.Binding valueBinding = new System.Windows.Data.Binding();
            valueBinding.Mode = BindingMode.TwoWay;
            valueBinding.NotifyOnValidationError = true;
            valueBinding.ValidatesOnExceptions = true;
            valueBinding.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
            valueBinding.Path = new PropertyPath(this.DataMemberBinding.Path.Path);
            return valueBinding;
        }
        public override void CopyPropertiesFrom(GridViewColumn source)
        {
            base.CopyPropertiesFrom(source);
            var radColorPickerColumn = source as RadColorPickerColumn;
            if (radColorPickerColumn != null)
            {
                this.MainPalette = radColorPickerColumn.MainPalette;
            }
        }
        public ColorPreset MainPalette
        {
            get
            {
                return (ColorPreset)GetValue(MainPaletteProperty);
            }
            set
            {
                SetValue(MainPaletteProperty, value);
            }
        }
        public static readonly DependencyProperty MainPaletteProperty = DependencyProperty.Register("MainPalette",
            typeof(ColorPreset),
            typeof(RadColorPickerColumn),
            new PropertyMetadata(null));
    }

}
