using System.Threading.Tasks;

namespace Judge0
{
    public class ResponseResult<T>
    {
        public int Code { get; set; }

        public string Raw { get; set; } = string.Empty;

        public string Error { get; set; } = string.Empty;

#pragma warning disable CS8618 // 不可为 null 的字段未初始化。请考虑声明为可以为 null。
        public T Result { get; set; }
#pragma warning restore CS8618 // 不可为 null 的字段未初始化。请考虑声明为可以为 null。
    }
}
