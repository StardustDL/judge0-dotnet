using System.Threading.Tasks;

namespace Judge0
{
    public interface IAuthorizationService
    {
        Task<ResponseResult<bool>> Authorize(string token);
    }

    //TODO: System and Configuration, Statistics, Health Check
}
