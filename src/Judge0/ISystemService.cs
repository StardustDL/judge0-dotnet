using Judge0.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Judge0
{
    public interface ISystemService
    {
        Task<ResponseResult<IDictionary<string, string>>> GetSystemInfo();

        Task<ResponseResult<ConfigInfo>> GetConfigInfo();

        Task<ResponseResult<IList<QueueStatus>>> GetWorkerHealthCheck();

        Task<ResponseResult<AboutInfo>> GetAbout();

        Task<ResponseResult<string>> GetVersion();

        Task<ResponseResult<string>> GetIsolate();

        Task<ResponseResult<string>> GetLicense();

        Task<ResponseResult<StatisticsInfo>> GetStatistics();
    }

    public class SystemService : ISystemService
    {
        public SystemService(HttpClient client) => Client = client;

        public HttpClient Client { get; }

        public async Task<ResponseResult<IList<JudgeStatus>>> Get()
        {
            var response = await Client.GetAsync("/system_info").ConfigureAwait(false);
            return await response.BuildResponseResult<IList<JudgeStatus>>().ConfigureAwait(false);
        }

        public async Task<ResponseResult<AboutInfo>> GetAbout()
        {
            var response = await Client.GetAsync("/aboud").ConfigureAwait(false);
            return await response.BuildResponseResult<AboutInfo>().ConfigureAwait(false);
        }

        public async Task<ResponseResult<ConfigInfo>> GetConfigInfo()
        {
            var response = await Client.GetAsync("/config_info").ConfigureAwait(false);
            return await response.BuildResponseResult<ConfigInfo>().ConfigureAwait(false);
        }

        public async Task<ResponseResult<string>> GetIsolate()
        {
            var response = await Client.GetAsync("/isolate").ConfigureAwait(false);
            return await response.BuildResponseResult<string>().ConfigureAwait(false);
        }
        public async Task<ResponseResult<string>> GetLicense()
        {
            var response = await Client.GetAsync("/license").ConfigureAwait(false);
            return await response.BuildResponseResult<string>().ConfigureAwait(false);
        }

        public async Task<ResponseResult<StatisticsInfo>> GetStatistics()
        {
            var response = await Client.GetAsync("/statistics").ConfigureAwait(false);
            return await response.BuildResponseResult<StatisticsInfo>().ConfigureAwait(false);
        }

        public async Task<ResponseResult<IDictionary<string, string>>> GetSystemInfo()
        {
            var response = await Client.GetAsync("/system_info").ConfigureAwait(false);
            return await response.BuildResponseResult<IDictionary<string, string>>().ConfigureAwait(false);
        }

        public async Task<ResponseResult<string>> GetVersion()
        {
            var response = await Client.GetAsync("/version").ConfigureAwait(false);
            return await response.BuildResponseResult<string>().ConfigureAwait(false);
        }

        public async Task<ResponseResult<IList<QueueStatus>>> GetWorkerHealthCheck()
        {
            var response = await Client.GetAsync("/workers").ConfigureAwait(false);
            return await response.BuildResponseResult<IList<QueueStatus>>().ConfigureAwait(false);
        }
    }
}
