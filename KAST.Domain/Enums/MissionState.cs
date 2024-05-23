using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Domain.Enums
{
    public enum MissionState
    {
        [Display(Name = "Anmeldung geöffnet")]
        Open = 0,

        [Display(Name = "Vorbereitung der Mission, Anmeldung geschlossen")]
        ClosedWarmup = 1,

        [Display(Name = "Mission in Vorbereitung, Anmeldung geschlossen")]
        ClosedCheckup = 2,

        [Display(Name = "Operation läuft")]
        InProgress = 3,

        [Display(Name = "Operation abgeschlossen")]
        Over = 4
    }
}
