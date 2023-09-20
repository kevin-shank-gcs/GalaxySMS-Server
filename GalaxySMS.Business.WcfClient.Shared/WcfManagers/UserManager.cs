////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\UserManager.cs
//
// summary:	Implements the user manager class
////////////////////////////////////////////////////////////////////////////////////////////////////
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
using GCS.Framework.Security;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Threading.Tasks;

namespace GalaxySMS.Client.SDK.Managers
{

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
        }

        #endregion

        #region Private fields
        private List<gcsUserSetting> _UserSettings;


        #endregion

        #region Public properties
        public ReadOnlyCollection<gcsUserSetting> UserSettings { get; internal set; }

        public gcsUser CurrentUser { get; internal set; }

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

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        var users = await proxy.GetAllUsersAsync();
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

            return savedUser;
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
                        savedUser = await proxy.SaveUserAsync(p);
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
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return savedUser;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a user. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A gcsUser. </returns>
        ///=================================================================================================

        public gcsUser SaveUser(SaveParameters<gcsUserSave> parameters)
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
                            var tempUser = new gcsUserSave(parameters.Data);
                            isNew = tempUser.UserId == Guid.Empty;
                            if (tempUser.UserPassword != string.Empty)
                            {
                                tempUser.UserPassword = Crypto.EncryptString(
                                    tempUser.UserPassword, tempUser.UserId.ToString());
                            }
                            var p = new SaveParameters<gcsUserSave>(tempUser, parameters);
                            savedUser = proxy.SaveUserSave(p);
                            //_Users.Add(savedUser);
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

            return savedUser;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a user asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;gcsUser&gt; </returns>
        ///=================================================================================================

        public async Task<gcsUser> SaveUserAsync(SaveParameters<gcsUserSave> parameters)
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
                        var tempUser = new gcsUserSave(parameters.Data);
                        isNew = tempUser.UserId == Guid.Empty;
                        if (tempUser.UserPassword != string.Empty)
                        {
                            tempUser.UserPassword = Crypto.EncryptString(
                                tempUser.UserPassword, tempUser.UserId.ToString());
                        }
                        var p = new SaveParameters<gcsUserSave>(tempUser, parameters);
                        savedUser = await proxy.SaveUserSaveAsync(p);
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
                AddError(new CustomError(ex.Detail));
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

        public PasswordValidationInfo ValidatePassword(gcsUser user, bool isEncrypted)
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
                            validationResult = proxy.ValidatePassword(tempUser, isEncrypted);
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

            return validationResult;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validates the password asynchronous described by user. </summary>
        /// 
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        /// 
        /// <param name="user"> The user. </param>
        /// <param name="isEncrypted"></param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<PasswordValidationInfo> ValidatePasswordAsync(gcsUser user, bool isEncrypted)
        {
            InitializeErrorsCollection();
            var validationResult = new PasswordValidationInfo();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        var tempUser = new gcsUser(user);
                        if( !isEncrypted)
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
                AddError(new CustomError(ex.Detail));
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

            return savedUser;
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
                        parameters.NewPassword = Crypto.EncryptString(parameters.NewPassword, Guid.Empty.ToString());//parameters.UserId.ToString()));
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

            return savedUserSetting;
        }


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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the user setting asynchronous described by userSetting. </summary>
        ///
        /// <param name="userSetting">  The user setting. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ///=================================================================================================

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
        /// <summary>   Deletes the setting by unique identifier described by parameters. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///=================================================================================================

        public void DeleteUserSettingByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteUserSettingByPk(parameters.UniqueId);
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

        public async Task<int> DeleteUserSettingByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                        GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                        {
                            var ret = await proxy.DeleteUserSettingByPkAsync(parameters.UniqueId);
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