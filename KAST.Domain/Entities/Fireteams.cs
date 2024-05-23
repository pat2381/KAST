using KAST.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Domain.Entities
{
    public class Fireteam : BaseEntity
    {

        
        public int Index { get; set; }
        public string? Name { get; set; }

        public bool RestrictTeamCompoition { get; set; }
        public bool InviteOnly { get; set; }

        public int SquadId { get; set; }
        public Squad? Squad { get; set; }

        public List<Slot>? Slots { get; set; }

        public int SlotsCount { get; set; }


    }
}
