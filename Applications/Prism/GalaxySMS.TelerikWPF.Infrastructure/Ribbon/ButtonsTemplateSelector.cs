using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaxySMS.TelerikWPF.Infrastructure.Ribbon.ViewModels;

namespace GalaxySMS.TelerikWPF.Infrastructure
{
    public class ButtonsTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Button { get; set; }
        public DataTemplate SplitButton { get; set; }
        public DataTemplate ButtonsGroup { get; set; }
        public DataTemplate SmallButtonGroup { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is SplitButtonViewModel)
            {
                return SplitButton;
            }
            else if (item is ButtonGroupViewModel)
            {
                return ((ButtonGroupViewModel)item).IsSmallGroup ? SmallButtonGroup : ButtonsGroup;
            }
            else
            {
                return Button;
            }
        }
    }
}
