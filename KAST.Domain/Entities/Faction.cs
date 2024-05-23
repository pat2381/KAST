using KAST.Domain.Common;
using KAST.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Domain.Entities
{
    public class Faction : BaseEntity
    {
       

        [Display(Name = "Flagge")]
        public string? Flag { get; set; }

        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Display(Name = "Seite")]
        public GameSide UseSide { get; set; }

        public List<Squad>? Squads { get; set; }
    }
}
