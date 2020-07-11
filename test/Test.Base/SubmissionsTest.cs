using Judge0;
using Judge0.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Base
{
    [TestClass]
    public class SubmissionsTest
    {
        SubmissionsService Service { get; set; }

        [TestInitialize]
        public async Task Setup()
        {
            var client = await Utils.CreateTestClient();

            Service = new SubmissionsService(client);
        }

        [TestMethod]
        public async Task CreateGetAndDelete()
        {
            var result = await Service.Create(new Submission
            {
                source_code = "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
                stdin = "world",
                language_id = 50,
            });
            Assert.IsTrue(result.IsSuccessStatusCode);
            string token = result.Result.token;

            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                var res = await Service.Get(token);
                Assert.IsTrue(res.IsSuccessStatusCode);
                if(res.Result.status?.id > 2)
                {
                    Assert.IsNotNull(res.Result.stdout);
                    StringAssert.StartsWith(res.Result.stdout, "hello, world");
                    break;
                }
            }

            var del = await Service.Delete(token);
            Assert.IsTrue(del.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task CreateWaitGetAndDelete()
        {
            var result = await Service.CreateAndWait(new Submission
            {
                source_code = "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
                stdin = "world",
                language_id = 50,
            });
            Assert.IsTrue(result.IsSuccessStatusCode);
            string token = result.Result.token;

            Assert.IsNotNull(result.Result.stdout);
            StringAssert.StartsWith(result.Result.stdout, "hello, world");

            var del = await Service.Delete(token);
            Assert.IsTrue(del.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task GetPaging()
        {
            var result = await Service.GetPaging();
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task Batch()
        {
            var result = await Service.BatchCreate(new SubmissionBatch
            {
                submissions = new[]{
                    new Submission
            {
                source_code = "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
                stdin = "world",
                language_id = 50,
            },
                    new Submission
            {
                source_code = "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\\n\", name);\n  return 0;\n}",
                stdin = "world",
                language_id = 50,
            }
                    }
            });
            Assert.IsTrue(result.IsSuccessStatusCode);
            var getres = await Service.BatchGet(result.Result.Select(x => x.token));
            Assert.IsTrue(getres.IsSuccessStatusCode);
        }

        [TestCleanup]
        public void Clean()
        {
            Service.Client.Dispose();
        }
    }
}
