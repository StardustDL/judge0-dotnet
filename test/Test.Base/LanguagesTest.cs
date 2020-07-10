using Judge0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Test.Base
{
    [TestClass]
    public class LanguagesTest
    {
        [TestMethod]
        public async Task Get()
        {
            using var client = Utils.CreateTestClient();

            LanguagesService service = new LanguagesService(client);
            var result = await service.Get();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }
    }
}
