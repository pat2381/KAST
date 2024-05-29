using KAST.Application.Common.Interfaces;
using KAST.Domain.Common.Entities;
using KAST.Domain.Identity;
using KAST.Infrastructure.Persistence.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection;


namespace KAST.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,ApplicationRoleClaim, ApplicationUserToken>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
        {}

        public DbSet<Logger> Loggers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<MissionUser> MissionUsers { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Fireteam> Fireteams { get; set; }
        public DbSet<Mod> Mods { get; set; }
        public DbSet<Server> Servers { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.ApplyGlobalFilters<ISoftDelete>(s => s.Deleted == null);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<string>().HaveMaxLength(450);
        }
    }
}
