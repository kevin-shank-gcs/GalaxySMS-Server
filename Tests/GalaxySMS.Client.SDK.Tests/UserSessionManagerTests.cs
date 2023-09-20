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
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.SDK.Tests
{
    [TestFixture]
    public class UserSessionManagerTests : GalaxySMSClientSDKManagerTestBase
    {
        UserSessionManager _manager = null;

        [SetUp]
        public override void Setup()
        {
            Trace.WriteLine("Setup: UserSessionManagerTests");
        }

        [TearDown]
        public override void TearDown()
        {
            Trace.WriteLine("TearDown: UserSessionManagerTests");
        }

        [Test]
        public void SignIn()
        {
            Assert.IsTrue(SignInResult.RequestResult == GCS.Framework.Security.UserSignInRequestResult.Success ||
                SignInResult.RequestResult == GCS.Framework.Security.UserSignInRequestResult.SuccessWithInfo);
        }
    }
}
