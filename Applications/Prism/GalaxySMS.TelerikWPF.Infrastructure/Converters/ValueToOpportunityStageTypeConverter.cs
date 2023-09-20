using System;
using System.Linq;
using System.Windows.Data;

namespace GalaxySMS.TelerikWPF.Infrastructure.Converters
{
    public class ValueToOpportunityStageTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //int stageType;
            //if (int.TryParse(value.ToString(), out stageType))
            //{
            //    return (OpportunityStageType)stageType;
            //}

            //return OpportunityStageType.Cold;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //OpportunityStageType stageType = OpportunityStageType.Cold;
            //Enum.TryParse(value.ToString(), out stageType);

            //return stageType;
            return null;
        }
    }
}