using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.GalaxyHardware
{
    public class BoardSectionModuleNodeTemplateSelector:DataTemplateSelector
    {
        public HierarchicalDataTemplate InterfaceBoardTemplate { get; set; }

        public HierarchicalDataTemplate InterfaceBoardSectionTemplate { get; set; }

        public HierarchicalDataTemplate HardwareModuleTemplate { get; set; }

        public DataTemplate NodeTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            base.SelectTemplate(item, container);

            if (item is GalaxyInterfaceBoard)
            {
                return this.InterfaceBoardTemplate;
            }
            else if (item is GalaxyInterfaceBoardSection)
            {
                return this.InterfaceBoardSectionTemplate;
            }
            else if (item is GalaxyHardwareModule)
            {
                return this.HardwareModuleTemplate;
            }
            else if (item is GalaxyInterfaceBoardSectionNode)
            {
                return this.NodeTemplate;
            }
            return null;
        }
    }
}
