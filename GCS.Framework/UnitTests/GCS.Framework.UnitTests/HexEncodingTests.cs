using GCS.Core.Common.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCS.Framework.UnitTests
{
    [TestClass]
    public class HexEncodingTests
    {
        [TestMethod]
        public void SetBit27Test()
        {
            var bytesUnderTest = new byte[32];
            var expectedResult = new byte[32];
            expectedResult[bytesUnderTest.Length - 4] = 0x04;
            var result = HexEncoding.SetBit(bytesUnderTest, 27, true);
            Assert.AreEqual(System.Convert.ToBase64String(bytesUnderTest),
                System.Convert.ToBase64String(expectedResult));
        }

        [TestMethod]
        public void SetBit1Test()
        {
            var bytesUnderTest = new byte[32];
            var expectedResult = new byte[32];
            expectedResult[bytesUnderTest.Length - 1] = 0x01;
            var result = HexEncoding.SetBit(bytesUnderTest, 1, true);
            Assert.AreEqual(System.Convert.ToBase64String(bytesUnderTest),
                System.Convert.ToBase64String(expectedResult));
        }

        [TestMethod]
        public void SetBit8Test()
        {
            var bytesUnderTest = new byte[32];
            var expectedResult = new byte[32];
            expectedResult[bytesUnderTest.Length - 1] = 0x80;
            var result = HexEncoding.SetBit(bytesUnderTest, 8, true);
            Assert.AreEqual(System.Convert.ToBase64String(bytesUnderTest),
                System.Convert.ToBase64String(expectedResult));
        }

        [TestMethod]
        public void GetBytesFromDecimalStringEmptyStringTest()
        {
            int discardedCount = 0;
            int length = 6;
            var emptyResult = new byte[length];
            var result = HexEncoding.GetBytesFromDecimalString(string.Empty, length, out discardedCount);
            Assert.AreEqual(System.Convert.ToBase64String(emptyResult), System.Convert.ToBase64String(result));
        }

        [TestMethod]
        public void GetBytesFromDecimalStringDecimalStringTest()
        {
            int discardedCount = 0;
            int length = 6;
            var emptyResult = new byte[length];
            var result = HexEncoding.GetBytesFromDecimalString("12345678", length, out discardedCount);
            Assert.AreNotEqual(System.Convert.ToBase64String(emptyResult), System.Convert.ToBase64String(result));
        }

        [TestMethod]
        public void GetBytesFromDecimalStringHexStringTest()
        {
            int discardedCount = 0;
            int length = 6;
            var emptyResult = new byte[length];
            var result = HexEncoding.GetBytesFromDecimalString("123abc", length, out discardedCount);
            Assert.AreNotEqual(System.Convert.ToBase64String(emptyResult), System.Convert.ToBase64String(result));
        }

        [TestMethod]
        public void GetBytesFromDecimalStringPrefixedHexStringTest()
        {
            int discardedCount = 0;
            int length = 6;
            var emptyResult = new byte[length];
            var result = HexEncoding.GetBytesFromDecimalString("0x123abc", length, out discardedCount);
            Assert.AreNotEqual(System.Convert.ToBase64String(emptyResult), System.Convert.ToBase64String(result));
        }


        [TestMethod]
        public void GetBytesFromString0xPrefixedHexStringTest()
        {
            int discardedCount = 0;
            int length = 6;
            var expectedResult = new byte[length];
            expectedResult[5] = 0xbc;
            expectedResult[4] = 0x3a;
            expectedResult[3] = 0x12;
            var result = HexEncoding.GetBytesFromString("0x123abc", length, out discardedCount);
            Assert.AreEqual(System.Convert.ToBase64String(expectedResult), System.Convert.ToBase64String(result));
        }


        [TestMethod]
        public void GetBytesFromStringxPrefixedHexStringTest()
        {
            int discardedCount = 0;
            int length = 6;
            var expectedResult = new byte[length];
            expectedResult[5] = 0xbc;
            expectedResult[4] = 0x3a;
            expectedResult[3] = 0x12;
            var result = HexEncoding.GetBytesFromString("x123abc", length, out discardedCount);
            Assert.AreEqual(System.Convert.ToBase64String(expectedResult), System.Convert.ToBase64String(result));
        }

        [TestMethod]
        public void GetBytesFromStringNoPrefixedHexStringTest()
        {
            int discardedCount = 0;
            int length = 6;
            var expectedResult = new byte[length];
            expectedResult[5] = 0xbc;
            expectedResult[4] = 0x3a;
            expectedResult[3] = 0x12;
            var result = HexEncoding.GetBytesFromString("123abc", length, out discardedCount);
            Assert.AreEqual(System.Convert.ToBase64String(expectedResult), System.Convert.ToBase64String(result));
        }

        [TestMethod]
        public void GetBytesFromStringDecimalStringTest()
        {
            int discardedCount = 0;
            int length = 6;
            var expectedResult = new byte[length];
            expectedResult[5] = 0x40;
            expectedResult[4] = 0xe2;
            expectedResult[3] = 0x1;

            var result = HexEncoding.GetBytesFromString("123456", length, out discardedCount);
            Assert.AreEqual(System.Convert.ToBase64String(expectedResult), System.Convert.ToBase64String(result));
        }

        [TestMethod]
        public void GetBytesFromStringPrefixedDecimalStringTest()
        {
            int discardedCount = 0;
            int length = 6;
            var expectedResult = new byte[length];
            expectedResult[5] = 0x56;
            expectedResult[4] = 0x34;
            expectedResult[3] = 0x12;

            var result = HexEncoding.GetBytesFromString("x123456", length, out discardedCount);
            Assert.AreEqual(System.Convert.ToBase64String(expectedResult), System.Convert.ToBase64String(result));
        }

    }
}
