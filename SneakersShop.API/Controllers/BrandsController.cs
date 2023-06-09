using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SneakersShop.API.Extensions;
using SneakersShop.Application.UseCaseHandling;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.Application.UseCases.Queries.Search;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SneakersShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandsController : ControllerBase
    {
        private SneakersShopContext _context;
        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public BrandsController(SneakersShopContext context, IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            this._context = context;
            this._queryHandler = queryHandler;
            this._commandHandler = commandHandler;
        }

        // GET: api/<BrandsController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] KeywordSearch search,
                                 [FromServices] IGetBrandsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
                                 [FromServices] IFindBrandQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<BrandsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateSizeCategoryBrandColorDTO dto, [FromServices] ICreateBrandCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
                                [FromBody] UpdateSizeCategoryColorBrandDTO dto, 
                                [FromServices] IUpdateBrandCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
                                    [FromServices] IDeleteBrandCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
