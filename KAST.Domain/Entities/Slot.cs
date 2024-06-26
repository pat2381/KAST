﻿using KAST.Domain.Common;
using KAST.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAST.Domain.Entities
{
    public class Slot : BaseEntity
    {
        public Guid SlotId { get; set; }
        public int SlotNumber { get; set; }

        public string? Label { get; set; }

        public Guid FireteamID { get; set; }
        public Fireteam? Fireteam { get; set; }

        public Guid? MissionUserID { get; set; }
        public MissionUser? AssignedUser { get; set; }

        public long? Timestamp { get; set; }

        public Role? Role { get; set; }

        public bool IsValideted { get; set; }

        public void SetTimestamp()
        {
            Timestamp = DateTime.UtcNow.Ticks;
        }


    }
}
