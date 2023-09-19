using System;
using GCS.Core.Common.Utils;
using GCS.Framework.CredentialProcessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCS.Framework.UnitTests
{
    [TestClass]
    public class CredentialProcessorTests
    {
        [TestMethod]
        public void TestCypress37BitCalculator()
        {
            var fcc = CredentialCypress37BitFormat.Compute(1, 1);
            Assert.AreEqual(fcc, "68987912194");

            fcc = CredentialCypress37BitFormat.Compute(128, CredentialCypress37BitFormat.IdCodeMaximumValue);
            Assert.AreEqual(fcc, "103347650559");

            fcc = CredentialCypress37BitFormat.Compute(CredentialCypress37BitFormat.FacilityCodeMaximumValue, CredentialCypress37BitFormat.IdCodeMaximumValue);
            Assert.AreEqual(fcc, "68719476735");
        }

        [TestMethod]
        public void TestXceedId40BitCalculator()
        {
            var fcc = CredentialXceedId40BitFormat.Compute(1, 1);
            Assert.AreEqual(fcc, "550292684803");

            fcc = CredentialXceedId40BitFormat.Compute(128, CredentialXceedId40BitFormat.IdCodeMaximumValue);
            Assert.AreEqual(fcc, "69256347646");

            fcc = CredentialXceedId40BitFormat.Compute((ushort)CredentialXceedId40BitFormat.SiteCodeMaximumValue, CredentialXceedId40BitFormat.IdCodeMaximumValue);
            Assert.AreEqual(fcc, "1099511627775");
        }

        [TestMethod]
        public void TestHIDH1030437BitCalculator()
        {
            var fcc = CredentialHIDH1030437BitFormat.Compute(1, 1);
            Assert.AreEqual(fcc, "68720525314");

            fcc = CredentialHIDH1030437BitFormat.Compute(127, CredentialHIDH1030437BitFormat.IdCodeMaximumValue - 1);
            Assert.AreEqual(fcc, "68853694461");

            fcc = CredentialHIDH1030437BitFormat.Compute(128, CredentialHIDH1030437BitFormat.IdCodeMaximumValue);
            Assert.AreEqual(fcc, "68854743038");

            fcc = CredentialHIDH1030437BitFormat.Compute((ushort)CredentialHIDH1030437BitFormat.FacilityCodeMaximumValue-1, CredentialHIDH1030437BitFormat.IdCodeMaximumValue-1);
            Assert.AreEqual(fcc, "137437904893");

            fcc = CredentialHIDH1030437BitFormat.Compute((ushort)CredentialHIDH1030437BitFormat.FacilityCodeMaximumValue, CredentialHIDH1030437BitFormat.IdCodeMaximumValue);
            Assert.AreEqual(fcc, "68719476734");
        }

        [TestMethod]
        public void TestStandard26BitCalculator()
        {
            var fcc = Credential26BitWiegandFormat.Compute(1, 1);
            Assert.AreEqual(fcc, "33685506");

            fcc = Credential26BitWiegandFormat.Compute(127, (ushort)Credential26BitWiegandFormat.IdCodeMaximumValue - 1);
            Assert.AreEqual(fcc, "50331644");

            fcc = Credential26BitWiegandFormat.Compute((ushort)Credential26BitWiegandFormat.FacilityCodeMaximumValue - 1, (ushort)Credential26BitWiegandFormat.IdCodeMaximumValue - 1);
            Assert.AreEqual(fcc, "66977788");

            fcc = Credential26BitWiegandFormat.Compute((ushort)Credential26BitWiegandFormat.FacilityCodeMaximumValue, (ushort)Credential26BitWiegandFormat.IdCodeMaximumValue);
            Assert.AreEqual(fcc, "33554431");
        }


        [TestMethod]
        public void TestHIDCorporate1K35itCalculator()
        {
            var fcc = CredentialHIDCorporate1K35BitFormat.Compute(1, 1);
            Assert.AreEqual(fcc, "25771900931");

            fcc = CredentialHIDCorporate1K35BitFormat.Compute(2051, CredentialHIDCorporate1K35BitFormat.IdCodeMaximumValue - 1);
            Assert.AreEqual(fcc, "30073159677");

            fcc = CredentialHIDCorporate1K35BitFormat.Compute(CredentialHIDCorporate1K35BitFormat.CompanyCodeMaximumValue - 1, CredentialHIDCorporate1K35BitFormat.IdCodeMaximumValue - 1);
            Assert.AreEqual(fcc, "17177772028");

            fcc = CredentialHIDCorporate1K35BitFormat.Compute(CredentialHIDCorporate1K35BitFormat.CompanyCodeMaximumValue, CredentialHIDCorporate1K35BitFormat.IdCodeMaximumValue);
            Assert.AreEqual(fcc, "25769803774");
        }



        [TestMethod]
        public void TestHIDCorporate1K48itCalculator()
        {
            var fcc = CredentialHIDCorporate1K48BitFormat.Compute(1, 1);
            Assert.AreEqual(fcc, "70368760954882");

            fcc = CredentialHIDCorporate1K48BitFormat.Compute(1398101, CredentialHIDCorporate1K48BitFormat.IdCodeMaximumValue - 1);
            Assert.AreEqual(fcc, "23456259244028");

            fcc = CredentialHIDCorporate1K48BitFormat.Compute(CredentialHIDCorporate1K48BitFormat.CompanyCodeMaximumValue - 1, CredentialHIDCorporate1K48BitFormat.IdCodeMaximumValue - 1);
            Assert.AreEqual(fcc, "281474959933436");

            fcc = CredentialHIDCorporate1K48BitFormat.Compute(CredentialHIDCorporate1K48BitFormat.CompanyCodeMaximumValue, CredentialHIDCorporate1K48BitFormat.IdCodeMaximumValue);
            Assert.AreEqual(fcc, "211106232532991");
        }
    }
}
