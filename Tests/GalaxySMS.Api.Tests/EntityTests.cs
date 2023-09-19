using System;
using System.Linq;
using GalaxySMS.Business.Entities.Api.NetCore;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using GalaxySMS.Api.Models.RequestModels;

namespace GalaxySMS.Api.Tests
{
    public class EntityTests : TestBase
    {
        private string _apiPrefix = "entity";
        private string _entityName = "Test Entity 1";
        private string _entityDesc = "Test Entity 1 Description";
        private string _entityKey = "TestEntity1Key";

        [Test]
        public async Task GetPass()
        {
            if(_signInResult == null)
                Assert.Fail($"{Statics.SignInResultNull}");
            else
            {
                var request = GetBearerAuthorizedRequest(_apiPrefix, Method.GET, DataFormat.Json);
                var result = await _client.ExecuteAsync(request);
                var data = JsonConvert.DeserializeObject<gcsEntity[]>(result.Content);
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(data.Length, Is.GreaterThan(1) );
                Assert.That(data[0].EntityId, Is.EqualTo(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_SystemEntity_Id));
                Assert.That(data[1].EntityId, Is.EqualTo(GalaxySMS.Common.Constants.EntityIds.GalaxySMS_DefaultEntity_Id));
            }
        }

        [Test]
        public async Task PostPutGetDelete()
        {
            if(_signInResult == null)
                Assert.Fail($"{Statics.SignInResultNull}");
            else
            {
                var postBody = new SaveParams<EntityReq>()
                {
                    Data = new EntityReq()
                    {
                        EntityId = Statics.TestEntityId,
                        EntityName = _entityName,
                        EntityDescription = _entityDesc,
                        EntityKey = _entityKey
                    },
                };

                var jsonBody = JsonConvert.SerializeObject(postBody);
  
                // Create test entity
                var postRequest = GetBearerAuthorizedRequest(_apiPrefix, Method.POST, DataFormat.Json);
                postRequest.AddJsonBody(postBody);
                var result = await _client.ExecuteAsync(postRequest);
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.Created), result.Content);
                var data = JsonConvert.DeserializeObject<gcsEntity>(result.Content);
                Assert.That(data.EntityName, Is.EqualTo(_entityName));


                // Update the test entity
                var putRequest = GetBearerAuthorizedRequest(_apiPrefix, Method.PUT, DataFormat.Json);
                var putParams = new SaveParams<EntityPutReq>()
                {
                    Data = new EntityPutReq()
                    {
                        EntityId = Statics.TestEntityId,
                        EntityName = _entityName.ToUpper(),
                        EntityDescription = _entityDesc.ToUpper(),
                        EntityKey = _entityKey.ToUpper(),
                        IsActive = !data.IsActive,
                        ConcurrencyValue = data.ConcurrencyValue
                    },
                };

                jsonBody = JsonConvert.SerializeObject(putParams);
                putRequest.AddJsonBody(jsonBody);
                result = await _client.ExecuteAsync(putRequest);
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK), result.Content);
                data = JsonConvert.DeserializeObject<gcsEntity>(result.Content);
                Assert.That(data.EntityName, Is.EqualTo(_entityName.ToUpper()));

                // GET the test entity
                
                var getRequest = GetBearerAuthorizedRequest($"{_apiPrefix}/{Statics.TestEntityId}", Method.GET, DataFormat.Json);
                result = await _client.ExecuteAsync(getRequest);
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK), result.Content);
                var getData = JsonConvert.DeserializeObject<gcsEntity>(result.Content);
                Assert.That(getData.ConcurrencyValue, Is.EqualTo(data.ConcurrencyValue));

                // Get the sites and delete them for the test entity
                var getSitesRequest = GetBearerAuthorizedRequest($"site/list", Method.GET, DataFormat.Json);
                var sitesResult = await _client.ExecuteAsync(getSitesRequest);
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK), sitesResult.Content);
                
                var sites = JsonConvert.DeserializeObject<ListItemBase[]>(sitesResult.Content);
                foreach (var s in sites.Where(o=>o.EntityId == Statics.TestEntityId))
                {
                    var deleteSiteRequest = GetBearerAuthorizedRequest($"site/{s.Uid}", Method.DELETE, DataFormat.Json);
                    result = await _client.ExecuteAsync(deleteSiteRequest);
                    Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK), result.Content);
                }


                // Get the regions and delete them for the test entity
                var getRegionsRequest = GetBearerAuthorizedRequest($"region/list", Method.GET, DataFormat.Json);
                var regionsResult = await _client.ExecuteAsync(getRegionsRequest);
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK), regionsResult.Content);
                var regions = JsonConvert.DeserializeObject<ListItemBase[]>(regionsResult.Content);
                foreach (var r in regions.Where(o=>o.EntityId == Statics.TestEntityId))
                {
                    var deleteRegionRequest = GetBearerAuthorizedRequest($"region/{r.Uid}", Method.DELETE, DataFormat.Json);
                    result = await _client.ExecuteAsync(deleteRegionRequest);
                    Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK), result.Content);
                }

                // Delete the test entity
                var deleteRequest = GetBearerAuthorizedRequest($"{_apiPrefix}/{Statics.TestEntityId}", Method.DELETE, DataFormat.Json);
                result = await _client.ExecuteAsync(deleteRequest);
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK), result.Content);

                //var deleteSiteRequest = GetBearerAuthorizedRequest($"site", Method.DELETE, DataFormat.Json);
                //deleteSiteRequest

            }
        }

    }
}