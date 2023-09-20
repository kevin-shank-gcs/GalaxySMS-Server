////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Telerik\DateTimePickerColumn.cs
//
// summary:	Implements the date time picker column class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Windows;
using System.Windows.Data;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using System;
using Telerik.Windows.Input.Touch;

namespace GCS.Core.Common.UI
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A date time picker column. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DateTimePickerColumn : GridViewBoundColumnBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time interval. </summary>
        ///
        /// <value> The time interval. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public TimeSpan TimeInterval
        {
            get
            {
                return (TimeSpan) GetValue(TimeIntervalProperty);
            }
            set
            {
                SetValue(TimeIntervalProperty, value);
            }
        }

        /// <summary>   The time interval property. </summary>
        public static readonly DependencyProperty TimeIntervalProperty =
            DependencyProperty.Register("TimeInterval", typeof(TimeSpan), typeof(DateTimePickerColumn), new PropertyMetadata(TimeSpan.FromHours(1d)));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates the element for the cell in edit mode. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="cell">     The cell. </param>
        /// <param name="dataItem"> The data item. </param>
        ///
        /// <returns>   The new cell edit element. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override FrameworkElement CreateCellEditElement(GridViewCell cell, object dataItem)
        {
            this.BindingTarget = RadDateTimePicker.SelectedValueProperty;

            RadDateTimePicker picker = new RadDateTimePicker();
            picker.IsTooltipEnabled = false;

            picker.TimeInterval = this.TimeInterval;

            picker.SetBinding(this.BindingTarget, this.CreateValueBinding());

            return picker;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets the new value from the editor. Used from the validation mechanism to get the new value
        /// before this value to be committed to the data source.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="editor">   The editor. </param>
        ///
        /// <returns>   The new value from editor. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override object GetNewValueFromEditor(object editor)
        {
            RadDateTimePicker picker = editor as RadDateTimePicker;
            if (picker != null)
            {
                picker.DateTimeText = picker.CurrentDateTimeText;
            }

            return base.GetNewValueFromEditor(editor);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates value binding. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The new value binding. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private Binding CreateValueBinding()
        {
            Binding valueBinding = new Binding();
            valueBinding.Mode = BindingMode.TwoWay;
            valueBinding.NotifyOnValidationError = true;
            valueBinding.ValidatesOnExceptions = true;
            valueBinding.UpdateSourceTrigger = UpdateSourceTrigger.Explicit;
            valueBinding.Path = new PropertyPath(this.DataMemberBinding.Path.Path);

            return valueBinding;
        }
    }

}
