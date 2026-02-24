namespace Finandina_Domain.Interface
{
    public interface ICurrentTenantProvider
    {
        int? TenantId { get; }
    }
}
