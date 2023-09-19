using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using GCS.Framework.Security;
using System;
using System.Collections.Generic;
using GalaxySMS.Common.Interfaces;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsUserRepository : IPagedDataRepository<gcsUser>
    {
        gcsUser GetByUserName(string userName, IApplicationUserSessionDataHeader sessionData, bool prepareForReturn);
        gcsUser GetByEmail(string email, IApplicationUserSessionDataHeader sessionData, bool prepareForReturn);

        String GetPasswordForUser(Guid userId, IApplicationUserSessionDataHeader sessionData);

        //IEnumerable<PasswordValidationResult> IsPasswordValid(gcsUser user);
        //IEnumerable<PasswordValidationResult> IsPasswordValid(gcsUserSave user);
        //IEnumerable<PasswordValidationResult> IsPasswordValidForEntityGuid(gcsUser user, Guid entityGuid);
        PasswordValidationInfo IsPasswordValid(gcsUser user, bool isEncrypted);
        PasswordValidationInfo IsPasswordValid(gcsUserSave user);
        PasswordValidationInfo IsPasswordValidForEntityGuid(gcsUser user, Guid entityGuid);

        IEnumerable<gcsUserOldPassword> GetOldPasswordsForUser(gcsUser user, int howMany,
            IApplicationUserSessionDataHeader sessionData);

        UserSignInResult SignInRequest(UserSignInRequest requestData, IApplicationUserSessionDataHeader sessionData,
            TwoFactorAuthParameters twoFactorAuthParameters);

        bool VerifyTwoFactorAuthenticationToken(TwoFactorAuthenticationData requestData,
            IApplicationUserSessionDataHeader sessionData, int tokenLifespan);

        UserSessionToken SignOut(UserSessionToken userToken, IApplicationUserSessionDataHeader sessionData);
        UserSessionToken RefreshUserToken(UserSessionToken userToken);
        UserData GetUserDataForApplicationByUserId(Guid userId, IApplicationUserSessionDataHeader sessionData);
        UserData GetUserDataForApplicationByUserName(string userName, IApplicationUserSessionDataHeader sessionData);
        UserData GetUserDataForApplicationByEmail(string email, IApplicationUserSessionDataHeader sessionData);
        string GeneratePasswordResetToken(Guid userId, IApplicationUserSessionDataHeader sessionData);

        gcsUser GetByPassword(string password, IApplicationUserSessionDataHeader sessionData);

//        bool DoesUserHavePermission(Guid userId, Guid entityId, Guid applicationId, Guid permissionId);
        bool DoesUserHavePermission(Guid userId, Guid entityId, Guid permissionId);

        //bool IsUserInRole(Guid userId, Guid entityId, Guid applicationId, Guid roleId);
        //bool IsUserInRole(Guid userId, Guid entityId, Guid applicationId, string roleName);
        bool IsUserInRole(Guid userId, Guid entityId, Guid roleId);
        bool IsUserInRole(Guid userId, Guid entityId, string roleName);

        IEnumerable<gcsUserBasic> GetUserList(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters);

        //bool IsUserInEntityApplicationRole(Guid userId, Guid entityApplicationRoleId);
        bool IsUserInRole(Guid userId, Guid roleId);

        //bool IsUserInAllEntityApplicationRoles(Guid userId, IEnumerable<Guid> entityApplicationRoleIds);
        bool IsUserInAllRoles(Guid userId, IEnumerable<Guid> roleIds);
        bool IsUniqueProperty(gcsUser user, ref string propertyName);
        bool IsUniqueProperty(gcsUserSave user, ref string propertyName);

        ArrayResponse<gcsUser> GetByPrimaryEntityId(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters);

        //UserSessionToken GetUserSessionTokenForApplications(Guid userId, Guid applicationId, IEnumerable<Guid> applicationIds, bool bIncludeEntityPhotos, int entityPhotosPixelWidth, bool bIncludeUserImages, int userImagesPixelWidth);
        UserSessionToken GetUserSessionTokenForApplications(Guid userId, Guid applicationId,
            UserSignInRequest requestData);

        UserSessionToken GetUserSessionTokenForSignInRequest(Guid userId, Guid applicationId,
            IEnumerable<Guid> applicationIds, bool bIncludeEntityPhotos, int entityPhotosPixelWidth,
            bool bIncludeUserImages, int userImagesPixelWidth, IEnumerable<Guid> permissionsForEntityIds,
            IApplicationUserSessionDataHeader sessionData);

        ArrayResponse<gcsUserBasic> GetUserListPaged(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters);

        //bool DoesUserHaveEntityApplication(Guid userId, Guid entityId, Guid applicationId);
        bool DoesUserHaveEntity(Guid userId, Guid entityId);
        bool DoesUserHaveAdminRole(Guid userId, Guid entityId);

        IEnumerable<Guid> GetPermissionIdsForUserEntityPermissionCategory(Guid userId, Guid entityId,
            Guid permissionCategoryId);

        ICurrentEntityInfo SetCurrentEntityId(Guid userId, Guid entityId,
            IApplicationUserSessionDataHeader sessionData);

        Guid GetPrimaryEntityId(Guid userId);

        UserRequestPasswordChangeTokenResponse RequestUserPasswordChangeToken(UserRequestPasswordChangeToken parameters, IApplicationUserSessionDataHeader sessionData, gcsUser user);

        UpdateUserPasswordResult UpdateUserPassword(UpdateUserPasswordParameters parameters, IApplicationUserSessionDataHeader sessionData);
        UserPasswordResetInformation GetPasswordResetInformation(Guid userId, IApplicationUserSessionDataHeader sessionData);

        PasswordResetParameters PasswordResetParameters { get; set; }
        UserEntityPermissions GetUserPermissions(GetParametersWithPhoto parameters);
    }
}
