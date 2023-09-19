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
    /// <summary>   Additional information for get all permissions completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GetAllPermissionsCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="permissions">          The permissions. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetAllPermissionsCompletedEventArgs(ReadOnlyCollection<gcsPermission> permissions, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            Permissions = permissions;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the permissions. </summary>
        ///
        /// <value> The permissions. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsPermission> Permissions { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for delete permission completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DeletePermissionCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="permission">           The permission. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DeletePermissionCompletedEventArgs(gcsPermission permission, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            Permission = permission;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the permission. </summary>
        ///
        /// <value> The permission. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsPermission Permission { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for save permission completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SavePermissionCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="permission">           The permission. </param>
        /// <param name="isNew">                True if this SavePermissionCompletedEventArgs is new,
        ///                                     false if not. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SavePermissionCompletedEventArgs(gcsPermission permission, Boolean isNew, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            Permission = permission;
            IsNew = isNew;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the permission. </summary>
        ///
        /// <value> The permission. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsPermission Permission { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this SavePermissionCompletedEventArgs is new.
        /// </summary>
        ///
        /// <value> True if this SavePermissionCompletedEventArgs is new, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Boolean IsNew { get; internal set; }
    }
    #endregion

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for permissions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PermissionManager : ManagerBase
    {
        #region Private fields
        /// <summary>   The permissions. </summary>
        private List<gcsPermission> _Permissions;
        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the permissions. </summary>
        ///
        /// <value> The permissions. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsPermission> Permissions { get; internal set; }
        #endregion

        #region Events and Delegates

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GetAllPermissionsCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Get all permissions completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GetAllPermissionsCompletedEventHandler(object sender, GetAllPermissionsCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in getAllPermissionsCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event GetAllPermissionsCompletedEventHandler GetAllPermissionsCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling DeletePermissionCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Delete permission completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void DeletePermissionCompletedEventHandler(object sender, DeletePermissionCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in deletePermissionCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event DeletePermissionCompletedEventHandler DeletePermissionCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling SavePermissionCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Save permission completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void SavePermissionCompletedEventHandler(object sender, SavePermissionCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in savePermissionCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event SavePermissionCompletedEventHandler SavePermissionCompletedEvent;
        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PermissionManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _Permissions = new List<gcsPermission>();
        }
        #endregion

        #region Public methods

        #region GetAll

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all permissions. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   all permissions. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsPermission> GetAllPermissions()
        {
            InitializeErrorsCollection();
            _Permissions = new List<gcsPermission>();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            gcsPermission[] permissions = proxy.GetAllPermissions();
                            if (permissions != null)
                            {
                                foreach (gcsPermission permission in permissions)
                                    _Permissions.Add(permission);
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

            Permissions = new ReadOnlyCollection<gcsPermission>(_Permissions);
            return Permissions;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all permissions asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetAllPermissionsAsync()
        {
            InitializeErrorsCollection();
            _Permissions = new List<gcsPermission>();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task<gcsPermission[]> t = proxy.GetAllPermissionsAsync();
                                gcsPermission[] permissions = await t;
                                if (permissions != null)
                                {
                                    foreach (gcsPermission permission in permissions)
                                    {
                                        _Permissions.Add(permission);
                                    }
                                }
                            };
                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = GetAllPermissionsCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetAllPermissionsCompletedEventArgs(
                                            new ReadOnlyCollection<gcsPermission>(_Permissions), startedAt, endedAt));
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
        /// <summary>   Gets all permissions for application. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="application">  The application. </param>
        ///
        /// <returns>   all permissions for application. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsPermission> GetAllPermissionsForApplication(gcsApplication application)
        {
            InitializeErrorsCollection();
            _Permissions = new List<gcsPermission>();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            gcsPermission[] permissions = proxy.GetAllPermissionsForApplication(application.ApplicationId);
                            if (permissions != null)
                            {
                                foreach (gcsPermission permission in permissions)
                                    _Permissions.Add(permission);
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

            Permissions = new ReadOnlyCollection<gcsPermission>(_Permissions);
            return Permissions;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all permissions for application asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="application">  The application. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetAllPermissionsForApplicationAsync(gcsApplication application)
        {
            InitializeErrorsCollection();
            _Permissions = new List<gcsPermission>();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task<gcsPermission[]> t = proxy.GetAllPermissionsForApplicationAsync(application.ApplicationId);
                                gcsPermission[] permissions = await t;
                                if (permissions != null)
                                {
                                    foreach (gcsPermission permission in permissions)
                                    {
                                        _Permissions.Add(permission);
                                    }
                                }
                            };
                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = GetAllPermissionsCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetAllPermissionsCompletedEventArgs(
                                            new ReadOnlyCollection<gcsPermission>(_Permissions), startedAt, endedAt));
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

        #region GetAllForRole

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all permissions for role. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="role"> The role. </param>
        ///
        /// <returns>   all permissions for role. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsPermission> GetAllPermissionsForRole(gcsRole role)
        {
            InitializeErrorsCollection();
            _Permissions = new List<gcsPermission>();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            gcsPermission[] permissions = proxy.GetAllPermissionsForRole(role.RoleId);
                            if (permissions != null)
                            {
                                foreach (gcsPermission permission in permissions)
                                    _Permissions.Add(permission);
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

            Permissions = new ReadOnlyCollection<gcsPermission>(_Permissions);
            return Permissions;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all permissions for role asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="role"> The role. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetAllPermissionsForRoleAsync(gcsRole role)
        {
            InitializeErrorsCollection();
            _Permissions = new List<gcsPermission>();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task<gcsPermission[]> t = proxy.GetAllPermissionsForRoleAsync(role.RoleId);
                                gcsPermission[] permissions = await t;
                                if (permissions != null)
                                {
                                    foreach (gcsPermission permission in permissions)
                                    {
                                        _Permissions.Add(permission);
                                    }
                                }
                            };
                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = GetAllPermissionsCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetAllPermissionsCompletedEventArgs(
                                            new ReadOnlyCollection<gcsPermission>(_Permissions), startedAt, endedAt));
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

        #region GetAllForPermissionCategory

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all permissions for permission category. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="permissionCategory">   Category the permission belongs to. </param>
        ///
        /// <returns>   all permissions for permission category. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsPermission> GetAllPermissionsForPermissionCategory(gcsPermissionCategory permissionCategory)
        {
            InitializeErrorsCollection();
            _Permissions = new List<gcsPermission>();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            gcsPermission[] permissions = proxy.GetAllPermissionsForPermissionCategory(permissionCategory.PermissionCategoryId);
                            if (permissions != null)
                            {
                                foreach (gcsPermission permission in permissions)
                                    _Permissions.Add(permission);
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

            Permissions = new ReadOnlyCollection<gcsPermission>(_Permissions);
            return Permissions;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all permissions for permission category asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="permissionCategory">   Category the permission belongs to. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetAllPermissionsForPermissionCategoryAsync(gcsPermissionCategory permissionCategory)
        {
            InitializeErrorsCollection();
            _Permissions = new List<gcsPermission>();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task<gcsPermission[]> t = proxy.GetAllPermissionsForPermissionCategoryAsync(permissionCategory.PermissionCategoryId);
                                gcsPermission[] permissions = await t;
                                if (permissions != null)
                                {
                                    foreach (gcsPermission permission in permissions)
                                    {
                                        _Permissions.Add(permission);
                                    }
                                }
                            };
                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = GetAllPermissionsCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetAllPermissionsCompletedEventArgs(
                                            new ReadOnlyCollection<gcsPermission>(_Permissions), startedAt, endedAt));
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
        /// <summary>   Deletes the permission described by permission. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="permission">   The permission. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeletePermission(gcsPermission permission)
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeletePermission(permission);
                            _Permissions.Remove(permission);
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
        /// <summary>   Deletes the permission asynchronous described by permission. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="permission">   The permission. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeletePermissionAsync(gcsPermission permission)
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
                                Task tDelete = proxy.DeletePermissionAsync(permission);
                                await tDelete;
                                _Permissions.Remove(permission);
                            };

                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = DeletePermissionCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new DeletePermissionCompletedEventArgs(
                                            permission, startedAt, endedAt));
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
        /// <summary>   Saves a permission. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A gcsPermission. </returns>
        ///=================================================================================================

        public gcsPermission SavePermission(SaveParameters<gcsPermission> parameters)
        {
            InitializeErrorsCollection();
            gcsPermission savedPermission = null;
            bool isNew = (parameters.Data.PermissionId == Guid.Empty);
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {

                            savedPermission = proxy.SavePermission(parameters);
                            _Permissions.Add(savedPermission);
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

            return savedPermission;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a permission asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///=================================================================================================

        public void SavePermissionAsync(SaveParameters<gcsPermission> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            gcsPermission savedPermission = null;
            bool isNew = false;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                isNew = (parameters.Data.PermissionId == Guid.Empty);
                                Task<gcsPermission> t = proxy.SavePermissionAsync(parameters);
                                savedPermission = await t;
                            };
                            try
                            {
                                task().Wait();
                                if (savedPermission != null)
                                {
                                    DateTimeOffset endedAt = DateTimeOffset.Now;
                                    var handler = SavePermissionCompletedEvent;
                                    if (handler != null)
                                    {
                                        handler(this,
                                            new SavePermissionCompletedEventArgs(
                                                savedPermission, isNew, startedAt, endedAt));
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
