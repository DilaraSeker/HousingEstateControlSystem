
namespace HousingEstateControlSystem.Common
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        public int StatusCode { get; set; }
        private ResponseDto() { }

        public ResponseDto(T data)
        {
            Data = data;
            Errors = new List<string>();
            StatusCode = 200;
        }

        public ResponseDto(List<string> errors)
        {
            Data = default(T);
            Errors = errors;
            StatusCode = 400;
        }

        public static ResponseDto<T> Success(T data)
        {
            return new ResponseDto<T>(data);
        }

        public static ResponseDto<T> Fail(List<string> errors)
        {
            return new ResponseDto<T>(errors);
        }

        public static ResponseDto<T> Fail(string error)
        {
            return new ResponseDto<T>(new List<string> { error });
        }
    }

}
