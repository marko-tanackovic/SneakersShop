using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SneakersShop.Application.UseCases.DTO
{
    public abstract class UpdateEntityDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
