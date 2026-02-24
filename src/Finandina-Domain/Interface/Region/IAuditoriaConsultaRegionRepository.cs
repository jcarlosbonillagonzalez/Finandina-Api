using Finandina_Domain.Entities;

namespace Finandina_Domain.Interface.Region
{
    public interface IAuditoriaConsultaRegionRepository
    {
        Task RegistrarAsync(AuditoriaConsultaRegion auditoria, CancellationToken cancellationToken = default);
    }
}
