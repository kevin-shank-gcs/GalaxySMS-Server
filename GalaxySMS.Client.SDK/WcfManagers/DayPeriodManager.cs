////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\ScheduleManager.cs
//
// summary:	Implements the Schedule manager class
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
    /// <summary>   Manager for day periods. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DayPeriodManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The day periods. </summary>
        private List<AssaDayPeriod> _DayPeriods;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the day periods. </summary>
        ///
        /// <value> The day periods. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<AssaDayPeriod> DayPeriods { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DayPeriodManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DayPeriodManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _DayPeriods = new List<AssaDayPeriod>();
        }

        #endregion

        #region Public methods
        #region Get All Day Periods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all day periods. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all day periods. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<AssaDayPeriod> GetAllDayPeriods(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _DayPeriods = new List<AssaDayPeriod>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllAssaDayPeriods(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _DayPeriods.Add(o);
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

            DayPeriods = new ReadOnlyCollection<AssaDayPeriod>(_DayPeriods);
            return DayPeriods;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all day periods asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all day periods asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<AssaDayPeriod>> GetAllDayPeriodsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _DayPeriods = new List<AssaDayPeriod>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllAssaDayPeriodsAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _DayPeriods.Add(o);
                            }
                            DayPeriods = new ReadOnlyCollection<AssaDayPeriod>(_DayPeriods);
                            return DayPeriods;
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

            return DayPeriods;
        }

        #endregion

        #region Get all Day Periods for a Entity

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets day periods for entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The day periods for entity. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<AssaDayPeriod> GetDayPeriodsForEntity(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _DayPeriods = new List<AssaDayPeriod>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllAssaDayPeriodsForEntity(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _DayPeriods.Add(o);
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

            DayPeriods = new ReadOnlyCollection<AssaDayPeriod>(_DayPeriods);
            return DayPeriods;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets day periods for entity asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The day periods for entity asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<AssaDayPeriod>> GetDayPeriodsForEntityAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _DayPeriods = new List<AssaDayPeriod>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllAssaDayPeriodsForEntityAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _DayPeriods.Add(o);
                            }
                            DayPeriods = new ReadOnlyCollection<AssaDayPeriod>(_DayPeriods);
                            return DayPeriods;
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

            return DayPeriods;
        }

        #endregion

        //#region Get all Day Periods for a Cluster

        //public ReadOnlyCollection<AssaDayPeriod> GetDayPeriodsForCluster(GetParametersWithPhoto parameters, bool rethrow)
        //{
        //    InitializeErrorsCollection();
        //    _DayPeriods = new List<AssaDayPeriod>();

        //    WithClient<ISystemManagementService>(
        //        _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    var data = proxy.GetAllAssaDayPeriodsForCluster(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _DayPeriods.Add(o);
        //                    }
        //                }
        //                catch (FaultException<ExceptionDetail> ex)
        //                {
        //                    AddError(new CustomError(ex.Detail));
        //                    if (rethrow)
        //                        throw ex;
        //                }
        //                catch (FaultException<ExceptionDetailEx> ex)
        //                {
        //                    AddError(new CustomError(ex.Detail));
        //                    if (rethrow)
        //                        throw ex;
        //                }
        //                catch (Exception ex)
        //                {
        //                    AddError(new CustomError(ex.Message));
        //                    if (rethrow)
        //                        throw ex;
        //                }
        //                if (Errors.Count != 0)
        //                    OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        //            });

        //    DayPeriods = new ReadOnlyCollection<AssaDayPeriod>(_DayPeriods);
        //    return DayPeriods;
        //}

        //public async Task<ReadOnlyCollection<AssaDayPeriod>> GetDayPeriodsForClusterAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _DayPeriods = new List<AssaDayPeriod>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    var data = await proxy.GetAllAssaDayPeriodsForClusterAsync(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _DayPeriods.Add(o);
        //                    }
        //                    DayPeriods = new ReadOnlyCollection<AssaDayPeriod>(_DayPeriods);
        //                    return DayPeriods;
        //                });
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        AddError(new CustomError(ex.Detail));
        //    }
        //    catch (FaultException<ExceptionDetailEx> ex)
        //    {
        //        AddError(new CustomError(ex.Detail));
        //    }
        //    catch (Exception ex)
        //    {
        //        AddError(new CustomError(ex.Message));
        //    }

        //    return DayPeriods;
        //}

        //#endregion

        //#region Get all Day Periods For a specific Assa Abloy DSR

        //public ReadOnlyCollection<AssaDayPeriod> GetAllDayPeriodsForAssaDsr(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _DayPeriods = new List<AssaDayPeriod>();

        //    WithClient<ISystemManagementService>(
        //        _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    var data = proxy.GetAllAssaDayPeriodsForAssaAbloyDsr(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _DayPeriods.Add(o);
        //                    }
        //                }
        //                catch (FaultException<ExceptionDetail> ex)
        //                {
        //                    AddError(new CustomError(ex.Detail));
        //                }
        //                catch (FaultException<ExceptionDetailEx> ex)
        //                {
        //                    AddError(new CustomError(ex.Detail));
        //                }
        //                catch (Exception ex)
        //                {
        //                    AddError(new CustomError(ex.Message));
        //                }
        //                if (Errors.Count != 0)
        //                    OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        //            });

        //    DayPeriods = new ReadOnlyCollection<AssaDayPeriod>(_DayPeriods);
        //    return DayPeriods;
        //}

        //public async Task<ReadOnlyCollection<AssaDayPeriod>> GetAllDayPeriodsForAssaDsrAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _DayPeriods = new List<AssaDayPeriod>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    var data = await proxy.GetAllAssaDayPeriodsForAssaAbloyDsrAsync(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _DayPeriods.Add(o);
        //                    }
        //                    DayPeriods = new ReadOnlyCollection<AssaDayPeriod>(_DayPeriods);
        //                    return DayPeriods;
        //                });
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        AddError(new CustomError(ex.Detail));
        //    }
        //    catch (FaultException<ExceptionDetailEx> ex)
        //    {
        //        AddError(new CustomError(ex.Detail));
        //    }
        //    catch (Exception ex)
        //    {
        //        AddError(new CustomError(ex.Message));
        //    }

        //    return DayPeriods;
        //}

        //#endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the day period described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteDayPeriod(DeleteParameters<AssaDayPeriod> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteAssaDayPeriod(parameters);
                            if(countDeleted == 1)
                                _DayPeriods.Remove(parameters.Data);
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
            return countDeleted;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the day period asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteDayPeriodAsync(DeleteParameters<AssaDayPeriod> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int countDeleted = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            // For some reason, the DeleteSiteAsync throws a WCF exception
                            countDeleted = await proxy.DeleteAssaDayPeriodAsync(parameters);
                            if(countDeleted == 1 )
                            {
                                _DayPeriods.Remove(parameters.Data);
                                DayPeriods = new ReadOnlyCollection<AssaDayPeriod>(_DayPeriods);
                                
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the day period by unique identifier described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteDayPeriodByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteAssaDayPeriodByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _DayPeriods)
                                {
                                    if (o.AssaDayPeriodUid == parameters.UniqueId)
                                    {
                                        _DayPeriods.Remove(o);
                                        break;
                                    }
                                }
                                DayPeriods = new ReadOnlyCollection<AssaDayPeriod>(_DayPeriods);
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
            return countDeleted;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the day period by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteDayPeriodByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int countDeleted = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            countDeleted = await proxy.DeleteAssaDayPeriodByPkAsync(parameters);
                            if( countDeleted == 1)
                            {
                                foreach (var o in _DayPeriods)
                                {
                                    if (o.AssaDayPeriodUid == parameters.UniqueId)
                                    {
                                        _DayPeriods.Remove(o);
                                        break;
                                    }
                                }
                                DayPeriods = new ReadOnlyCollection<AssaDayPeriod>(_DayPeriods);
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

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a day period. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An AssaDayPeriod. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaDayPeriod SaveDayPeriod(SaveParameters<AssaDayPeriod> parameters)
        {
            InitializeErrorsCollection();
            AssaDayPeriod savedItem = null;
            bool isNew = (parameters.Data.AssaDayPeriodUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveAssaDayPeriod(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _DayPeriods
                                    where i.AssaDayPeriodUid == parameters.Data.AssaDayPeriodUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _DayPeriods.Remove(originalItem);
                            }
                            _DayPeriods.Add(savedItem);
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

            return savedItem;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a day period asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;AssaDayPeriod&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AssaDayPeriod> SaveDayPeriodAsync(SaveParameters<AssaDayPeriod> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            AssaDayPeriod savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.AssaDayPeriodUid == Guid.Empty);
                            savedItem = await proxy.SaveAssaDayPeriodAsync(parameters);
                            if( isNew == false)
                            {
                                var originalItem = (from i in _DayPeriods
                                    where i.AssaDayPeriodUid == parameters.Data.AssaDayPeriodUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _DayPeriods.Remove(originalItem);
                            }
                            _DayPeriods.Add(savedItem);
                            return savedItem;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return savedItem;
        }

        #endregion

        #region Get by Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets day period. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The day period. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AssaDayPeriod GetDayPeriod(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            AssaDayPeriod DayPeriod = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            DayPeriod = proxy.GetAssaDayPeriod(parameters);
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

            return DayPeriod;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets day period asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The day period asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AssaDayPeriod> GetDayPeriodAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            AssaDayPeriod DayPeriod = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            DayPeriod = await proxy.GetAssaDayPeriodAsync(parameters);
                            return DayPeriod;
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

            return DayPeriod;
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