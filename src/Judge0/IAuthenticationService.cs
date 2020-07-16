using Judge0.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Judge0
{
    public interface IAuthenticationService
    {
        Task<ResponseResult<bool>> Authenticate(string token, CancellationToken cancellationToken = default);

        Task<ResponseResult<bool>> Authorize(string token, CancellationToken cancellationToken = default);
    }

    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService(HttpClient client) => Client = client;

        public HttpClient Client { get; }

        public async Task<ResponseResult<bool>> Authenticate(string token, CancellationToken cancellationToken = default)
        {
            Client.DefaultRequestHeaders.Add("X-Auth-Token", token);
            var response = await Client.PostAsJsonAsync("/authenticate", new object(), cancellationToken: cancellationToken).ConfigureAwait(false);
            return (await response.BuildResponseResult<object>(cancellationToken: cancellationToken)).Map(_ => response.IsSuccessStatusCode);
        }

        public async Task<ResponseResult<bool>> Authorize(string token, CancellationToken cancellationToken = default)
        {
            Client.DefaultRequestHeaders.Add("X-Auth-User", token);
            var response = await Client.PostAsJsonAsync("/authorize", new object(), cancellationToken: cancellationToken).ConfigureAwait(false);
            return (await response.BuildResponseResult<object>(cancellationToken: cancellationToken)).Map(_ => response.IsSuccessStatusCode);
        }
    }
}
