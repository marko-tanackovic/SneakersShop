using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SneakersShop.API.DTO
{
    public class AppSettings
    {
        public JwtSettings Jwt { get; set; }
        public string BugSnagKey { get; set; }
    }

    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public int DurationSeconds { get; set; }
        public string Issuer { get; set; }
    }
}
