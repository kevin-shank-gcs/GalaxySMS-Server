using System;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace GalaxySMS.TelerikWPF.Infrastructure.Appearance
{
    public class ThemeResourceExtension : MarkupExtension
    {
        public Resources Resource { get; set; }

        public ThemeResourceExtension()
        {
            
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException("serviceProvider");
            }

            if (this.Resource == null)
            {
                throw new ArgumentException("Resource cannot be null.");
            }

            string propertyPath;
            if (ThemePalette.TryGetResource(this.Resource, out propertyPath))
            {
                Binding binding = new Binding(propertyPath)
                {
                    Source = ThemePalette.Palette,
                    Converter = new ColorToSolidColorBrushConverter(),
                    Mode = BindingMode.OneWay
                };
                return binding.ProvideValue(serviceProvider);
            }

            return null;
        }
    }
}