using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Domain.Enums
{
    public enum MissionTemplate
    {
        [Display(Name = "Kooperative Mission einer Seite/einer Armee (PVE)")]
        SingleSideCooperative,

        [Display(Name = "Wettbewerbsmission in zwei Runden, mit zwei Seiten (PVP)")]
        TwoRoundsTwoSidesCompetitive,

        [Display(Name = "Wettbewerbsmission in zwei Runden mit drei Lagern (PVP)")]
        TwoRoundsThreeSidesCompetitive
    }
}
