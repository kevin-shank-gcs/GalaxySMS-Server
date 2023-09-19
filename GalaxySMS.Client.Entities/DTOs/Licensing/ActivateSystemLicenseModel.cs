using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Constants;
using GCS.Core.Common.Core;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Client.Licensing.Entities
{
    public class ActivateSystemLicenseModel
    {

        public string LicenseKey { get; set; }

        public string CustomerJobNumber { get; set; }

        public string CustomerPurchaseOrder { get; set; }


        #region Properties provided at license activation / product registration time

        public string SystemThumbprint { get; set; }


        public string CustomerName { get; set; }

        public string CustomerEmailAddress { get; set; }


        public string FacilityType { get; set; }

        public string CountryIso3 { get; set; }

        public string StateProvinceCode { get; set; }

        public string City { get; set; }

        public string StreetAddress { get; set; }

        public string CustomerContactPerson { get; set; }

        public string CustomerContactPhone { get; set; }
        #endregion

        public string ServerSystemNumber { get; set; }

        public int MajorVersion { get; set; }
        public string ActivatedByPersonName { get; set; }

        public LicenseType LicenseType { get; set; }
    }

    public partial class ActivateSystemLicenseData : ObjectBase// : ViewModelBase//ObjectBase
    {

        #region Private Fields

        private string _LicenseKey;
        private string _ServerSystemNumber;
        private string _SystemThumbprint;
        private string _CustomerName;
        private string _CustomerContactPerson;
        private string _CustomerEmailAddress;
        private string _CustomerContactPhone;
        private string _CustomerJobNumber;
        private string _CustomerPurchaseOrder;
        private string _ActivatedByPersonName;
        private string _FacilityType;
        private string _CountryIso3;
        private string _StateProvinceCode;
        private string _City;
        private string _StreetAddress;

        #endregion

        public string LicenseKey
        {
            get { return _LicenseKey; }
            set
            {
                if (_LicenseKey != value)
                {
                    _LicenseKey = value;
                    OnPropertyChanged(() => LicenseKey, true);
                }
            }
        }

        public string CustomerJobNumber
        {
            get { return _CustomerJobNumber; }
            set
            {
                if (_CustomerJobNumber != value)
                {
                    _CustomerJobNumber = value;
                    OnPropertyChanged(() => CustomerJobNumber, true);
                }
            }
        }

        public string CustomerPurchaseOrder
        {
            get { return _CustomerPurchaseOrder; }
            set
            {
                if (_CustomerPurchaseOrder != value)
                {
                    _CustomerPurchaseOrder = value;
                    OnPropertyChanged(() => CustomerPurchaseOrder, true);
                }
            }
        }

        #region Properties provided at license activation / product registration time

        public string SystemThumbprint
        {
            get { return _SystemThumbprint; }
            set
            {
                if (_SystemThumbprint != value)
                {
                    _SystemThumbprint = value;
                    OnPropertyChanged(() => SystemThumbprint, true);
                }
            }
        }

        public string CustomerName
        {
            get { return _CustomerName; }
            set
            {
                if (_CustomerName != value)
                {
                    _CustomerName = value;
                    OnPropertyChanged(() => CustomerName, true);
                }
            }
        }

        public string CustomerEmailAddress
        {
            get { return _CustomerEmailAddress; }
            set
            {
                if (_CustomerEmailAddress != value)
                {
                    _CustomerEmailAddress = value;
                    OnPropertyChanged(() => CustomerEmailAddress, true);
                }
            }
        }

        public string FacilityType
        {
            get { return _FacilityType; }
            set
            {
                if (_FacilityType != value)
                {
                    _FacilityType = value;
                    OnPropertyChanged(() => FacilityType, true);
                }
            }
        }

        public string CountryIso3
        {
            get { return _CountryIso3; }
            set
            {
                if (_CountryIso3 != value)
                {
                    _CountryIso3 = value;
                    OnPropertyChanged(() => CountryIso3, true);
                }
            }
        }

        public string StateProvinceCode
        {
            get { return _StateProvinceCode; }
            set
            {
                if (_StateProvinceCode != value)
                {
                    _StateProvinceCode = value;
                    OnPropertyChanged(() => StateProvinceCode, true);
                }
            }
        }

        public string City
        {
            get { return _City; }
            set
            {
                if (_City != value)
                {
                    _City = value;
                    OnPropertyChanged(() => City, true);
                }
            }
        }

        public string StreetAddress
        {
            get { return _StreetAddress; }
            set
            {
                if (_StreetAddress != value)
                {
                    _StreetAddress = value;
                    OnPropertyChanged(() => StreetAddress, true);
                }
            }
        }

        public string CustomerContactPerson
        {
            get { return _CustomerContactPerson; }
            set
            {
                if (_CustomerContactPerson != value)
                {
                    _CustomerContactPerson = value;
                    OnPropertyChanged(() => CustomerContactPerson, true);
                }
            }
        }

        public string CustomerContactPhone
        {
            get { return _CustomerContactPhone; }
            set
            {
                if (_CustomerContactPhone != value)
                {
                    _CustomerContactPhone = value;
                    OnPropertyChanged(() => CustomerContactPhone, true);
                }
            }
        }

        #endregion

        public string ServerSystemNumber
        {
            get { return _ServerSystemNumber; }
            set
            {
                if (_ServerSystemNumber != value)
                {
                    _ServerSystemNumber = value;
                    OnPropertyChanged(() => ServerSystemNumber, true);
                }
            }
        }

        public string ActivatedByPersonName
        {
            get { return _ActivatedByPersonName; }
            set
            {
                if (_ActivatedByPersonName != value)
                {
                    _ActivatedByPersonName = value;
                    OnPropertyChanged(() => ActivatedByPersonName, true);
                }
            }
        }

        public int MajorVersion { get; set; }

        public LicenseType LicenseType { get; set; }
    }

}
