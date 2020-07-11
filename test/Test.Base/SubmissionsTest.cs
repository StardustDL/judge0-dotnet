using Judge0;
using Judge0.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        public async Task CreateAndGet()
        {
            var result = await Service.Create(new Submission
            {
                source_code = "#include <stdio.h>\n\nint main(void) {\n  char name[10];\n  scanf(\"%s\", name);\n  printf(\"hello, %s\n\", name);\n  return 0;\n}",
                stdin = "world",
                language_id = 50,
            });
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestCleanup]
        public void Clean()
        {
            Service.Client.Dispose();
        }
    }
}
