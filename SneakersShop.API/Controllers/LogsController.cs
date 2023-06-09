using Microsoft.AspNetCore.Mvc;
using SneakersShop.Application.UseCaseHandling;
using SneakersShop.Application.UseCases.Queries;
using SneakersShop.Application.UseCases.Queries.Search;
using SneakersShop.DataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SneakersShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private SneakersShopContext _context;
        private IQueryHandler _queryHandler;

        public LogsController(SneakersShopContext context,
                              IQueryHandler queryHandler)
        {
            this._context = context;
            this._queryHandler = queryHandler;
        }

        // GET: api/<LogController>
        [HttpGet]
        public IActionResult Get([FromQuery] LogEntrySearch search,
                                 [FromServices] ISearchLogEntriesQuery query)
        {
            return Ok(_queryHandler.HandleQuery(query, search));
        }

        // GET api/<LogController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LogController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LogController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LogController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
