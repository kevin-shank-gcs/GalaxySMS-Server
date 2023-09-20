using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaxySMS.Client.Entities;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.PersonCredential.Support
{
    public class RegionSiteClusterMasterDetailSelector : DataTemplateSelector
    {
        private readonly DataTemplate emptyTemplate = new DataTemplate();
        public DataTemplate RegionTemplate { get; set; }
        public DataTemplate SiteTemplate { get; set; }
        public DataTemplate ClusterTemplate { get; set; }

        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {

            if (item is RegionSelectionItem)
            {
                return this.RegionTemplate;
            }
            if (item is SiteSelectionItem)
            {
                return this.SiteTemplate;
            }
            if (item is ClusterSelectionItem)
            {
                return this.ClusterTemplate;
            }


            return emptyTemplate;
        }

    }

}
