using Finandina_Domain.Entities;
using Finandina_Domain.Interface.Region;
using Finandina_Persistence.Context;

namespace Finandina_Persistence.Repository.Region
{
    public class AuditoriaConsultaRegionRepository : IAuditoriaConsultaRegionRepository
    {
        private readonly ApplicationContext _context;

        public AuditoriaConsultaRegionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task RegistrarAsync(AuditoriaConsultaRegion auditoria, CancellationToken cancellationToken = default)
        {
            await _context.AuditoriaConsultaRegion.AddAsync(auditoria, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
