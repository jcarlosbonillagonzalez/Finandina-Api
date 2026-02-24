namespace Finandina_Domain.Interface
{
    public interface IDateTimeProvider
    {
        DateTime NowUtc { get; }
    }
}
