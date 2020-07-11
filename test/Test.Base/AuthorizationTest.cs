using Judge0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Test.Base
{
    [TestClass]
    public class AuthorizationTest
    {
        AuthorizationService Service { get; set; }

        [TestInitialize]
        public async Task Setup()
        {
            var client = await Utils.CreateTestClient();

            Service = new AuthorizationService(client);
        }

        [TestMethod]
        public async Task Authorize()
        {
            var result = await Service.Authorize("user");
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestCleanup]
        public void Clean()
        {
            Service.Client.Dispose();
        }
    }
}
