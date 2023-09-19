using System;
using System.Linq;
using System.Windows.Data;

namespace GalaxySMS.TelerikWPF.Infrastructure.Converters
{
    public class ValueToPriorityTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //int priorityType;
            //if (int.TryParse(value.ToString(), out priorityType))
            //{
            //    return (PriorityType)priorityType;
            //}

            //return PriorityType.Low;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //PriorityType type = PriorityType.Low;
            //Enum.TryParse(value.ToString(), out type);

            //return type;
            return null;
        }
    }
}