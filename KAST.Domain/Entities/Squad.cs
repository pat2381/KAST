using KAST.Domain.Common;
using KAST.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Domain.Entities
{
    public class Squad : BaseEntity
    {
        //ID in BaseEntity

        public int MissionID { get; set; }
        public Mission? Mission { get; set; }
        public string? Name { get; set; }
        public List<MissionUser>? MissionUsers { get; set; }
        public List<Fireteam>? Fireteams { get; set; }
        public int Number { get; set; }
        public int MaxUsuerCount { get; set; }
        public SquadsPolicy SquadPolicy { get; set; }
        public GameSide GameSide { get; set; }
        public int FactionID { get; set; }
        public Faction? Faction { get; set; }

    }
}
