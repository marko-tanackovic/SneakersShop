using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public class UpdateRoleDTO : UpdateEntityDTO
    {
        public int RoleId { get; set; }
    }
}
