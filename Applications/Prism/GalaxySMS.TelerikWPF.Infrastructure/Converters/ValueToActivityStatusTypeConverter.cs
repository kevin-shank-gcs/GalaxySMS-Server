using System;
using System.Linq;
using System.Windows.Data;

namespace GalaxySMS.TelerikWPF.Infrastructure.Converters
{
    public class ValueToActivityStatusTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //int statusType;
            //if (int.TryParse(value.ToString(), out statusType))
            //{
            //    return (ActivityStatusType)statusType;
            //}
            
            //return ActivityStatusType.NotStarted;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //ActivityStatusType statusType = ActivityStatusType.NotStarted;
            //Enum.TryParse(value.ToString(), out statusType);

            //return statusType;
            return null;
        }
    }
}
