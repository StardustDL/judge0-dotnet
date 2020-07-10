using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Test.Base
{
    class Utils
    {
        public static HttpClient CreateTestClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://judge0.p.rapidapi.com/")
            };

            client.DefaultRequestHeaders.Add("x-rapidapi-host", "judge0.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-key", Environment.GetEnvironmentVariable("Test_Server_Key") ?? File.ReadAllText("key.txt"));
            client.DefaultRequestHeaders.Add("useQueryString", "true");

            return client;
        }
    }
}
