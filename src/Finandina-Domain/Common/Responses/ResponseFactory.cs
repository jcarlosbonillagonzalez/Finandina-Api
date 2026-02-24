using System.Net;
using Finandina_Domain.Dto;
using Finandina_Domain.Enums;
using Finandina_Domain.Packager;

namespace Finandina_Domain.Common.Responses
{
    /// <summary>
    /// Centralised helpers to build BaseResponse / PagedResponse with a uniform shape.
    /// </summary>
    public static class ResponseFactory
    {
        private static List<ErrorDTO> Single(ListErrorCode code, string? detail = null) =>
            new()
            {
                new ErrorDTO
                {
                    Code    = code,
                    Message = code.GetDescription(),
                    Detail  = detail
                }
            };

        public static BaseResponse<T> Ok<T>(T data, string msg = "Success") =>
            new(HttpStatusCode.OK, msg, data, null);

        public static PagedResponse<List<T>> Page<T>(
            List<T> data,
            int pageIndex,
            int pageSize,
            int totalCount,
            string msg = "Success",
            HttpStatusCode status = HttpStatusCode.OK)
        {
            var totalPages = pageSize == int.MaxValue
                           ? 1
                           : (int)Math.Ceiling((double)totalCount / pageSize);

            return new(status, msg, data, pageIndex, pageSize, totalPages, totalCount, null);
        }

        public static BaseResponse<T> Error<T>(
            System.Exception ex,
            ListErrorCode code = ListErrorCode.E020,
            string? customMsg = null) =>
            new(HttpStatusCode.InternalServerError,
                customMsg ?? code.GetDescription(),
                default,
                Single(code, ex.Message));

        public static BaseResponse<T> Fail<T>(
            ListErrorCode code,
            string? detail = null,
            HttpStatusCode status = HttpStatusCode.BadRequest) =>
            new(status, code.GetDescription(), default, Single(code, detail));

        public static PagedResponse<List<T>> FailPage<T>(
            ListErrorCode code,
            int pageIndex,
            int pageSize,
            string? detail = null,
            HttpStatusCode status = HttpStatusCode.InternalServerError) =>
            new(status,
                code.GetDescription(),
                new(),
                pageIndex,
                pageSize,
                0,
                0,
                Single(code, detail)
        );
    }
}
