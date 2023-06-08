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
    public class ReviewsController : ControllerBase
    {
        private SneakersShopContext _context;
        private IQueryHandler _queryHandler;
        private ICommandHandler _commandHandler;

        public ReviewsController(SneakersShopContext context, 
                                IQueryHandler queryHandler, 
                                ICommandHandler commandHandler)
        {
            this._context = context;
            this._queryHandler = queryHandler;
            this._commandHandler = commandHandler;
        }

        // GET: api/<ReviewsController>
        [HttpGet]
        public IActionResult Get([FromQuery] ReviewSearch search,
                                 [FromServices] IGetReviewsQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<ReviewsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
                          [FromServices] IFindReviewQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<ReviewsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateReviewDTO dto,
                         [FromServices] ICreateReviewCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<ReviewsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
                       [FromBody] UpdateReviewDTO dto,
                       [FromServices] IUpdateReviewCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<ReviewsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
                                    [FromServices] IDeleteReviewCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
