using KAST.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Domain.Entities
{
    public class User : BaseEntity
    {
        public Guid UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? EMail { get; set; }
        public string? SteamName { get; set; }
        public UInt64 SteamID { get; set; }
        public string? ImagePath { get; set; }
        public int MissionCount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsActive { get; set; }

    }
}
