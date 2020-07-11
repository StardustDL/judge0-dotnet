using Judge0.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Judge0
{
    public interface ILanguagesService
    {
        Task<ResponseResult<IList<Language>>> GetAll();

        Task<ResponseResult<IList<Language>>> Get();

        Task<ResponseResult<Language>> Get(int id);
    }

    public class LanguagesService : ILanguagesService
    {
        const string PrepUrl = "/languages";

        public LanguagesService(HttpClient client) => Client = client;

        public HttpClient Client { get; }

        public async Task<ResponseResult<IList<Language>>> Get()
        {
            var response = await Client.GetAsync(PrepUrl).ConfigureAwait(false);
            return await response.BuildResponseResult<IList<Language>>().ConfigureAwait(false);
        }

        public async Task<ResponseResult<Language>> Get(int id)
        {
            var response = await Client.GetAsync($"{PrepUrl}/{id}").ConfigureAwait(false);
            return await response.BuildResponseResult<Language>().ConfigureAwait(false);
        }

        public async Task<ResponseResult<IList<Language>>> GetAll()
        {
            var response = await Client.GetAsync($"{PrepUrl}/all").ConfigureAwait(false);
            return await response.BuildResponseResult<IList<Language>>().ConfigureAwait(false);
        }
    }
}
