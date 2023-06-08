using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SneakersShop.Application.UseCaseHandling;
using SneakersShop.Application.UseCases.Commands;
using SneakersShop.Application.UseCases.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SneakersShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductSizeController : ControllerBase
    {
        private ICommandHandler _commandHandler;

        public ProductSizeController(ICommandHandler commandHandler)
        {
            this._commandHandler = commandHandler;
        }

        // POST api/<ProductSizeController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductSizeDTO dto,
                                  [FromServices] ICreateProductSizeCommand command)
        {
            _commandHandler.HandleCommand(command, dto);
            return StatusCode(201);
        }
    }
}
