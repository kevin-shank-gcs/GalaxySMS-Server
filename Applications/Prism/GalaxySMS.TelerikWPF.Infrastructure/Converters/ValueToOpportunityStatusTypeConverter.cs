using System;
using System.Linq;
using System.Windows.Data;

namespace GalaxySMS.TelerikWPF.Infrastructure.Converters
{
    public class ValueToOpportunityStatusTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //int statusType;
            //if (int.TryParse(value.ToString(), out statusType))
            //{
            //    return (OpportunityStatusType)statusType;
            //}

            //return OpportunityStatusType.Open;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //OpportunityStatusType statusType = OpportunityStatusType.Open;
            //Enum.TryParse(value.ToString(), out statusType);

            //return statusType;
            return null;
        }
    }
}