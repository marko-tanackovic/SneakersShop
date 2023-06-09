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
    public class SizeCategoriesController : ControllerBase
    {
        private SneakersShopContext _context;
        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public SizeCategoriesController(SneakersShopContext context, IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            this._context = context;
            this._queryHandler = queryHandler;
            this._commandHandler = commandHandler;
        }

        // GET: api/<SizeCategoriesController>
        [HttpGet]
        public IActionResult Get([FromQuery] KeywordSearch search,
                                 [FromServices] IGetSizeCategoriesQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<SizeCategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
                                 [FromServices] IFindSizeCategoryQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<SizeCategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateSizeCategoryBrandColorDTO dto,
                         [FromServices] ICreateSizeCategoryCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<SizeCategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
                                 [FromBody] UpdateSizeCategoryColorBrandDTO dto,
                                 [FromServices] IUpdateSizeCategoryCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<SizeCategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
                           [FromServices] IDeleteSizeCategoryCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
