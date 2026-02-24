using Finandina_Domain.Dto;
using Finandina_Domain.Enums;
using FluentValidation.Results;

namespace Finandina_Application
{
    public static class ValidationExtension
    {
        public static List<ErrorDTO> ToErrors(this ValidationResult result)
        {
            return result.Errors
                         .Select(v => new ErrorDTO
                         {
                             Code = ListErrorCode.E006,
                             Message = v.ErrorMessage,
                             Detail = v.PropertyName
                         })
                         .ToList();
        }
    }
}
