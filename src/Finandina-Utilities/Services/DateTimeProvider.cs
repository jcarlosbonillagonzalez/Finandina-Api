using Finandina_Domain.Interface;

namespace Finandina_Utilities.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
