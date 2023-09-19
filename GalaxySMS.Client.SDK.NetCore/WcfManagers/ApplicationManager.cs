////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\ApplicationManager.cs
//
// summary:	Implements the application manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
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
using GCS.Framework.Utilities;

namespace GalaxySMS.Client.SDK.Managers
{
    #region EventArg Classes

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for get all applications completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GetAllApplicationsCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="applications">         The applications. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetAllApplicationsCompletedEventArgs(ReadOnlyCollection<gcsApplication> applications, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            Applications = applications;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the applications. </summary>
        ///
        /// <value> The applications. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsApplication> Applications { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for get application completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GetApplicationCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="application">          The application. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetApplicationCompletedEventArgs(gcsApplication application, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            Application = application;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the application. </summary>
        ///
        /// <value> The application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsApplication Application { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for delete application completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DeleteApplicationCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="application">          The application. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DeleteApplicationCompletedEventArgs(gcsApplication application, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            Application = application;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the application. </summary>
        ///
        /// <value> The application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsApplication Application { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for save application completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SaveApplicationCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="application">          The application. </param>
        /// <param name="isNew">                True if this SaveApplicationCompletedEventArgs is new,
        ///                                     false if not. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveApplicationCompletedEventArgs(gcsApplication application, Boolean isNew, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            Application = application;
            IsNew = isNew;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the application. </summary>
        ///
        /// <value> The application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsApplication Application { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this SaveApplicationCompletedEventArgs is new.
        /// </summary>
        ///
        /// <value> True if this SaveApplicationCompletedEventArgs is new, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Boolean IsNew { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Additional information for application validated with server completed events.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ApplicationValidatedWithServerCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="application">              The application. </param>
        /// <param name="isValidated">              True if this
        ///                                         ApplicationValidatedWithServerCompletedEventArgs is
        ///                                         validated, false if not. </param>
        /// <param name="isNew">                    True if this
        ///                                         ApplicationValidatedWithServerCompletedEventArgs is
        ///                                         new, false if not. </param>
        /// <param name="requestInvokedAt">         The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">       The request completed at Date/Time. </param>
        /// <param name="serverConnectionSettings"> The server connection settings. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ApplicationValidatedWithServerCompletedEventArgs(gcsApplication application, Boolean isValidated, Boolean isNew, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt,
            IGalaxySiteServerConnectionSettings serverConnectionSettings)
            : base(requestInvokedAt, requestCompletedAt, serverConnectionSettings)
        {
            Application = application;
            IsValidated = isValidated;
            IsNew = isNew;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ApplicationValidatedWithServerCompletedEventArgs
        /// is validated.
        /// </summary>
        ///
        /// <value>
        /// True if this ApplicationValidatedWithServerCompletedEventArgs is validated, false if not.
        /// </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsValidated { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the application. </summary>
        ///
        /// <value> The application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsApplication Application { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ApplicationValidatedWithServerCompletedEventArgs
        /// is new.
        /// </summary>
        ///
        /// <value>
        /// True if this ApplicationValidatedWithServerCompletedEventArgs is new, false if not.
        /// </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Boolean IsNew { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Additional information for save application audit data completed events.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SaveApplicationAuditDataCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveApplicationAuditDataCompletedEventArgs(DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
        }
    }
    #endregion

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for applications. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ApplicationManager : ManagerBase
    {
        #region Private fields
        /// <summary>   The applications. </summary>
        private List<gcsApplication> _Applications;
        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the applications. </summary>
        ///
        /// <value> The applications. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsApplication> Applications { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the application. </summary>
        ///
        /// <value> The application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsApplication Application { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets my application. </summary>
        ///
        /// <value> my application. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsApplication MyApplication { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets a value indicating whether this ApplicationManager is my application validated with
        /// server.
        /// </summary>
        ///
        /// <value>
        /// True if this ApplicationManager is my application validated with server, false if not.
        /// </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsMyApplicationValidatedWithServer
        {
            get
            {
                if (MyApplication == null)
                    return false;
                return true;
            }
        }

        #endregion

        #region Events and Delegates

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GetAllApplicationsCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Get all applications completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GetAllApplicationsCompletedEventHandler(object sender, GetAllApplicationsCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in getAllApplicationsCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event GetAllApplicationsCompletedEventHandler GetAllApplicationsCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GetApplicationCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Get application completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GetApplicationCompletedEventHandler(object sender, GetApplicationCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in getApplicationCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event GetApplicationCompletedEventHandler GetApplicationCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling DeleteApplicationCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Delete application completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void DeleteApplicationCompletedEventHandler(object sender, DeleteApplicationCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in deleteApplicationCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event DeleteApplicationCompletedEventHandler DeleteApplicationCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling SaveApplicationCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Save application completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void SaveApplicationCompletedEventHandler(object sender, SaveApplicationCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in saveApplicationCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event SaveApplicationCompletedEventHandler SaveApplicationCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling ApplicationValidatedWithServer events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Application validated with server completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void ApplicationValidatedWithServerEventHandler(
            object sender, ApplicationValidatedWithServerCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in applicationValidatedWithServer events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event ApplicationValidatedWithServerEventHandler ApplicationValidatedWithServerEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling SaveApplicationAuditDataCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Save application audit data completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void SaveApplicationAuditDataCompletedEventHandler(object sender, SaveApplicationAuditDataCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in saveApplicationAuditDataCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event SaveApplicationAuditDataCompletedEventHandler SaveApplicationAuditDataCompletedEvent;

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ApplicationManager()
        {
            _Applications = new List<gcsApplication>();
            Application = new gcsApplication();
            MyApplication = null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [ImportingConstructor]
        public ApplicationManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _Applications = new List<gcsApplication>();
            Application = new gcsApplication();
            MyApplication = null;
        }
        #endregion

        #region Public methods

        #region GetAll

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all applications. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   all applications. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsApplication> GetAllApplications()
        {
            InitializeErrorsCollection();
            _Applications = new List<gcsApplication>();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            gcsApplication[] applications = proxy.GetAllApplications();
                            if (applications != null)
                            {
                                foreach (gcsApplication application in applications)
                                    _Applications.Add(application);
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

            Applications = new ReadOnlyCollection<gcsApplication>(_Applications);
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            return Applications;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all applications asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetAllApplicationsAsync()
        {
            InitializeErrorsCollection();
            _Applications = new List<gcsApplication>();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task<gcsApplication[]> t = proxy.GetAllApplicationsAsync();
                                gcsApplication[] applications = await t;
                                if (applications != null)
                                {
                                    foreach (gcsApplication application in applications)
                                    {
                                        _Applications.Add(application);
                                    }
                                }
                            };
                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = GetAllApplicationsCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetAllApplicationsCompletedEventArgs(
                                            new ReadOnlyCollection<gcsApplication>(_Applications), startedAt, endedAt));
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

        #region Get Single Record

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets an application. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="applicationId">    Identifier for the application. </param>
        ///
        /// <returns>   The application. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsApplication GetApplication(Guid applicationId)
        {
            InitializeErrorsCollection();
            Application = new gcsApplication();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            Application = proxy.GetApplication(applicationId);
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
            return Application;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets application asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="applicationId">    Identifier for the application. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetApplicationAsync(Guid applicationId)
        {
            InitializeErrorsCollection();
            Application = new gcsApplication();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task<gcsApplication> t = proxy.GetApplicationAsync(applicationId);
                                Application = await t;
                            };
                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = GetApplicationCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetApplicationCompletedEventArgs(
                                             Application, startedAt, endedAt));
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

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the application described by application. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="application">  The application. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteApplication(gcsApplication application)
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            int ret = proxy.DeleteApplication(application);
                            _Applications.Remove(application);
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

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the application asynchronous described by application. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="application">  The application. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteApplicationAsync(gcsApplication application)
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
                                var tDelete = proxy.DeleteApplicationAsync(application);
                                await tDelete;
                                _Applications.Remove(application);
                            };

                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = DeleteApplicationCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new DeleteApplicationCompletedEventArgs(
                                            application, startedAt, endedAt));
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
        /// <summary>   Saves an application. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A gcsApplication. </returns>
        ///=================================================================================================

        public gcsApplication SaveApplication(SaveParameters<gcsApplication> parameters)
        {
            InitializeErrorsCollection();
            gcsApplication savedApplication = null;
            bool isNew = (parameters.Data.ApplicationId == Guid.Empty);
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {

                            savedApplication = proxy.SaveApplication(parameters);
                            _Applications.Add(savedApplication);
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

            return savedApplication;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves an application asynchronous with events. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///=================================================================================================

        public void SaveApplicationAsyncWithEvents(SaveParameters<gcsApplication> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            gcsApplication savedApplication = null;
            bool isNew = false;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                isNew = (parameters.Data.ApplicationId == Guid.Empty);
                                Task<gcsApplication> t = proxy.SaveApplicationAsync(parameters);
                                savedApplication = await t;
                            };
                            try
                            {
                                task().Wait();
                                if (savedApplication != null)
                                {
                                    DateTimeOffset endedAt = DateTimeOffset.Now;
                                    var handler = SaveApplicationCompletedEvent;
                                    if (handler != null)
                                    {
                                        handler(this,
                                            new SaveApplicationCompletedEventArgs(
                                                savedApplication, isNew, startedAt, endedAt));
                                    }
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

        #region Create Application

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validates my application with server. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="bCreate">      True to create. </param>
        /// <param name="systemRole">   The system role. </param>
        ///
        /// <returns>   A gcsApplication. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsApplication ValidateMyApplicationWithServer(bool bCreate, gcsRole systemRole)
        {
            InitializeErrorsCollection();
            MyApplication = null;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        AssemblyAttributes assemblyAttributes = null;
                        try
                        {
                            assemblyAttributes = GCS.Framework.Utilities.SystemUtilities.GetEntryAssemblyAttributes();
                            bool bResult = proxy.IsApplicationInDatabase(assemblyAttributes.Guid);
                            if (bResult == false)
                            {
                                if (bCreate == true)
                                {
                                    var newApplication = new gcsApplication();
                                    newApplication.ApplicationId = assemblyAttributes.Guid;
                                    newApplication.ApplicationName = assemblyAttributes.Product;
                                    newApplication.ApplicationDescription = assemblyAttributes.Description;
                                    if (systemRole != null)
                                    {
                                        newApplication.AllRoles.Add(systemRole);
                                        newApplication.SystemRoleId = systemRole.RoleId;
                                    }
                                    MyApplication = SaveApplication(new SaveParameters<gcsApplication>(newApplication));
                                }
                            }
                            else
                            {
                                MyApplication = proxy.GetApplication(assemblyAttributes.Guid);
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
            return MyApplication;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validates my application with server asynchronous with events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="bCreate">      True to create. </param>
        /// <param name="systemRole">   The system role. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ValidateMyApplicationWithServerAsyncWithEvents(bool bCreate, gcsRole systemRole)
        {
            InitializeErrorsCollection();
            MyApplication = null;
            bool isNew = false;

            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            bool bResult = false;
                            AssemblyAttributes assemblyAttributes = GCS.Framework.Utilities.SystemUtilities.GetEntryAssemblyAttributes();
                            Func<Task> task = async () =>
                            {
                                Task<bool> t = proxy.IsApplicationInDatabaseAsync(assemblyAttributes.Guid);
                                bResult = await t;
                            };


                            Func<Task> taskCreate = async () =>
                            {
                                isNew = true;
                                var newApplication = new gcsApplication();
                                newApplication.ApplicationId = assemblyAttributes.Guid;
                                newApplication.ApplicationName = assemblyAttributes.Product;
                                newApplication.ApplicationDescription = assemblyAttributes.Description;
                                if (systemRole != null)
                                {
                                    newApplication.AllRoles.Add(systemRole);
                                    newApplication.SystemRoleId = systemRole.RoleId;
                                }

                                Task<gcsApplication> t = proxy.SaveApplicationAsync(new SaveParameters<gcsApplication>(newApplication));
                                MyApplication = await t;
                            };

                            Func<Task> taskGet = async () =>
                            {
                                isNew = false;
                                Task<gcsApplication> t = proxy.GetApplicationAsync(assemblyAttributes.Guid);
                                MyApplication = await t;
                            };
                            try
                            {
                                task().Wait();

                                if (bResult == false)
                                {
                                    if (bCreate)
                                    {
                                        taskCreate().Wait();
                                    }
                                }
                                else
                                {
                                    taskGet().Wait();
                                }

                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = ApplicationValidatedWithServerEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new ApplicationValidatedWithServerCompletedEventArgs(
                                             MyApplication, IsMyApplicationValidatedWithServer, isNew, startedAt, endedAt, base.SiteServerConnection.ConnectionSettings));
                                }
                            }
                            catch (AggregateException ae)
                            {
                                ae = ae.Flatten();
                                foreach (Exception ex in ae.InnerExceptions)
                                {
                                    AddError(new CustomError(ex.Message));
                                    this.Log().DebugFormat(ex.Message);
                                }
                                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                            }
                        }
                    });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validates my application with server asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="bCreate">      True to create. </param>
        /// <param name="systemRole">   The system role. </param>
        ///
        /// <returns>   A Task&lt;gcsApplication&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<gcsApplication> ValidateMyApplicationWithServerAsync(bool bCreate, gcsRole systemRole)
        {
            InitializeErrorsCollection();
            MyApplication = null;

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);
                var assemblyAttributes = GCS.Framework.Utilities.SystemUtilities.GetEntryAssemblyAttributes();
                bool bResult = await client.IsApplicationInDatabaseAsync(assemblyAttributes.Guid);
                if (bResult == false)
                {
                    if (bCreate == true)
                    {
                        var newApplication = new gcsApplication();
                        newApplication.ApplicationId = assemblyAttributes.Guid;
                        newApplication.ApplicationName = assemblyAttributes.Product;
                        newApplication.ApplicationDescription = assemblyAttributes.Description;
                        if (systemRole != null)
                        {
                            newApplication.AllRoles.Add(systemRole);
                            newApplication.SystemRoleId = systemRole.RoleId;
                        }
                        MyApplication = await client.SaveApplicationAsync(new SaveParameters<gcsApplication>(newApplication));
                    }
                }
                else
                {
                    MyApplication = await client.GetApplicationAsync(assemblyAttributes.Guid);
                }

                bResult = await client.IsApplicationInDatabaseAsync(assemblyAttributes.Guid);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();

            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();
                foreach (var ex in ae.InnerExceptions)
                {
                    AddError(new CustomError(ex.Message));
                    this.Log().Debug(ex.Message);
                }
            }
            return MyApplication;
        }
        #endregion

        #region Save Audit Data

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves an application audit data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="auditData">    Information describing the audit. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SaveApplicationAuditData(SaveParameters<gcsApplicationAudit> parameters)
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {

                            proxy.SaveApplicationAuditData(parameters);
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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves an application audit data asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="auditData">    Information describing the audit. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SaveApplicationAuditDataAsync(SaveParameters<gcsApplicationAudit> parameters)
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
                                Task t = proxy.SaveApplicationAuditDataAsync(parameters);
                                await t;
                            };
                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = SaveApplicationAuditDataCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new SaveApplicationAuditDataCompletedEventArgs(
                                            startedAt, endedAt));
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

        #region Get gcsApplicationBasic List

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a list of entities. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all entities. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsApplicationBasic> GetApplicationBasicList()
        {
            InitializeErrorsCollection();
            ReadOnlyCollection<gcsApplicationBasic> returnList = null;

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var apps = proxy.GetAllApplications();
                            var appsBasic = new List<gcsApplicationBasic>();
                            foreach( var app in apps )
                            {
                                appsBasic.Add(new gcsApplicationBasic(app));
                            }
                            returnList = new ReadOnlyCollection<gcsApplicationBasic>(appsBasic);
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
            return returnList;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a list of entities. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all entities asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<gcsApplicationBasic>> GetApplicationBasicListAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            ReadOnlyCollection<gcsApplicationBasic> returnList = null;
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var apps = await proxy.GetAllApplicationBasicAsync(parameters);
                            var appsBasic = new List<gcsApplicationBasic>();
                            foreach( var app in apps )
                            {
                                appsBasic.Add(new gcsApplicationBasic(app));
                            }
                            returnList = new ReadOnlyCollection<gcsApplicationBasic>(appsBasic);
                            return returnList;
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

            return returnList;
        }

        #endregion

        #region gcsApplicationSetting methods

        #region GetSettingsForApplication

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all settings for application asynchronous. </summary>
        ///
        /// <param name="applicationId">    Identifier for the application. </param>
        ///
        /// <returns>   all settings for application asynchronous. </returns>
        ///=================================================================================================

        public async Task<IEnumerable<gcsApplicationSetting>> GetAllSettingsForApplicationAsync(Guid applicationId)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = await client.GetAllApplicationSettingsForApplicationAsync(applicationId);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;
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
            return new List<gcsApplicationSetting>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all settings for applications in this collection. </summary>
        ///
        /// <param name="applicationId">    Identifier for the application. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process all settings for applications in this
        /// collection.
        /// </returns>
        ///=================================================================================================

        public IEnumerable<gcsApplicationSetting> GetAllSettingsForApplication(Guid applicationId)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = client.GetAllApplicationSettingsForApplication(applicationId);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;

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
            return new List<gcsApplicationSetting>();
        }

        #endregion

        #region GetSettingFromParams

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets application setting from parameters asynchronous. </summary>
        ///
        /// <param name="applicationId">        Identifier for the application. </param>
        /// <param name="category">             The category. </param>
        /// <param name="settingKey">           The setting key. </param>
        /// <param name="defaultValue">         The default value. </param>
        /// <param name="defaultDescription">   The default description. </param>
        /// <param name="bCreateIfNotFound">    True to create if not found. </param>
        ///
        /// <returns>   The application setting from parameters asynchronous. </returns>
        ///=================================================================================================

        public async Task<gcsApplicationSetting> GetApplicationSettingFromParamsAsync(Guid applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = await client.GetApplicationSettingFromParamsAsync(applicationId, category, settingKey, defaultValue, defaultDescription, bCreateIfNotFound);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets setting from parameters. </summary>
        ///
        /// <param name="applicationId">        Identifier for the application. </param>
        /// <param name="category">             The category. </param>
        /// <param name="settingKey">           The setting key. </param>
        /// <param name="defaultValue">         The default value. </param>
        /// <param name="defaultDescription">   The default description. </param>
        /// <param name="bCreateIfNotFound">    True to create if not found. </param>
        ///
        /// <returns>   The setting from parameters. </returns>
        ///=================================================================================================

        public gcsApplicationSetting GetSettingFromParams(Guid applicationId, string category, string settingKey, string defaultValue, string defaultDescription, bool bCreateIfNotFound)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = client.GetApplicationSettingFromParams(applicationId, category, settingKey, defaultValue, defaultDescription, bCreateIfNotFound);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;

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

        #region GetSettingsForEntityAndGroup

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets settings for application and category asynchronous. </summary>
        ///
        /// <param name="applicationId">    Identifier for the application. </param>
        /// <param name="category">         The category. </param>
        ///
        /// <returns>   The settings for application and category asynchronous. </returns>
        ///=================================================================================================

        public async Task<IEnumerable<gcsApplicationSetting>> GetSettingsForApplicationAndCategoryAsync(Guid applicationId, string category)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = await client.GetAllApplicationSettingsForApplicationCategoryAsync(applicationId, category);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;
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
            return new List<gcsApplicationSetting>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the settings for application and categories in this collection. </summary>
        ///
        /// <param name="applicationId">    Identifier for the application. </param>
        /// <param name="category">         The category. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process the settings for application and
        /// categories in this collection.
        /// </returns>
        ///=================================================================================================

        public IEnumerable<gcsApplicationSetting> GetSettingsForApplicationAndCategory(Guid applicationId, string category)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entities = client.GetAllApplicationSettingsForApplicationCategory(applicationId, category);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entities;

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
            return new List<gcsApplicationSetting>();
        }

        #endregion

        #region Get

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a setting. </summary>
        ///
        /// <param name="setting">              The setting. </param>
        /// <param name="bCreateIfNotFound">    True to create if not found. </param>
        ///
        /// <returns>   The setting. </returns>
        ///=================================================================================================

        public gcsApplicationSetting GetSetting(gcsApplicationSetting setting, bool bCreateIfNotFound)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = client.GetApplicationSetting(setting, bCreateIfNotFound);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets setting asynchronous. </summary>
        ///
        /// <param name="setting">              The setting. </param>
        /// <param name="bCreateIfNotFound">    True to create if not found. </param>
        ///
        /// <returns>   The setting asynchronous. </returns>
        ///=================================================================================================

        public async Task<gcsApplicationSetting> GetSettingAsync(gcsApplicationSetting setting, bool bCreateIfNotFound)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = await client.GetApplicationSettingAsync(setting, bCreateIfNotFound);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
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
            catch (FaultException ex)
            {
                AddError(new CustomError(ex.Message));
                this.Log().Debug(ex.Message);
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return null;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the setting described by applicationSetting. </summary>
        ///
        /// <param name="applicationSetting">   The application setting. </param>
        ///=================================================================================================

        public void DeleteSetting(gcsApplicationSetting applicationSetting )
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteApplicationSetting(applicationSetting);
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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the setting asynchronous described by applicationSetting. </summary>
        ///
        /// <param name="applicationSetting">   The application setting. </param>
        ///
        /// <returns>   A Task. </returns>
        ///=================================================================================================

        public async Task<int> DeleteSettingAsync(gcsApplicationSetting applicationSetting)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
               return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            return await proxy.DeleteApplicationSettingAsync(applicationSetting);
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
            return 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the setting by unique identifier described by parameters. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///=================================================================================================

        public void DeleteSettingByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteApplicationSettingByPk(parameters.UniqueId);
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
        /// Deletes the setting by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ///=================================================================================================

        public async Task<int> DeleteSettingByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var ret  = await proxy.DeleteApplicationSettingByPkAsync(parameters.UniqueId);
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
            return 0;
        }

        #endregion

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a setting. </summary>
        ///
        /// <param name="entity">   The entity. </param>
        ///
        /// <returns>   A gcsApplicationSetting. </returns>
        ///=================================================================================================

        public gcsApplicationSetting SaveSetting(SaveParameters<gcsApplicationSetting> parameters)
        {
            InitializeErrorsCollection();
            gcsApplicationSetting savedItem = null;
            bool isNew = (parameters.Data.ApplicationSettingId == Guid.Empty);
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
//                            var p = new SaveParameters<gcsApplicationSetting>() { Data = entity };
                            savedItem = proxy.SaveApplicationSetting(parameters);
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
        /// <summary>   Saves a setting asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;gcsApplicationSetting&gt; </returns>
        ///=================================================================================================

        public async Task<gcsApplicationSetting> SaveSettingAsync(SaveParameters<gcsApplicationSetting> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            gcsApplicationSetting savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        isNew = (parameters.Data.ApplicationSettingId == Guid.Empty);
                        savedItem = await proxy.SaveApplicationSettingAsync(parameters);
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

        #endregion

        #region gcsSerializedObject methods

        #region Get
        public gcsSerializedObject GetSerializedObject(Guid serializedObjectId)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = client.GetSerializedObject(serializedObjectId);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
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


        public async Task<gcsSerializedObject> GetSerializedObjectAsync(Guid serializedObjectId)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = await client.GetSerializedObjectAsync(serializedObjectId);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
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
            //catch (FaultException ex)
            //{
            //    AddError(new CustomError(ex.Message));
            //    this.Log().Debug(ex.Message);
            //    OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            //}
            return null;
        }

        public gcsSerializedObject GetSerializedObjectByApplicationIdAndKey(Guid applicationId, string key)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = client.GetSerializedObjectByApplicationIdAndKey(applicationId, key);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
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

        public async Task<gcsSerializedObject> GetSerializedObjectByApplicationIdAndKeyAsync(Guid applicationId, string key)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                var entity = await client.GetSerializedObjectByApplicationIdAndKeyAsync(applicationId, key);

                IDisposable disposableClient = client as IDisposable;
                if (disposableClient != null)
                    disposableClient.Dispose();
                return entity;
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
            //catch (FaultException ex)
            //{
            //    AddError(new CustomError(ex.Message));
            //    this.Log().Debug(ex.Message);
            //    OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            //}
            return null;
        }
        #endregion

        #region Delete


        public int DeleteSerializedObject(Guid serializedObjectId)
        {
            InitializeErrorsCollection();
            int x = 0;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            x = proxy.DeleteSerializedObjectByPk(serializedObjectId);
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
            return x;
        }

        public async Task<int> DeleteSerializedObjectAsync(Guid serializedObjectId)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                 return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            return await proxy.DeleteSerializedObjectByPkAsync(serializedObjectId);
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
            return 0;
        }

        #endregion

        #region Save

        public gcsSerializedObject SaveSerializedObject(SaveParameters<gcsSerializedObject> parameters)
        {
            InitializeErrorsCollection();
            gcsSerializedObject savedItem = null;
            bool isNew = (parameters.Data.SerializedObjectId == Guid.Empty);
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
//                            var p = new SaveParameters<gcsApplicationSetting>() { Data = entity };
                            savedItem = proxy.SaveSerializedObject(parameters);
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


        public async Task<gcsSerializedObject> SaveSerializedObjectAsync(SaveParameters<gcsSerializedObject> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            gcsSerializedObject savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        isNew = (parameters.Data.SerializedObjectId == Guid.Empty);
                        savedItem = await proxy.SaveSerializedObjectAsync(parameters);
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
        #endregion
    }
}
