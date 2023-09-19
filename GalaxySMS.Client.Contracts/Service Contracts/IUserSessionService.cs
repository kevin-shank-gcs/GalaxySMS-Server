using GalaxySMS.Client.Entities;
using GalaxySMS.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.ServiceModel;
using GCS.Framework.Security;

namespace GalaxySMS.Client.Contracts
{
    [ServiceContract]
    public interface IUserSessionService : IServiceContract
    {
        #region Sign On/Off/Refresh Operations
        #region Synchronous operations        
        
        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserSignInResult SignInRequest(UserSignInRequest requestData);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserSessionToken SignOutUserSessionToken(UserSessionToken userToken);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserSessionToken SignOut(Guid sessionid);
        
        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserSessionToken KeepAlive(Guid sessionid);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserSessionToken UpdateSessionSettings(SaveParameters<UserSessionSettings> parameters);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserData GetUserDataForApplicationByUserId(Guid userId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserData GetUserDataForApplicationByUserName(string userName);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserData GetUserDataForApplicationByEmail(string email);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool DoesUserHavePermission(Guid userId, Guid entityId, Guid applicationId, Guid permissionId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool IsUserInRole(Guid userId, Guid entityId, Guid applicationId, Guid roleId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool IsUserInRoleName(Guid userId, Guid entityId, Guid applicationId, string roleName);

        #endregion

        #region Async operations
        [OperationContract]
        Task<UserSignInResult> SignInRequestAsync(UserSignInRequest requestData);

        [OperationContract]
        Task<UserSessionToken> SignOutUserSessionTokenAsync(UserSessionToken userToken);

        [OperationContract]
        Task<UserSessionToken> SignOutAsync(Guid sessionid);

        [OperationContract]
        Task<UserSessionToken> KeepAliveAsync(Guid sessionid);

        [OperationContract]
        Task<UserSessionToken> UpdateSessionSettingsAsync(SaveParameters<UserSessionSettings> parameters);

        [OperationContract]
        Task<UserData> GetUserDataForApplicationByUserIdAsync(Guid userId);

        [OperationContract]
        Task<UserData> GetUserDataForApplicationByUserNameAsync(string userName);

        [OperationContract]
        Task<UserData> GetUserDataForApplicationByEmailAsync(string email);

        [OperationContract]
        Task<bool> DoesUserHavePermissionAsync(Guid userId, Guid entityId, Guid applicationId, Guid permissionId);

        [OperationContract]
        Task<bool> IsUserInRoleAsync(Guid userId, Guid entityId, Guid applicationId, Guid roleId);

        [OperationContract]
        Task<bool> IsUserInRoleNameAsync(Guid userId, Guid entityId, Guid applicationId, string roleName);
        
        #endregion
        #endregion
    }
}