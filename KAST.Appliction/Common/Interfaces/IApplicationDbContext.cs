// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using KAST.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace KAST.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Logger> Loggers { get; set; }

    DbSet<Author> Authors { get; set; }
    DbSet<Mission> Missions { get; set; }
    DbSet<MissionUser> MissionUsers { get; set; }
    DbSet<Faction> Factions { get; set; }
    DbSet<Squad> Squads { get; set; }
    DbSet<Slot> Slots { get; set; }
     DbSet<Fireteam> Fireteams { get; set; }
    DbSet<Mod> Mods { get; set; }
    DbSet<Server> Servers { get; set; }

    DbSet<Tenant> Tenants { get; set; }



    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}