using Judge0;
using Judge0.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Test.Base
{
    [TestClass]
    public class StatusesTest
    {
        StatusesService Service { get; set; }

        [TestInitialize]
        public void Setup()
        {
            var client = Utils.CreateTestClient();

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

    [TestClass]
    public class SubmissionsTest
    {
        SubmissionsService Service { get; set; }

        [TestInitialize]
        public void Setup()
        {
            var client = Utils.CreateTestClient();

            Service = new SubmissionsService(client);
        }

        [TestMethod]
        public async Task Get()
        {
            var result = await Service.Get("dc0605b3-1367-4768-91ce-591bf1e1a7e5");
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task Create()
        {
            var result = await Service.Create(new Submission
            {
                source_code = "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
                stdin = "world",
                language_id = 50,
            });
            Assert.IsTrue(result.IsSuccessStatusCode);

            var token = result.Result.token;

            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                var subresult = await Service.Get(token, true);
                Assert.IsTrue(subresult.IsSuccessStatusCode);
                if (subresult.Result.status?.id > 2)
                {
                    StringAssert.StartsWith(System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(subresult.Result.stdout)), "hello, world");
                    break;
                }
            }
        }

        [TestCleanup]
        public void Clean()
        {
            Service.Client.Dispose();
        }
    }
}
