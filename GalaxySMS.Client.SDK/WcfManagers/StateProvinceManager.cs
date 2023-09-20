////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\StateProvinceManager.cs
//
// summary:	Implements the role manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Contracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for state provinces. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class StateProvinceManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The states provinces. </summary>
        private List<StateProvince> _StatesProvinces;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the states provinces. </summary>
        ///
        /// <value> The states provinces. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<StateProvince> StatesProvinces { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public StateProvinceManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public StateProvinceManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _StatesProvinces = new List<StateProvince>();
        }

        #endregion

        #region Public methods

        #region Get all states/provinces for country

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets states provinces for country. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The states provinces for country. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<StateProvince> GetStatesProvincesForCountry(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _StatesProvinces = new List<StateProvince>();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            StateProvince[] statesProvinces = proxy.GetAllStatesProvincesForCountry(parameters);
                            if (statesProvinces != null)
                            {
                                foreach (var region in statesProvinces)
                                    _StatesProvinces.Add(region);
                            }
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                            if (rethrow)
                                throw ex;
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                            if (rethrow)
                                throw ex;
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                            if (rethrow)
                                throw ex;
                        }
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            StatesProvinces = new ReadOnlyCollection<StateProvince>(_StatesProvinces);
            return StatesProvinces;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets states provinces for country asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The states provinces for country asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<StateProvince>> GetStatesProvincesForCountryAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _StatesProvinces = new List<StateProvince>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            StateProvince[] statesProvinces = await proxy.GetAllStatesProvincesForCountryAsync(parameters);
                            if (statesProvinces != null)
                            {
                                foreach (var sp in statesProvinces)
                                    _StatesProvinces.Add(sp);
                            }
                            StatesProvinces = new ReadOnlyCollection<StateProvince>(_StatesProvinces);
                            return StatesProvinces;
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

            return StatesProvinces;
        }

        #endregion

        #region GetAll

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all states provinces. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all states provinces. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<StateProvince> GetAllStatesProvinces(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _StatesProvinces = new List<StateProvince>();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            StateProvince[] statesProvinces = proxy.GetAllStatesProvinces(parameters);
                            if (statesProvinces != null)
                            {
                                foreach (var region in statesProvinces)
                                    _StatesProvinces.Add(region);
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

            StatesProvinces = new ReadOnlyCollection<StateProvince>(_StatesProvinces);
            return StatesProvinces;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all states provinces asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all states provinces asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<StateProvince>> GetAllStatesProvincesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _StatesProvinces = new List<StateProvince>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            StateProvince[] statesProvinces = await proxy.GetAllStatesProvincesAsync(parameters);
                            if (statesProvinces != null)
                            {
                                foreach (var region in statesProvinces)
                                    _StatesProvinces.Add(region);
                            }
                            StatesProvinces = new ReadOnlyCollection<StateProvince>(_StatesProvinces);
                            return StatesProvinces;
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

            return StatesProvinces;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the state province described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteStateProvince(DeleteParameters<StateProvince> parameters)
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteStateProvince(parameters);
                            _StatesProvinces.Remove(parameters.Data);
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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the state province asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task DeleteStateProvinceAsync(DeleteParameters<StateProvince> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                await WithClientAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                        {
                            // For some reason, the DeleteStateProvinceAsync throws a WCF exception
                            //await proxy.DeleteStateProvinceAsync(parameters);
                            proxy.DeleteStateProvince(parameters);
                            _StatesProvinces.Remove(parameters.Data);
                            StatesProvinces = new ReadOnlyCollection<StateProvince>(_StatesProvinces);
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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the state province by unique identifier described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteStateProvinceByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteStateProvinceByPk(parameters);
                            foreach (var r in _StatesProvinces)
                            {
                                if (r.StateProvinceUid == parameters.UniqueId)
                                {
                                    _StatesProvinces.Remove(r);
                                    break;
                                }
                            }
                            StatesProvinces = new ReadOnlyCollection<StateProvince>(_StatesProvinces);
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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the state province by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task DeleteStateProvinceByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                await WithClientAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            await proxy.DeleteStateProvinceByPkAsync(parameters);
                            foreach (var r in _StatesProvinces)
                            {
                                if (r.StateProvinceUid == parameters.UniqueId)
                                {
                                    _StatesProvinces.Remove(r);
                                    break;
                                }
                            }
                            StatesProvinces = new ReadOnlyCollection<StateProvince>(_StatesProvinces);
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
        }

        #endregion

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a state province. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A StateProvince. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public StateProvince SaveStateProvince(SaveParameters<StateProvince> parameters)
        {
            InitializeErrorsCollection();
            StateProvince savedStateProvince = null;
            bool isNew = (parameters.Data.StateProvinceUid == Guid.Empty);
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedStateProvince = proxy.SaveStateProvince(parameters);
                            _StatesProvinces.Add(savedStateProvince);
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

            return savedStateProvince;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a state province asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;StateProvince&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<StateProvince> SaveStateProvinceAsync(SaveParameters<StateProvince> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            StateProvince savedStateProvince = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.StateProvinceUid == Guid.Empty);
                            savedStateProvince = await proxy.SaveStateProvinceAsync(parameters);
                            return savedStateProvince;
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

            return savedStateProvince;
        }

        #endregion

        #region Get by Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets state province. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The state province. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public StateProvince GetStateProvince(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            StateProvince region = null;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            region = proxy.GetStateProvince(parameters);
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
        /// <summary>   Gets state province asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The state province asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<StateProvince> GetStateProvinceAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            StateProvince region = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            region = await proxy.GetStateProvinceAsync(parameters);
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