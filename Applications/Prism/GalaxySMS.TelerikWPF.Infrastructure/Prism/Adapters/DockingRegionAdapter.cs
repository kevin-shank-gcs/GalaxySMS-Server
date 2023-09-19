using Microsoft.Practices.ServiceLocation;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Composition;
using Telerik.Windows.Controls;
using Prism.Regions;

namespace GalaxySMS.TelerikWPF.Infrastructure.Prism
{
    [Export(typeof(DockingRegionAdapter))]
    public class DockingRegionAdapter : RegionAdapterBase<RadDocking>
    {
        private IServiceLocator serviceLocator;

        [ImportingConstructor]
        public DockingRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory, IServiceLocator serviceLocator)
            : base(regionBehaviorFactory)
        {
            this.serviceLocator = serviceLocator;
        }

        protected override void Adapt(IRegion region, RadDocking regionTarget)
        {
            regionTarget.PanesSource = region.Views;
        }

        protected override IRegion CreateRegion()
        {
            var region = new Region();
            region.Behaviors.Add("DockActivationRegionBehavior", serviceLocator.GetInstance<DockActivationRegionBehavior>());
            return region;
        }
    }
}