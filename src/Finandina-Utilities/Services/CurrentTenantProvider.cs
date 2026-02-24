using Finandina_Domain.Interface;

namespace Finandina_Utilities.Services
{
    public class CurrentTenantProvider : ICurrentTenantProvider
    {
        public int? TenantId => 1;
    }
}
