using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace GalaxySMS.Admin.Converters
{
    public class ApplicationGuidToApplicationNameConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (targetType != typeof(String) ||
            //    targetType != typeof(Object))
            //    throw new InvalidOperationException("The target must be a string");
            
            Guid incomingGuid;
            if(Guid.TryParse(value.ToString(), out incomingGuid) == false )
                throw new InvalidOperationException("The value must be a Guid");

            return (from a in Globals.Instance.Applications
                        where a.ApplicationId == incomingGuid
                        select a.ApplicationName).FirstOrDefault();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }}
