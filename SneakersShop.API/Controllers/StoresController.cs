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
    public class StoresController : ControllerBase
    {
        private SneakersShopContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;

        public StoresController(SneakersShopContext context, ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            this._context = context;
            this._commandHandler = commandHandler;
            this._queryHandler = queryHandler;
        }

        // GET: api/<StoresController>
        [HttpGet]
        public IActionResult Get([FromQuery] KeywordSearch search,
                                 [FromServices] IGetStoresQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<StoresController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
                                 [FromServices] IFindStoreQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<StoresController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateStoreDTO dto,
                         [FromServices] ICreateStoreCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<StoresController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
                        [FromBody] UpdateStoreDTO dto,
                        [FromServices] IUpdateStoreCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<StoresController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
                           [FromServices] IDeleteStoreCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
