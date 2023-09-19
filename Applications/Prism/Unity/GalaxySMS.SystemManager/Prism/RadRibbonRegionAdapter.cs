using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Regions;
using Telerik.Windows.Controls;

namespace GalaxySMS.Prism.Prism
{
    public class RadRibbonRegionAdapter : RegionAdapterBase<RadRibbonView>
    {
        public RadRibbonRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, RadRibbonView regionTarget)
        {
            if (region == null) throw new ArgumentNullException("region");
            if (regionTarget == null) throw new ArgumentNullException("regionTarget");

            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (var view in e.NewItems)
                    {
                        AddViewToRegion(view, regionTarget);
                    }

                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var view in e.OldItems)
                    {
                        RemoveViewFromRegion(view, regionTarget);
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }

        static void AddViewToRegion(object view, RadRibbonView radRibbon)
        {
            var ribbonTabItem = view as RadRibbonTab;
            if (ribbonTabItem != null)
                radRibbon.Items.Add(ribbonTabItem);
        }

        static void RemoveViewFromRegion(object view, RadRibbonView radRibbon)
        {
            var ribbonTabItem = view as RadRibbonTab;
            if (ribbonTabItem != null)
                radRibbon.Items.Remove(ribbonTabItem);
        }
    }

}
