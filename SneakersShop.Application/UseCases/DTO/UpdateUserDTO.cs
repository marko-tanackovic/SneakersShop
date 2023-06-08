using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class UpdateUserDTO : UpdateEntityDTO
    {
        public string Image { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
    }
}
