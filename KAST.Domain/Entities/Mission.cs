using KAST.Domain.Common;
using KAST.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Domain.Entities
{
    public class Mission : BaseEntity
    {
        public Guid MissionId { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public DateTimeOffset MissionDate { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string? Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? Worldanme { get; set; }
        public MissionTemplate Template { get; set; }
        public string? RuleLink { get; set; }
        public MissionState State { get; set; }
        public string? MissionBriefingLink { get; set; }


        //Database Mapping
        public List<Squad> squads { get; set; } = new List<Squad>();
        public List<MissionUser> Users { get; set; } = new List<MissionUser>();
    }
}
