using Finandina_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finandina_Persistence.Context.Builders
{
    public class AuditoriaConsultaRegionConfiguration : IEntityTypeConfiguration<AuditoriaConsultaRegion>
    {
        public void Configure(EntityTypeBuilder<AuditoriaConsultaRegion> builder)
        {
            builder.ToTable("AuditoriaConsultaRegion");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.RegionId)
                   .IsRequired();

            builder.Property(x => x.RegionNombre)
                   .HasMaxLength(200);

            builder.Property(x => x.RegionDescripcion)
                   .HasMaxLength(1000);

            builder.Property(x => x.FechaConsulta)
                   .IsRequired();

            builder.Property(x => x.HoraConsumoApiExterna)
                   .IsRequired();

            builder.Property(x => x.TiempoRespuestaMs)
                   .IsRequired();
        }
    }
}
