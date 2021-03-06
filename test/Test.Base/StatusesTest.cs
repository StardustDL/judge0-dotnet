﻿using Judge0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Test.Base
{
    [TestClass]
    public class StatusesTest
    {
        StatusesService Service { get; set; }

        [TestInitialize]
        public async Task Setup()
        {
            var client = await Utils.CreateTestClient();

            Service = new StatusesService(client);
        }

        [TestMethod]
        public async Task Get()
        {
            var result = await Service.Get();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestCleanup]
        public void Clean()
        {
            Service.Client.Dispose();
        }
    }
}
