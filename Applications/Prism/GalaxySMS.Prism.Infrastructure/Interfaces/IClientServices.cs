using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Managers;
using GCS.Core.Common;
using GCS.Framework.Licensing;
using GCS.Framework.Utilities;
using Portable.Licensing.Prime;
using Portable.Licensing.Prime.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GalaxySMS.Prism.Infrastructure
{
    public interface IClientServices
    {
        #region Properties
        ObservableCollection<IGalaxySiteServerConnection> ServerConnections { get; set; }

        UserSessionToken UserSessionToken { get; set; }
        Guid CurrentSessionId { get; }
        Guid CurrentEntityId { get; }
        Site CurrentSite { get; set; }
        ListCollectionView CurrentEntitySites { get; set; }

        AssemblyAttributes MyAssemblyAttributes { get; set; }
        bool IsApplicationValidatedWithServer { get; }
        gcsApplication ThisApplication { get; }
        string EntityAlias { get; set; }
        string EntityAliasPlural { get; set; }
        string CustomerName { get; set; }
        string CustomerEmail { get; set; }

        bool IsLicenseValid { get; }

        LicenseData MyLicense { get; }
        gcsSystem SystemData { get; }

        string LicensedCustomerName { get; }

        string LicensedCustomerCompany { get; }

        string LicensedCustomerEmail { get; }

        DateTimeOffset LicenseExpiration { get; }

        LicenseType LicenseType { get; }

        string LicenseTypeDescription { get; }

        Guid LicenseId { get; }

        IEnumerable<IValidationFailure> LicenseValidationFailures { get; }
        IEnumerable<CustomError> InitializeSystemDatabaseErrors { get; }
        IEnumerable<CustomError> ApplicationManagerErrors { get; }

        int DefaultGridPageSize { get; set; }
        int ThumbnailPixelWidth { get; set; }
        #endregion

        #region Methods
        void Initialize(GalaxySiteServerConnection serverConnection, AssemblyAttributes assemblyAttributes);
        void ChangeCulture(string culture, string uiCulture);
        T GetManager<T>() where T : ManagerBase, new();
        bool LoadLicense(string publicKey, string licenseFilename, bool bUseLocalLicenseFile);
        InitializeSystemDatabaseRequest GetDefaultRequestData();
        Task<bool> InitializeSystemDatabaseAsync(InitializeSystemDatabaseRequest initializeData);
        //Task<gcsApplication> ValidateMyApplicationWithServerAsync(bool bCreate, gcsRole systemRole);
        Task<gcsApplication> ValidateMyApplicationWithServerAsync(bool bCreate);
        ReadOnlyCollection<Region> GetRegions();

        ReadOnlyCollection<Country> GetCountries(bool bIncludeStatesProvinces);
        Task<ReadOnlyCollection<Country>> GetCountriesAsync(bool bIncludeStatesProvinces);
        ReadOnlyCollection<StateProvince> GetStatesProvincesForCountry(Country country);
        Task<ReadOnlyCollection<StateProvince>> GetStatesProvincesForCountryAsync(Country country);
        ReadOnlyCollection<Client.Entities.TimeZone> GetTimeZones();
        ReadOnlyCollection<StringIntPair> GetAccessRuleOverrideTimeoutValues();
        ReadOnlyCollection<StringIntPair> GetUnlimitedCredentialTimeoutValues();
        ICollection<UserEntitySelect> BuildUserEntitiesSelectionList(IHasEntityMappingList item, Guid ownerEntityId);
        Task RefreshEntityList(bool bIncludePhoto);
        Task<gcsEntity> GetEntity(Guid entityId);
        Task UserEntitiesChanged();

        #endregion
    }
}