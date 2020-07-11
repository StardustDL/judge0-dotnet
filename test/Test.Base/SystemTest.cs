using Judge0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Test.Base
{
    [TestClass]
    public class SystemTest
    {
        SystemService Service { get; set; }

        [TestInitialize]
        public async Task Setup()
        {
            var client = await Utils.CreateTestClient();

            Service = new SystemService(client);
        }

        [TestMethod]
        public async Task GetSystemInfo()
        {
            var result = await Service.GetSystemInfo();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task GetAbout()
        {
            var result = await Service.GetAbout();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task GetConfigInfo()
        {
            var result = await Service.GetConfigInfo();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task GetIsolate()
        {
            var result = await Service.GetIsolate();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task GetLicense()
        {
            var result = await Service.GetLicense();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task GetStatistics()
        {
            var result = await Service.GetStatistics();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task GetWorkerHealthCheck()
        {
            var result = await Service.GetWorkerHealthCheck();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task GetVersion()
        {
            var result = await Service.GetVersion();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestCleanup]
        public void Clean()
        {
            Service.Client.Dispose();
        }
    }
}
