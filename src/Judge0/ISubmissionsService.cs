namespace Judge0
{
    public interface ISubmissionsService
    {
        ResponseResult<string> Create(bool base64Encoded = false);

        ResponseResult<Submission> CreateAndWait(bool base64Encoded = false);

        ResponseResult<Submission> Get(string token, bool base64Encoded = false, string fields = null);

        ResponseResult<Submission> Get(int page = 1, int perPage = 20, bool base64Encoded = false, string fields = null);

        ResponseResult<Submission> Delete(string token, string fields = null);
    }

    //TODO: System and Configuration, Statistics, Health Check
}
