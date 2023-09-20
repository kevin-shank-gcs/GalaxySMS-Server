using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace GalaxySMS.SiteManager.Converters
{
    public class LanguageGuidToLanguageNameConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (targetType != typeof(String) ||
            //    targetType != typeof(Object))
            //    throw new InvalidOperationException("The target must be a string");

            Guid incomingGuid;
            if (Guid.TryParse(value.ToString(), out incomingGuid) == false)
                throw new InvalidOperationException("The value must be a Guid");

            return (from l in Globals.Instance.Languages
                    where l.LanguageId == incomingGuid
                    select l.LanguageName).FirstOrDefault();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
