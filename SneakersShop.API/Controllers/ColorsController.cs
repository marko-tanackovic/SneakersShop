using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakersShop.Application.UseCaseHandling;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.Application.UseCases.Queries.Search;
using SneakersShop.DataAccess;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SneakersShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ColorsController : ControllerBase
    {
        private SneakersShopContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;

        public ColorsController(SneakersShopContext context, ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            this._context = context;
            this._commandHandler = commandHandler;
            this._queryHandler = queryHandler;
        }

        // GET: api/<ColorsController>
        [HttpGet]
        public IActionResult Get([FromQuery] KeywordSearch search,
                                 [FromServices] IGetColorsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<ColorsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
                                 [FromServices] IFindColorQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<ColorsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateSizeCategoryBrandColorDTO dto,
                         [FromServices] ICreateColorCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<ColorsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
                        [FromBody] UpdateSizeCategoryColorBrandDTO dto,
                        [FromServices] IUpdateColorCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<ColorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
                           [FromServices] IDeleteColorCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
