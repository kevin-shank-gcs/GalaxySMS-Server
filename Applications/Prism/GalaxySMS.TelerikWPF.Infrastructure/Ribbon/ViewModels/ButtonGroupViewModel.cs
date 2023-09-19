using System.Collections.ObjectModel;

namespace GalaxySMS.TelerikWPF.Infrastructure.Ribbon.ViewModels
{
	public class ButtonGroupViewModel : ButtonViewModel
	{
		private bool _isSmallGroup;
		private ObservableCollection<ButtonViewModel> _buttons;

		public ButtonGroupViewModel()
		{
			_buttons = new ObservableCollection<ButtonViewModel>();
		}

		public ObservableCollection<ButtonViewModel> Buttons
		{
			get
			{
				return _buttons;
			}
		}

		public bool IsSmallGroup
		{
			get
			{
				return _isSmallGroup;
			}
			set
			{
				_isSmallGroup = value;
			}
		}
	}
}
