using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GalaxySMS.Business.Entities;
using GalaxySMS.Data;

namespace RepoTests
{
    [TestClass]
    public class DtTestTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var repo = new DtTestRepository();
            var savedItem = repo.Add(new DtTest()
            {
                Dt = DateTimeOffset.Now,
                Dto = DateTimeOffset.Now,
                DtUtc = DateTimeOffset.UtcNow,
                DtoUtc = DateTimeOffset.UtcNow
            }, null, null);
            Assert.IsTrue(true);
        }
    }
}
