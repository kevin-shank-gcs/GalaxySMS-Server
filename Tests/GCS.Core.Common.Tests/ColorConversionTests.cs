using System;
using System.Collections.Generic;
using System.ComponentModel;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCS.Core.Common.Tests
{
    [TestClass]
    public class ColorConversionTests
    {
        [TestMethod]
        public void test_IntToRBBA()
        {
            uint i = 0;
            var rgba = i.ToRGBA();
            var rgb = i.ToRGB();
            Assert.IsTrue(rgba == "#00000000");
            Assert.IsTrue(rgb == "#000000");

            i = 0xff000000;
            rgba = i.ToRGBA();
            rgb = i.ToRGB();
            Assert.IsTrue(rgba == "#FF000000");
            Assert.IsTrue(rgb == "#FF0000");

            i = 0x00ff0000;
            rgba = i.ToRGBA();
            rgb = i.ToRGB();
            Assert.IsTrue(rgba == "#00FF0000");
            Assert.IsTrue(rgb == "#00FF00");

            i = 0x0000ff00;
            rgba = i.ToRGBA();
            rgb = i.ToRGB();
            Assert.IsTrue(rgba == "#0000FF00");
            Assert.IsTrue(rgb == "#0000FF");

            i = 0x0A00ff80;
            rgba = i.ToRGBA();
            rgb = i.ToRGB();
            Assert.IsTrue(rgba == "#0A00ff80");
            Assert.IsTrue(rgb == "#0A00ff");


        }
    }
}
