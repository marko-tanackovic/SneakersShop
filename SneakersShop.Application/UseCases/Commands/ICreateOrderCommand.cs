using SneakersShop.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.Commands
{
    public interface ICreateOrderCommand : ICommand<CreateOrderDTO>
    {
    }
}
