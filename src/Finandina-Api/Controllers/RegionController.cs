using Finandina_Api.Controllers.Base;
using Finandina_Domain.Dto.Region;
using Finandina_Domain.Interface.Region;
using Finandina_Domain.Packager;
using Microsoft.AspNetCore.Mvc;

namespace Finandina_Api.Controllers
{
    [Route("/api/v1/Region")]
    public class RegionController : BaseController
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseResponse<ICollection<RegionDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<ICollection<RegionDto>>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await _regionService.GetAllRegionsAsync(cancellationToken);
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(BaseResponse<RegionDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<RegionDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var response = await _regionService.GetRegionByIdAsync(id, cancellationToken);
            return StatusCode(response.Code, response);
        }
    }
}
