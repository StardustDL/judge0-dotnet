namespace Judge0
{
    public interface IAuthenticationService
    {
        ResponseResult<bool> Authenticate(string token);
    }

    //TODO: System and Configuration, Statistics, Health Check
}
