using System.Collections.Generic;

namespace Judge0
{
    public interface ILanguagesService
    {
        ResponseResult<IList<Language>> GetAll();

        ResponseResult<IList<Language>> Get();

        ResponseResult<Language> Get(int id);
    }

    //TODO: System and Configuration, Statistics, Health Check
}
