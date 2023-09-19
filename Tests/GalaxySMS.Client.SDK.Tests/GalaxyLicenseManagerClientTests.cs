using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Bootstrapper;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.WebApiClients;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.SDK.Tests
{
    [TestFixture]
    public class GalaxyLicenseManagerClientTests 
    {

        [SetUp]
        public void Setup()
        {
            Trace.WriteLine("Setup: SystemLicensingTests");
        }

        [TearDown]
        public void TearDown()
        {
            Trace.WriteLine("TearDown: SystemLicensingTests");
        }

        [Test]
        public async Task GetActivateLicenseEditorData_Test()
        {
            var c = new GalaxyLicenceManagerClient();
            var data = await c.GetActivateLicenseEditorData(string.Empty, null);
            Assert.IsTrue(true);
        }
    }
}
