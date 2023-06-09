using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SneakersShop.API.DTO;
using SneakersShop.API.Extensions;
using SneakersShop.Application.UseCaseHandling;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.Application.UseCases.DTO;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.Application.UseCases.Queries.Search;
using SneakersShop.DataAccess;
using SneakersShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SneakersShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private SneakersShopContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;

        public ProductsController(SneakersShopContext context, ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            this._context = context;
            this._commandHandler = commandHandler;
            this._queryHandler = queryHandler;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] ProductSearch search,
                                 [FromServices] ISearchProductsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, 
                                 [FromServices] IFindProductQuery query) 
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductDTO dto, [FromServices] ICreateProductCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
                                 [FromBody] UpdateProductDTO dto, 
                                 [FromServices] IUpdateProductCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
                                    [FromServices] IDeleteProductCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
