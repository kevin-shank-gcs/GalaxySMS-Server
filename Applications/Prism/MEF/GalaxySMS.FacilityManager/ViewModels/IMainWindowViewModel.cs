using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaxySMS.TelerikWPF.Infrastructure;

namespace GalaxySMS.FacilityManager.ViewModels
{
    public interface IMainWindowViewModel
    {
        ICommand SwitchContentRegionViewCommand { get; }
        ICommand ShowSettingsPanelCommand { get; }
        string CurrentViewName { get; }
        bool IsLoadingData { get; set; }
        ObservableCollection<IPaneViewModel> Panes { get; set; }
    }
}