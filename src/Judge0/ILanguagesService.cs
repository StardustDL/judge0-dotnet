using Judge0.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Judge0
{
    public interface ILanguagesService
    {
        Task<ResponseResult<IList<Language>>> GetAll(CancellationToken cancellationToken = default);

        Task<ResponseResult<IList<Language>>> Get(CancellationToken cancellationToken = default);

        Task<ResponseResult<Language>> Get(int id, CancellationToken cancellationToken = default);
    }

    public class LanguagesService : ILanguagesService
    {
        const string PrepUrl = "/languages";

        public LanguagesService(HttpClient client) => Client = client;

        public HttpClient Client { get; }

        public async Task<ResponseResult<IList<Language>>> Get(CancellationToken cancellationToken = default)
        {
            var response = await Client.GetAsync(PrepUrl, cancellationToken: cancellationToken).ConfigureAwait(false);
            return await response.BuildResponseResult<IList<Language>>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<ResponseResult<Language>> Get(int id, CancellationToken cancellationToken = default)
        {
            var response = await Client.GetAsync($"{PrepUrl}/{id}", cancellationToken: cancellationToken).ConfigureAwait(false);
            return await response.BuildResponseResult<Language>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<ResponseResult<IList<Language>>> GetAll(CancellationToken cancellationToken = default)
        {
            var response = await Client.GetAsync($"{PrepUrl}/all", cancellationToken: cancellationToken).ConfigureAwait(false);
            return await response.BuildResponseResult<IList<Language>>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
