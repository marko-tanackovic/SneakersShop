using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakersShop.Application.UseCaseHandling;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.Application.UseCases.Queries.Search;
using SneakersShop.DataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SneakersShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CitiesController : ControllerBase
    {
        private SneakersShopContext _context;
        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public CitiesController(SneakersShopContext context, IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            this._context = context;
            this._queryHandler = queryHandler;
            this._commandHandler = commandHandler;
        }

        // GET: api/<CitiesController>
        [HttpGet]
        public IActionResult Get([FromQuery] KeywordSearch search,
                                 [FromServices] IGetCitiesQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<CitiesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
                          [FromServices] IFindCityQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<CitiesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateCityDTO dto,
                         [FromServices] ICreateCityCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<CitiesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
                                 [FromBody] UpdateCityDTO dto,
                                 [FromServices] IUpdateCityCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<CitiesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
                           [FromServices] IDeleteCityCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
