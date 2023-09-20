using GalaxySMS.Business.Entities;
using GCS.Core.Common.ServiceModel;
using System;
using System.ServiceModel;

namespace GalaxySMS.Business.Contracts
{
    [ServiceContract]
    public interface IUserSessionService
    {
        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserSignInResult SignInRequest(UserSignInRequest requestData);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserSignInResult VerifyTwoFactorAuthenticationToken(TwoFactorAuthenticationData requestData);

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

        //[OperationContract]
        //UserSessionToken SetJwt(Guid sessionId, string jwt);

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
        bool DoesUserHavePermission(Guid userId, Guid entityId, Guid permissionId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool IsUserInRole(Guid userId, Guid entityId, Guid roleId);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        bool IsUserInRoleName(Guid userId, Guid entityId, string roleName);

        [OperationContract]
        [FaultContract(typeof(ExceptionDetailEx))]
        UserEntity GetUserEntity(Guid entityId);
    }
}