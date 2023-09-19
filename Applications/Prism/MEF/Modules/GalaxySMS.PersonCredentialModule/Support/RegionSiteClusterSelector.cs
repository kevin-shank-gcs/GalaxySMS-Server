using GalaxySMS.Client.Entities;
using System.Windows;
using System.Windows.Controls;

namespace GalaxySMS.PersonCredential.Support
{
    public class RegionSiteClusterSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            base.SelectTemplate(item, container);

            //if (item is RegionSelectionItem)
            //{
            //    return this.RegionTemplate;
            //}
            //else if (item is SiteSelectionItem)
            //{
            //    return this.SiteTemplate;
            //}
            //else if (item is ClusterSelectionItem)
            //{
            //    return this.ClusterTemplate;
            //}

            if (item is RegionSelectionItemBasic)
            {
                return this.RegionTemplate;
            }
            else if (item is SiteSelectionItemBasic)
            {
                return this.SiteTemplate;
            }
            else if (item is ClusterSelectionItemBasic)
            {
                return this.ClusterTemplate;
            }

            return null;
        }

        public HierarchicalDataTemplate RegionTemplate { get; set; }
        public HierarchicalDataTemplate SiteTemplate { get; set; }
        public DataTemplate ClusterTemplate { get; set; }

    }

}
