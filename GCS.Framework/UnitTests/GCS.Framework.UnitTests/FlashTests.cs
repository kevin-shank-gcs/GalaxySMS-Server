using System;
using GCS.Framework.Flash;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCS.Framework.UnitTests
{
    [TestClass]
    public class FlashTests
    {
        [TestMethod]
        public void LoadS28FileTest()
        {
            String filename = "E:\\Dev\\Installs\\SG_V11_1_0\\Components\\Program Files\\Flash\\600\\CPU_635_11-0-2_release.s28";
            var flashHelper = new GalaxyFlashImageHelper();
            flashHelper.ReadFlashS28File(filename);
            Assert.AreEqual(true, true);

        }
    }
}
