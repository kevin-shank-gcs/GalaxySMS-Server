////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	WcfManagers\UserSessionManager.cs
//
// summary:	Implements the user session manager class
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
using GCS.Framework.Security;
using GCS.Framework.Utilities;

namespace GalaxySMS.Client.SDK.Managers
{
    #region EventArg Classes

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for request user sign in completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class RequestUserSignInCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="signInResult">         The sign in result. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RequestUserSignInCompletedEventArgs(UserSignInResult signInResult, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            UserSignInResult = signInResult;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user sign in result. </summary>
        ///
        /// <value> The user sign in result. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSignInResult UserSignInResult { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for user sign out completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class UserSignOutCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionToken">         The session token. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSignOutCompletedEventArgs(UserSessionToken sessionToken, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            UserSessionToken = sessionToken;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user session token. </summary>
        ///
        /// <value> The user session token. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSessionToken UserSessionToken { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for user refresh completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class UserRefreshCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionToken">         The session token. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserRefreshCompletedEventArgs(UserSessionToken sessionToken, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            UserSessionToken = sessionToken;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user session token. </summary>
        ///
        /// <value> The user session token. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSessionToken UserSessionToken { get; internal set; }
    }
    #endregion

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for user sessions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class UserSessionManager : ManagerBase
    {
        #region Private fields
        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user sign in result. </summary>
        ///
        /// <value> The user sign in result. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSignInResult UserSignInResult { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user session token. </summary>
        ///
        /// <value> The user session token. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSessionToken UserSessionToken { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the user. </summary>
        ///
        /// <value> Information describing the user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserData UserData { get; internal set; }

        #endregion

        #region Events and Delegates

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling RequestUserSignInCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Request user sign in completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void RequestUserSignInCompletedEventHandler(object sender, RequestUserSignInCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in requestUserSignInCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event RequestUserSignInCompletedEventHandler RequestUserSignInCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling UserSignOutCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        User sign out completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void UserSignOutCompletedEventHandler(object sender, UserSignOutCompletedEventArgs e);
        /// <summary>   Event queue for all listeners interested in userSignOutCompleted events. </summary>
        public event UserSignOutCompletedEventHandler UserSignOutCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling UserRefreshCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        User refresh completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void UserRefreshCompletedEventHandler(object sender, UserRefreshCompletedEventArgs e);
        /// <summary>   Event queue for all listeners interested in userRefreshCompleted events. </summary>
        public event UserRefreshCompletedEventHandler UserRefreshCompletedEvent;
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

        #region Sign In

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sign in request. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="requestData">  Information describing the request. </param>
        ///
        /// <returns>   An UserSignInResult. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSignInResult SignInRequest(UserSignInRequest requestData)
        {
            //UserSignInResult = new UserSignInResult();
            InitializeErrorsCollection();
            var addr = GetServiceAddress(ServiceNames.UserSessionService);

            var cli = _ServiceFactory.CreateClient<IUserSessionService>(Binding, addr, ClientUserSessionData);


            WithClient<IUserSessionService>(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            PrepareRequestData(ref requestData);

                            UserSignInResult = proxy.SignInRequest(requestData);
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
            return UserSignInResult;
        }

        #region GetByUserId

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user data for application by user identifier. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">   Identifier for the user. </param>
        ///
        /// <returns>   The user data for application by user identifier. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserData GetUserDataForApplicationByUserId(Guid userId)
        {
            InitializeErrorsCollection();

            WithClient(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            UserData = proxy.GetUserDataForApplicationByUserId(userId);
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

            return UserData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user data for application by user identifier asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">   Identifier for the user. </param>
        ///
        /// <returns>   The user data for application by user identifier asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<UserData> GetUserDataForApplicationByUserIdAsync(Guid userId)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData);

                UserData = await client.GetUserDataForApplicationByUserIdAsync(userId);

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
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return UserData;
        }

        #endregion

        #region GetByUserName

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user data for application by user name. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userName"> Name of the user. </param>
        ///
        /// <returns>   The user data for application by user name. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserData GetUserDataForApplicationByUserName(string userName)
        {
            InitializeErrorsCollection();

            WithClient(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            UserData = proxy.GetUserDataForApplicationByUserName(userName);
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

            return UserData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user data for application by user name asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userName"> Name of the user. </param>
        ///
        /// <returns>   The user data for application by user name asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<UserData> GetUserDataForApplicationByUserNameAsync(string userName)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData);

                UserData = await client.GetUserDataForApplicationByUserNameAsync(userName);

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
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return UserData;
        }
        #endregion

        #region GetByEmail

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user data for application by user email. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="email">    The email. </param>
        ///
        /// <returns>   The user data for application by user email. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserData GetUserDataForApplicationByUserEmail(string email)
        {
            InitializeErrorsCollection();

            WithClient(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            UserData = proxy.GetUserDataForApplicationByEmail(email);
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

            return UserData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets user data for application by user email asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="email">    The email. </param>
        ///
        /// <returns>   The user data for application by user email asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<UserData> GetUserDataForApplicationByUserEmailAsync(string email)
        {
            InitializeErrorsCollection();

            try
            {
                var client = _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData);

                UserData = await client.GetUserDataForApplicationByEmailAsync(email);

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
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return UserData;
        }
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Prepare request data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="requestData">  [in,out] Information describing the request. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void PrepareRequestData(ref UserSignInRequest requestData)
        {
            var encryptPasspharase = requestData.SignInRequestDateTime.Ticks.ToString();
            foreach (var ipAddr in requestData.ComputerInformation.IPAddresses)
                encryptPasspharase += ipAddr;
            encryptPasspharase += requestData.ComputerInformation.MachineName;
            encryptPasspharase += requestData.ApplicationName;
            encryptPasspharase += requestData.ComputerInformation.DomainName;
            encryptPasspharase += requestData.CurrentWindowsUserIdentity.DomainName;
            encryptPasspharase += requestData.CurrentWindowsUserIdentity.Name;
            encryptPasspharase += requestData.ApplicationId.ToString();
            var encryptedPassword = Crypto.EncryptString(requestData.Password, encryptPasspharase);
            requestData.Password = encryptedPassword;
        }

        //public void SignInRequestAsync(UserSignInRequest requestData)
        //{
        //    //UserSignInResult = new UserSignInResult();
        //    InitializeErrorsCollection();

        //    DateTimeOffset startedAt = DateTimeOffset.Now;

        //    WithClientAsync<IUserSessionService>(
        //        _ServiceFactory.CreateClient<IUserSessionService>(Binding,
        //            GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
        //            {
        //                if (proxy != null)
        //                {
        //                    Func<Task> task = async () =>
        //                    {
        //                        PrepareRequestData(ref requestData);

        //                        Task<UserSignInResult> t = proxy.SignInRequestAsync(requestData);
        //                        UserSignInResult = await t;
        //                    };
        //                    try
        //                    {
        //                        task().Wait();
        //                        DateTimeOffset endedAt = DateTimeOffset.Now;
        //                        var handler = RequestUserSignInCompletedEvent;
        //                        if (handler != null)
        //                        {
        //                            handler(this,
        //                                new RequestUserSignInCompletedEventArgs(
        //                                    UserSignInResult, startedAt, endedAt));
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sign in request asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="requestData">  Information describing the request. </param>
        ///
        /// <returns>   A Task&lt;UserSignInResult&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<UserSignInResult> SignInRequestAsync(UserSignInRequest requestData)
        {
            try
            {
                UserSignInResult = new UserSignInResult();
                InitializeErrorsCollection();


                //ChannelFactory<IUserSessionService> channelFactory = null; 
                //EndpointAddress ep = null;

                //string strEPAdr = "net.tcp://localhost:8010/UserSessionService";
                //var tcpb = new NetTcpBinding();
                //tcpb.ReliableSession = new OptionalReliableSession(){ Enabled = true,};

                //channelFactory = new ChannelFactory<IUserSessionService>(tcpb);
                //// Create End Point
                //ep = new EndpointAddress(strEPAdr);

                //// Create Channel
                //IUserSessionService userSessionSvcObj = channelFactory.CreateChannel(ep);
                //UserSignInResult = await userSessionSvcObj.SignInRequestAsync(requestData);

                //var addr = GetServiceAddress(ServiceNames.UserSessionService);
                //var cli = _ServiceFactory.CreateClient<IUserSessionService>(Binding, addr, ClientUserSessionData);


                var client = _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData);

                PrepareRequestData(ref requestData);

                UserSignInResult = await client.SignInRequestAsync(requestData);

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
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return UserSignInResult;
        }

        #endregion

        #region

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Verify two factor authentication token. </summary>
        ///
        /// <param name="requestData">  Information describing the request. </param>
        ///
        /// <returns>   An UserSignInResult. </returns>
        ///=================================================================================================

        public UserSignInResult VerifyTwoFactorAuthenticationToken(TwoFactorAuthenticationData requestData)
        {
            //UserSignInResult = new UserSignInResult();
            InitializeErrorsCollection();
            var addr = GetServiceAddress(ServiceNames.UserSessionService);

            var cli = _ServiceFactory.CreateClient<IUserSessionService>(Binding, addr, ClientUserSessionData);


            WithClient<IUserSessionService>(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), proxy =>
                    {
                        try
                        {

                            UserSignInResult = proxy.VerifyTwoFactorAuthenticationToken(requestData);
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
            return UserSignInResult;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Verify two factor authentication token asynchronous. </summary>
        ///
        /// <param name="requestData">  Information describing the request. </param>
        ///
        /// <returns>   A Task&lt;UserSignInResult&gt; </returns>
        ///=================================================================================================

        public async Task<UserSignInResult> VerifyTwoFactorAuthenticationTokenAsync(TwoFactorAuthenticationData requestData)
        {
            try
            {
                UserSignInResult = new UserSignInResult();
                InitializeErrorsCollection();

                var client = _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData);


                UserSignInResult = await client.VerifyTwoFactorAuthenticationTokenAsync(requestData);

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
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return UserSignInResult;
        }

        #endregion

        #region Sign Out

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sign out user session token. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userToken">    The user token. </param>
        ///
        /// <returns>   An UserSessionToken. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSessionToken SignOutUserSessionToken(UserSessionToken userToken)
        {
            InitializeErrorsCollection();

            WithClient<IUserSessionService>(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            UserSessionToken = proxy.SignOutUserSessionToken(userToken);
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
            return UserSessionToken;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sign out user session token void asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userToken">    The user token. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SignOutUserSessionTokenVoidAsync(UserSessionToken userToken)
        {
            InitializeErrorsCollection();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IUserSessionService>(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task<UserSessionToken> t = proxy.SignOutUserSessionTokenAsync(userToken);
                                UserSessionToken = await t;
                            };
                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = UserSignOutCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new UserSignOutCompletedEventArgs(
                                            UserSessionToken, startedAt, endedAt));
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sign out user session tokent asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userToken">    The user token. </param>
        ///
        /// <returns>   A Task&lt;UserSessionToken&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<UserSessionToken> SignOutUserSessionTokenAsync(UserSessionToken userToken)
        {
            InitializeErrorsCollection();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            return await WithClientFuncAsync<IUserSessionService, UserSessionToken>(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
                    {
                        UserSessionToken = await proxy.SignOutUserSessionTokenAsync(userToken);
                        return UserSessionToken;
                    });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sign out. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionId">    Identifier for the session. </param>
        ///
        /// <returns>   An UserSessionToken. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSessionToken SignOut(Guid sessionId)
        {
            InitializeErrorsCollection();

            WithClient<IUserSessionService>(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            UserSessionToken = proxy.SignOut(sessionId);
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
            return UserSessionToken;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sign out asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionId">    Identifier for the session. </param>
        ///
        /// <returns>   A Task&lt;UserSessionToken&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<UserSessionToken> SignOutAsync(Guid sessionId)
        {
            InitializeErrorsCollection();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            return await WithClientFuncAsync<IUserSessionService, UserSessionToken>(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
                    {
                        UserSessionToken = await proxy.SignOutAsync(sessionId);
                        return UserSessionToken;
                    });
        }

        #endregion

        #region KeepAlive

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Keep alive. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionId">    Identifier for the session. </param>
        ///
        /// <returns>   An UserSessionToken. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSessionToken KeepAlive(Guid sessionId)
        {
            InitializeErrorsCollection();

            WithClient<IUserSessionService>(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            UserSessionToken = proxy.KeepAlive(sessionId);
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
            return UserSessionToken;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Keep alive asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sessionId">    Identifier for the session. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //public void KeepAliveAsync(Guid sessionId)
        //{
        //    InitializeErrorsCollection();

        //    DateTimeOffset startedAt = DateTimeOffset.Now;

        //    WithClientAsync<IUserSessionService>(
        //        _ServiceFactory.CreateClient<IUserSessionService>(Binding,
        //            GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
        //            {
        //                if (proxy != null)
        //                {
        //                    Func<Task> task = async () =>
        //                    {
        //                        Task<UserSessionToken> t = proxy.KeepAliveAsync(sessionId);
        //                        UserSessionToken = await t;
        //                    };
        //                    try
        //                    {
        //                        task().Wait();
        //                        DateTimeOffset endedAt = DateTimeOffset.Now;
        //                        var handler = UserSignOutCompletedEvent;
        //                        if (handler != null)
        //                        {
        //                            handler(this,
        //                                new UserSignOutCompletedEventArgs(
        //                                    UserSessionToken, startedAt, endedAt));
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


        public async Task<UserSessionToken> KeepAliveAsync(Guid sessionId)
        {
            InitializeErrorsCollection();

            await WithClientAsync<IUserSessionService>(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
                    {
                        try
                        {
                            UserSessionToken = await proxy.KeepAliveAsync(sessionId);
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
            return UserSessionToken;

        }

        #endregion

        #region UpdateSessionSettings

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Updates the session settings described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An UserSessionToken. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSessionToken UpdateSessionSettings(SaveParameters<UserSessionSettings> parameters)
        {
            InitializeErrorsCollection();

            WithClient<IUserSessionService>(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            UserSessionToken = proxy.UpdateSessionSettings(parameters);
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
            return UserSessionToken;
        }

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

            await WithClientAsync<IUserSessionService>(
                _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData), async proxy =>
                    {
                        try
                        {
                            UserSessionToken = await proxy.UpdateSessionSettingsAsync(parameters);
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
            return UserSessionToken;
        }

        #endregion

        #region FindByUserId

        #endregion

        #region FindByUserName

        #endregion

        #region FindByEmail

        #endregion

        #region DoesUserHavePermission

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Does user have permission. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">           Identifier for the user. </param>
        /// <param name="entityId">         Identifier for the entity. </param>
        /// <param name="permissionId">     Identifier for the permission. </param>
        ///
        /// <returns>   A Task&lt;bool&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> DoesUserHavePermission(Guid userId, Guid entityId, Guid permissionId)
        {
            InitializeErrorsCollection();
            bool result = false;
            try
            {
                var client = _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData);

                result = await client.DoesUserHavePermissionAsync(userId, entityId, permissionId);

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
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return result;
        }

        #endregion

        #region IsUserInRole & IsUserInRoleName

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Is user in role. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">           Identifier for the user. </param>
        /// <param name="entityId">         Identifier for the entity. </param>
        /// <param name="roleId">           Identifier for the role. </param>
        ///
        /// <returns>   A Task&lt;bool&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> IsUserInRole(Guid userId, Guid entityId, Guid roleId)
        {
            InitializeErrorsCollection();
            bool result = false;
            try
            {
                var client = _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData);

                result = await client.IsUserInRoleAsync(userId, entityId, roleId);

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
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Is user in role name. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userId">           Identifier for the user. </param>
        /// <param name="entityId">         Identifier for the entity. </param>
        /// <param name="roleName">         Name of the role. </param>
        ///
        /// <returns>   A Task&lt;bool&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> IsUserInRoleName(Guid userId, Guid entityId, string roleName)
        {
            InitializeErrorsCollection();
            bool result = false;
            try
            {
                var client = _ServiceFactory.CreateClient<IUserSessionService>(Binding,
                    GetServiceAddress(ServiceNames.UserSessionService), ClientUserSessionData);

                result = await client.IsUserInRoleNameAsync(userId, entityId, roleName);

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
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            }
            return result;
        }

        #endregion


        #region GetUserEntityForApplication 

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

        #endregion
    }
}
