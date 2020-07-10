namespace Judge0
{
    public class ResponseResult<T>
    {
        public int Code { get; set; }

        public string Raw { get; set; }

        public string Error { get; set; }

        public T Result { get; set; }
    }
}
