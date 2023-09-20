using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using NUnit.Framework;

namespace GalaxySMS.Client.SDK.Tests
{
    public class Helpers
    {
        public static async Task<UserSignInResult> SignIn(IGalaxySiteServerConnection connectionData)
        {
            var manager = new UserSessionManager(connectionData);
            var requestData = new UserSignInRequest();
            requestData.ApplicationId = ApplicationIds.GalaxySMS_FacilityManager_Id;
            requestData.UserName = MagicStrings.UserName;
            requestData.Password = MagicStrings.Password;
            requestData.PermissionsForApplicationIds.Add(ApplicationIds.GalaxySMS_Admin_Id);

            var response = await manager.SignInRequestAsync(requestData);
            Assert.IsTrue(response.RequestResult == GCS.Framework.Security.UserSignInRequestResult.Success ||
                response.RequestResult == GCS.Framework.Security.UserSignInRequestResult.SuccessWithInfo);

            return response;
        }

        public static async Task<UserSessionToken> SignOut(IGalaxySiteServerConnection connectionData, Guid sessionId)
        {
            var manager = new UserSessionManager(connectionData);

            var sessionToken = await manager.SignOutAsync(sessionId);
            Assert.IsTrue(sessionToken.SessionId == Guid.Empty);

            return sessionToken;
        }
    }
}
