using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakersShop.Application.UseCaseHandling;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.Application.UseCases.Queries.Search;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SneakersShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private IQueryHandler _queryHandler;

        public RolesController(IQueryHandler queryHandler)
        {
            this._queryHandler = queryHandler;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public IActionResult Get([FromQuery] KeywordSearch search,
                                 [FromServices] IGetRolesQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }
    }
}
