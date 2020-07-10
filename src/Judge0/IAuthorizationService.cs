using Judge0.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Judge0
{
    public interface IAuthorizationService
    {
        Task<ResponseResult<bool>> Authorize(string token);
    }

    public class AuthorizationService : IAuthorizationService
    {
        const string PrepUrl = "/authorize";

        public AuthorizationService(HttpClient client) => Client = client;

        public HttpClient Client { get; }

        public async Task<ResponseResult<bool>> Authorize(string token)
        {
            Client.DefaultRequestHeaders.Add("X-Auth-User", token);
            var response = await Client.PostAsJsonAsync(PrepUrl, new object()).ConfigureAwait(false);
            return (await response.BuildResponseResult<object>()).Map(_ => response.IsSuccessStatusCode);
        }
    }
}
