using System;
using GCS.Core.Common.Utils;
using GCS.Framework.Badging.IdProducer;
using GCS.Framework.Biometrics.MorphoManager.BioBridge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace GCS.Framework.UnitTests
{
    [TestClass]
    public class IdProducerApiTests
    {
        string _masterUserName = "master@idProducer.com";
        string _masterPassword = "master";
        string _c1UserName = "master@c1.com";
        string _c1Password = "master";

        [TestMethod]
        public void idProducer_GetSubscriptionsTest()
        {
            var api = GetIdProducerApi(_masterUserName, _masterPassword);
            var subData = api.GetSubscriptionBranchData();

            var allSubs = api.GetAllSubscriptionsResponse();

            //var c1api = GetIdProducerApi(_c1UserName, _c1Password);
            //var c1subData = c1api.GetSubscriptionBranchData();
            //var c1allSubs = c1api.GetAllSubscriptionsResponse();

            Assert.AreEqual(true, true);
        }


        [TestMethod]
        public void idProducer_UpdateRootLicenseCompanyName()
        {
            var api = GetIdProducerApi(_masterUserName, _masterPassword);
            var subscriptions = api.GetAllSubscriptionsResponse();
            if (subscriptions.IsSuccessful)
            {
                var rootSub = subscriptions.Subscriptions.FirstOrDefault(s => s.ID == 1000);
                if (rootSub != null)
                {
                    var botApi = GetLicenseBotIdProducerApi();
                    rootSub.CompanyName = "idProducer_UpdateRootLicenseCompanyName Test";
                    var r = botApi.UpdateSubscriptionProfile(rootSub);
                }
            }
            else
                Assert.AreEqual(true, subscriptions?.IsSuccessful);

        }

        [TestMethod]
        public void idProducer_GetAllPrintRequests()
        {
            var api = GetIdProducerApi(_masterUserName, _masterPassword);
            var printRequests = api.GetAllPrintRequests();
            if (printRequests.IsSuccessful)
            {
            }
            else
                Assert.AreEqual(true, printRequests?.IsSuccessful);
        }

        [TestMethod]
        public void idProducer_DeletePrintRequest()
        {
            var api = GetIdProducerApi(_masterUserName, _masterPassword);
            var printRequests = api.GetAllPrintRequests();
            if (printRequests.IsSuccessful)
            {
                var pr = printRequests.PrintRequests.FirstOrDefault();
                if (pr != null)
                {
                    List<int> ids = new List<int>();
                    ids.Add(pr.ID);
                    var resp = api.CloseRequests(ids, "test");
                    Assert.AreEqual(true, true);
                }
                else
                    Assert.AreEqual(true, false);
            }
            else
                Assert.AreEqual(true, false);
        }

        [TestMethod]
        public void idProducer_DeleteCardTemplate()
        {
            var api = GetIdProducerApi(_masterUserName, _masterPassword);
            var deleteResponse = api.DeleteCardTemplate("5");
            Assert.AreEqual(deleteResponse.IsSuccessful, true);
        }

        
        [TestMethod]
        public void idProducer_GetVersionNumber()
        {
            var api = GetIdProducerApi(_masterUserName, _masterPassword);
            var version = api.GetServerVersionNumber();
            Assert.AreEqual(version.IsSuccessful, true);
            Assert.IsNotNull(version.Version);
        }
        
        [TestMethod]
        public void idProducer_GetSubscriptionTemplateFields()
        {
            var api = GetIdProducerApi(_masterUserName, _masterPassword);
            var templateFields = api.GetAllSubscriptionTemplateFields();
            Assert.AreEqual(templateFields.IsSuccessful, true);
        }

        [TestMethod]
        public void idProducer_GetUserById()
        {
            var api = GetIdProducerApi(_masterUserName, _masterPassword);
            var user = api.GetUserResponse(4);
            Assert.AreEqual(user.IsSuccessful, true);
        }

        [TestMethod]
        public void idProducer_GetUserByName()
        {
            var api = GetIdProducerApi(_masterUserName, _masterPassword);
            var user = api.GetUserResponse($"1@idproducer.com");
            Assert.AreEqual(user.IsSuccessful, true);
        }

        [TestMethod]
        public void idProducer_UpdateUser()
        {
            var username = "10000@idproducer.com";
            var password = "pendants(CHUCKLED";

            //var api = GetIdProducerApi(_masterUserName, _masterPassword);
            var api = GetIdProducerApi(username, password);
            var user = api.GetUserResponse("10000@idproducer.com");
            if (user.IsSuccessful)
            {
                user.User.UserName = $"{user.User.SubscriptionID}@idproducer.com";
                var response = api.UpdateUser(user.User);
                Assert.AreEqual(response.IsSuccessful, true);
            }
            Assert.AreEqual(user.IsSuccessful, true);
        }



        private idProducerAPI GetIdProducerApi(string userName, string password)
        {
            var url = "http://localhost:81/idProducer.BadgingServer/MasterService/JsonService_V2/";
            var urlDev = "http://localhost:81/idProducer.BadgingServer/MasterService/JsonService_dev/";

            return new idProducerAPI(url, userName, password, urlDev, string.Empty);
        }


        private idProducerAPI GetLicenseBotIdProducerApi()
        {
            var url = "http://localhost:81/idProducer.BadgingServer/MasterService/JsonService_V2/";
            var urlDev = "http://localhost:81/idProducer.BadgingServer/MasterService/JsonService_dev/";

            return new idProducerAPI(url, "licensebot@specsid.com", "p@$$30Rd", urlDev, string.Empty);
        }


    }
}
