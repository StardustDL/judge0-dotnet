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

        public async Task<ResponseResult<ConfigInfo>> GetConfigInfo()
        {
            var response = await Client.GetAsync("/config_info").ConfigureAwait(false);
            return await response.BuildResponseResult<ConfigInfo>().ConfigureAwait(false);
        }

        public async Task<ResponseResult<IDictionary<string, string>>> GetSystemInfo()
        {
            var response = await Client.GetAsync("/system_info").ConfigureAwait(false);
            return await response.BuildResponseResult<IDictionary<string, string>>().ConfigureAwait(false);
        }
    }
}
