using Finandina_Domain.Common;
using Finandina_Domain.Entities;
using Finandina_Domain.Interface;
using Finandina_Persistence.Context.Builders;
using Microsoft.EntityFrameworkCore;

namespace Finandina_Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        private readonly IDateTimeProvider? _dateTimeProvider;
        private readonly ICurrentUser? _currentUser;
        private readonly ICurrentTenantProvider? _tenantProvider;

        // Constructor mínimo para EF tools (migrations)
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        // Constructor completo con servicios de auditoría
        public ApplicationContext(
            DbContextOptions<ApplicationContext> options,
            IDateTimeProvider dateTimeProvider,
            ICurrentUser currentUser,
            ICurrentTenantProvider tenantProvider
        ) : base(options)
        {
            _dateTimeProvider = dateTimeProvider;
            _currentUser = currentUser;
            _tenantProvider = tenantProvider;
        }

        public DbSet<AuditoriaConsultaRegion> AuditoriaConsultaRegion => Set<AuditoriaConsultaRegion>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AuditoriaConsultaRegionConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
