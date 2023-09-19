////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\CountryManager.cs
//
// summary:	Implements the country manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Client.Contracts.NetCore;
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for countries. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CountryManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The country. </summary>
        private List<Country> _Countries;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the country. </summary>
        ///
        /// <value> The country. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<Country> Countries { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CountryManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CountryManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _Countries = new List<Country>();
        }

        #endregion

        #region Public methods

        #region GetAll

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all countries. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all countries. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<Country> GetAllCountries(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Countries = new List<Country>();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            Country[] data = proxy.GetAllCountries(parameters);
                            if (data != null)
                            {
                                foreach (var c in data)
                                    _Countries.Add(c);
                            }
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            Countries = new ReadOnlyCollection<Country>(_Countries);
            return Countries;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all countries asynchronously. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all countries asynchronously. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<Country>> GetAllCountriesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Countries = new List<Country>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllCountriesAsync(parameters);
                            if (data != null)
                            {
                                foreach (var c in data)
                                    _Countries.Add(c);
                            }
                            Countries = new ReadOnlyCollection<Country>(_Countries);
                            return Countries;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return Countries;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the country described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteCountry(DeleteParameters<Country> parameters)
        {
            InitializeErrorsCollection();
            int ret = 0;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            ret = proxy.DeleteCountry(parameters);
                            _Countries.Remove(parameters.Data);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }

                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });
            return ret;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the country asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteCountryAsync(DeleteParameters<Country> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int ret = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            // For some reason, the DeleteCountryAsync throws a WCF exception
                            //await proxy.DeleteCountryAsync(parameters);
                            ret = proxy.DeleteCountry(parameters);
                            _Countries.Remove(parameters.Data);
                            Countries = new ReadOnlyCollection<Country>(_Countries);
                            return ret;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            return ret;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the country by unique identifier described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteCountryByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int ret = 0;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            ret = proxy.DeleteCountryByPk(parameters);
                            foreach (var r in _Countries)
                            {
                                if (r.CountryUid == parameters.UniqueId)
                                {
                                    _Countries.Remove(r);
                                    break;
                                }
                            }
                            Countries = new ReadOnlyCollection<Country>(_Countries);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }

                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });
            return ret;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the country by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteCountryByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int ret = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            ret = await proxy.DeleteCountryByPkAsync(parameters);
                            foreach (var r in _Countries)
                            {
                                if (r.CountryUid == parameters.UniqueId)
                                {
                                    _Countries.Remove(r);
                                    break;
                                }
                            }
                            Countries = new ReadOnlyCollection<Country>(_Countries);
                            return ret;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            return ret;
        }

        #endregion

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a country. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Country. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Country SaveCountry(SaveParameters<Country> parameters)
        {
            InitializeErrorsCollection();
            Country savedCountry = null;
            bool isNew = (parameters.Data.CountryUid == Guid.Empty);
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedCountry = proxy.SaveCountry(parameters);
                            _Countries.Add(savedCountry);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return savedCountry;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a country asynchronously. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;Country&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<Country> SaveCountryAsync(SaveParameters<Country> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            Country savedCountry = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.CountryUid == Guid.Empty);
                            savedCountry = await proxy.SaveCountryAsync(parameters);
                            return savedCountry;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return savedCountry;
        }

        #endregion

        #region Get by Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a country. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The country. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Country GetCountry(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            Country region = null;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            region = proxy.GetCountry(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return region;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets country asynchronously. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The country asynchronously. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<Country> GetCountryAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            Country region = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            region = await proxy.GetCountryAsync(parameters);
                            return region;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return region;
        }

        #endregion

        #region Get by Iso

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets country by ISO value </summary>
        /// <remarks>   Assign the country ISO 2 character value to search for to the parameters.GetString property</remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The country by ISO. </returns>
        ///=================================================================================================

        public Country GetCountryByIso(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            Country item = null;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            item = proxy.GetCountryByIso(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return item;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets country by ISO value asynchronously. </summary>
        /// <remarks>   Assign the country ISO 2 character value to search for to the parameters.GetString property</remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The country by ISO asynchronously. </returns>
        ///=================================================================================================

        public async Task<Country> GetCountryByIsoAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            Country item = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            item = await proxy.GetCountryByIsoAsync(parameters);
                            return item;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return item;
        }

        #endregion

        #region Get by Iso

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets country by ISO 3. </summary>
        /// <remarks>   Assign the country ISO3 value to search for to the parameters.GetString property</remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The country by ISO 3. </returns>
        ///=================================================================================================

        public Country GetCountryByIso3(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            Country item = null;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            item = proxy.GetCountryByIso3(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return item;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets country asynchronously. </summary>
        /// <remarks>   Assign the country ISO3 value to search for to the parameters.GetString property</remarks>
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The country asynchronously. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<Country> GetCountryByIso3Async(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            Country item = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            item = await proxy.GetCountryByIso3Async(parameters);
                            return item;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return item;
        }

        #endregion

        #region Get by Country Name

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets country by country name. </summary>
        /// <remarks>   Assign the country name to search for to the parameters.GetString property</remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The country by country name. </returns>
        ///=================================================================================================

        public ReadOnlyCollection<Country> GetByCountryName(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _Countries = new List<Country>();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetCountriesByCountryName(parameters);
                            if (data != null)
                            {
                                foreach (var c in data)
                                    _Countries.Add(c);
                            }

                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            Countries = new ReadOnlyCollection<Country>(_Countries);
            return Countries;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets country by country name asynchronously. </summary>
        /// <remarks>   Assign the country name to search for to the parameters.GetString property</remarks>
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The country by country name asynchronously. </returns>
        ///=================================================================================================

        public async Task<ReadOnlyCollection<Country>> GetByCountryNameAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetCountriesByCountryNameAsync(parameters);
                            if (data != null)
                            {
                                foreach (var c in data)
                                    _Countries.Add(c);
                            }
                            Countries = new ReadOnlyCollection<Country>(_Countries);
                            return Countries;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            Countries = new ReadOnlyCollection<Country>(_Countries);
            return Countries;
        }

        #endregion
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the errors occurred event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnErrorsOccurred(ErrorsOccurredEventArgs e)
        {
            base.OnErrorsOccurred(e);
        }
    }
}
