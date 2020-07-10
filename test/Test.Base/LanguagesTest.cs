using Judge0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Test.Base
{
    [TestClass]
    public class LanguagesTest
    {
        LanguagesService Service { get; set; }

        [TestInitialize]
        public void Setup()
        {
            var client = Utils.CreateTestClient();

            Service = new LanguagesService(client);
        }

        [TestMethod]
        public async Task Get()
        {
            var result = await Service.Get();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task GetById()
        {
            var result = await Service.Get(50);
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task GetAll()
        {
            var result = await Service.GetAll();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestCleanup]
        public void Clean()
        {
            Service.Client.Dispose();
        }
    }
}
