using System.Collections.ObjectModel;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.TelerikWPF.Infrastructure.Ribbon.ViewModels
{
	public class ContextualGroupViewModel : ViewModelBase
	{
		private string _name;

		public ContextualGroupViewModel()
		{
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}		
	}
}
