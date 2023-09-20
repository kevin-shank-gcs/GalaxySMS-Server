using System;
using System.Collections.Generic;
using System.Linq;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
using System.Runtime.Serialization;
using GalaxySMS.Common.Constants;
using System.Diagnostics;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class gcsSystem
    {
        public gcsSystem()
        {
            Initialize();
        }

        public gcsSystem(gcsSystem e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsSystem e)
        {
            Initialize();
            if (e == null)
                return;
            this.SystemId = e.SystemId;
            this.License = e.License;
            this.PublicKey = e.PublicKey;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.SystemName = e.SystemName;
            this.CompanyName = e.CompanyName;
            this.CompanyEmail = e.CompanyEmail;
            this.SupportCompany = e.SupportCompany;
            this.SupportContact = e.SupportContact;
            this.SupportPhone = e.SupportPhone;
            this.SupportEmail = e.SupportEmail;
            this.SupportUrl = e.SupportUrl;
            this.SupportImage = e.SupportImage;
            this.SystemImage = e.SystemImage;
            this.SystemVersion = e.SystemVersion;
            this.TheLicense = GCS.Core.Common.Utils.XmlUtilities.ConvertXmlStringtoObject<License>(License);
            this.IdProducerRootData = e.IdProducerRootData;
            this.IsLicenseValid = e.IsLicenseValid;
        }

        public gcsSystem Clone(gcsSystem e)
        {
            return new gcsSystem(e);
        }

        public bool Equals(gcsSystem other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsSystem other)
        {
            if (other == null)
                return false;

            if (other.SystemId != this.SystemId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

#if NetCoreApi
#else
        [DataMember]
#endif

        public SubscriptionData IdProducerRootData { get; set; }


        public T GetLicenseFeatureValue<T>(LicenseFeatureKey featureKey)
        {
            var feature = TheLicense?.ProductFeatures?.FirstOrDefault(o => o.name == featureKey.ToString());
            if (feature == null)
                return Activator.CreateInstance<T>();
            var sValue = feature.Value;
            return (T)Convert.ChangeType(sValue, typeof(T));
        }

#if NetCoreApi
#else
        [DataMember]
#endif

        public bool IsLicenseValid { get; set; }

        public bool IsLicenseTrial
        {
            get
            {
                return TheLicense?.Type?.ToLower() == "trial";
            }
        }

        public bool IsLicenseExpired
        {
            get
            {
                if( string.IsNullOrEmpty(TheLicense?.Expiration))
                    return true;
                DateTimeOffset expirationDate = DateTimeOffset.MinValue;
                if( DateTimeOffset.TryParse(TheLicense.Expiration, out expirationDate))
                    return expirationDate < DateTimeOffset.Now;
                return true;
            }
        }
    }
}
