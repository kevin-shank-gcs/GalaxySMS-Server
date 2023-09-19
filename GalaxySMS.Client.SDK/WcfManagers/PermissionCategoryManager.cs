////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\PermissionManager.cs
//
// summary:	Implements the permission manager class
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
    #region EventArg Classes

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Additional information for get all permission categories completed events.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GetAllPermissionCategoriesCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="permissionCategories"> The permission categories. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetAllPermissionCategoriesCompletedEventArgs(ReadOnlyCollection<gcsPermissionCategory> permissionCategories, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            PermissionCategories = permissionCategories;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the categories the permission belongs to. </summary>
        ///
        /// <value> The permission categories. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsPermissionCategory> PermissionCategories { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Additional information for delete permission category completed events.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DeletePermissionCategoryCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="permissionCategory">   The permission category. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DeletePermissionCategoryCompletedEventArgs(gcsPermissionCategory permissionCategory, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            PermissionCategory = permissionCategory;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the category the permission belongs to. </summary>
        ///
        /// <value> The permission category. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsPermissionCategory PermissionCategory { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for save permission category completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SavePermissionCategoryCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="permissionCategory">   The permission category. </param>
        /// <param name="isNew">                True if this SavePermissionCategoryCompletedEventArgs is
        ///                                     new, false if not. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SavePermissionCategoryCompletedEventArgs(gcsPermissionCategory permissionCategory, Boolean isNew, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            PermissionCategory = permissionCategory;
            IsNew = isNew;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the category the permission belongs to. </summary>
        ///
        /// <value> The permission category. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsPermissionCategory PermissionCategory { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this SavePermissionCategoryCompletedEventArgs is
        /// new.
        /// </summary>
        ///
        /// <value> True if this SavePermissionCategoryCompletedEventArgs is new, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Boolean IsNew { get; internal set; }
    }

    #endregion

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for permission categories. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PermissionCategoryManager : ManagerBase
    {
        #region Private fields
        /// <summary>   Categories the permission belongs to. </summary>
        private List<gcsPermissionCategory> _PermissionCategories;
        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the categories the permission belongs to. </summary>
        ///
        /// <value> The permission categories. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsPermissionCategory> PermissionCategories { get; internal set; }

        #endregion

        #region Events and Delegates

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GetAllPermissionCategoriesCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Get all permission categories completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GetAllPermissionCategoriesCompletedEventHandler(object sender, GetAllPermissionCategoriesCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in getAllPermissionCategoriesCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event GetAllPermissionCategoriesCompletedEventHandler GetAllPermissionCategoriesCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling DeletePermissionCategoryCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Delete permission category completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void DeletePermissionCategoryCompletedEventHandler(object sender, DeletePermissionCategoryCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in deletePermissionCategoryCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event DeletePermissionCategoryCompletedEventHandler DeletePermissionCategoryCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling SavePermissionCategoryCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Save permission category completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void SavePermissionCategoryCompletedEventHandler(object sender, SavePermissionCategoryCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in savePermissionCategoryCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event SavePermissionCategoryCompletedEventHandler SavePermissionCategoryCompletedEvent;

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PermissionCategoryManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _PermissionCategories = new List<gcsPermissionCategory>();
        }
        #endregion

        #region Public methods

        #region GetAll

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all permission categories. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   all permission categories. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsPermissionCategory> GetAllPermissionCategories()
        {
            InitializeErrorsCollection();
            _PermissionCategories = new List<gcsPermissionCategory>();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            gcsPermissionCategory[] permissionCategories = proxy.GetAllPermissionCategories();
                            if (permissionCategories != null)
                            {
                                foreach (gcsPermissionCategory permissionCategory in permissionCategories)
                                    _PermissionCategories.Add(permissionCategory);
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

            PermissionCategories = new ReadOnlyCollection<gcsPermissionCategory>(_PermissionCategories);
            return PermissionCategories;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all permission categories asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetAllPermissionCategoriesAsync()
        {
            InitializeErrorsCollection();
            _PermissionCategories = new List<gcsPermissionCategory>();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task<gcsPermissionCategory[]> t = proxy.GetAllPermissionCategoriesAsync();
                                gcsPermissionCategory[] permissionCategories = await t;
                                if (permissionCategories != null)
                                {
                                    foreach (gcsPermissionCategory permissionCategory in permissionCategories)
                                    {
                                        _PermissionCategories.Add(permissionCategory);
                                    }
                                }
                            };
                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = GetAllPermissionCategoriesCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetAllPermissionCategoriesCompletedEventArgs(
                                            new ReadOnlyCollection<gcsPermissionCategory>(_PermissionCategories), startedAt, endedAt));
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

        #region GetAllForApplication

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all permission categories for application. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="application">  The application. </param>
        ///
        /// <returns>   all permission categories for application. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsPermissionCategory> GetAllPermissionCategoriesForApplication(gcsApplication application)
        {
            InitializeErrorsCollection();
            _PermissionCategories = new List<gcsPermissionCategory>();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            gcsPermissionCategory[] permissionCategories = proxy.GetAllPermissionCategoriesForApplication(application.ApplicationId);
                            if (permissionCategories != null)
                            {
                                foreach (gcsPermissionCategory permissionCategory in permissionCategories)
                                    _PermissionCategories.Add(permissionCategory);
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

            PermissionCategories = new ReadOnlyCollection<gcsPermissionCategory>(_PermissionCategories);
            return PermissionCategories;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all permission categories for application asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="application">  The application. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetAllPermissionCategoriesForApplicationAsync(gcsApplication application)
        {
            InitializeErrorsCollection();
            _PermissionCategories = new List<gcsPermissionCategory>();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task<gcsPermissionCategory[]> t = proxy.GetAllPermissionCategoriesForApplicationAsync(application.ApplicationId);
                                gcsPermissionCategory[] permissionCategories = await t;
                                if (permissionCategories != null)
                                {
                                    foreach (gcsPermissionCategory permissionCategory in permissionCategories)
                                    {
                                        _PermissionCategories.Add(permissionCategory);
                                    }
                                }
                            };
                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = GetAllPermissionCategoriesCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetAllPermissionCategoriesCompletedEventArgs(
                                            new ReadOnlyCollection<gcsPermissionCategory>(_PermissionCategories), startedAt, endedAt));
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
        /// <summary>   Deletes the permission category described by permissionCategory. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="permissionCategory">   Category the permission belongs to. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeletePermissionCategory(gcsPermissionCategory permissionCategory)
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeletePermissionCategory(permissionCategory);
                            _PermissionCategories.Remove(permissionCategory);
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
        /// Deletes the permission category asynchronous described by permissionCategory.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="permissionCategory">   Category the permission belongs to. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeletePermissionCategoryAsync(gcsPermissionCategory permissionCategory)
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
                                Task tDelete = proxy.DeletePermissionCategoryAsync(permissionCategory);
                                await tDelete;
                                _PermissionCategories.Remove(permissionCategory);
                            };

                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = DeletePermissionCategoryCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new DeletePermissionCategoryCompletedEventArgs(
                                            permissionCategory, startedAt, endedAt));
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
       /// <summary>    Saves a permission category. </summary>
       ///
       /// <param name="parameters">    Options for controlling the operation. </param>
       ///
       /// <returns>    A gcsPermissionCategory. </returns>
       ///=================================================================================================

       public gcsPermissionCategory SavePermissionCategory(SaveParameters<gcsPermissionCategory> parameters)
        {
            InitializeErrorsCollection();
            gcsPermissionCategory savedPermissionCategory = null;
            bool isNew = (parameters.Data.PermissionCategoryId == Guid.Empty);
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {

                            savedPermissionCategory = proxy.SavePermissionCategory(parameters);
                            _PermissionCategories.Add(savedPermissionCategory);
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

            return savedPermissionCategory;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a permission category asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///=================================================================================================

        public void SavePermissionCategoryAsync(SaveParameters<gcsPermissionCategory> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            gcsPermissionCategory savedPermissionCategory = null;
            bool isNew = false;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                isNew = (parameters.Data.PermissionCategoryId == Guid.Empty);
                                Task<gcsPermissionCategory> t = proxy.SavePermissionCategoryAsync(parameters);
                                savedPermissionCategory = await t;
                            };
                            try
                            {
                                task().Wait();
                                if (savedPermissionCategory != null)
                                {
                                    DateTimeOffset endedAt = DateTimeOffset.Now;
                                    var handler = SavePermissionCategoryCompletedEvent;
                                    if (handler != null)
                                    {
                                        handler(this,
                                            new SavePermissionCategoryCompletedEventArgs(
                                                savedPermissionCategory, isNew, startedAt, endedAt));
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
