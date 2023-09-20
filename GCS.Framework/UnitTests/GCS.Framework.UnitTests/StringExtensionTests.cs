using GCS.Core.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCS.Framework.UnitTests
{
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void GenerateRandomStringTest()
        {
            var result = string.Empty;
            for (int x = 0; x < 100; x++)
            {
                result = StringExtensions.GenerateRandomString(40);
                System.Threading.Thread.Sleep(1);
                System.Diagnostics.Trace.WriteLine(result);
            }
            Assert.AreEqual(40, result.Length);
        }


        [TestMethod]
        public void IsHexTest()
        {
            var testThis = "80b9ebDd5";

            var isHexResult = testThis.IsHexadecimal(true);

            Assert.AreEqual(true, isHexResult);
        }

        [TestMethod]
        public void IsDecimalTest()
        {
            var testThis = "80b9ebDd5";

            var isDecimalResult = testThis.IsDecimal();

            Assert.AreEqual(false, isDecimalResult);
        }
    }
}
