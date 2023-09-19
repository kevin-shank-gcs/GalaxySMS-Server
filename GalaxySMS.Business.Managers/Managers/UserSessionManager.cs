using GalaxySMS.Business.Contracts;
using GalaxySMS.Business.Entities;
using GalaxySMS.Common.Constants;
using GalaxySMS.Data.Contracts;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.ServiceModel.Extensions;
using GCS.Framework.Security;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Transactions;
using GalaxySMS.Data;

namespace GalaxySMS.Business.Managers
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                    ConcurrencyMode = ConcurrencyMode.Multiple,
                    ReleaseServiceInstanceOnTransactionComplete = false,
                    TransactionTimeout = "00:10:00",// - Defaults to 00:00:00 (no timeout)
                    TransactionIsolationLevel = IsolationLevel.ReadUncommitted)] // defaults to Serializable
    [ApplicationUserSessionHeaderInspectorBehavior]
    public class UserSessionManager : ManagerBase, IUserSessionService
    {
        public UserSessionManager()
        {
        }

        public UserSessionManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
        }

        public UserSessionManager(IDataRepositoryFactory dataRepositoryFactory, IBusinessEngineFactory businessEngineFactory)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
            _BusinessEngineFactory = businessEngineFactory;
        }

        [Import]
        IDataRepositoryFactory _DataRepositoryFactory;

        [Import]
        IBusinessEngineFactory _BusinessEngineFactory;


        #region IUserSessionService Members

        [OperationBehavior(TransactionScopeRequired = true)]
        public UserSignInResult SignInRequest(UserSignInRequest requestData)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var startedAt = DateTimeOffset.Now;
                var userRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();

                var twoFactorAuthParameters = new TwoFactorAuthParameters()
                {
                    TwoFactorTokenLifespan = Globals.Instance.TwoFactorAuthenticationSettings.TokenLifespan,
                    TwoFactorAuthTokenEmailTemplate = $"{Globals.Instance.TemplateFolder}{Globals.Instance.TwoFactorAuthenticationSettings.AuthTokenEmailTemplate}",
                    TwoFactorAuthTokenEmailSubject = Globals.Instance.TwoFactorAuthenticationSettings.AuthTokenEmailSubject,
                    TwoFactorAuthTokenSmsTemplate = $"{Globals.Instance.TemplateFolder}{Globals.Instance.TwoFactorAuthenticationSettings.AuthTokenSmsTemplate}"
                };

                var sessionTimeout = Globals.Instance.UserSessionTimeout;
                if (requestData.SessionTimeout > 0)
                {
                    var tout = new TimeSpan(0, 0, requestData.SessionTimeout, 0);
                    if (tout < sessionTimeout)
                        sessionTimeout = tout;
                }

                var result = userRepository.SignInRequest(requestData, ApplicationUserSessionHeader, twoFactorAuthParameters);
                switch (result.RequestResult)
                {
                    case UserSignInRequestResult.MustProvideTwoFactorToken:
                        result.SessionToken.Timeout = sessionTimeout;//Globals.Instance.UserSessionTimeout;
                        Globals.Instance.CurrentTwoFactorPendingUserSessions.Add(result.SessionToken.SessionId, result);
                        var returnData = new UserSignInResult(result);
                        // truncate the data that we do not want to return
                        returnData.SessionToken?.UserData?.UserEntities.Clear();
                        CreateJwtToken(returnData.SessionToken);
                        return returnData;

                    case UserSignInRequestResult.Success:
                    case UserSignInRequestResult.SuccessWithInfo:
                        result.SessionToken.Timeout = sessionTimeout;//Globals.Instance.UserSessionTimeout;
                        Globals.Instance.CurrentUserSessions.Add(result.SessionToken.SessionId, result.SessionToken);
                        CreateJwtToken(result.SessionToken);
                        break;

                    case UserSignInRequestResult.Unknown:
                        break;
                    case UserSignInRequestResult.InvalidUserName:
                        break;
                    case UserSignInRequestResult.InvalidPassword:
                        break;
                    case UserSignInRequestResult.UserAccountIsNotActive:
                        break;
                    case UserSignInRequestResult.UserAccountIsLockedOut:
                        break;
                    case UserSignInRequestResult.ApplicationNotPermitted:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                //// This is here simply to give the caller time to alert/notify the user that something is happening
                //if (requestData.MinimumExecutionTime > 0)
                //{
                //    while ((DateTimeOffset.Now - startedAt) < new TimeSpan(0, 0, 0, 0, requestData.MinimumExecutionTime))
                //        Thread.Sleep(100);
                //}
                return result;
            });
        }


        private void CreateJwtToken(UserSessionToken sessionToken)
        {
            var userClaims = new List<Claim>();
            foreach (var ue in sessionToken.UserData.UserEntities.Where(o => o.IsActive == true))
            {
                foreach (var r in ue.UserRoles)
                {
                    if (sessionToken.IsInAdminRole(ue.EntityId))
                    {
                        if (userClaims.FirstOrDefault(o => o.Type == GalaxySMSClaimTypes.EntityAdmin && o.Value == ue.EntityId.ToString()) == null)
                            userClaims.Add(new Claim(GalaxySMSClaimTypes.EntityAdmin, ue.EntityId.ToString()));
                    }

                    var value = $"{ue.EntityId}^{r.RoleName}";
                    if (userClaims.FirstOrDefault(o => o.Type == GalaxySMSClaimTypes.EntityRole && o.Value == value) == null)
                        userClaims.Add(new Claim(GalaxySMSClaimTypes.EntityRole, value));
                }
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, sessionToken.UserData.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, sessionToken.UserData.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, sessionToken.UserData.LastName),
                new Claim(JwtRegisteredClaimNames.Email, sessionToken.UserData.Email),
                new Claim(GalaxySMSClaimTypes.SessionId, sessionToken.SessionId.ToString()),
                new Claim(GalaxySMSClaimTypes.ApplicationId, sessionToken.ApplicationId.ToString()),
                new Claim(GalaxySMSClaimTypes.ApplicationName, sessionToken.ApplicationName),
                //new Claim(GalaxySMSClaimTypes.CurrentEntityId, result.SessionToken.CurrentEntityId.ToString()),
                new Claim(GalaxySMSClaimTypes.UserId, sessionToken.UserData.UserId.ToString()),
            }.Union(userClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Globals.Instance.TokenSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Globals.Instance.TokenSettings.Issuer,
                audience: Globals.Instance.TokenSettings.Audience,
                claims: claims,
                expires: sessionToken.ExpirationDateTime.DateTime,
                signingCredentials: creds
            );

            //var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            //var jwtTokenValidTill = token.ValidTo;

            sessionToken.JwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            sessionToken.JwtTokenValidTill = token.ValidTo;
            //SetJwt(sessionToken.SessionId, jwtToken);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public UserSignInResult VerifyTwoFactorAuthenticationToken(TwoFactorAuthenticationData requestData)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                UserSignInResult result = null;
                if (Globals.Instance.CurrentTwoFactorPendingUserSessions.TryGetValue(requestData.SessionId, out result))
                {
                    var startedAt = DateTimeOffset.Now;
                    var userRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                    var isValid = userRepository.VerifyTwoFactorAuthenticationToken(requestData, ApplicationUserSessionHeader, Globals.Instance.TwoFactorAuthenticationSettings.TokenLifespan);
                    if (isValid)
                    {
                        if (result.SuccessInformation.Any())
                            result.RequestResult = UserSignInRequestResult.SuccessWithInfo;
                        else
                            result.RequestResult = UserSignInRequestResult.Success;

                        var sessionTimeout = Globals.Instance.UserSessionTimeout;
                        if (result.RequestData.SessionTimeout > 0)
                        {
                            var tout = new TimeSpan(0, 0, result.RequestData.SessionTimeout, 0);
                            if (tout < sessionTimeout)
                                sessionTimeout = tout;
                        }

                        result.SessionToken.Timeout = sessionTimeout;//Globals.Instance.UserSessionTimeout;
                        Globals.Instance.CurrentUserSessions.Add(result.SessionToken.SessionId, result.SessionToken);
                        CreateJwtToken(result.SessionToken);
                    }
                    else
                    {
                        result.RequestResult = UserSignInRequestResult.InvalidTwoFactorToken;
                        result.SessionToken = null;
                    }
                    Globals.Instance.CurrentTwoFactorPendingUserSessions.Remove(requestData.SessionId);
                }
                return result;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public UserSessionToken SignOutUserSessionToken(UserSessionToken userToken)
        {
            return SignOut(userToken.SessionId);
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public UserSessionToken SignOut(Guid sessionId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                try
                {
                    var t = Globals.Instance.GetUserBySessionId(sessionId);
                    if (t != null && t.SessionId != Guid.Empty && t.UserData != null)
                    {
                        var userRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                        var result = userRepository.SignOut(t, ApplicationUserSessionHeader);
                        return result;
                    }
                    return t;
                }
                catch (UnauthorizedAccessException e)
                {   // THi

                }
                return null;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public UserSessionToken KeepAlive(Guid sessionid)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var t = Globals.Instance.GetUserBySessionId(sessionid);
                t?.KeepAlive();
                CreateJwtToken(t);

                return t;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public UserSessionToken UpdateSessionSettings(SaveParameters<UserSessionSettings> parameters)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var t = Globals.Instance.GetUserBySessionId(ApplicationUserSessionHeader.SessionGuid);//parameters.SessionId);
                if (t != null)
                {
                    if (t.CurrentEntityId != parameters.CurrentEntityId)
                    {
                        var e = Globals.Instance.DoesUserHaveEntity(UserId, parameters.CurrentEntityId);
                        if (e)
                        {
                            t.CurrentEntityId = parameters.CurrentEntityId;
                            var userRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                            var currentEntityInfo = userRepository.SetCurrentEntityId(t.UserData.UserId, t.CurrentEntityId, ApplicationUserSessionHeader);
                            t.CurrentEntityId = currentEntityInfo.CurrentEntityId;
                            t.UserData.CurrentEntityId = currentEntityInfo.CurrentEntityId;
                            t.UserData.CurrentEntityName = currentEntityInfo.CurrentEntityName;
                            t.UserData.CurrentEntityType = currentEntityInfo.CurrentEntityType;
                        }
                        else
                            throw new UnauthorizedAccessException();
                    }

                    return t;
                }
                return null;
            });
        }

        //public UserSessionToken UpdateSessionSettings(SaveParameters<UserSessionSettings> parameters)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        var t = Globals.Instance.GetUserBySessionId(ApplicationUserSessionHeader.SessionGuid);//parameters.SessionId);
        //        if (t != null)
        //        {
        //            if (t.CurrentEntityId != parameters.CurrentEntityId)
        //            {
        //                var e = 
        //                    (from ue in t.UserData.UserEntities where ue.EntityId == parameters.CurrentEntityId select ue)
        //                        .FirstOrDefault();
        //                if (e != null)
        //                {
        //                    t.CurrentEntityId = parameters.CurrentEntityId;
        //                }
        //                else
        //                    throw new UnauthorizedAccessException();
        //            }

        //            return t;
        //        }
        //        return null;
        //    });
        //}


        //public UserSessionToken SetJwt(Guid sessionId, string jwt)
        //{
        //    return ExecuteFaultHandledOperation(() =>
        //    {
        //        try
        //        {
        //            var t = Globals.Instance.GetUserBySessionId(sessionId);
        //            if (t != null && t.SessionId != Guid.Empty && t.UserData != null)
        //            {
        //                t.Jwt = jwt;
        //            }
        //            return t;
        //        }
        //        catch (UnauthorizedAccessException e)
        //        {   // THi

        //        }
        //        return null;
        //    });
        //}


        [OperationBehavior(TransactionScopeRequired = true)]
        public UserData GetUserDataForApplicationByUserId(Guid userId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var startedAt = DateTimeOffset.Now;
                var userRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                var result = userRepository.GetUserDataForApplicationByUserId(userId, ApplicationUserSessionHeader);
                return result;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public UserData GetUserDataForApplicationByUserName(string userName)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var startedAt = DateTimeOffset.Now;
                var userRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                var result = userRepository.GetUserDataForApplicationByUserName(userName, ApplicationUserSessionHeader);
                return result;
            });
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public UserData GetUserDataForApplicationByEmail(string email)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var startedAt = DateTimeOffset.Now;
                var userRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                var result = userRepository.GetUserDataForApplicationByEmail(email, ApplicationUserSessionHeader);
                return result;
            });
        }

        public bool DoesUserHavePermission(Guid userId, Guid entityId, Guid permissionId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var startedAt = DateTimeOffset.Now;
                var userRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                var result = userRepository.DoesUserHavePermission(userId, entityId, permissionId);
                return result;
            });
        }

        public bool IsUserInRole(Guid userId, Guid entityId, Guid roleId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var startedAt = DateTimeOffset.Now;
                var userRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                var result = userRepository.IsUserInRole(userId, entityId, roleId);
                return result;
            });
        }

        public bool IsUserInRoleName(Guid userId, Guid entityId, string roleName)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var startedAt = DateTimeOffset.Now;
                var userRepository = _DataRepositoryFactory.GetDataRepository<IGcsUserRepository>();
                var result = userRepository.IsUserInRole(userId, entityId, roleName);
                return result;
            });
        }


        public UserEntity GetUserEntity(Guid entityId)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var t = Globals.Instance.GetUserBySessionId(ApplicationUserSessionHeader.SessionGuid);//parameters.SessionId);
                if (t != null)
                {
                    var userRepo = new GcsUserRepository();
                    //var ue = userRepo.GetUserEntityForApplication(UserId, entityId, applicationId);
                    var ue = userRepo.GetUserEntityViaSp(UserId, entityId);
                    return ue;
                }
                return null;
            });

        }
        #endregion
    }
}
