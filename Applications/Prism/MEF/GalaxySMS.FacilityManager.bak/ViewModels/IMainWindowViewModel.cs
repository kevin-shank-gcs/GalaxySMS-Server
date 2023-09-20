using System.Windows.Input;

namespace GalaxySMS.FacilityManager.ViewModels
{
    public interface IMainWindowViewModel
    {
        ICommand SwitchContentRegionViewCommand { get; }
        ICommand ShowSettingsPanelCommand { get; }
        string CurrentViewName { get; }
        bool IsLoadingData { get; set; }
    }
}