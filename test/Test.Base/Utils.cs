using Judge0;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Test.Base
{
    class Utils
    {
        public static async Task<HttpClient> CreateTestClient(bool authentication = true, bool authorization = true)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:3000/")
            };

            AuthenticationService service = new AuthenticationService(client);

            if (authentication)
            {
                Assert.IsTrue((await service.Authenticate("token")).Result);
            }

            if (authorization)
            {
                Assert.IsTrue((await service.Authorize("user")).Result);
            }
            return client;
        }
    }
}
