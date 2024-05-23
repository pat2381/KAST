using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Domain.Enums
{
    public enum SquadsPolicy
    {
        [Display(Name = "Keine Einschränkungen")]
        Unrestricted,

        [Display(Name = "Definition von Gruppen durch Organisatoren")]
        SquadsRestricted,

        [Display(Name = "Definition von Gruppen und deren Zusammensetzung durch die Organisatoren")]
        SquadsAndSlotsRestricted
    }
}
