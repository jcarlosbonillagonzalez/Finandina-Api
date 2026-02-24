using System.Diagnostics;
using Finandina_Domain.Common.Responses;
using Finandina_Domain.Dto.Region;
using Finandina_Domain.Entities;
using Finandina_Domain.Interface.Region;
using Finandina_Domain.Packager;
using ColombiaApiClient = Finandina_External.ColombiaApi.ColombiaApi;

namespace Finandina_Application.Feature.Region
{
    public class RegionService : IRegionService
    {
        private readonly ColombiaApiClient _colombiaApi;
        private readonly IAuditoriaConsultaRegionRepository _auditoriaRepo;

        public RegionService(
            ColombiaApiClient colombiaApi,
            IAuditoriaConsultaRegionRepository auditoriaRepo)
        {
            _colombiaApi = colombiaApi;
            _auditoriaRepo = auditoriaRepo;
        }

        public async Task<BaseResponse<ICollection<RegionDto>>> GetAllRegionsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var regions = await _colombiaApi.RegionAllAsync(null, null, cancellationToken);

                var result = regions
                    .Select(r => new RegionDto
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Description = r.Description
                    })
                    .ToList();

                return ResponseFactory.Ok<ICollection<RegionDto>>(result);
            }
            catch (System.Exception ex)
            {
                return ResponseFactory.Error<ICollection<RegionDto>>(ex);
            }
        }

        public async Task<BaseResponse<RegionDto>> GetRegionByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var stopwatch = Stopwatch.StartNew();
            var horaConsumo = DateTime.UtcNow;

            try
            {
                var region = await _colombiaApi.RegionAsync(id, cancellationToken);
                stopwatch.Stop();

                var result = new RegionDto
                {
                    Id = region.Id,
                    Name = region.Name,
                    Description = region.Description
                };

                // Registrar auditoría en base de datos
                var auditoria = new AuditoriaConsultaRegion
                {
                    RegionId             = region.Id,
                    RegionNombre         = region.Name,
                    RegionDescripcion    = region.Description,
                    FechaConsulta        = DateTime.UtcNow,
                    HoraConsumoApiExterna = horaConsumo,
                    TiempoRespuestaMs    = stopwatch.ElapsedMilliseconds
                };

                await _auditoriaRepo.RegistrarAsync(auditoria, cancellationToken);

                return ResponseFactory.Ok(result);
            }
            catch (System.Exception ex)
            {
                stopwatch.Stop();
                return ResponseFactory.Error<RegionDto>(ex);
            }
        }
    }
}
