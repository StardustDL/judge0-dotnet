using Judge0.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Judge0
{
    public interface ISystemService
    {
        Task<ResponseResult<IDictionary<string, string>>> GetSystemInfo(CancellationToken cancellationToken = default);

        Task<ResponseResult<ConfigInfo>> GetConfigInfo(CancellationToken cancellationToken = default);

        Task<ResponseResult<IList<QueueStatus>>> GetWorkerHealthCheck(CancellationToken cancellationToken = default);

        Task<ResponseResult<AboutInfo>> GetAbout(CancellationToken cancellationToken = default);

        Task<ResponseResult<string>> GetVersion(CancellationToken cancellationToken = default);

        Task<ResponseResult<string>> GetIsolate(CancellationToken cancellationToken = default);

        Task<ResponseResult<string>> GetLicense(CancellationToken cancellationToken = default);

        Task<ResponseResult<StatisticsInfo>> GetStatistics(CancellationToken cancellationToken = default);
    }

    public class SystemService : ISystemService
    {
        public SystemService(HttpClient client) => Client = client;

        public HttpClient Client { get; }

        public async Task<ResponseResult<AboutInfo>> GetAbout(CancellationToken cancellationToken = default)
        {
            var response = await Client.GetAsync("/about", cancellationToken: cancellationToken).ConfigureAwait(false);
            return await response.BuildResponseResult<AboutInfo>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<ResponseResult<ConfigInfo>> GetConfigInfo(CancellationToken cancellationToken = default)
        {
            var response = await Client.GetAsync("/config_info", cancellationToken: cancellationToken).ConfigureAwait(false);
            return await response.BuildResponseResult<ConfigInfo>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<ResponseResult<string>> GetIsolate(CancellationToken cancellationToken = default)
        {
            var response = await Client.GetAsync("/isolate", cancellationToken: cancellationToken).ConfigureAwait(false);
            return await response.BuildResponseResult<string>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
        public async Task<ResponseResult<string>> GetLicense(CancellationToken cancellationToken = default)
        {
            var response = await Client.GetAsync("/license", cancellationToken: cancellationToken).ConfigureAwait(false);
            return await response.BuildResponseResult<string>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<ResponseResult<StatisticsInfo>> GetStatistics(CancellationToken cancellationToken = default)
        {
            var response = await Client.GetAsync("/statistics", cancellationToken: cancellationToken).ConfigureAwait(false);
            return await response.BuildResponseResult<StatisticsInfo>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<ResponseResult<IDictionary<string, string>>> GetSystemInfo(CancellationToken cancellationToken = default)
        {
            var response = await Client.GetAsync("/system_info", cancellationToken: cancellationToken).ConfigureAwait(false);
            return await response.BuildResponseResult<IDictionary<string, string>>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<ResponseResult<string>> GetVersion(CancellationToken cancellationToken = default)
        {
            var response = await Client.GetAsync("/version", cancellationToken: cancellationToken).ConfigureAwait(false);
            return await response.BuildResponseResult<string>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<ResponseResult<IList<QueueStatus>>> GetWorkerHealthCheck(CancellationToken cancellationToken = default)
        {
            var response = await Client.GetAsync("/workers", cancellationToken: cancellationToken).ConfigureAwait(false);
            return await response.BuildResponseResult<IList<QueueStatus>>(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
