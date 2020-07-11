using Judge0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Test.Base
{
    [TestClass]
    public class AuthenticationTest
    {
        AuthenticationService Service { get; set; }

        [TestInitialize]
        public async Task Setup()
        {
            var client = await Utils.CreateTestClient(false, false);

            Service = new AuthenticationService(client);
        }

        [TestMethod]
        public async Task AuthenticateAndAuthorize()
        {
            var result = await Service.Authenticate("token");
            Assert.IsTrue(result.IsSuccessStatusCode);

            result = await Service.Authorize("token");
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestCleanup]
        public void Clean()
        {
            Service.Client.Dispose();
        }
    }
}
