using System.Collections.Generic;
using System.Threading.Tasks;

namespace Judge0
{
    public interface IStatusesService
    {
        Task<ResponseResult<IList<JudgeStatus>>> Get();
    }

    //TODO: System and Configuration, Statistics, Health Check
}
