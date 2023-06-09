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
    public class SizesController : ControllerBase
    {
        private SneakersShopContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;

        public SizesController(SneakersShopContext context, ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            this._context = context;
            this._commandHandler = commandHandler;
            this._queryHandler = queryHandler;
        }

        // GET: api/<SizesController>
        [HttpGet]
        public IActionResult Get([FromBody] SizeSearch search,
                                 [FromServices] IGetSizesQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<SizesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
                          [FromServices] IFindSizeQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<SizesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateSizeDTO dto,
                         [FromServices] ICreateSizeCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<SizesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
                                 [FromBody] UpdateSizeDTO dto,
                                 [FromServices] IUpdateSizeCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<SizesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
                                    [FromServices] IDeleteSizeCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
