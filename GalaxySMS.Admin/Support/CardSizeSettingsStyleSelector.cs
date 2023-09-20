using GalaxySMS.Admin.ViewModels;
using GalaxySMS.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;


namespace GalaxySMS.Admin.Support
{
    public class CardSizeSettingsStyleSelector : System.Windows.Controls.StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            ////var viewModel = (container as GridViewCell).ParentOfType<RadGridView>().DataContext as GalaxyPanelCommunicationViewModel;
            //var style = new Style(typeof(Telerik.Windows.Controls.GridView.GridViewCell));

            if (item is CpuConnection)
            {
                CpuConnection cpuConnection = item as CpuConnection;

                if (cpuConnection.ConnectionInfo.CredentialSizeSettingsMatch == true)
                {
                    return MatchStyle;
                }
                else
                {
                    return MisMatchStyle;
                }
            }
            return null;
        }
        public Style MatchStyle { get; set; }
        public Style MisMatchStyle { get; set; }
    }
}
