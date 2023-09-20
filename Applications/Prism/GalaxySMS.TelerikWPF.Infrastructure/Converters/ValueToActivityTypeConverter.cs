using System;
using System.Linq;
using System.Windows.Data;

namespace GalaxySMS.TelerikWPF.Infrastructure.Converters
{
    public class ValueToActivityTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //int type;
            //if (int.TryParse(value.ToString(), out type))
            //{
            //    return (ActivityType)type;
            //}

            //return ActivityType.Call;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //ActivityType type = ActivityType.Call;
            //Enum.TryParse(value.ToString(), out type);

            //return type;
            return null;
        }
    }
}