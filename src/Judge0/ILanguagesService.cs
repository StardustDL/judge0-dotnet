using System.Collections.Generic;
using System.Threading.Tasks;

namespace Judge0
{
    public interface ILanguagesService
    {
        Task<ResponseResult<IList<Language>>> GetAll();

        Task<ResponseResult<IList<Language>>> Get();

        Task<ResponseResult<Language>> Get(int id);
    }

    //TODO: System and Configuration, Statistics, Health Check
}
