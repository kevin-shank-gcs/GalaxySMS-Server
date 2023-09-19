
using System.Collections.ObjectModel;
using GCS.Core.Common.UI.Core;


namespace GalaxySMS.TelerikWPF.Infrastructure.Ribbon.ViewModels
{
	public class RibbonTabViewModel : ViewModelBase
	{
		private bool _isSelected;
		private string _text;

		private ObservableCollection<GroupViewModel> groups;

		public RibbonTabViewModel()
		{
			groups = new ObservableCollection<GroupViewModel>();
		}

		public ObservableCollection<GroupViewModel> Groups
		{
			get
			{
				return groups;
			}
		}

		public bool IsSelected
		{
			get
			{
				return this._isSelected;
			}
			set
			{
				if (this._isSelected != value)
				{
					this._isSelected = value;
                    OnPropertyChanged(() => IsSelected, false);
                }
            }
		}

		public string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				if (this._text != value)
				{
					this._text = value;
                    OnPropertyChanged(() => Text, false);
                }
            }
		}
	}
}
