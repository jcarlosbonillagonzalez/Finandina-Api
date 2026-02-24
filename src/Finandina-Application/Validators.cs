using System.Net;
using Finandina_Domain.Packager;
using FluentValidation;

namespace Finandina_Application
{
    public class Validators<T>
    {
        private readonly IValidator<T> _validator;

        public Validators(IValidator<T> validator)
        {
            _validator = validator;
        }

        public async Task<BaseResponse<TResponse>> ValidateAsync<TResponse>(
            T request,
            Func<T, Task<BaseResponse<TResponse>>> next,
            HttpStatusCode code = HttpStatusCode.BadRequest)
        {
            var result = await _validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                var errors = result.ToErrors();
                return new BaseResponse<TResponse>(
                    code: code,
                    errors: errors
                );
            }

            return await next(request);
        }
    }
}
