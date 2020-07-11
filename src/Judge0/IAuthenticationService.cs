using Judge0.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Judge0
{
    public interface IAuthenticationService
    {
        Task<ResponseResult<bool>> Authenticate(string token);

        Task<ResponseResult<bool>> Authorize(string token);
    }

    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService(HttpClient client) => Client = client;

        public HttpClient Client { get; }

        public async Task<ResponseResult<bool>> Authenticate(string token)
        {
            Client.DefaultRequestHeaders.Add("X-Auth-Token", token);
            var response = await Client.PostAsJsonAsync("/authenticate", new object()).ConfigureAwait(false);
            return (await response.BuildResponseResult<object>()).Map(_ => response.IsSuccessStatusCode);
        }

        public async Task<ResponseResult<bool>> Authorize(string token)
        {
            Client.DefaultRequestHeaders.Add("X-Auth-User", token);
            var response = await Client.PostAsJsonAsync("/authorize", new object()).ConfigureAwait(false);
            return (await response.BuildResponseResult<object>()).Map(_ => response.IsSuccessStatusCode);
        }
    }
}
