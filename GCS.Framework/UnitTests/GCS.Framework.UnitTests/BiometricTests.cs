using System;
using GCS.Core.Common.Utils;
using GCS.Framework.Biometrics.MorphoManager.BioBridge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCS.Framework.UnitTests
{
    [TestClass]
    public class BiometricTests
    {
        [TestMethod]
        public void IsBioBridgeInstalledTest()
        {
            var bIsInstalled = BioBridgeUser.IsBioBridgeInstalled();
            Assert.AreEqual(bIsInstalled, true);
        }

        [TestMethod]
        public void IsBioBridgeNotInstalledTest()
        {
            var bIsInstalled = BioBridgeUser.IsBioBridgeInstalled();
            Assert.AreEqual(bIsInstalled, false);
        }

    }
}
