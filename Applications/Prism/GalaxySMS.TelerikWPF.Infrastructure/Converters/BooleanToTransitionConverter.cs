using GalaxySMS.TelerikWPF.Infrastructure;
//using Microsoft.Practices.Prism.MefExtensions.Modularity;
//using Microsoft.Practices.Prism.Modularity;
using System;
using System.Globalization;
using System.Windows.Data;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.TransitionControl;

namespace GalaxySMS.TelerikWPF.Infrastructure.Converters
{	
	public class BooleanToTransitionConverter : IValueConverter
	{
		public TransitionProvider TransitionForward { get; set; }
		public TransitionProvider TransitionBackward { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is bool) || (bool)value)
			{
				return TransitionForward;
			}
			else
			{
				return TransitionBackward;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
