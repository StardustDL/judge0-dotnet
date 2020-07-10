using Judge0.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Judge0
{
    public interface IStatusesService
    {
        Task<ResponseResult<IList<JudgeStatus>>> Get();
    }

    public class StatusesService : IStatusesService
    {
        const string PrepUrl = "/statuses";

        public StatusesService(HttpClient client) => Client = client;

        public HttpClient Client { get; }

        public async Task<ResponseResult<IList<JudgeStatus>>> Get()
        {
            var response = await Client.GetAsync(PrepUrl).ConfigureAwait(false);
            return await response.BuildResponseResult<IList<JudgeStatus>>().ConfigureAwait(false);
        }
    }
}
