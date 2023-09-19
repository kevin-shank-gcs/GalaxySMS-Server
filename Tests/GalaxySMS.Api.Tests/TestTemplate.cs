using GalaxySMS.Business.Entities.Api.NetCore;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Tests
{
    public class TestTemplate : TestBase
    {
        private string _apiPrefix = "auth/Entity";

        [Test]
        public async Task GetPass<T,TR>()
        {
            if(_signInResult == null)
                Assert.Fail();
            else
            {
                var request = new RestRequest($"{_apiPrefix}", Method.GET);
                request.AddHeader("authorization", "Bearer " + _signInResult?.SessionToken.JwtToken);
                var result = await _client.ExecuteAsync<T>(request);
                var data = JsonConvert.DeserializeObject<TR>(result.Content);
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
        }

        [Test]
        public async Task PostPass<T,TR>()
        {
            if(_signInResult == null)
                Assert.Fail();
            else
            {
                var request = new RestRequest($"{_apiPrefix}", Method.POST);
                request.AddHeader("authorization", "Bearer " + _signInResult?.SessionToken.JwtToken);
                var result = await _client.ExecuteAsync<T>(request);
                var data = JsonConvert.DeserializeObject<TR>(result.Content);
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            }
        }

        [Test]
        public async Task PutPass<T,TR>()
        {
            if(_signInResult == null)
                Assert.Fail();
            else
            {
                var request = new RestRequest($"{_apiPrefix}", Method.PUT);
                request.AddHeader("authorization", "Bearer " + _signInResult?.SessionToken.JwtToken);
                var result = await _client.ExecuteAsync<T>(request);
                var data = JsonConvert.DeserializeObject<TR>(result.Content);
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
        }

        [Test]
        public async Task DeletePass<T>()
        {
            if(_signInResult == null)
                Assert.Fail();
            else
            {
                var request = new RestRequest($"{_apiPrefix}", Method.DELETE);
                request.AddHeader("authorization", "Bearer " + _signInResult?.SessionToken.JwtToken);
                var result = await _client.ExecuteAsync<T>(request);
                var data = JsonConvert.DeserializeObject<T>(result.Content);
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            }
        }
    }
}