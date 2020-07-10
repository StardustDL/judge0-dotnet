using Judge0.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Judge0
{
    public interface ISubmissionsService
    {
        Task<ResponseResult<Submission>> Create(Submission request, bool base64Encoded = false);

        Task<ResponseResult<Submission>> CreateAndWait(Submission request, bool base64Encoded = false);

        Task<ResponseResult<Submission>> Get(string token, bool base64Encoded = false, string fields = SubmissionsService.DefaultFields);

        Task<ResponseResult<SubmissionPaging>> GetPaging(int page = 1, int perPage = 20, bool base64Encoded = false, string fields = SubmissionsService.DefaultFields);

        Task<ResponseResult<Submission>> Delete(string token, string? fields = null);
    }

    //TODO: System and Configuration, Statistics, Health Check

    public class SubmissionsService : ISubmissionsService
    {
        public const string DefaultFields = "stdout,time,memory,stderr,token,compile_output,message,status";

        const string PrepUrl = "/submissions";

        public SubmissionsService(HttpClient client) => Client = client;

        public HttpClient Client { get; }

        public async Task<ResponseResult<Submission>> Create(Submission request, bool base64Encoded = false)
        {
            var response = await Client.PostAsJsonAsync($"{PrepUrl}/?base64_encoded={(base64Encoded ? "true" : "false")}&wait=false", request).ConfigureAwait(false);
            return await response.BuildResponseResult<Submission>().ConfigureAwait(false);
        }

        public async Task<ResponseResult<Submission>> CreateAndWait(Submission request, bool base64Encoded = false)
        {
            var response = await Client.PostAsJsonAsync($"{PrepUrl}/?base64_encoded={(base64Encoded ? "true" : "false")}&wait=true", request).ConfigureAwait(false);
            return await response.BuildResponseResult<Submission>().ConfigureAwait(false);
        }

        public async Task<ResponseResult<Submission>> Delete(string token, string? fields = null)
        {
            var response = await Client.DeleteAsync($"{PrepUrl}/{token}?fields={fields}").ConfigureAwait(false);
            return await response.BuildResponseResult<Submission>().ConfigureAwait(false);
        }

        public async Task<ResponseResult<Submission>> Get(string token, bool base64Encoded = false, string fields = SubmissionsService.DefaultFields)
        {
            var response = await Client.GetAsync($"{PrepUrl}/{token}?base64_encoded={(base64Encoded ? "true" : "false")}&fields={fields}").ConfigureAwait(false);
            return await response.BuildResponseResult<Submission>().ConfigureAwait(false);
        }

        public async Task<ResponseResult<SubmissionPaging>> GetPaging(int page = 1, int perPage = 20, bool base64Encoded = false, string fields = SubmissionsService.DefaultFields)
        {
            var response = await Client.GetAsync($"{PrepUrl}/?base64_encoded={(base64Encoded ? "true" : "false")}&fields={fields}&page={page}&per_page={perPage}").ConfigureAwait(false);
            return await response.BuildResponseResult<SubmissionPaging>().ConfigureAwait(false);
        }
    }
}
