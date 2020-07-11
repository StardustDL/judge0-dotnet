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
        public static async Task<HttpClient> CreateTestClient(bool auth = true)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:3000/")
            };
            if (auth)
            {
                AuthenticationService service = new AuthenticationService(client);
                await service.Authenticate("token");
            }
            return client;
        }
    }
}
