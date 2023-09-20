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
using System.ServiceModel;
//using System.Threading.Channels;
using System.Threading.Tasks;

namespace GalaxySMS.Client.SDK.Managers
{
    public class UserSessionManager : ManagerBase
    {
        #region Private fields
        #endregion

        #region Public properties

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSessionManager()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSessionManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
        }
        #endregion

        #region Public Methods

        public async Task<UserSignInResult> SignInAsync(UserSignInRequest requestData)
        {
            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                        GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
                    {
                        var data = await proxy.SignInRequestAsync(requestData);
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

        public async Task<UserSignInResult> VerifyTwoFactorAuthenticationTokenAsync(TwoFactorAuthenticationData requestData)
        {
            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                        GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
                    {
                        var data = await proxy.VerifyTwoFactorAuthenticationTokenAsync(requestData);
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

        public async Task<UserSessionToken> SignOutUserSessionTokenAsync(UserSessionToken userToken)
        {
            InitializeErrorsCollection();

            return await WithClientFuncAsync(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
                {
                    var data = await proxy.SignOutUserSessionTokenAsync(userToken);
                    return data;
                });
        }

        public async Task<UserSessionToken> SignOutAsync(Guid sessionId)
        {
            InitializeErrorsCollection();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            return await WithClientFuncAsync(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
                {
                    var data = await proxy.SignOutAsync(sessionId);
                    return data;
                });
        }

        public async Task<UserEntity> GetUserEntityAsync(Guid entityId)
        {
            InitializeErrorsCollection();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            return await WithClientFuncAsync(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
                {
                    var data = await proxy.GetUserEntityAsync(entityId);
                    return data;
                });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Keep alive asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionId">    Identifier for the session. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<UserSessionToken> KeepAliveAsync(Guid sessionId)
        {
            InitializeErrorsCollection();

            return await WithClientFuncAsync(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
                {
                    var data = await proxy.KeepAliveAsync(sessionId);
                    return data;
                });
        }


        //public async Task<UserSessionToken> SetJwtAsync(Guid sessionId, string jwt)
        //{
        //    InitializeErrorsCollection();

        //    return await WithClientFuncAsync(
        //        _ServiceFactory.CreateClient<IUserSessionService>(Binding,
        //            GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
        //        {
        //            var data = await proxy.SetJwtAsync(sessionId, jwt);
        //            return data;
        //        });
        //       }



        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the session settings asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;UserSessionToken&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<UserSessionToken> UpdateSessionSettingsAsync(SaveParameters<UserSessionSettings> parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
                    {
                        var data = await proxy.UpdateSessionSettingsAsync(parameters);
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

    }
}
