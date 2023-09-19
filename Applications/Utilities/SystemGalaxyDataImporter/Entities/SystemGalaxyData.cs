using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.WebApi.SysGal.Entities;

namespace SystemGalaxyDataImporter.Entities
{
    public class SystemGalaxyData : ObjectBase
    {
        public SystemGalaxyData()
        {
            
        }

		private ObservableCollection<CompositeCustomerData> _customerList = new ObservableCollection<CompositeCustomerData>();
        private ObservableCollection<CompositeClusterData> _clusters = new CollectionBase<CompositeClusterData>();

		public ObservableCollection<CompositeCustomerData> CustomerList
		{
			get { return _customerList; }
			set
			{
				if (_customerList != value)
				{
                    _customerList = value;
					OnPropertyChanged(() => CustomerList, true);
				}
			}
		}


		public ObservableCollection<CompositeClusterData> ClusterList
		{
			get { return _clusters; }
			set
			{
				if (_clusters != value)
				{
					_clusters = value;
					OnPropertyChanged(() => ClusterList, true);
				}
			}
		}


	}
}
