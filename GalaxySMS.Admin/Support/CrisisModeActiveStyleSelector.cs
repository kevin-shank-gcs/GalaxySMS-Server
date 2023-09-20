using GalaxySMS.Admin.ViewModels;
using GalaxySMS.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;


namespace GalaxySMS.Admin.Support
{
    public class CrisisModeActiveStyleSelector: System.Windows.Controls.StyleSelector
    {
         public override Style SelectStyle(object item, DependencyObject container)
        {
            var viewModel = (container as GridViewCell).ParentOfType<RadGridView>().DataContext as GalaxyPanelCommunicationViewModel;

            if (item is CpuConnection)
            {
                CpuConnection cpuConnection = item as CpuConnection;
                if (cpuConnection.ConnectionInfo.GalaxyCpuInformation.InqueryReply.CrisisModeActive == Common.Enums.CrisisModeState.Active)
                {
                    return CrisisModeActiveStyle;
                }
                else
                {
                    return CrisisModeInactiveStyle;
                }
            }
            return null;
        }
        public Style CrisisModeActiveStyle { get; set; }
        public Style CrisisModeInactiveStyle { get; set; }       
    }
}
