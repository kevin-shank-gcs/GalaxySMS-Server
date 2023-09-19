using System;
using Telerik.Windows.Controls.RibbonView;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.TelerikWPF.Infrastructure.Ribbon.ViewModels
{
	public class ButtonViewModel : ViewModelBase
    {
		private String _text;
		private ButtonSize _size;

		private string _smallImage;

		private string _largeImage;

		/// <summary>
		///     Gets or sets Text.
		/// </summary>
		public String Text
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

		public ButtonSize Size
		{
			get
			{
				return _size;
			}
			set
			{
				_size = value;
			}
		}

		public string SmallImage
		{
			get
			{
				return _smallImage;
			}
			set
			{
				_smallImage = value;
			}
		}

		public string LargeImage
		{
			get
			{
				return _largeImage;
			}
			set
			{
				_largeImage = value;
			}
		}

        public DelegateCommand<object> Command { get; set; }
        public object CommandParameter { get; set; }

    }
}
