using GalaxySMS.Client.Contracts;
using GalaxySMS.Client.Entities;
using GCS.Core.Common.ServiceModel;
using GCS.Core.Common.ServiceModel.Extensions;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Proxies
{
    [Export(typeof(IUserSessionService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [ApplicationUserSessionHeaderInspectorBehavior]
    public class UserSessionClient : UserClientBase<IUserSessionService>, IUserSessionService
    {
        #region IUserSessionService Members
        #region Synchronous operations

        public UserSignInResult SignInRequest(UserSignInRequest requestData)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SignInRequest(requestData);
        }
        public UserSignInResult VerifyTwoFactorAuthenticationToken(TwoFactorAuthenticationData requestData)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.VerifyTwoFactorAuthenticationToken(requestData);
        }

        public UserSessionToken SignOutUserSessionToken(UserSessionToken userToken)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SignOutUserSessionToken(userToken);
        }

        public UserSessionToken SignOut(Guid sessionid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SignOut(sessionid);
        }

        public UserSessionToken KeepAlive(Guid sessionid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.KeepAlive(sessionid);
        }

        public UserSessionToken UpdateSessionSettings(SaveParameters<UserSessionSettings> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.UpdateSessionSettings(parameters);
        }

        public UserData GetUserDataForApplicationByUserId(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserDataForApplicationByUserId(userId);
        }

        public UserData GetUserDataForApplicationByUserName(string userName)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserDataForApplicationByUserName(userName);
        }

        public UserData GetUserDataForApplicationByEmail(string email)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserDataForApplicationByEmail(email);
        }

        public bool DoesUserHavePermission(Guid userId, Guid entityId, Guid permissionId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DoesUserHavePermission(userId, entityId, permissionId);
        }

        public bool IsUserInRole(Guid userId, Guid entityId, Guid roleId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsUserInRole(userId, entityId, roleId);
        }

        public bool IsUserInRoleName(Guid userId, Guid entityId, string roleName)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsUserInRoleName(userId, entityId, roleName);
        }

        public UserEntity GetUserEntity(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserEntity(entityId);
        }

        #endregion

        #region Async operations
        public Task<UserSignInResult> SignInRequestAsync(UserSignInRequest requestData)
        {
            System.Diagnostics.Trace.WriteLine($"ClientProxies SignInRequestAsync");
            base.InsertUserDataToOutgoingHeader();
            return Channel.SignInRequestAsync(requestData);
        }

        public Task<UserSignInResult> VerifyTwoFactorAuthenticationTokenAsync(TwoFactorAuthenticationData requestData)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.VerifyTwoFactorAuthenticationTokenAsync(requestData);
        }

        public Task<UserSessionToken> SignOutUserSessionTokenAsync(UserSessionToken userToken)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SignOutUserSessionTokenAsync(userToken);
        }

        public Task<UserSessionToken> SignOutAsync(Guid sessionId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.SignOutAsync(sessionId);
        }

        public Task<UserSessionToken> KeepAliveAsync(Guid sessionid)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.KeepAliveAsync(sessionid);
        }

        public Task<UserSessionToken> UpdateSessionSettingsAsync(SaveParameters<UserSessionSettings> parameters)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.UpdateSessionSettingsAsync(parameters);
        }

        public Task<UserData> GetUserDataForApplicationByUserIdAsync(Guid userId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserDataForApplicationByUserIdAsync(userId);
        }

        public Task<UserData> GetUserDataForApplicationByUserNameAsync(string userName)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserDataForApplicationByUserNameAsync(userName);
        }

        public Task<UserData> GetUserDataForApplicationByEmailAsync(string email)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserDataForApplicationByEmailAsync(email);
        }

        public Task<bool> DoesUserHavePermissionAsync(Guid userId, Guid entityId, Guid permissionId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.DoesUserHavePermissionAsync(userId, entityId, permissionId);
        }

        public Task<bool> IsUserInRoleAsync(Guid userId, Guid entityId, Guid roleId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsUserInRoleAsync(userId, entityId, roleId);
        }

        public Task<bool> IsUserInRoleNameAsync(Guid userId, Guid entityId, string roleName)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.IsUserInRoleNameAsync(userId, entityId, roleName);
        }

        public Task<UserEntity> GetUserEntityAsync(Guid entityId)
        {
            base.InsertUserDataToOutgoingHeader();
            return Channel.GetUserEntityAsync(entityId);
        }
        #endregion
        #endregion
    }
}
