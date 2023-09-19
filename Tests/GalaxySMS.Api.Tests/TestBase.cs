using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities.Api.NetCore;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace GalaxySMS.Api.Tests
{
    public class TestBase
    {
        protected RestClient _client = null;
        protected UserSignInResult _signInResult = null;

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(Statics.ApiUri);
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
            var result = _client.Execute<UserSignInResult>(request);
            _signInResult = JsonConvert.DeserializeObject<UserSignInResult>(result.Content);
        }

        protected RestRequest GetBearerAuthorizedRequest(string apiPrefix, Method method = Method.GET, DataFormat dataFormat = DataFormat.Json)
        {
            var request = new RestRequest($"{apiPrefix}", method, dataFormat);
            request.AddHeader("authorization", "Bearer " + _signInResult?.SessionToken.JwtToken);
            return request;
        }
    }
}
