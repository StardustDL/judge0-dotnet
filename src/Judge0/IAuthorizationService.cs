namespace Judge0
{
    public interface IAuthorizationService
    {
        ResponseResult<bool> Authorize(string token);
    }

    //TODO: System and Configuration, Statistics, Health Check
}
