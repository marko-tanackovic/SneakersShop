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
    public class UsersController : ControllerBase
    {
        private SneakersShopContext _context;
        private ICommandHandler _commandHandler;
        private IQueryHandler _queryHandler;

        public UsersController(SneakersShopContext context, ICommandHandler commandHandler, IQueryHandler queryHandler)
        {
            this._context = context;
            this._commandHandler = commandHandler;
            this._queryHandler = queryHandler;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search,
                                 [FromServices] IGetUsersQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,
                                 [FromServices] IFindUserQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, id));
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDTO dto,
                         [FromServices] ICreateUserCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, 
                        [FromBody] UpdateUserDTO dto,
                        [FromServices] IUpdateUserCommand command)
        {
            dto.Id = id;
            _commandHandler.HandleCommand(command, dto);
            return NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
                                    [FromServices] IDeleteUserCommand command)
        {
            _commandHandler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
