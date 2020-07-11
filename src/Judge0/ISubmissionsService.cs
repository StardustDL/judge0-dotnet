using Judge0.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Judge0
{
    public interface ISubmissionsService
    {
        Task<ResponseResult<Submission>> Create(Submission request);

        Task<ResponseResult<Submission>> CreateAndWait(Submission request);

        Task<ResponseResult<Submission>> Get(string token, string fields = SubmissionsService.DefaultFields);

        Task<ResponseResult<SubmissionPaging>> GetPaging(int page = 1, int perPage = 20, string fields = SubmissionsService.DefaultFields);

        Task<ResponseResult<Submission>> Delete(string token, string? fields = null);
    }

    public class SubmissionsService : ISubmissionsService
    {
        public const string DefaultFields = "stdout,time,memory,stderr,token,compile_output,message,status";

        const string PrepUrl = "/submissions";

        public SubmissionsService(HttpClient client) => Client = client;

        public HttpClient Client { get; }

        public async Task<ResponseResult<Submission>> Create(Submission request)
        {
            request = request.Base64Encode();
            var response = await Client.PostAsJsonAsync($"{PrepUrl}/?base64_encoded=true&wait=false", request).ConfigureAwait(false);
            var result = await response.BuildResponseResult<Submission>().ConfigureAwait(false);
            return result.Map(x => x.Base64Decode());
        }

        public async Task<ResponseResult<Submission>> CreateAndWait(Submission request)
        {
            request = request.Base64Encode();
            var response = await Client.PostAsJsonAsync($"{PrepUrl}/?base64_encoded=true&wait=true", request).ConfigureAwait(false);
            var result = await response.BuildResponseResult<Submission>().ConfigureAwait(false);
            return result.Map(x => x.Base64Decode());
        }

        public async Task<ResponseResult<Submission>> Delete(string token, string? fields = null)
        {
            var response = await Client.DeleteAsync($"{PrepUrl}/{token}?fields={fields}").ConfigureAwait(false);
            var result = await response.BuildResponseResult<Submission>().ConfigureAwait(false);
            return result.Map(x => x.Base64Decode());
        }

        public async Task<ResponseResult<Submission>> Get(string token, string fields = SubmissionsService.DefaultFields)
        {
            var response = await Client.GetAsync($"{PrepUrl}/{token}?base64_encoded=true&fields={fields}").ConfigureAwait(false);
            var result = await response.BuildResponseResult<Submission>().ConfigureAwait(false);
            return result.Map(x => x.Base64Decode());
        }

        public async Task<ResponseResult<SubmissionPaging>> GetPaging(int page = 1, int perPage = 20, string fields = SubmissionsService.DefaultFields)
        {
            var response = await Client.GetAsync($"{PrepUrl}/?base64_encoded=true&fields={fields}&page={page}&per_page={perPage}").ConfigureAwait(false);
            var result = await response.BuildResponseResult<SubmissionPaging>().ConfigureAwait(false);
            return result.Map(x => new SubmissionPaging
            {
                meta = x.meta,
                submissions = x.submissions.Select(x => x.Base64Decode()).ToArray()
            });
        }

        public async Task<ResponseResult<SubmissionBatch>> BatchGet(IEnumerable<string> tokens, string fields = SubmissionsService.DefaultFields)
        {
            var response = await Client.GetAsync($"{PrepUrl}/batch?tokens={string.Join(',', tokens)}&base64_encoded=true&fields={fields}").ConfigureAwait(false);
            var result = await response.BuildResponseResult<SubmissionBatch>().ConfigureAwait(false);
            return result.Map(x => new SubmissionBatch
            {
                submissions = x.submissions.Select(x => x.Base64Decode()).ToArray()
            });
        }

        public async Task<ResponseResult<IList<Submission>>> BatchCreate(SubmissionBatch requests)
        {
            requests = new SubmissionBatch
            {
                submissions = requests.submissions.Select(x => x.Base64Encode()).ToArray()
            };
            var response = await Client.PostAsJsonAsync($"{PrepUrl}/batch?base64_encoded=true", requests).ConfigureAwait(false);
            var result = await response.BuildResponseResult<IList<Submission>>().ConfigureAwait(false);
            return result.Map(x => (IList<Submission>)x.Select(c => c.Base64Decode()).ToArray());
        }
    }
}
