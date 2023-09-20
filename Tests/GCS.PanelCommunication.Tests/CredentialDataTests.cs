using System;
using GCS.PanelProtocols.Series6xx.Messages;
using NUnit.Framework;

//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCS.PanelCommunication.Tests
{
    [TestFixture]
    public class CredentialDataTests
    {

        [Test]
        public void Test48BitAlarmCredentialData()
        {
            try
            {
                var p = Helpers.GetNewPacketToSend(1, 1, 1, 1);

                var d48 = new CredentialData48Bit(0);
                d48.CredentialData[0].AlarmControlCredential = new AlarmControlCredentialData48Bit(new byte[6]);

                p.FillData(d48);
                p.PrepareForTransmission(false, true, string.Empty);
                Assert.AreEqual(1,1);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Test48BitAccessCredentialData()
        {
            try
            {
                var p = Helpers.GetNewPacketToSend(1, 1, 1, 1);

                var d48 = new CredentialData48Bit(0);
                d48.CredentialData[0].AccessControlCredential = new AccessControlCredentialData48Bit(new byte[6]);

                p.FillData(d48);
                p.PrepareForTransmission(false, true, string.Empty);
                Assert.AreEqual(1, 1);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void Test48BitCredentialDataUnion()
        {
            try
            {
                var p = Helpers.GetNewPacketToSend(1, 1, 1, 1);

                var d48 = new CredentialData48BitUnion();
                d48.AccessControlCredential = new AccessControlCredentialData48Bit(new byte[6]);

                p.FillData(d48);
                p.PrepareForTransmission(false, true, string.Empty);
                Assert.AreEqual(1, 1);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }
    }
}
