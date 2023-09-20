using System.Collections.ObjectModel;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.TelerikWPF.Infrastructure.Ribbon.ViewModels
{
    public class GroupViewModel : ViewModelBase
    {
        private string _text;

		private ObservableCollection<ButtonViewModel> _buttons;

		public GroupViewModel()
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

        /// <summary>
        ///     Gets or sets Text.
        /// </summary>
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
