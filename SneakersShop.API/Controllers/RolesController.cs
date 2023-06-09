using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakersShop.Application.UseCaseHandling;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.Application.UseCases.DTO;
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
        private ICommandHandler _commandHandler;

        public RolesController(IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            this._queryHandler = queryHandler;
            this._commandHandler = commandHandler;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public IActionResult Get([FromQuery] KeywordSearch search,
                                 [FromServices] IGetRolesQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,
                                 [FromBody] UpdateRoleDTO dto,
                                 [FromServices] IUpdateRoleCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
        }
    }
}
