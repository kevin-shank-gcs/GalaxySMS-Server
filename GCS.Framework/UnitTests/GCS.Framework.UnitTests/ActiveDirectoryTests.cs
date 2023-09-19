using System;
using System.Collections.Generic;
using System.Linq;
using GCS.Core.Common.Utils;
using GCS.Framework.ActiveDirectory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCS.Framework.UnitTests
{
    [TestClass]
    public class ActiveDirectoryTests
    {
        [TestMethod]
        public void GetAllAdGroupsTest()
        {
            var groups = GCSADManager.GetGroups(string.Empty, false);
            var localGroups = GCSADManager.GetLocalGroups();

            Assert.AreNotEqual(groups.Count, 0);
        }

        [TestMethod]
        public void GetLocalGroupsTest()
        {
            var groups = GCSADManager.GetLocalGroups();

            Assert.AreNotEqual(groups.Count, 0);
        }

        [TestMethod]
        public void GetLocalUsersTest()
        {
            var users = GCSADManager.GetLocalUsers();

            Assert.AreNotEqual(users.Count, 0);
        }

        [TestMethod]
        public void CreateGroupTest()
        {
            var groupName = "testGroup";
            var b = GCSADManager.CreateLocalGroup(groupName, "trest group");
            Assert.IsTrue(b);
        }


        [TestMethod]
        public void CreateUserTest()
        {
            var groupName = "testGroup";
            var userName = "testUser";
            var password = "P@$$w0rd";
            var groups = new List<string>();
            groups.Add("testGroup");
            groups.Add("CarRentalUser");
            groups.Add("Users");
            var b = GCSADManager.CreateLocalUser(userName, password, "desc", groups);
            Assert.IsTrue(b);
        }
    }
}
