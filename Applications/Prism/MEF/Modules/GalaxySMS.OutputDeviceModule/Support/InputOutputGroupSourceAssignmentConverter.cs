using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using GalaxySMS.Client.Entities;
using GCS.Core.Common.Extensions;
using IEnumerable = System.Collections.IEnumerable;

namespace GalaxySMS.OutputDevice.Support
{
    public class InputOutputGroupSourceAssignmentConverter : IMultiValueConverter
    {
        #region Implementation of IMultiValueConverter

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var ret = new MoveInputOutputGroupAssignmentSourceParameters();
            if (values[0] == null || values[1] == null)
                return ret;
            if (values[0] is GalaxyOutputDeviceInputSource)
                ret.GalaxyOutputDeviceInputSource = values[0] as GalaxyOutputDeviceInputSource;
            var t = values[1].GetType();
            Trace.WriteLine(t);

            if (values[1] is IEnumerable selectedItems)
            {
                foreach (var i in selectedItems)
                {
                    if (i is InputOutputGroupAssignmentSource source)
                        ret.SelectedInputOutputGroupAssignmentSources.Add(source);
                }
            }
            return ret;
            return values.Clone();
            Tuple<object, object> tuple = new Tuple<object, object>(values[0], values[1]);
            return tuple;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion
    }
}
