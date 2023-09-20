using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Entities;
using GCS.Core.Common.Core;
using GCS.WebApi.SysGal.Entities;

namespace SystemGalaxyDataImporter.Entities
{
    public class CompositeCustomerData : ObjectBase
    {
        private CUSTOMERS _fullSgCustomerData;
        private Customer _customer;
        private gcsEntity _smsEntity;

        public CompositeCustomerData(Customer customer)
        {
            Customer = customer;
        }

        public Customer Customer
        {
            get => _customer;
            set
            {
                if (_customer != value)
                {
                    _customer = value;
                    OnPropertyChanged(() => Customer, false);
                }
            }
        }

        public CUSTOMERS FullSgCustomerDataCustomers
        {
            get => _fullSgCustomerData;
            set
            {
                if (_fullSgCustomerData != value)
                {
                    _fullSgCustomerData = value;
                    OnPropertyChanged(() => FullSgCustomerDataCustomers, false);
                }
            }
        }

        public gcsEntity SmsEntity
        {
            get => _smsEntity;
            set
            {
                if (_smsEntity != value)
                {
                    _smsEntity = value;
                    OnPropertyChanged(() => SmsEntity, false);
                }
            }
        }


    }
}
