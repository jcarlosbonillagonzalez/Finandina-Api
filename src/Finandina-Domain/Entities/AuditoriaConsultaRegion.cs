using Finandina_Domain.Common;

namespace Finandina_Domain.Entities
{
    public class AuditoriaConsultaRegion : AuditableEntity
    {
        public int Id { get; set; }

        // Datos de la región consultada
        public int RegionId { get; set; }
        public string? RegionNombre { get; set; }
        public string? RegionDescripcion { get; set; }

        // Auditoría del consumo
        public DateTime FechaConsulta { get; set; }
        public DateTime HoraConsumoApiExterna { get; set; }
        public long TiempoRespuestaMs { get; set; }
    }
}
