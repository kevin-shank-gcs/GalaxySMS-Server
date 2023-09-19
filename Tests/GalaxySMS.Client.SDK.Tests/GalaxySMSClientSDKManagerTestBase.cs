using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GalaxySMS.Client.Bootstrapper;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Managers;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.ServiceModel;
using GCS.Framework.Utilities;
using NUnit.Framework;

namespace GalaxySMS.Client.SDK.Tests
{
    public class GalaxySMSClientSDKManagerTestBase
    {
        protected UserSignInResult SignInResult = null;
        protected IGalaxySiteServerConnection LocalSiteServerConnection;
        protected IApplicationUserSessionDataHeader SessionHeader;

        public IApplicationUserSessionDataHeader GetApplicationUserSessionHeader()
        {
            var attributes = GetMyAssemblyAttributes();

            var ret = new ApplicationUserSessionHeader(attributes);
            ret.UserName = WindowsIdentity.GetCurrent()?.Name;

            ret.MachineName = Environment.MachineName;
            ret.ClientTimeZoneId = System.TimeZone.CurrentTimeZone.StandardName;
            ret.Culture = Thread.CurrentThread.CurrentCulture.Name;
            ret.UiCulture = Thread.CurrentThread.CurrentUICulture.Name;

            ret.ApplicationId = SignInResult.SessionToken.ApplicationId;
            ret.SessionGuid = SignInResult.SessionToken.SessionId;
            ret.ApplicationName = SignInResult.SessionToken.ApplicationName;
            return ret;
        }

        public static AssemblyAttributes GetMyAssemblyAttributes()
        {
            var ass = Assembly.GetExecutingAssembly();
            var attributes = SystemUtilities.GetAssemblyAttributes(ref ass);
            return attributes;
        }

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            Trace.WriteLine("OneTimeSetup: GalaxySMSClientSDKManagerTestBase");
            var catalog = new List<ComposablePartCatalog>()
            {
                new AssemblyCatalog(Assembly.GetExecutingAssembly())
            };

            catalog.Add(new AssemblyCatalog(typeof(ApplicationManager).Assembly));

            StaticObjects.Container = MEFLoader.Init(catalog);
            LocalSiteServerConnection = new GalaxySiteServerConnection(new GalaxySiteServerConnectionSettings());
            SignInResult = await Helpers.SignIn(LocalSiteServerConnection);

            SessionHeader = GetApplicationUserSessionHeader();
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            var t = Task.Run(() => Helpers.SignOut(LocalSiteServerConnection, SignInResult.SessionToken.SessionId));
            t.Wait();
            SignInResult.SessionToken = t.Result;
        }

        [SetUp]
        public virtual void Setup()
        {

        }

        [TearDown]
        public virtual void TearDown() { }
    }
}
