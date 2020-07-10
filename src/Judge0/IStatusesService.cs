using System.Collections.Generic;

namespace Judge0
{
    public interface IStatusesService
    {
        ResponseResult<IList<JudgeStatus>> Get();
    }

    //TODO: System and Configuration, Statistics, Health Check
}
