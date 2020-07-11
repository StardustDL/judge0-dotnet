using Judge0;
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
                await service.Authenticate("token");
            }

            if (authorization)
            {
                await service.Authorize("user");
            }
            return client;
        }
    }
}
