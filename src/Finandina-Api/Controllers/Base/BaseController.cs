using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Finandina_Api.Controllers.Base
{
    [ApiController]
    [Route("/api/[controller]")]
    public abstract class BaseController : ControllerBase { }
}
