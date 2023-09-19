using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaxySMS.MonitorManager.ViewModels;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Prism.Attributes;
using Prism.Regions;

namespace GalaxySMS.MonitorManager.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
	[ViewExport(RegionName = RegionNames.SubHeader)]
    public partial class SettingsView : UserControl, INavigationAware
    {
        private readonly Storyboard loadAnimation;
        private readonly Storyboard unloadAnimation;

        [Import]
        public SettingsViewModel ViewModel
        {
            private get
            {
                return this.DataContext as SettingsViewModel;
            }

            set
            {
                this.DataContext = value;
            }
        }

        public SettingsView()
        {
            InitializeComponent();

            this.loadAnimation = (Storyboard)this.Resources["LoadAnimation"];
            this.unloadAnimation = (Storyboard)this.Resources["UnloadAnimation"];
        }

        internal void PlayUnloadAnimation(IRegion region)
        {
            this.unloadAnimation.Begin();
            this.unloadAnimation.Completed += (s, a) =>
            {
                region.Deactivate(this);
            };
        }

        protected void PlayLoadAnimation()
        {
            this.loadAnimation.Begin();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.PlayLoadAnimation();
        }
    }
}
