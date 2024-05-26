using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Domain.Entities
{
    public class UserSession
    {
        public string? Username { get; set; }
        public string? Role { get; set; }

    }
}
