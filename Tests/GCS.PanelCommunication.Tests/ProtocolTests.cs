using System;
using System.Diagnostics;
using GCS.PanelProtocols.Series6xx.Messages;
using NUnit.Framework;


namespace GCS.PanelCommunication.Tests
{
    [TestFixture]
    public class ProtocolTests
    {

        [Test]
        public void TestPacketDataCode6xx()
        {
            try
            {
                foreach (var code in Enum.GetValues(typeof(PanelProtocols.Enums.PacketDataCodeTo6xx)))
                {
                    var hex = (UInt16)code;
                    Trace.WriteLine($"0x{hex:X2}:{code.ToString()}");
                }
                Assert.AreEqual(1,1);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

    }
}
