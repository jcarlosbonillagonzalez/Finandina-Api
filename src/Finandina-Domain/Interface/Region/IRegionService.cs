using Finandina_Domain.Dto.Region;
using Finandina_Domain.Packager;

namespace Finandina_Domain.Interface.Region
{
    public interface IRegionService
    {
        Task<BaseResponse<ICollection<RegionDto>>> GetAllRegionsAsync(CancellationToken cancellationToken = default);
        Task<BaseResponse<RegionDto>> GetRegionByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
