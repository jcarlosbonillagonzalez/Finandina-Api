using System.Net;
using Finandina_Domain.Dto;

namespace Finandina_Domain.Packager
{
    public class BaseResponse<T>
    {
        public BaseResponse(
            HttpStatusCode code = HttpStatusCode.OK,
            string message = "",
            T data = default,
            List<ErrorDTO>? errors = null)
        {
            Code = (int)code;
            Message = message;
            Data = data;
            Errors = errors;
        }

        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<ErrorDTO>? Errors { get; set; }
    }
}
