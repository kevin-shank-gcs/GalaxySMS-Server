using GCS.Framework.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GCS.Framework.UnitTests
{
    [TestClass]
    public class UtilityTests
    {
        [TestMethod]
        public void test_GetProcessorInfo()
        {
            var procInfo = SystemUtilities.GetProcessorInfo();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void test_GetHardDriveInfo()
        {
            var hdInfo = SystemUtilities.GetDriveInfo();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void test_MachineThumbPrint()
        {
            var tp = MachineThumbPrint.Value();
            Assert.IsFalse(string.IsNullOrEmpty(tp));
        }

        [TestMethod]
        public void test_GetLogicalDriveInfo()
        {
            //         var di = SystemUtilities.GetLogicalDriveInfo(string.Empty);
            var di = SystemUtilities.GetLogicalDriveInfo("E:");
            var sn = di.VolumeSerialNumber;
            var snd = di.VolumeSerialNumberDecimal;     // This is what System Galaxy uses.
            Assert.IsFalse(string.IsNullOrEmpty(di.VolumeSerialNumberDecimal));
        }

        [TestMethod]
        public void test_DateTimeTicks()
        {
            var start = DateTimeOffset.Now;
            var end = start.AddSeconds(2);
            while (DateTimeOffset.Now < end)
            {
                var dt = DateTimeOffset.Now;
                System.Diagnostics.Trace.WriteLine($"{dt.Hour}:{dt.Minute}:{dt.Second}:{dt.Millisecond}, ticks:{dt.Ticks}");
            }

            Assert.IsTrue(true);
        }
    }
}
