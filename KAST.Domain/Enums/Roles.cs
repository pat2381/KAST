using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Domain.Enums
{
    public enum Role
    {
        [Display(Name = "Zugführer")]
        Zugfüherer,

        [Display(Name = "Stellv.Zugführer")]
        StellvZugführer,

        [Display(Name = "Gruppenführer")]
        Gruppenführer,

        [Display(Name = "Truppführer")]
        Truppführer,

        [Display(Name = "Schütze")]
        Schütze,

        [Display(Name = "LMG-Schützer")]
        LMGSchütze,

        [Display(Name = "Grenadier")]
        Grenadier,

        [Display(Name = "AT-Schützer")]
        ATSchützer,

        [Display(Name = "DMR-Schützer")]
        DMRSchütze,

        [Display(Name = "JTAC")]
        JTAC,

        [Display(Name = "Pionier")]
        Pionier,

        [Display(Name = "Pilot")]
        Pilot,

        [Display(Name = "Co-Pilot")]
        CoPilot,

        [Display(Name = "Leitender Arzt")]
        LeitenderArzt,

        [Display(Name = "Sanitäter")]
        Sanitäter,

        [Display(Name = "Leitender Logistik")]
        LeiternderLogistik,

        [Display(Name = "Logistiker")]
        Logistiker



    }
}
