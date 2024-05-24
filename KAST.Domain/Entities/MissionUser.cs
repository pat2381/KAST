using KAST.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Domain.Entities
{
    public class MissionUser : BaseEntity
    {
        public Guid MissionUserId { get; set; }

        [Display(Name = "Squad")]
        public Guid SquadID { get; set; }

        [Display(Name = "Squad")]
        public Squad? Side { get; set; }

        public List<Slot>? Slots { get; set; }

        [Display(Name = "Operation")]
        public Guid MissionID { get; set; }

        [Display(Name = "Operation")]
        public Mission? Mission { get; set; }

        [Display(Name = "Eingetragen")]
        public Guid UserID { get; set; }

        [Display(Name = "Eingetragen")]
        public User? User { get; set; }
    }
}
