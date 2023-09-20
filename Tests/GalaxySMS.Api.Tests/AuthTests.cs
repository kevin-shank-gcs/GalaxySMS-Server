using System.Net;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities.Api.NetCore;
using GCS.Framework.Security;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace GalaxySMS.Api.Tests
{
    public class AuthTests : TestBase
    {

        [Test]
        public async Task SignInRequestPass()
        {
            var body = new UserSignInRequest()
            {
                UserName = Statics.UserName,
                Password = Statics.Password,
                IncludeUserPhotos = true,
                UserPhotosPixelWidth = 200
            };

            var jsonBody = JsonConvert.SerializeObject(body);
            var request = new RestRequest("auth/signinrequest", Method.POST)
            { RequestFormat = RestSharp.DataFormat.Json }.AddJsonBody(jsonBody);
            var result = await _client.ExecuteAsync<UserSignInResult>(request);
            _signInResult = JsonConvert.DeserializeObject<UserSignInResult>(result.Content);
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(_signInResult.RequestResult == UserSignInRequestResult.Success);
        }


        [Test]
        public async Task KeepAlivePass()
        {
            if(_signInResult == null)
                Assert.Fail();
            else
            {
                var request = new RestRequest("auth/keepalive", Method.POST);
                request.AddHeader("authorization", "Bearer " + _signInResult?.SessionToken.JwtToken);
                var result = await _client.ExecuteAsync<UserSignInResult>(request);
                _signInResult.SessionToken = JsonConvert.DeserializeObject<UserSessionToken>(result.Content);
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
        }
    }
}