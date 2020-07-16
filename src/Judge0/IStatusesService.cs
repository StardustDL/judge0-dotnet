using Judge0.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Judge0
{
    public interface IStatusesService
    {
        Task<ResponseResult<IList<JudgeStatus>>> Get(CancellationToken cancellationToken = default);
    }

    public class StatusesService : IStatusesService
    {
        const string PrepUrl = "/statuses";

        public StatusesService(HttpClient client) => Client = client;

        public HttpClient Client { get; }

        public async Task<ResponseResult<IList<JudgeStatus>>> Get(CancellationToken cancellationToken = default)
        {
            var response = await Client.GetAsync(PrepUrl, cancellationToken: cancellationToken).ConfigureAwait(false);
            return await response.BuildResponseResult<IList<JudgeStatus>>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
