using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Judge0
{
    public static class HttpClientExtensions
    {
        // default implement for PostAsJsonAsync with JsonContent will failed for Judge0, use StringContent instead.
        public static Task<HttpResponseMessage> PostAsJsonAsync<TValue>(this HttpClient client, string? requestUri, TValue value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }
            StringContent content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return client.PostAsync(requestUri, content, cancellationToken);
        }
    }
}
