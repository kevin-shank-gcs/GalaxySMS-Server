////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\UserManager.cs
//
// summary:	Implements the user manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Client.Contracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;
using GCS.Framework.Security;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GalaxySMS.Client.SDK.Managers
{

    #region EventArg Classes

    #region GcsUser

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for get all users completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GetAllUsersCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="users">                The users. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetAllUsersCompletedEventArgs(ReadOnlyCollection<gcsUser> users, DateTimeOffset requestInvokedAt,
            DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            Users = users;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the users. </summary>
        ///
        /// <value> The users. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsUser> Users { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for delete user completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DeleteUserCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="user">                 The user. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DeleteUserCompletedEventArgs(gcsUser user, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            User = user;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user. </summary>
        ///
        /// <value> The user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUser User { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for get user completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GetUserCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="user">                 The user. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetUserCompletedEventArgs(gcsUser user, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            User = user;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user. </summary>
        ///
        /// <value> The user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUser User { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for save user completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SaveUserCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="user">                 The user. </param>
        /// <param name="isNew">                True if this SaveUserCompletedEventArgs is new, false if
        ///                                     not. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveUserCompletedEventArgs(gcsUser user, bool isNew, DateTimeOffset requestInvokedAt,
            DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            User = user;
            IsNew = isNew;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user. </summary>
        ///
        /// <value> The user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUser User { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this SaveUserCompletedEventArgs is new.
        /// </summary>
        ///
        /// <value> True if this SaveUserCompletedEventArgs is new, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsNew { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for validate password completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ValidatePasswordCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="validationResult">     The validation result. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ValidatePasswordCompletedEventArgs(PasswordValidationInfo validationResult,
            DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            ValidationResults = validationResult;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the validation results. </summary>
        ///
        /// <value> The validation results. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PasswordValidationInfo ValidationResults { get; internal set; }
    }

    #endregion

    #region GcsUserSetting

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for get user settings completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GetUserSettingsCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userSettings">         The user settings. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetUserSettingsCompletedEventArgs(ReadOnlyCollection<gcsUserSetting> userSettings,
            DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            UserSettings = userSettings;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user settings. </summary>
        ///
        /// <value> The user settings. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsUserSetting> UserSettings { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for delete user setting completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DeleteUserSettingCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userSetting">          The user setting. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DeleteUserSettingCompletedEventArgs(gcsUserSetting userSetting, DateTimeOffset requestInvokedAt,
            DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            UserSetting = userSetting;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user setting. </summary>
        ///
        /// <value> The user setting. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUserSetting UserSetting { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for save user setting completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SaveUserSettingCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userSetting">          The user setting. </param>
        /// <param name="isNew">                True if this SaveUserSettingCompletedEventArgs is new,
        ///                                     false if not. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveUserSettingCompletedEventArgs(gcsUserSetting userSetting, bool isNew, DateTimeOffset requestInvokedAt,
            DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            UserSetting = userSetting;
            IsNew = isNew;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user setting. </summary>
        ///
        /// <value> The user setting. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUserSetting UserSetting { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this SaveUserSettingCompletedEventArgs is new.
        /// </summary>
        ///
        /// <value> True if this SaveUserSettingCompletedEventArgs is new, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsNew { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for get user setting completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GetUserSettingCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userSetting">          The user setting. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetUserSettingCompletedEventArgs(gcsUserSetting userSetting, DateTimeOffset requestInvokedAt,
            DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            UserSetting = userSetting;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user setting. </summary>
        ///
        /// <value> The user setting. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUserSetting UserSetting { get; internal set; }
    }

    #endregion

    #endregion

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for users. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class UserManager : ManagerBase
    {
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

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserManager()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            //_Users = new List<gcsUser>();
            //_UserSettings = new List<gcsUserSetting>();
        }

        #endregion

        #region Private fields

        ///// <summary>   The users. </summary>
        //private List<gcsUser> _Users;
        ///// <summary>   The user settings. </summary>
        private List<gcsUserSetting> _UserSettings;
        //private List<gcsUserBasic> _UsersList;

        #endregion

        #region Public properties

        public gcsUser CurrentUser { get; internal set; }
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the users. </summary>
        /////
        ///// <value> The users. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public ReadOnlyCollection<gcsUser> Users { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user settings. </summary>
        ///
        /// <value> The user settings. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsUserSetting> UserSettings { get; internal set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets the current user. </summary>
        /////
        ///// <value> The current user. </value>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public gcsUser CurrentUser { get; internal set; }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Gets or sets a list of users. </summary>
        /////
        ///// <value> A List of users. </value>
        /////=================================================================================================

        //public ReadOnlyCollection<gcsUserBasic> UsersList { get; internal set; }

        #endregion

        #region Events and Delegates

        #region GcsUser

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GetAllUsersCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Get all users completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GetAllUsersCompletedEventHandler(object sender, GetAllUsersCompletedEventArgs e);

        /// <summary>   Event queue for all listeners interested in getAllUsersCompleted events. </summary>
        public event GetAllUsersCompletedEventHandler GetAllUsersCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GetUserCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Get user completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GetUserCompletedEventHandler(object sender, GetUserCompletedEventArgs e);

        /// <summary>   Event queue for all listeners interested in getUserCompleted events. </summary>
        public event GetUserCompletedEventHandler GetUserCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling DeleteUserCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Delete user completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void DeleteUserCompletedEventHandler(object sender, DeleteUserCompletedEventArgs e);

        /// <summary>   Event queue for all listeners interested in deleteUserCompleted events. </summary>
        public event DeleteUserCompletedEventHandler DeleteUserCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling SaveUserCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Save user completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void SaveUserCompletedEventHandler(object sender, SaveUserCompletedEventArgs e);

        /// <summary>   Event queue for all listeners interested in saveUserCompleted events. </summary>
        public event SaveUserCompletedEventHandler SaveUserCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling ValidatePasswordCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Validate password completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void ValidatePasswordCompletedEventHandler(object sender, ValidatePasswordCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in validatePasswordCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event ValidatePasswordCompletedEventHandler ValidatePasswordCompletedEvent;

        #endregion

        #region GcsUserSetting

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GetUserSettingsCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Get user settings completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GetUserSettingsCompletedEventHandler(object sender, GetUserSettingsCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in getUserSettingsCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event GetUserSettingsCompletedEventHandler GetUserSettingsCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GetUserSettingCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Get user setting completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GetUserSettingCompletedEventHandler(object sender, GetUserSettingCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in getUserSettingCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event GetUserSettingCompletedEventHandler GetUserSettingCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling DeleteUserSettingCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Delete user setting completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void DeleteUserSettingCompletedEventHandler(object sender, DeleteUserSettingCompletedEventArgs e
            );

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in deleteUserSettingCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event DeleteUserSettingCompletedEventHandler DeleteUserSettingCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling SaveUserSettingCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Save user setting completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void SaveUserSettingCompletedEventHandler(object sender, SaveUserSettingCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in saveUserSettingCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event SaveUserSettingCompletedEventHandler SaveUserSettingCompletedEvent;

        #endregion

        #endregion

        #region Public methods

        #region GcsUser

        #region GetAll

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all users. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   all users. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<gcsUser> GetAllUsers()
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsUser> users = null;
            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            users = proxy.GetAllUsers();
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

            return users;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all users asynchronous. </summary>
        ///
        /// <returns>   all users asynchronous. </returns>
        ///=================================================================================================

        public async Task<ArrayResponse<gcsUser>> GetAllUsersAsync()
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsUser> users = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        users = await proxy.GetAllUsersAsync();
                        return users;
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

            return null;
        }

        #endregion

        #region GetAllList

        public ArrayResponse<gcsUserBasic> GetAllUsersList(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsUserBasic> data = null;
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetAllUsersList(parameters);
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

            return data;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all users. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   all users. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ArrayResponse<gcsUserBasic>> GetAllUsersListAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllUsersListAsync(parameters);
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

            return null;
        }


        #endregion

        #region GetAllForApplication

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all users for application. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="application">  The application. </param>
        ///
        /// <returns>   all users for application. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<gcsUser> GetAllUsersForApplication(gcsApplication application)
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsUser> users = null;
            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            users = proxy.GetAllUsersForApplication(application.ApplicationId);
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

            return users;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all users for application asynchronous. </summary>
        ///
        /// <param name="application">  The application. </param>
        ///
        /// <returns>   all users for application asynchronous. </returns>
        ///=================================================================================================

        public async Task<ArrayResponse<gcsUser>> GetAllUsersForApplicationAsync(gcsApplication application)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        var users = await proxy.GetAllUsersForApplicationAsync(application.ApplicationId);

                        return users;
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

            return null;
        }

        #endregion

        #region GetAllForRole

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all users for role. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="role"> The role. </param>
        ///
        /// <returns>   all users for role. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<gcsUser> GetAllUsersForRole(gcsRole role)
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsUser> users = null;
            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            users = proxy.GetAllUsersForRole(role.RoleId);
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

            return users;
        }

        public async Task<ArrayResponse<gcsUser>> GetAllUsersForRoleAsync(gcsRole role)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        var users = await proxy.GetAllUsersForRoleAsync(role.RoleId);
                        return users;
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

            return null;
        }

        #endregion

        #region GetAllForEntity

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all users for entity. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="entity">   The entity. </param>
        ///
        /// <returns>   all users for entity. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayResponse<gcsUser> GetAllUsersForEntity(gcsEntity entity)
        {
            InitializeErrorsCollection();
            ArrayResponse<gcsUser> users = null;

            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            users = proxy.GetAllUsersForEntity(new GetParametersWithPhoto() { UniqueId = entity.EntityId });
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

            return users;
        }


        public async Task<ArrayResponse<gcsUser>> GetAllUsersForEntityAsync(gcsEntity entity)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        var users = await proxy.GetAllUsersForEntityAsync(new GetParametersWithPhoto() { UniqueId = entity.EntityId });
                        return users;
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

            return null;
        }


        #endregion

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a user. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A gcsUser. </returns>
        ///=================================================================================================

        public gcsUser SaveUser(SaveParameters<gcsUser> parameters)
        {
            InitializeErrorsCollection();
            gcsUser savedUser = null;
            var isNew = parameters.Data.UserId == Guid.Empty;
            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var tempUser = new gcsUser(parameters.Data);
                            isNew = tempUser.UserId == Guid.Empty;
                            if (tempUser.UserPassword != string.Empty)
                            {
                                tempUser.UserPassword = Crypto.EncryptString(
                                    tempUser.UserPassword, tempUser.UserId.ToString());
                            }
                            tempUser.UserOldPasswords.Clear();
                            var p = new SaveParameters<gcsUser>(tempUser, parameters);
                            savedUser = proxy.SaveUser(p);
                            //_Users.Add(savedUser);
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

            return savedUser;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a user asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///=================================================================================================

        public void SaveUserRaiseEvent(SaveParameters<gcsUser> parameters)
        {
            InitializeErrorsCollection();
            var startedAt = DateTimeOffset.Now;
            gcsUser savedUser = null;
            var isNew = false;

            WithClientAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                var tempUser = new gcsUser(parameters.Data);
                                isNew = tempUser.UserId == Guid.Empty;
                                if (tempUser.UserPassword != string.Empty)
                                {
                                    tempUser.UserPassword = Crypto.EncryptString(
                                        tempUser.UserPassword, tempUser.UserId.ToString());
                                }
                                tempUser.UserOldPasswords.Clear();
                                var p = new SaveParameters<gcsUser>(tempUser, parameters);

                                var t = proxy.SaveUserAsync(p);
                                savedUser = await t;
                            };
                            try
                            {
                                task().Wait();
                                if (savedUser != null)
                                {
                                    var endedAt = DateTimeOffset.Now;
                                    var handler = SaveUserCompletedEvent;
                                    if (handler != null)
                                    {
                                        handler(this,
                                            new SaveUserCompletedEventArgs(
                                                savedUser, isNew, startedAt, endedAt));
                                    }
                                }
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
                        }
                    });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a user asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;gcsUser&gt; </returns>
        ///=================================================================================================

        public async Task<gcsUser> SaveUserAsync(SaveParameters<gcsUser> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            gcsUser savedUser = null;
            var isNew = parameters.Data.UserId == Guid.Empty;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        var tempUser = new gcsUser(parameters.Data);
                        isNew = tempUser.UserId == Guid.Empty;
                        if (tempUser.UserPassword != string.Empty)
                        {
                            tempUser.UserPassword = Crypto.EncryptString(
                                tempUser.UserPassword, tempUser.UserId.ToString());
                        }
                        tempUser.UserOldPasswords.Clear();
                        var p = new SaveParameters<gcsUser>(tempUser, parameters);
                        savedUser = await proxy.SaveUserAsync(parameters);
                        //_Users.Add(savedUser);
                        return savedUser;
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

            return savedUser;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Enumerates validate password in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="user"> The user. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process validate password in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PasswordValidationInfo ValidatePassword(gcsUser user)
        {
            InitializeErrorsCollection();
            var validationResult = new PasswordValidationInfo();
            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var tempUser = new gcsUser(user);
                            tempUser.UserPassword = Crypto.EncryptString(tempUser.UserPassword,
                                tempUser.UserId.ToString()); //tempUser.LoginName);
                            validationResult = proxy.ValidatePassword(tempUser, true);
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

            return validationResult;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validates the password asynchronous described by user. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="user"> The user. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ValidatePasswordRaiseEvent(gcsUser user)
        {
            InitializeErrorsCollection();
            var startedAt = DateTimeOffset.Now;
            var validationResult = new PasswordValidationInfo();

            WithClientAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                var tempUser = new gcsUser(user);
                                tempUser.UserPassword = Crypto.EncryptString(tempUser.UserPassword,
                                    tempUser.UserId.ToString()); //tempUser.LoginName);
                                var t = proxy.ValidatePasswordAsync(tempUser, true);
                                validationResult = await t;
                            };
                            try
                            {
                                task().Wait();
                                var endedAt = DateTimeOffset.Now;
                                var handler = ValidatePasswordCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new ValidatePasswordCompletedEventArgs(
                                            validationResult, startedAt, endedAt));
                                }
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
                        }
                    });
        }

        public async Task<PasswordValidationInfo> ValidatePasswordAsync(gcsUser user)
        {
            InitializeErrorsCollection();
            InitializeErrorsCollection();
            var validationResult = new PasswordValidationInfo();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        var tempUser = new gcsUser(user);
                        tempUser.UserPassword = Crypto.EncryptString(tempUser.UserPassword,
                            tempUser.UserId.ToString()); //tempUser.LoginName);
                        validationResult = await proxy.ValidatePasswordAsync(tempUser, true);

                        return validationResult;
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

            return validationResult;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a user account request. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="user"> The user. </param>
        ///
        /// <returns>   A gcsUser. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUser SaveUserAccountRequest(gcsUser user)
        {
            InitializeErrorsCollection();
            gcsUser savedUser = null;
            var isNew = user.UserId == Guid.Empty;
            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            if (user.UserPassword != string.Empty)
                            {
                                user.UserPassword = Crypto.EncryptString(
                                    user.UserPassword, user.UserId.ToString()); //user.LoginName);
                            }

                            savedUser = proxy.SaveUserAccountRequest(user);
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

            return savedUser;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a user account request void asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="user"> The user. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SaveUserAccountRequestRaiseEvent(gcsUser user)
        {
            InitializeErrorsCollection();
            var startedAt = DateTimeOffset.Now;
            gcsUser savedUser = null;
            var isNew = false;

            WithClientAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                var tempUser = new gcsUser(user);
                                isNew = tempUser.UserId == Guid.Empty;
                                if (user.UserPassword != string.Empty)
                                {
                                    user.UserPassword = Crypto.EncryptString(
                                        user.UserPassword, user.UserId.ToString()); //user.LoginName);
                                }

                                var t = proxy.SaveUserAccountRequestAsync(tempUser);
                                savedUser = await t;
                            };
                            try
                            {
                                task().Wait();
                                if (savedUser != null)
                                {
                                    var endedAt = DateTimeOffset.Now;
                                    var handler = SaveUserCompletedEvent;
                                    if (handler != null)
                                    {
                                        handler(this,
                                            new SaveUserCompletedEventArgs(
                                                savedUser, isNew, startedAt, endedAt));
                                    }
                                }
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
                        }
                    });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a user account request asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="user"> The user. </param>
        ///
        /// <returns>   A Task&lt;gcsUser&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<gcsUser> SaveUserAccountRequestAsync(gcsUser user)
        {
            InitializeErrorsCollection();

            gcsUser savedUser = null;
            var isNew = user.UserId == Guid.Empty;
            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            if (user.UserPassword != string.Empty)
                            {
                                user.UserPassword = Crypto.EncryptString(
                                    user.UserPassword, user.UserId.ToString()); //user.LoginName);
                            }

                            savedUser = await proxy.SaveUserAccountRequestAsync(user);
                            return savedUser;
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
            return savedUser;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the user described by user. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="user"> The user. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteUser(gcsUser user)
        {
            InitializeErrorsCollection();
            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteUser(user);
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
        /// <summary>   Deletes the user asynchronous described by user. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="user"> The user. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteUserRaiseEvent(gcsUser user)
        {
            InitializeErrorsCollection();
            var startedAt = DateTimeOffset.Now;

            WithClientAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                var tDelete = proxy.DeleteUserAsync(user);
                                await tDelete;
                            };

                            try
                            {
                                task().Wait();
                                var endedAt = DateTimeOffset.Now;
                                var handler = DeleteUserCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new DeleteUserCompletedEventArgs(
                                            user, startedAt, endedAt));
                                }
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
                        }
                    });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the user asynchronous described by user. </summary>
        ///
        /// <param name="user"> The user. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ///=================================================================================================

        public async Task<int> DeleteUserAsync(gcsUser user)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int countDeleted = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        // For some reason, the DeleteSiteAsync throws a WCF exception
                        countDeleted = await proxy.DeleteUserByPkAsync(user.UserId);
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

        public void DeleteUser(gcsUserBasic user)
        {
            InitializeErrorsCollection();
            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteUserByPk(user.UserId);
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
        /// <summary>   Deletes the user asynchronous described by user. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="user"> The user. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteUserAsync(gcsUserBasic user)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int countDeleted = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            // For some reason, the DeleteSiteAsync throws a WCF exception
                            countDeleted = await proxy.DeleteUserByPkAsync(user.UserId);
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

        #region GetByUserId

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets by user identifier. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">   Identifier for the user. </param>
        ///
        /// <returns>   The by user identifier. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public gcsUser GetByUserId(Guid userId)
        //{
        //    InitializeErrorsCollection();
        //    CurrentUser = new gcsUser();

        //    WithClient(
        //        _ServiceFactory.CreateClient<IAdministrationService>(Binding,
        //            GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
        //            {
        //                try
        //                {
        //                    CurrentUser = proxy.GetUser(userId);
        //                    if (CurrentUser != null)
        //                    {
        //                        if (CurrentUser.UserPassword != string.Empty)
        //                        {
        //                            CurrentUser.UserPassword = Crypto.DecryptString(
        //                                CurrentUser.UserPassword, CurrentUser.UserId.ToString());
        //                            CurrentUser.ConfirmPassword = CurrentUser.UserPassword;
        //                        }
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

        //    return CurrentUser;
        //}

        public gcsUser GetByUserId(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            CurrentUser = new gcsUser();

            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            CurrentUser = proxy.GetUser(parameters);
                            if (CurrentUser != null)
                            {
                                if (CurrentUser.UserPassword != string.Empty)
                                {
                                    CurrentUser.UserPassword = Crypto.DecryptString(
                                        CurrentUser.UserPassword, CurrentUser.UserId.ToString());
                                    CurrentUser.ConfirmPassword = CurrentUser.UserPassword;
                                }
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

            return CurrentUser;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets by user identifier asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">   Identifier for the user. </param>
        ///
        /// <returns>   The by user identifier asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public async Task<gcsUser> GetByUserIdAsync(Guid userId)
        //{
        //    InitializeErrorsCollection();
        //    CurrentUser = new gcsUser();

        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<IAdministrationService>(Binding,
        //                GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
        //                {
        //                    CurrentUser = await proxy.GetUserAsync(userId);
        //                    if (CurrentUser != null)
        //                    {
        //                        if (CurrentUser.UserPassword != string.Empty)
        //                        {
        //                            CurrentUser.UserPassword = Crypto.DecryptString(
        //                                CurrentUser.UserPassword, CurrentUser.UserId.ToString()); //user.LoginName);
        //                            CurrentUser.ConfirmPassword = CurrentUser.UserPassword;
        //                        }
        //                    }
        //                    return CurrentUser;
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

        //    return CurrentUser;
        //}
        public async Task<gcsUser> GetByUserIdAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            CurrentUser = new gcsUser();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            CurrentUser = await proxy.GetUserAsync(parameters);
                            if (CurrentUser != null)
                            {
                                if (CurrentUser.UserPassword != string.Empty)
                                {
                                    CurrentUser.UserPassword = Crypto.DecryptString(
                                        CurrentUser.UserPassword, CurrentUser.UserId.ToString()); //user.LoginName);
                                    CurrentUser.ConfirmPassword = CurrentUser.UserPassword;
                                }
                            }
                            return CurrentUser;
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

            return CurrentUser;
        }

        #endregion

        #region GetByUserName

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets by user name. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userName"> Name of the user. </param>
        ///
        /// <returns>   The by user name. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUser GetByUserName(string userName)
        {
            InitializeErrorsCollection();
            CurrentUser = new gcsUser();

            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            CurrentUser = proxy.GetByUserName(userName);
                            if (CurrentUser != null)
                            {
                                if (CurrentUser.UserPassword != string.Empty)
                                {
                                    CurrentUser.UserPassword = Crypto.DecryptString(
                                        CurrentUser.UserPassword, CurrentUser.UserId.ToString());
                                    CurrentUser.ConfirmPassword = CurrentUser.UserPassword;
                                }
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

            return CurrentUser;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets by user name asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userName"> Name of the user. </param>
        ///
        /// <returns>   The by user name asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<gcsUser> GetByUserNameAsync(string userName)
        {
            InitializeErrorsCollection();
            CurrentUser = new gcsUser();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                CurrentUser = await client.GetByUserNameAsync(userName);
                if (CurrentUser != null)
                {
                    if (CurrentUser.UserPassword != string.Empty)
                    {
                        CurrentUser.UserPassword = Crypto.DecryptString(
                            CurrentUser.UserPassword, CurrentUser.UserId.ToString()); //user.LoginName);
                        CurrentUser.ConfirmPassword = CurrentUser.UserPassword;
                    }
                }

                var disposableClient = client as IDisposable;
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
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return CurrentUser;
        }

        #endregion

        #region GetByEmail

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets by email. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="email">    The email. </param>
        ///
        /// <returns>   The by email. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUser GetByEmail(string email)
        {
            InitializeErrorsCollection();
            CurrentUser = new gcsUser();

            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            CurrentUser = proxy.GetByEmail(email);
                            if (CurrentUser != null)
                            {
                                if (CurrentUser.UserPassword != string.Empty)
                                {
                                    CurrentUser.UserPassword = Crypto.DecryptString(
                                        CurrentUser.UserPassword, CurrentUser.UserId.ToString());
                                    CurrentUser.ConfirmPassword = CurrentUser.UserPassword;
                                }
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

            return CurrentUser;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets by email asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="email">    The email. </param>
        ///
        /// <returns>   The by email asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<gcsUser> GetByEmailAsync(string email)
        {
            InitializeErrorsCollection();
            CurrentUser = new gcsUser();

            try
            {
                var client = _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData);

                CurrentUser = await client.GetByEmailAsync(email);
                if (CurrentUser != null)
                {
                    if (CurrentUser.UserPassword != string.Empty)
                    {
                        CurrentUser.UserPassword = Crypto.DecryptString(
                            CurrentUser.UserPassword, CurrentUser.UserId.ToString()); //user.LoginName);
                        CurrentUser.ConfirmPassword = CurrentUser.UserPassword;
                    }
                }

                var disposableClient = client as IDisposable;
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
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return CurrentUser;
        }

        #endregion

        #region GetByPassword

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets by password. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="password"> The password. </param>
        ///
        /// <returns>   The by password. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUser GetByPassword(string password)
        {
            InitializeErrorsCollection();
            CurrentUser = new gcsUser();

            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            CurrentUser = proxy.GetByPassword(password);
                            if (CurrentUser != null)
                            {
                                if (CurrentUser.UserPassword != string.Empty)
                                {
                                    CurrentUser.UserPassword = Crypto.DecryptString(
                                        CurrentUser.UserPassword, CurrentUser.UserId.ToString());
                                    CurrentUser.ConfirmPassword = CurrentUser.UserPassword;
                                }
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

            return CurrentUser;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets by password asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="password"> The password. </param>
        ///
        /// <returns>   The by password asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<gcsUser> GetByPasswordAsync(string password)
        {
            InitializeErrorsCollection();
            CurrentUser = new gcsUser();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            CurrentUser = await proxy.GetByPasswordAsync(password);
                            if (CurrentUser != null)
                            {
                                if (CurrentUser.UserPassword != string.Empty)
                                {
                                    CurrentUser.UserPassword = Crypto.DecryptString(
                                        CurrentUser.UserPassword, CurrentUser.UserId.ToString()); //user.LoginName);
                                    CurrentUser.ConfirmPassword = CurrentUser.UserPassword;
                                }
                            }
                            return CurrentUser;
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
            return CurrentUser;
        }

        #endregion

        #region GeneratePasswordResetTokenAsync

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Generates a password reset token asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">   Identifier for the user. </param>
        ///
        /// <returns>   The password reset token asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<string> GeneratePasswordResetTokenAsync(Guid userId)
        {
            InitializeErrorsCollection();

            var startedAt = DateTimeOffset.Now;
            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var newPassword = await proxy.GeneratePasswordResetTokenAsync(userId);
                            return newPassword;
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
                this.Log().Debug(ex.Message);
            }
            return string.Empty;
        }

        #endregion

        #region ChangePasswordAsync

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Change password asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">           Identifier for the user. </param>
        /// <param name="currentPassword">  The current password. </param>
        /// <param name="newPassword">      The new password. </param>
        ///
        /// <returns>   A Task&lt;string&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<string> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            InitializeErrorsCollection();

            var startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            currentPassword = Crypto.EncryptString(currentPassword, userId.ToString());
                            newPassword = Crypto.EncryptString(newPassword, userId.ToString());
                            var returnPassword =
                                await proxy.ChangePasswordAsync(userId, currentPassword, newPassword);
                            returnPassword = Crypto.DecryptString(returnPassword, userId.ToString());
                            return returnPassword;
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
            return string.Empty;
        }

        #endregion

        #region RequestUserPasswordChangeTokenAsync
        public async Task<UserRequestPasswordChangeTokenResponse> RequestUserPasswordChangeTokenAsync(UserRequestPasswordChangeToken parameters)
        {
            InitializeErrorsCollection();

            var startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        var result =
                            await proxy.RequestUserPasswordChangeTokenAsync(parameters);
                        return result;
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
            return null;
        }
        #endregion

        #region UpdateUserPasswordAsync
        public async Task<UpdateUserPasswordResult> UpdateUserPasswordAsync(UpdateUserPasswordParameters parameters)
        {
            InitializeErrorsCollection();

            var startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        parameters.NewPassword = Crypto.EncryptString(parameters.NewPassword, parameters.UserId.ToString());
                        var result =
                            await proxy.UpdateUserPasswordAsync(parameters);
                        return result;
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
            return null;

        }
        #endregion


        #region GetUserPermissions

        public UserEntityPermissions GetUserPermissions(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            UserEntityPermissions data = null;

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetUserPermissions(parameters);
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

            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all users. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   all users. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<UserEntityPermissions> GetUsersPermissionsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetUserPermissionsAsync(parameters);
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

            return null;
        }


        #endregion

        #endregion

        #region GcsUserSetting Methods

        #region GetUserSetting

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user setting. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">               Identifier for the user. </param>
        /// <param name="applicationId">        Identifier for the application. </param>
        /// <param name="category">             The category. </param>
        /// <param name="keyValue">             The key value. </param>
        /// <param name="defaultValue">         The default value. </param>
        /// <param name="defaultDescription">   The default description. </param>
        /// <param name="bCreateIfNotFound">    True to create if not found. </param>
        ///
        /// <returns>   The user setting. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUserSetting GetUserSetting(Guid userId, Guid? applicationId, string category, string keyValue,
            string defaultValue, string defaultDescription, bool bCreateIfNotFound)
        {
            InitializeErrorsCollection();
            gcsUserSetting userSetting = null;

            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            userSetting = proxy.GetUserSettingFromParams(userId, applicationId, category, keyValue,
                                defaultValue, defaultDescription, bCreateIfNotFound);
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

            return userSetting;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user setting asynchronous. </summary>
        ///
        /// <param name="userId">               Identifier for the user. </param>
        /// <param name="applicationId">        Identifier for the application. </param>
        /// <param name="category">             The category. </param>
        /// <param name="keyValue">             The key value. </param>
        /// <param name="defaultValue">         The default value. </param>
        /// <param name="defaultDescription">   The default description. </param>
        /// <param name="bCreateIfNotFound">    True to create if not found. </param>
        ///
        /// <returns>   The user setting asynchronous. </returns>
        ///=================================================================================================

        public async Task<gcsUserSetting> GetUserSettingAsync(Guid userId, Guid? applicationId, string category, string keyValue,
            string defaultValue, string defaultDescription, bool bCreateIfNotFound)
        {
            InitializeErrorsCollection();
            gcsUserSetting userSetting = null;

            return await WithClientFuncAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                {
                    try
                    {
                        userSetting = await proxy.GetUserSettingFromParamsAsync(userId, applicationId, category, keyValue,
                            defaultValue, defaultDescription, bCreateIfNotFound);
                        return userSetting;
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

                    return userSetting;
                });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user setting asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">               Identifier for the user. </param>
        /// <param name="applicationId">        Identifier for the application. </param>
        /// <param name="category">             The category. </param>
        /// <param name="keyValue">             The key value. </param>
        /// <param name="defaultValue">         The default value. </param>
        /// <param name="defaultDescription">   The default description. </param>
        /// <param name="bCreateIfNotFound">    True to create if not found. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetUserSettingRaiseEvent(Guid userId, Guid? applicationId, string category, string keyValue,
            string defaultValue, string defaultDescription, bool bCreateIfNotFound)
        {
            InitializeErrorsCollection();
            gcsUserSetting userSetting = null;

            var startedAt = DateTimeOffset.Now;

            WithClientAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                var t = proxy.GetUserSettingFromParamsAsync(userId, applicationId, category, keyValue,
                                    defaultValue, defaultDescription, bCreateIfNotFound);
                                userSetting = await t;
                            };
                            try
                            {
                                task().Wait();
                                var endedAt = DateTimeOffset.Now;
                                var handler = GetUserSettingCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetUserSettingCompletedEventArgs(userSetting, startedAt, endedAt));
                                }
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
                        }
                    });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user setting. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userSetting">          The user setting. </param>
        /// <param name="bCreateIfNotFound">    True to create if not found. </param>
        ///
        /// <returns>   The user setting. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUserSetting GetUserSetting(gcsUserSetting userSetting, bool bCreateIfNotFound)
        {
            InitializeErrorsCollection();

            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            userSetting = proxy.GetUserSetting(userSetting, bCreateIfNotFound);
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

            return userSetting;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user setting asynchronous. </summary>
        ///
        /// <param name="userSetting">          The user setting. </param>
        /// <param name="bCreateIfNotFound">    True to create if not found. </param>
        ///
        /// <returns>   The user setting asynchronous. </returns>
        ///=================================================================================================

        public async Task<gcsUserSetting> GetUserSettingAsync(gcsUserSetting userSetting, bool bCreateIfNotFound)
        {
            InitializeErrorsCollection();

            return await WithClientFuncAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                {
                    try
                    {
                        userSetting = await proxy.GetUserSettingAsync(userSetting, bCreateIfNotFound);
                        return userSetting;
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
                    return userSetting;
                });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user setting asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userSetting">          The user setting. </param>
        /// <param name="bCreateIfNotFound">    True to create if not found. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetUserSettingRaiseEvent(gcsUserSetting userSetting, bool bCreateIfNotFound)
        {
            InitializeErrorsCollection();

            var startedAt = DateTimeOffset.Now;

            WithClientAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                var t = proxy.GetUserSettingAsync(userSetting, bCreateIfNotFound);
                                userSetting = await t;
                            };
                            try
                            {
                                task().Wait();
                                var endedAt = DateTimeOffset.Now;
                                var handler = GetUserSettingCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetUserSettingCompletedEventArgs(userSetting, startedAt, endedAt));
                                }
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
                        }
                    });
        }

        #endregion

        #region GetAllForApplication

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user settings for application. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="applicationId">    Identifier for the application. </param>
        ///
        /// <returns>   all user settings for application. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsUserSetting> GetAllUserSettingsForApplication(Guid? applicationId)
        {
            InitializeErrorsCollection();
            _UserSettings = new List<gcsUserSetting>();

            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var userSettings = proxy.GetAllUserSettingsForApplication(applicationId);
                            if (userSettings != null)
                            {
                                foreach (var setting in userSettings)
                                    _UserSettings.Add(setting);
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

            UserSettings = new ReadOnlyCollection<gcsUserSetting>(_UserSettings);
            return UserSettings;
        }

        public async Task<ReadOnlyCollection<gcsUserSetting>> GetAllUserSettingsForApplicationAsync(Guid? applicationId)
        {
            InitializeErrorsCollection();
            _UserSettings = new List<gcsUserSetting>();

            return await WithClientFuncAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                {
                    try
                    {
                        var userSettings = await proxy.GetAllUserSettingsForApplicationAsync(applicationId);
                        if (userSettings != null)
                        {
                            foreach (var setting in userSettings)
                                _UserSettings.Add(setting);
                        }
                        UserSettings = new ReadOnlyCollection<gcsUserSetting>(_UserSettings);
                        return UserSettings;
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

                    UserSettings = new ReadOnlyCollection<gcsUserSetting>(_UserSettings);
                    return UserSettings;
                });

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user settings for application asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="applicationId">    Identifier for the application. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetAllUserSettingsForApplicationRaiseEvent(Guid? applicationId)
        {
            InitializeErrorsCollection();
            _UserSettings = new List<gcsUserSetting>();

            var startedAt = DateTimeOffset.Now;

            WithClientAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                var t = proxy.GetAllUserSettingsForApplicationAsync(applicationId);
                                var userSettings = await t;
                                if (userSettings != null)
                                {
                                    foreach (var setting in userSettings)
                                    {
                                        _UserSettings.Add(setting);
                                    }
                                }
                            };
                            try
                            {
                                task().Wait();
                                var endedAt = DateTimeOffset.Now;
                                var handler = GetUserSettingsCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetUserSettingsCompletedEventArgs(
                                            new ReadOnlyCollection<gcsUserSetting>(_UserSettings), startedAt, endedAt));
                                }
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
                        }
                    });
        }

        #endregion

        #region GetAllForUser

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user settings for user. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">   Identifier for the user. </param>
        ///
        /// <returns>   all user settings for user. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsUserSetting> GetAllUserSettingsForUser(Guid userId)
        {
            InitializeErrorsCollection();
            _UserSettings = new List<gcsUserSetting>();

            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var userSettings = proxy.GetAllUserSettingsForUser(userId);
                            if (userSettings != null)
                            {
                                foreach (var setting in userSettings)
                                    _UserSettings.Add(setting);
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

            UserSettings = new ReadOnlyCollection<gcsUserSetting>(_UserSettings);
            return UserSettings;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user settings for user asynchronous. </summary>
        ///
        /// <param name="userId">   Identifier for the user. </param>
        ///
        /// <returns>   all user settings for user asynchronous. </returns>
        ///=================================================================================================

        public async Task<ReadOnlyCollection<gcsUserSetting>> GetAllUserSettingsForUserAsync(Guid userId)
        {
            InitializeErrorsCollection();
            _UserSettings = new List<gcsUserSetting>();

            return await WithClientFuncAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                {
                    try
                    {
                        var userSettings = await proxy.GetAllUserSettingsForUserAsync(userId);
                        if (userSettings != null)
                        {
                            foreach (var setting in userSettings)
                                _UserSettings.Add(setting);
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
                    UserSettings = new ReadOnlyCollection<gcsUserSetting>(_UserSettings);
                    return UserSettings;
                });

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user settings for user asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">   Identifier for the user. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetAllUserSettingsForUserRaiseEvent(Guid userId)
        {
            InitializeErrorsCollection();
            _UserSettings = new List<gcsUserSetting>();

            var startedAt = DateTimeOffset.Now;

            WithClientAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                var t = proxy.GetAllUserSettingsForUserAsync(userId);
                                var userSettings = await t;
                                if (userSettings != null)
                                {
                                    foreach (var setting in userSettings)
                                    {
                                        _UserSettings.Add(setting);
                                    }
                                }
                            };
                            try
                            {
                                task().Wait();
                                var endedAt = DateTimeOffset.Now;
                                var handler = GetUserSettingsCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetUserSettingsCompletedEventArgs(
                                            new ReadOnlyCollection<gcsUserSetting>(_UserSettings), startedAt, endedAt));
                                }
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
                        }
                    });
        }

        #endregion

        #region GetAllForUserApplication

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user settings for user application. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">           Identifier for the user. </param>
        /// <param name="applicationId">    Identifier for the application. </param>
        ///
        /// <returns>   all user settings for user application. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsUserSetting> GetAllUserSettingsForUserApplication(Guid userId, Guid? applicationId)
        {
            InitializeErrorsCollection();
            _UserSettings = new List<gcsUserSetting>();

            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var userSettings = proxy.GetAllUserSettingsForUserApplication(userId, applicationId);
                            if (userSettings != null)
                            {
                                foreach (var setting in userSettings)
                                    _UserSettings.Add(setting);
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

            UserSettings = new ReadOnlyCollection<gcsUserSetting>(_UserSettings);
            return UserSettings;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user settings for user application asynchronous. </summary>
        ///
        /// <param name="userId">           Identifier for the user. </param>
        /// <param name="applicationId">    Identifier for the application. </param>
        ///
        /// <returns>   all user settings for user application asynchronous. </returns>
        ///=================================================================================================

        public async Task<ReadOnlyCollection<gcsUserSetting>> GetAllUserSettingsForUserApplicationAsync(Guid userId, Guid? applicationId)
        {
            InitializeErrorsCollection();
            _UserSettings = new List<gcsUserSetting>();

            return await WithClientFuncAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                {
                    try
                    {
                        var userSettings = await proxy.GetAllUserSettingsForUserApplicationAsync(userId, applicationId);
                        if (userSettings != null)
                        {
                            foreach (var setting in userSettings)
                                _UserSettings.Add(setting);
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

                    UserSettings = new ReadOnlyCollection<gcsUserSetting>(_UserSettings);
                    return UserSettings;
                });

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user settings for user application asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">           Identifier for the user. </param>
        /// <param name="applicationId">    Identifier for the application. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async void GetAllUserSettingsForUserApplicationRaiseEvent(Guid userId, Guid? applicationId)
        {
            InitializeErrorsCollection();
            _UserSettings = new List<gcsUserSetting>();

            var startedAt = DateTimeOffset.Now;

            WithClientAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                var t = proxy.GetAllUserSettingsForUserApplicationAsync(userId, applicationId);
                                var userSettings = await t;
                                if (userSettings != null)
                                {
                                    foreach (var setting in userSettings)
                                    {
                                        _UserSettings.Add(setting);
                                    }
                                }
                            };
                            try
                            {
                                task().Wait();
                                var endedAt = DateTimeOffset.Now;
                                var handler = GetUserSettingsCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetUserSettingsCompletedEventArgs(
                                            new ReadOnlyCollection<gcsUserSetting>(_UserSettings), startedAt, endedAt));
                                }
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
                        }
                    });
        }

        #endregion

        #region GetAllForUserApplicationCategory

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user settings for user application category. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">           Identifier for the user. </param>
        /// <param name="applicationId">    Identifier for the application. </param>
        /// <param name="category">         The category. </param>
        ///
        /// <returns>   all user settings for user application category. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsUserSetting> GetAllUserSettingsForUserApplicationCategory(Guid userId,
            Guid? applicationId, string category)
        {
            InitializeErrorsCollection();
            _UserSettings = new List<gcsUserSetting>();

            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var userSettings = proxy.GetAllUserSettingsForUserApplicationCategory(userId, applicationId,
                                category);
                            if (userSettings != null)
                            {
                                foreach (var setting in userSettings)
                                    _UserSettings.Add(setting);
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

            UserSettings = new ReadOnlyCollection<gcsUserSetting>(_UserSettings);
            return UserSettings;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user settings for user application category asynchronous. </summary>
        ///
        /// <param name="userId">           Identifier for the user. </param>
        /// <param name="applicationId">    Identifier for the application. </param>
        /// <param name="category">         The category. </param>
        ///
        /// <returns>   all user settings for user application category asynchronous. </returns>
        ///=================================================================================================

        public async Task<ReadOnlyCollection<gcsUserSetting>> GetAllUserSettingsForUserApplicationCategoryAsync(Guid userId,
            Guid? applicationId, string category)
        {
            InitializeErrorsCollection();
            _UserSettings = new List<gcsUserSetting>();

            return await WithClientFuncAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                {
                    try
                    {
                        var userSettings = await proxy.GetAllUserSettingsForUserApplicationCategoryAsync(userId, applicationId,
                            category);
                        if (userSettings != null)
                        {
                            foreach (var setting in userSettings)
                                _UserSettings.Add(setting);
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
                    UserSettings = new ReadOnlyCollection<gcsUserSetting>(_UserSettings);
                    return UserSettings;
                });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all user settings for user application category asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">           Identifier for the user. </param>
        /// <param name="applicationId">    Identifier for the application. </param>
        /// <param name="category">         The category. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetAllUserSettingsForUserApplicationCategoryRaiseEvent(Guid userId, Guid? applicationId, string category)
        {
            InitializeErrorsCollection();
            _UserSettings = new List<gcsUserSetting>();

            var startedAt = DateTimeOffset.Now;

            WithClientAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                var t = proxy.GetAllUserSettingsForUserApplicationCategoryAsync(userId, applicationId,
                                    category);
                                var userSettings = await t;
                                if (userSettings != null)
                                {
                                    foreach (var setting in userSettings)
                                    {
                                        _UserSettings.Add(setting);
                                    }
                                }
                            };
                            try
                            {
                                task().Wait();
                                var endedAt = DateTimeOffset.Now;
                                var handler = GetUserSettingsCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetUserSettingsCompletedEventArgs(
                                            new ReadOnlyCollection<gcsUserSetting>(_UserSettings), startedAt, endedAt));
                                }
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
                        }
                    });
        }

        #endregion

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a user setting. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A gcsUserSetting. </returns>
        ///=================================================================================================
        public gcsUserSetting SaveUserSetting(SaveParameters<gcsUserSetting> parameters)
        {
            InitializeErrorsCollection();
            gcsUserSetting savedUserSetting = null;
            var isNew = parameters.Data.UserSettingId == Guid.Empty;
            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedUserSetting = proxy.SaveUserSetting(parameters);
                            _UserSettings.Add(savedUserSetting);
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

            return savedUserSetting;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a user setting asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;gcsUserSetting&gt; </returns>
        ///=================================================================================================

        public async Task<gcsUserSetting> SaveUserSettingAsync(SaveParameters<gcsUserSetting> parameters)
        {
            InitializeErrorsCollection();
            gcsUserSetting savedUserSetting = null;
            var isNew = parameters.Data.UserSettingId == Guid.Empty;
            return await WithClientFuncAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                {
                    try
                    {
                        savedUserSetting = await proxy.SaveUserSettingAsync(parameters);
                        _UserSettings.Add(savedUserSetting);
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
                    return savedUserSetting;
                });

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a user setting asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///=================================================================================================

        public void SaveUserSettingRaiseEvent(SaveParameters<gcsUserSetting> parameters)
        {
            InitializeErrorsCollection();
            var startedAt = DateTimeOffset.Now;
            gcsUserSetting savedUserSetting = null;
            var isNew = false;

            WithClientAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                isNew = parameters.Data.UserSettingId == Guid.Empty;
                                var t = proxy.SaveUserSettingAsync(parameters);
                                savedUserSetting = await t;
                            };
                            try
                            {
                                task().Wait();
                                if (savedUserSetting != null)
                                {
                                    var endedAt = DateTimeOffset.Now;
                                    var handler = SaveUserSettingCompletedEvent;
                                    if (handler != null)
                                    {
                                        handler(this,
                                            new SaveUserSettingCompletedEventArgs(
                                                savedUserSetting, isNew, startedAt, endedAt));
                                    }
                                }
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
                        }
                    });
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the user setting described by userSetting. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userSetting">  The user setting. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteUserSetting(gcsUserSetting userSetting)
        {
            InitializeErrorsCollection();
            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteUserSetting(userSetting);
                            _UserSettings.Remove(userSetting);
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

        public async Task<int> DeleteUserSettingAsync(gcsUserSetting userSetting)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        // For some reason, the DeleteSiteAsync throws a WCF exception
                        countDeleted = await proxy.DeleteUserSettingAsync(userSetting);
                        if (countDeleted == 1)
                        {
                            _UserSettings.Remove(userSetting);
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
        /// <summary>   Deletes the user setting asynchronous described by userSetting. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userSetting">  The user setting. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteUserSettingRaiseEvent(gcsUserSetting userSetting)
        {
            InitializeErrorsCollection();
            var startedAt = DateTimeOffset.Now;

            WithClientAsync(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                var tDelete = proxy.DeleteUserSettingAsync(userSetting);
                                await tDelete;
                                _UserSettings.Remove(userSetting);
                            };

                            try
                            {
                                task().Wait();
                                var endedAt = DateTimeOffset.Now;
                                var handler = DeleteUserSettingCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new DeleteUserSettingCompletedEventArgs(
                                            userSetting, startedAt, endedAt));
                                }
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
                        }
                    });
        }

        #endregion

        #endregion

        #region Get User Editing Data
        public gcsUserEditingData GetUserEditingData(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            gcsUserEditingData editingData = null;
            WithClient(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            editingData = proxy.GetUserEditingData(parameters);
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

            return editingData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets by user identifier asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">   Identifier for the user. </param>
        ///
        /// <returns>   The by user identifier asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<gcsUserEditingData> GetUserEditingDataAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetUserEditingDataAsync(parameters);
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

            return null;
        }
        #endregion

        #endregion
    }
}