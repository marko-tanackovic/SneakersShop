using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.Uploads
{
    public class UploadFileExtensions
    {
        public IEnumerable<string> Extensions => new List<string>
        {
            "jpg", "png", "jpeg"
        };
    }
}
