////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\SystemManager.cs
//
// summary:	Implements the system manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
#if NETCOREAPP
using GalaxySMS.Client.Contracts.NetCore;
#else
using GalaxySMS.Client.Contracts;
#endif
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Client.SDK.Managers
{
    #region EventArg Classes

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for get all systems completed events. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GetAllSystemsCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="systems">              The systems. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetAllSystemsCompletedEventArgs(ReadOnlyCollection<gcsSystem> systems, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            Systems = systems;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the systems. </summary>
        ///
        /// <value> The systems. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsSystem> Systems { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for get system completed event. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GetSystemCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="system">               The system. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetSystemCompletedEventArgs(gcsSystem system, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            System = system;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the system. </summary>
        ///
        /// <value> The system. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsSystem System { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for delete system completed events. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DeleteSystemCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="system">               The system. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DeleteSystemCompletedEventArgs(gcsSystem system, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            System = system;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the system. </summary>
        ///
        /// <value> The system. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsSystem System { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for save system completed events. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SaveSystemCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="system">               The system. </param>
        /// <param name="isNew">                true if this object is new, false if not. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveSystemCompletedEventArgs(gcsSystem system, Boolean isNew, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            System = system;
            IsNew = isNew;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the system. </summary>
        ///
        /// <value> The system. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsSystem System { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this object is new. </summary>
        ///
        /// <value> true if this object is new, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Boolean IsNew { get; internal set; }
    }
    #endregion

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for systems. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SystemManager : ManagerBase
    {
        #region Private fields
        /// <summary>   The systems. </summary>
        private List<gcsSystem> _Systems;

        /// <summary>   The system. </summary>
        private gcsSystem _System;
        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the systems. </summary>
        ///
        /// <value> The systems. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsSystem> Systems { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the system. </summary>
        ///
        /// <value> The system. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsSystem System { get; internal set; }

        #endregion

        #region Events and Delegates

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GetAllSystemsCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Get all systems completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GetAllSystemsCompletedEventHandler(object sender, GetAllSystemsCompletedEventArgs e);

        /// <summary>   Event queue for all listeners interested in getAllSystemsCompleted events. </summary>

        public event GetAllSystemsCompletedEventHandler GetAllSystemsCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GetSystemCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Get system completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GetSystemCompletedEventHandler(object sender, GetSystemCompletedEventArgs e);

        /// <summary>   Event queue for all listeners interested in getSystemCompleted events. </summary>

        public event GetSystemCompletedEventHandler GetSystemCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling DeleteSystemCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Delete system completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void DeleteSystemCompletedEventHandler(object sender, DeleteSystemCompletedEventArgs e);

        /// <summary>   Event queue for all listeners interested in deleteSystemCompleted events. </summary>

        public event DeleteSystemCompletedEventHandler DeleteSystemCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling SaveSystemCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Save system completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void SaveSystemCompletedEventHandler(object sender, SaveSystemCompletedEventArgs e);
        /// <summary>   Event queue for all listeners interested in saveSystemCompleted events. </summary>
        public event SaveSystemCompletedEventHandler SaveSystemCompletedEvent;
        #endregion

        #region Constructor
        public SystemManager()
        {

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SystemManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _Systems = new List<gcsSystem>();
        }
        #endregion

        #region Public methods

        #region GetAll

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all systems. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <returns>   all systems. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsSystem> GetAllSystems()
        {
            InitializeErrorsCollection();
            _Systems = new List<gcsSystem>();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            gcsSystem[] systems = proxy.GetAllSystems();
                            if (systems != null)
                            {
                                foreach (gcsSystem system in systems)
                                    _Systems.Add(system);
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
                    });

            Systems = new ReadOnlyCollection<gcsSystem>(_Systems);
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            return Systems;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all systems asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public void GetAllSystemsAsync()
        //{
        //    InitializeErrorsCollection();
        //    _Systems = new List<gcsSystem>();

        //    DateTimeOffset startedAt = DateTimeOffset.Now;

        //    WithClientAsync<IAdministrationService>(
        //        _ServiceFactory.CreateClient<IAdministrationService>(Binding,
        //            GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
        //            {
        //                if (proxy != null)
        //                {
        //                    Func<Task> task = async () =>
        //                    {
        //                        Task<gcsSystem[]> t = proxy.GetAllSystemsAsync();
        //                        gcsSystem[] systems = await t;
        //                        if (systems != null)
        //                        {
        //                            foreach (gcsSystem system in systems)
        //                            {
        //                                _Systems.Add(system);
        //                            }
        //                        }
        //                    };
        //                    try
        //                    {
        //                        task().Wait();
        //                        DateTimeOffset endedAt = DateTimeOffset.Now;
        //                        var handler = GetAllSystemsCompletedEvent;
        //                        if (handler != null)
        //                        {
        //                            handler(this,
        //                                new GetAllSystemsCompletedEventArgs(
        //                                    new ReadOnlyCollection<gcsSystem>(_Systems), startedAt, endedAt));
        //                        }
        //                    }
        //                    catch (AggregateException ae)
        //                    {
        //                        ae = ae.Flatten();
        //                        foreach (Exception ex in ae.InnerExceptions)
        //                        {
        //                            AddError(new CustomError(ex.Message));
        //                            this.Log().Debug(ex.Message);
        //                        }
        //                        OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        //                    }
        //                }
        //            });
        //}

        public async Task<ReadOnlyCollection<gcsSystem>> GetAllSystemsAsync()
        {
            InitializeErrorsCollection();
            _Systems = new List<gcsSystem>();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllSystemsAsync();
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _Systems.Add(o);
                            }
                            Systems = new ReadOnlyCollection<gcsSystem>(_Systems);
                            return Systems;
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

            return Systems;
        }

        #endregion

        #region Get

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a specific system. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="systemId"> The system id. </param>
        ///
        /// <returns>   system. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsSystem GetSystem(Guid systemId)
        {
            InitializeErrorsCollection();
            System = new gcsSystem();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var system = proxy.GetSystem(systemId);
                            System = system;
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
            return System;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets system asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="systemId"> The system id. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public void GetSystemAsync(Guid systemId)
        //{
        //    InitializeErrorsCollection();
        //    System = new gcsSystem();

        //    DateTimeOffset startedAt = DateTimeOffset.Now;

        //    WithClientAsync<IAdministrationService>(
        //        _ServiceFactory.CreateClient<IAdministrationService>(Binding,
        //            GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
        //            {
        //                if (proxy != null)
        //                {
        //                    Func<Task> task = async () =>
        //                    {
        //                        Task<gcsSystem> t = proxy.GetSystemAsync(systemId);
        //                        System = await t;
        //                    };
        //                    try
        //                    {
        //                        task().Wait();
        //                        DateTimeOffset endedAt = DateTimeOffset.Now;
        //                        var handler = GetSystemCompletedEvent;
        //                        if (handler != null)
        //                        {
        //                            handler(this,
        //                                new GetSystemCompletedEventArgs(
        //                                    System, startedAt, endedAt));
        //                        }
        //                    }
        //                    catch (AggregateException ae)
        //                    {
        //                        ae = ae.Flatten();
        //                        foreach (Exception ex in ae.InnerExceptions)
        //                        {
        //                            AddError(new CustomError(ex.Message));
        //                            this.Log().Debug(ex.Message);
        //                        }
        //                        OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        //                    }
        //                }
        //            });
        //}


        public async Task<gcsSystem> GetSystemAsync(Guid systemId)
        {
            InitializeErrorsCollection();
            System = new gcsSystem();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var System = await client.GetSystemAsync(systemId);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return System;
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }

            return null;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the system described by system. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="system">   The system. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteSystem(gcsSystem system)
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteSystem(system);
                            _Systems.Remove(system);
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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the system asynchronous described by system. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="system">   The system. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteSystemAsync(gcsSystem system)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task tDelete = proxy.DeleteSystemAsync(system);
                                await tDelete;
                                _Systems.Remove(system);
                            };

                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = DeleteSystemCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new DeleteSystemCompletedEventArgs(
                                            system, startedAt, endedAt));
                                }
                            }
                            catch (AggregateException ae)
                            {
                                ae = ae.Flatten();
                                foreach (Exception ex in ae.InnerExceptions)
                                {
                                    AddError(new CustomError(ex.Message));
                                    this.Log().Debug(ex.Message);
                                }
                                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                            }
                        }
                    });

        }
        #endregion

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a system. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A gcsSystem. </returns>
        ///=================================================================================================

        public gcsSystem SaveSystem(SaveParameters<gcsSystem> parameters)
        {
            InitializeErrorsCollection();

            gcsSystem savedSystem = null;
            bool isNew = (parameters.Data.SystemId == Guid.Empty);
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {

                            savedSystem = proxy.SaveSystem(parameters);
                            _Systems.Add(savedSystem);
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

            return savedSystem;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a system asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///=================================================================================================

        //public void SaveSystemAsync(SaveParameters<gcsSystem> parameters)
        //{
        //    InitializeErrorsCollection();
        //    DateTimeOffset startedAt = DateTimeOffset.Now;
        //    gcsSystem savedSystem = null;
        //    bool isNew = false;

        //    WithClientAsync<IAdministrationService>(
        //        _ServiceFactory.CreateClient<IAdministrationService>(Binding,
        //            GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
        //            {
        //                if (proxy != null)
        //                {
        //                    Func<Task> task = async () =>
        //                    {
        //                        isNew = (parameters.Data.SystemId == Guid.Empty);
        //                        Task<gcsSystem> t = proxy.SaveSystemAsync(parameters.Data);
        //                        savedSystem = await t;
        //                    };
        //                    try
        //                    {
        //                        task().Wait();
        //                        if (savedSystem != null)
        //                        {
        //                            DateTimeOffset endedAt = DateTimeOffset.Now;
        //                            var handler = SaveSystemCompletedEvent;
        //                            if (handler != null)
        //                            {
        //                                handler(this,
        //                                    new SaveSystemCompletedEventArgs(
        //                                        savedSystem, isNew, startedAt, endedAt));
        //                            }
        //                        }
        //                    }
        //                    catch (AggregateException ae)
        //                    {
        //                        ae = ae.Flatten();
        //                        foreach (Exception ex in ae.InnerExceptions)
        //                        {
        //                            AddError(new CustomError(ex.Message));
        //                            this.Log().Debug(ex.Message);
        //                        }
        //                        OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        //                    }
        //                }
        //            });
        //}
        public async Task<gcsSystem> SaveSystemAsync(SaveParameters<gcsSystem> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            gcsSystem savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.SystemId == Guid.Empty);
                            savedItem = await proxy.SaveSystemAsync(parameters);
                            return savedItem;
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

            return savedItem;

        }
        #endregion

        #region SaveLicense

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a system. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="systemId">     The system id. </param>
        /// <param name="publicKey">    The public key. </param>
        /// <param name="license">      The license text. </param>
        ///
        /// <returns>   A gcsSystem. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsSystem SaveSystemLicense(Guid systemId, string publicKey, string license)
        {
            InitializeErrorsCollection();

            gcsSystem savedSystem = null;
            bool isNew = (systemId == Guid.Empty);
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {

                            savedSystem = proxy.SaveSystemLicense(systemId, publicKey, license);
                            _Systems.Add(savedSystem);
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

            return savedSystem;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a system asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="systemId">     The system id. </param>
        /// <param name="publicKey">    The public key. </param>
        /// <param name="license">      The license text. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<gcsSystem> SaveSystemLicenseAsync(Guid systemId, string publicKey, string license)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            gcsSystem savedItem = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            savedItem = await proxy.SaveSystemLicenseAsync(systemId, publicKey, license);
                            return savedItem;
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

            return savedItem;
        }

        //public void SaveSystemLicenseAsync(Guid systemId, string publicKey, string license)
        //{
        //    InitializeErrorsCollection();
        //    DateTimeOffset startedAt = DateTimeOffset.Now;
        //    gcsSystem savedSystem = null;
        //    bool isNew = false;

        //    WithClientAsync<IAdministrationService>(
        //        _ServiceFactory.CreateClient<IAdministrationService>(Binding,
        //            GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
        //            {
        //                if (proxy != null)
        //                {
        //                    Func<Task> task = async () =>
        //                    {
        //                        isNew = (systemId == Guid.Empty);
        //                        Task<gcsSystem> t = proxy.SaveSystemLicenseAsync(systemId, publicKey, license);
        //                        savedSystem = await t;
        //                    };
        //                    try
        //                    {
        //                        task().Wait();
        //                        if (savedSystem != null)
        //                        {
        //                            DateTimeOffset endedAt = DateTimeOffset.Now;
        //                            var handler = SaveSystemCompletedEvent;
        //                            if (handler != null)
        //                            {
        //                                handler(this,
        //                                    new SaveSystemCompletedEventArgs(
        //                                        savedSystem, isNew, startedAt, endedAt));
        //                            }
        //                        }
        //                    }
        //                    catch (AggregateException ae)
        //                    {
        //                        ae = ae.Flatten();
        //                        foreach (Exception ex in ae.InnerExceptions)
        //                        {
        //                            AddError(new CustomError(ex.Message));
        //                            this.Log().Debug(ex.Message);
        //                        }
        //                        OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
        //                    }
        //                }
        //            });
        //}
        #endregion


        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the errors occurred event. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="e">    Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnErrorsOccurred(ErrorsOccurredEventArgs e)
        {
            base.OnErrorsOccurred(e);
        }
    }
}
