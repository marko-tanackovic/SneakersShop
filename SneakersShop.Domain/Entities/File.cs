using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Domain.Entities
{
    public class File : Entity
    {
        public string Path { get; set; }
        public int Size { get; set; }
    }
}
