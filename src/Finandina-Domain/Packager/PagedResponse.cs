using System.Net;
using Finandina_Domain.Dto;

namespace Finandina_Domain.Packager
{
    public class PagedResponse<T> : BaseResponse<PaginatedData<T>>
    {
        public PagedResponse(
            HttpStatusCode code,
            string message,
            T data,
            int pageIndex,
            int pageSize,
            int totalPages,
            int totalCount,
            List<ErrorDTO>? errors = null
        ) : base(
            code,
            message,
            new PaginatedData<T>
            {
                TotalCount = totalCount,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPages = totalPages,
                Data = data
            },
            errors
        )
        {
        }

        public IAsyncEnumerable<object>? Total { get; set; }
    }

    public class PaginatedData<T>
    {
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public T Data { get; set; }
    }
}
