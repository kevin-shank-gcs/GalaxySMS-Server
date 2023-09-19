using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common;
using GCS.Framework.Licensing;
using GCS.Framework.Utilities;

namespace GalaxySMS.Services
{
    public class ClientServices : IClientServices
    {
        public ObservableCollection<IGalaxySiteServerConnection> ServerConnections { get; set; }
        public UserSessionToken UserSessionToken { get; set; }
        public AssemblyAttributes MyAssemblyAtrributes { get; set; }

        public bool IsApplicationValidatedWithServer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public gcsApplication ThisApplication
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string CustomerName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string CustomerEmail
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsLicenseValid
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public string LicensedCustomerName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string LicensedCustomerCompany
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string LicensedCustomerEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DateTimeOffset LicenseExpiration
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public global::Portable.Licensing.Prime.LicenseType LicenseType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string LicenseTypeDescription
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Guid LicenseId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<global::Portable.Licensing.Prime.Validation.IValidationFailure> LicenseValidationFailures
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<CustomError> InitializeSystemDatabaseErrors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<CustomError> ApplicationManagerErrors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public LicenseData MyLicense
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Guid CurrentSessionId => throw new NotImplementedException();

        public Guid CurrentEntityId => throw new NotImplementedException();

        public Site CurrentSite { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ListCollectionView CurrentEntitySites { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public AssemblyAttributes MyAssemblyAttributes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EntityAlias { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EntityAliasPlural { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int DefaultGridPageSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ThumbnailPixelWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool LoadLicense(string publicKey, string licenseFilename)
        {
            throw new NotImplementedException();
        }

        public InitializeSystemDatabaseRequest GetDefaultRequestData()
        {
            throw new NotImplementedException();
        }

        public Task<bool> InitializeSystemDatabaseAsync(InitializeSystemDatabaseRequest initializeData)
        {
            throw new NotImplementedException();
        }

        public Task<gcsApplication> ValidateMyApplicationWithServerAsync(bool bCreate, gcsRole systemRole)
        {
            throw new NotImplementedException();
        }

        public void Initialize(GalaxySiteServerConnection serverConnection, AssemblyAttributes assemblyAttributes)
        {
            throw new NotImplementedException();
        }

        public T GetManager<T>() where T : ManagerBase, new()
        {
            throw new NotImplementedException();
        }

        public void ChangeCulture(string culture, string uiCulture)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Region> GetRegions()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Country> GetCountries(bool bIncludeStatesProvinces)
        {
            throw new NotImplementedException();
        }

        public Task<ReadOnlyCollection<Country>> GetCountriesAsync(bool bIncludeStatesProvinces)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<StateProvince> GetStatesProvincesForCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public Task<ReadOnlyCollection<StateProvince>> GetStatesProvincesForCountryAsync(Country country)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<Client.Entities.TimeZone> GetTimeZones()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<StringShortPair> GetAccessRuleOverrideTimeoutValues()
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<StringShortPair> GetUnlimitedCredentialTimeoutValues()
        {
            throw new NotImplementedException();
        }

        public ICollection<UserEntitySelect> BuildUserEntitiesSelectionList(IHasEntityMappingList item, Guid ownerEntityId)
        {
            throw new NotImplementedException();
        }

        public Task RefreshEntityList(bool bIncludePhoto)
        {
            throw new NotImplementedException();
        }

        public Task<gcsEntity> GetEntity(Guid entityId)
        {
            throw new NotImplementedException();
        }
    }
}
