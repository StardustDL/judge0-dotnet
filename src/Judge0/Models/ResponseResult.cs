using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Judge0.Models
{
    public class ResponseResult<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccessStatusCode
        {
            get
            {
                int value = (int)StatusCode;
                return value >= 200 && value <= 299;
            }
        }

        public string Raw { get; set; } = string.Empty;

        public string Error { get; set; } = string.Empty;

#pragma warning disable CS8618 // 不可为 null 的字段未初始化。请考虑声明为可以为 null。
        public T Result { get; set; }
#pragma warning restore CS8618 // 不可为 null 的字段未初始化。请考虑声明为可以为 null。
    }

    public static class ResponseResultExtensions
    {
        public static async Task<ResponseResult<T>> BuildResponseResult<T>(this HttpResponseMessage response, CancellationToken cancellationToken = default)
        {
            var result = new ResponseResult<T>();
            result.StatusCode = response.StatusCode;
            result.Raw = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            try
            {
                result.Result = JsonSerializer.Deserialize<T>(result.Raw);
            }
            catch
            {

            }
            try
            {
                var error = JsonSerializer.Deserialize<ErrorResult>(result.Raw);
                result.Error = error.error;
            }
            catch
            {

            }
            return result;
        }

        public static ResponseResult<TDest> Map<TSrc, TDest>(this ResponseResult<TSrc> result, Func<TSrc, TDest> mapper)
        {
            return new ResponseResult<TDest>
            {
                Error = result.Error,
                Raw = result.Raw,
                StatusCode = result.StatusCode,
                Result = mapper(result.Result)
            };
        }
    }
}
