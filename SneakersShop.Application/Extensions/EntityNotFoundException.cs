using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.Extensions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, string entityType)
            : base($"Entity of type {entityType} with an id {id} is not found.")
        {

        }
    }
}
