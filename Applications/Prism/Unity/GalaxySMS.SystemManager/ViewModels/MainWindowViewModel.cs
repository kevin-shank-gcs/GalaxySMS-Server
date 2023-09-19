using GalaxySMS.Prism.Helpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace GalaxySMS.Prism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; set; }

        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            Title = GCS.Framework.Utilities.SystemUtilities.GetEntryAssemblyAttributes().Title;
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }
        void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate("ContentRegion", navigationPath);
        }
    }
}
