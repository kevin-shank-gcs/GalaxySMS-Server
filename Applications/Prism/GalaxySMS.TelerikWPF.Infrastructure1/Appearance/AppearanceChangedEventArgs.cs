using System;
using CRM.Infrastructure.Appearance;

namespace GalaxySMS.TelerikWPF.Infrastructure.Appearance
{
    public class AppearanceChangedEventArgs : EventArgs
    {
        public Themes Theme { get; private set; }
        public ColorVariations  ColorVariation { get; private set; }

        public AppearanceChangedEventArgs(Themes theme, ColorVariations colorVariation)
        {
            this.Theme = theme;
            this.ColorVariation = colorVariation;
        }
    }
}