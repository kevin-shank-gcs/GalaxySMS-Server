using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaxySMS.Client.Entities;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Admin.Support
{
    public class PanelModelFlashImageSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (item is CpuModel)
            {
                var model = (CpuModel)item;

                if (model == CpuModel.Cpu600)
                    return FlashImage600Template;

                if (model == CpuModel.Cpu635)
                    return FlashImage635Template;
            }
            return null;
        }

        public DataTemplate FlashImage600Template { get; set; }
        public DataTemplate FlashImage635Template { get; set; }
    }
}
