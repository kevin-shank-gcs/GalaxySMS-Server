////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\GalaxyCpuManager.cs
//
// summary:	Implements the GalaxyCpu manager class
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
    /// <summary>   Manager for galaxy cpus. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyCpuManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The galaxy cpus. </summary>
        private List<GalaxyCpu> _GalaxyCpus;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy cpus. </summary>
        ///
        /// <value> The galaxy cpus. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyCpu> GalaxyCpus { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _GalaxyCpus = new List<GalaxyCpu>();
        }

        #endregion

        #region Public methods

        #region Get all GalaxyCpus for a Cluster

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy cpus for cluster. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy cpus for cluster. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyCpu> GetGalaxyCpusForCluster(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyCpus = new List<GalaxyCpu>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyCpusForCluster(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyCpus.Add(o);
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

            GalaxyCpus = new ReadOnlyCollection<GalaxyCpu>(_GalaxyCpus);
            return GalaxyCpus;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy cpus for cluster asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy cpus for cluster asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyCpu>> GetGalaxyCpusForClusterAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyCpus = new List<GalaxyCpu>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyCpusForClusterAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyCpus.Add(o);
                            }
                            GalaxyCpus = new ReadOnlyCollection<GalaxyCpu>(_GalaxyCpus);
                            return GalaxyCpus;
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

            return GalaxyCpus;
        }

        #endregion

        #region Get GalaxyCpus for a Panel

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy cpus for panel. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The galaxy cpus for panel. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyCpu> GetGalaxyCpusForPanel(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _GalaxyCpus = new List<GalaxyCpu>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyCpusForPanel(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyCpus.Add(o);
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

            GalaxyCpus = new ReadOnlyCollection<GalaxyCpu>(_GalaxyCpus);
            return GalaxyCpus;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy cpus for panel asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy cpus for panel asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyCpu>> GetGalaxyCpusForPanelAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyCpus = new List<GalaxyCpu>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyCpusForPanelAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyCpus.Add(o);
                            }
                            GalaxyCpus = new ReadOnlyCollection<GalaxyCpu>(_GalaxyCpus);
                            return GalaxyCpus;
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

            return GalaxyCpus;
        }

        #endregion

        //#region Get GalaxyCpus For a Entity

        //public ReadOnlyCollection<GalaxyCpu> GetAllGalaxyCpusForEntity(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _GalaxyCpus = new List<GalaxyCpu>();

        //    WithClient<ISystemManagementService>(
        //        _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //            GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    var data = proxy.GetAllGalaxyCpusForEntity(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _GalaxyCpus.Add(o);
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

        //    GalaxyCpus = new ReadOnlyCollection<GalaxyCpu>(_GalaxyCpus);
        //    return GalaxyCpus;
        //}

        //public async Task<ReadOnlyCollection<GalaxyCpu>> GetAllGalaxyCpusForEntityAsync(GetParametersWithPhoto parameters)
        //{
        //    InitializeErrorsCollection();
        //    _GalaxyCpus = new List<GalaxyCpu>();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //                {
        //                    var data = await proxy.GetAllGalaxyCpusForEntityAsync(parameters);
        //                    if (data != null)
        //                    {
        //                        foreach (var o in data)
        //                            _GalaxyCpus.Add(o);
        //                    }
        //                    GalaxyCpus = new ReadOnlyCollection<GalaxyCpu>(_GalaxyCpus);
        //                    return GalaxyCpus;
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

        //    return GalaxyCpus;
        //}

        //#endregion

        #region Get All GalaxyCpus

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy cpus. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy cpus. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyCpu> GetAllGalaxyCpus(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyCpus = new List<GalaxyCpu>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyCpus(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyCpus.Add(o);
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

            GalaxyCpus = new ReadOnlyCollection<GalaxyCpu>(_GalaxyCpus);
            return GalaxyCpus;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy cpus asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy cpus asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyCpu>> GetAllGalaxyCpusAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyCpus = new List<GalaxyCpu>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyCpusAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyCpus.Add(o);
                            }
                            GalaxyCpus = new ReadOnlyCollection<GalaxyCpu>(_GalaxyCpus);
                            return GalaxyCpus;
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

            return GalaxyCpus;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the galaxy CPU described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyCpu(DeleteParameters<GalaxyCpu> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyCpu(parameters);
                            if (countDeleted == 1)
                            {
                                _GalaxyCpus.Remove(parameters.Data);
                                GalaxyCpus = new ReadOnlyCollection<GalaxyCpu>(_GalaxyCpus);
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
        /// <summary>   Deletes the galaxy CPU asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyCpuAsync(DeleteParameters<GalaxyCpu> parameters)
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
                            // For some reason, the DeleteGalaxyCpuAsync throws a WCF exception
                            countDeleted = await proxy.DeleteGalaxyCpuAsync(parameters);
                            if(countDeleted == 1 )
                            {
                                _GalaxyCpus.Remove(parameters.Data);
                                GalaxyCpus = new ReadOnlyCollection<GalaxyCpu>(_GalaxyCpus);
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
        /// <summary>   Deletes the galaxy CPU by unique identifier described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyCpuByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyCpuByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _GalaxyCpus)
                                {
                                    if (o.CpuUid == parameters.UniqueId)
                                    {
                                        _GalaxyCpus.Remove(o);
                                        break;
                                    }
                                }
                                GalaxyCpus = new ReadOnlyCollection<GalaxyCpu>(_GalaxyCpus);
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
        /// Deletes the galaxy CPU by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyCpuByUniqueIdAsync(DeleteParameters parameters)
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
                            countDeleted = await proxy.DeleteGalaxyCpuByPkAsync(parameters);
                            if( countDeleted == 1)
                            {
                                foreach (var o in _GalaxyCpus)
                                {
                                    if (o.CpuUid == parameters.UniqueId)
                                    {
                                        _GalaxyCpus.Remove(o);
                                        break;
                                    }
                                }
                                GalaxyCpus = new ReadOnlyCollection<GalaxyCpu>(_GalaxyCpus);
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
        /// <summary>   Saves a galaxy CPU. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A GalaxyCpu. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpu SaveGalaxyCpu(SaveParameters<GalaxyCpu> parameters)
        {
            InitializeErrorsCollection();
            GalaxyCpu savedItem = null;
            bool isNew = (parameters.Data.CpuUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveGalaxyCpu(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _GalaxyCpus
                                    where i.CpuUid == parameters.Data.CpuUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _GalaxyCpus.Remove(originalItem);
                            }
                            _GalaxyCpus.Add(savedItem);
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
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return savedItem;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a galaxy CPU asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;GalaxyCpu&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyCpu> SaveGalaxyCpuAsync(SaveParameters<GalaxyCpu> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyCpu savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.CpuUid == Guid.Empty);
                            savedItem = await proxy.SaveGalaxyCpuAsync(parameters);
                            if( isNew == false)
                            {
                                var originalItem = (from i in _GalaxyCpus
                                    where i.CpuUid == parameters.Data.CpuUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _GalaxyCpus.Remove(originalItem);
                            }
                            _GalaxyCpus.Add(savedItem);
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
                
        #region Save Cpu Info

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a galaxy CPU connection information. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A GalaxyCpuDatabaseInformation. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuDatabaseInformation SaveGalaxyCpuConnectionInfo(SaveParameters<CpuConnectionInfo> parameters)
        {
            InitializeErrorsCollection();
            GalaxyCpuDatabaseInformation savedItem = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveGalaxyCpuConnectionInfo(parameters);
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
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return savedItem;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a galaxy CPU connection information asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;GalaxyCpuDatabaseInformation&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyCpuDatabaseInformation> SaveGalaxyCpuConnectionInfoAsync(SaveParameters<CpuConnectionInfo> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyCpuDatabaseInformation savedItem = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            savedItem = await proxy.SaveGalaxyCpuConnectionInfoAsync(parameters);
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
        /// <summary>   Gets galaxy CPU. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy CPU. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpu GetGalaxyCpu(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            GalaxyCpu GalaxyCpu = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            GalaxyCpu = proxy.GetGalaxyCpu(parameters);
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

            return GalaxyCpu;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy CPU asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy CPU asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyCpu> GetGalaxyCpuAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyCpu GalaxyCpu = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            GalaxyCpu = await proxy.GetGalaxyCpuAsync(parameters);
                            return GalaxyCpu;
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

            return GalaxyCpu;
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