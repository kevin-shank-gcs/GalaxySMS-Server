using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaxySMS.TelerikWPF.Infrastructure.Appearance;
using Prism.Commands;

namespace GalaxySMS.FacilityManager.ViewModels
{
    [Export(typeof(SettingsViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SettingsViewModel
    {
        [ImportingConstructor]
        public SettingsViewModel()
        {
            this.ChangeAppearanceCommand = new DelegateCommand<AppearanceCommandParameter>(this.ChangeTheme);

            this.CurrentTheme = GalaxySMS.TelerikWPF.Infrastructure.Appearance.Themes.Office2013;
            this.ColorVariation = ColorVariations.Light;
        }

        private void ChangeTheme(AppearanceCommandParameter parameter)
        {
            if (this.CurrentTheme == parameter.Theme &&
                this.ColorVariation == parameter.ColorVariation)
            {
                return;
            }

            this.CurrentTheme = parameter.Theme;
            this.ColorVariation = parameter.ColorVariation;

            AppearanceManager.ChangeAppearance(this.CurrentTheme, this.ColorVariation);
        }

        public ICommand ChangeAppearanceCommand { get; private set; }

        public ColorVariations ColorVariation { get; private set; }

        public GalaxySMS.TelerikWPF.Infrastructure.Appearance.Themes CurrentTheme { get; private set; }
    }

}
