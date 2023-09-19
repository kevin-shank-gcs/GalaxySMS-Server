using System;
using GCS.Core.Common.Utils;
using GCS.Framework.Badging.IdProducer;
using GCS.Framework.Biometrics.MorphoManager.BioBridge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using GCS.Framework.Farpointe.Conekt;
using GCS.Framework.Farpointe.Conekt.Entities;

namespace GCS.Framework.UnitTests
{
    [TestClass]
    public class FarpointeApiTests
    {
        private FpConektApi GetFarpointeConektApi()
        {
            return new FpConektApi();
        }

        [TestMethod]
        public async Task FarpointeConekt_PlaceOrderTest()
        {
            var api = GetFarpointeConektApi();
            var subData = await api.PlaceOrderAsync(new NewOrder()
            {
                credentialCount = 1,
                formatName = "Galaxy40",
                purchaseOrder = "open po",
                credentialContents = new CredentialData()
                {
                    Prefix = 6, startIndex = 1
                }

            }, new TimeSpan(0, 0, 20));


            Assert.AreEqual(subData?.StatusCode, StatusCode.COMPLETED);
        }



    }
}
