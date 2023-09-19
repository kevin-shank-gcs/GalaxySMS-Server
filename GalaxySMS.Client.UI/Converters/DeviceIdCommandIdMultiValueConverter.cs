using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GalaxySMS.Client.UI
{
    public class DeviceIdCommandIdMultiValueConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {   // Value 1 = DeviceUid value
            // Value 2 = CommandUid
            if (values == null || values.Length != 2)
                return null;
            var result = new List<KeyValuePair<string, Guid>>();
            Guid g = Guid.Empty;
            if( Guid.TryParse(values[0].ToString(), out g))
            {
                result.Add(new KeyValuePair<string, Guid>("deviceUid", g));
            }
            if( Guid.TryParse(values[1].ToString(), out g))
            {
                result.Add(new KeyValuePair<string, Guid>("commandUid", g));
            }
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
