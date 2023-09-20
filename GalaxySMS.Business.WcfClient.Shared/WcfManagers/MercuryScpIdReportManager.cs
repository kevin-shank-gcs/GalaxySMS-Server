////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\RoleManager.cs
//
// summary:	Implements the role manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Business.Entities;
#if NETCOREAPP
using GalaxySMS.Client.Contracts.NetCore;
#else
using GalaxySMS.Client.Contracts;
#endif
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.ServiceModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for MercuryScpIdReports. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class MercuryScpIdReportManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The MercScpIdReports. </summary>
        private List<MercScpIdReport> _MercScpIdReports;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the MercScpIdReports. </summary>
        ///
        /// <value> The MercScpIdReports. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<MercScpIdReport> MercScpIdReports { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MercuryScpIdReportManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MercuryScpIdReportManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _MercScpIdReports = new List<MercScpIdReport>();
        }

        #endregion

        #region Public methods

        #region GetAllMercScpIdReports

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all MercScpIdReports. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all MercScpIdReports. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<MercScpIdReport> GetAllMercScpIdReports(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _MercScpIdReports = new List<MercScpIdReport>();

            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            MercScpIdReport[] data = proxy.GetAllMercScpIdReports(parameters);
                            if (data != null)
                            {
                                foreach (var item in data)
                                    _MercScpIdReports.Add(item);
                            }
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            MercScpIdReports = new ReadOnlyCollection<MercScpIdReport>(_MercScpIdReports);
            return MercScpIdReports;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all MercScpIdReports asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all MercScpIdReports asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<MercScpIdReport>> GetAllMercScpIdReportsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _MercScpIdReports = new List<MercScpIdReport>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            MercScpIdReport[] data = await proxy.GetAllMercScpIdReportsAsync(parameters);
                            if (data != null)
                            {
                                foreach (var item in data)
                                    _MercScpIdReports.Add(item);
                            }
                            MercScpIdReports = new ReadOnlyCollection<MercScpIdReport>(_MercScpIdReports);
                            return MercScpIdReports;
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

            return MercScpIdReports;
        }

        #endregion

        #region Get MercScpIdReports by Mac Address

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all MercScpIdReports. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all MercScpIdReports. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<MercScpIdReport> GetMercScpIdReportsByMacAddress(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _MercScpIdReports = new List<MercScpIdReport>();

            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            MercScpIdReport[] data = proxy.GetMercScpIdReportsByMacAddress(parameters);
                            if (data != null)
                            {
                                foreach (var item in data)
                                    _MercScpIdReports.Add(item);
                            }
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            MercScpIdReports = new ReadOnlyCollection<MercScpIdReport>(_MercScpIdReports);
            return MercScpIdReports;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all MercScpIdReports asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all MercScpIdReports asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<MercScpIdReport>> GetMercScpIdReportsByMacAddressAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _MercScpIdReports = new List<MercScpIdReport>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            MercScpIdReport[] data = await proxy.GetMercScpIdReportsByMacAddressAsync(parameters);
                            if (data != null)
                            {
                                foreach (var item in data)
                                    _MercScpIdReports.Add(item);
                            }
                            MercScpIdReports = new ReadOnlyCollection<MercScpIdReport>(_MercScpIdReports);
                            return MercScpIdReports;
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

            return MercScpIdReports;
        }

        #endregion

        #region GetMercScpIdReport by Model & Serial Number

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all MercScpIdReports. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all MercScpIdReports. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<MercScpIdReport> GetMercScpIdReportsByModelAndSerialNumber(GetParametersWithPhoto parameters, string model)
        {
            InitializeErrorsCollection();
            _MercScpIdReports = new List<MercScpIdReport>();

            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            MercScpIdReport[] data = proxy.GetMercScpIdReportsByModelAndSerialNumber(parameters, model);
                            if (data != null)
                            {
                                foreach (var item in data)
                                    _MercScpIdReports.Add(item);
                            }
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            MercScpIdReports = new ReadOnlyCollection<MercScpIdReport>(_MercScpIdReports);
            return MercScpIdReports;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all MercScpIdReports asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all MercScpIdReports asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<MercScpIdReport>> GetMercScpIdReportsByModelAndSerialNumberAsync(GetParametersWithPhoto parameters, string model)
        {
            InitializeErrorsCollection();
            _MercScpIdReports = new List<MercScpIdReport>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            MercScpIdReport[] data = await proxy.GetMercScpIdReportsByModelAndSerialNumberAsync(parameters, model);
                            if (data != null)
                            {
                                foreach (var item in data)
                                    _MercScpIdReports.Add(item);
                            }
                            MercScpIdReports = new ReadOnlyCollection<MercScpIdReport>(_MercScpIdReports);
                            return MercScpIdReports;
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

            return MercScpIdReports;
        }

        #endregion

        #region Get by Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a MercScpIdReport. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The MercScpIdReport. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MercScpIdReport GetMercScpIdReport(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            MercScpIdReport data = null;
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetMercScpIdReport(parameters);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets MercScpIdReport asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The MercScpIdReport asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<MercScpIdReport> GetMercScpIdReportAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            MercScpIdReport data = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            data = await proxy.GetMercScpIdReportAsync(parameters);
                            return data;
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

            return data;
        }

        #endregion

        #region Insert

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a MercScpIdReport. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A MercScpIdReport. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MercScpIdReport InsertMercScpIdReport(SaveParameters<MercScpIdReport> parameters)
        {
            InitializeErrorsCollection();
            MercScpIdReport saved = null;
            bool isNew = (parameters.Data.MercScpIdReportUid == Guid.Empty);
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            saved = proxy.InsertMercScpIdReport(parameters);
                            _MercScpIdReports.Add(saved);
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return saved;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inserts a MercScpIdReport asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;MercScpIdReport&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<MercScpIdReport> InsertMercScpIdReportAsync(SaveParameters<MercScpIdReport> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            MercScpIdReport saved = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.MercScpIdReportUid == Guid.Empty);
                            saved = await proxy.InsertMercScpIdReportAsync(parameters);
                            return saved;
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

            return saved;
        }

        #endregion

        #region DeleteByUniqueId

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the MercScpIdReport by unique identifier described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteMercScpIdReportByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<IMercuryManagementService>(
                _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                    GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteMercScpIdReportByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var i in _MercScpIdReports)
                                {
                                    if (i.MercScpIdReportUid == parameters.UniqueId)
                                    {
                                        _MercScpIdReports.Remove(i);
                                        break;
                                    }
                                }
                                MercScpIdReports = new ReadOnlyCollection<MercScpIdReport>(_MercScpIdReports);
                            }
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                        }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                if( !string.IsNullOrEmpty(ex.Message))
                    AddError(new CustomError(ex));
                else
                    AddError(new CustomError(ex.Detail));
            }

                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                        }
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });


            return countDeleted;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the MercScpIdReport by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteMercScpIdReportByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int countDeleted = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IMercuryManagementService>(Binding,
                        GetServiceAddress(ServiceNames.MercuryManagementService), ClientUserSessionData), async proxy =>
                        {
                            // For some reason, the DeleteCountryAsync throws a WCF exception
                            //await proxy.DeleteCountryAsync(parameters);
                            countDeleted = await proxy.DeleteMercScpIdReportByPkAsync(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var i in _MercScpIdReports)
                                {
                                    if (i.MercScpIdReportUid == parameters.UniqueId)
                                    {
                                        _MercScpIdReports.Remove(i);
                                        break;
                                    }
                                }
                                MercScpIdReports = new ReadOnlyCollection<MercScpIdReport>(_MercScpIdReports);
                            }
                            return countDeleted;
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
            return countDeleted;
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