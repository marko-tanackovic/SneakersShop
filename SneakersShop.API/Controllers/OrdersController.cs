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
    public class OrdersController : ControllerBase
    {
        private SneakersShopContext _context;
        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public OrdersController(SneakersShopContext context, IQueryHandler queryHandler, ICommandHandler commandHandler)
        {
            this._context = context;
            this._queryHandler = queryHandler;
            this._commandHandler = commandHandler;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch search,
                                       [FromServices] IGetOrdersQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query,search));
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
                          [FromServices] IFindOrderQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderDTO dto,
                         [FromServices] ICreateOrderCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
                                [FromBody] UpdateOrderDTO dto,
                                [FromServices] IUpdateOrderCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
                           [FromServices] IDeleteOrderCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
