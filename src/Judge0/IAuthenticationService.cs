using System.Threading.Tasks;

namespace Judge0
{
    public interface IAuthenticationService
    {
        Task<ResponseResult<bool>> Authenticate(string token);
    }

    //TODO: System and Configuration, Statistics, Health Check
}
