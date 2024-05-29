
using Microsoft.Extensions.Configuration;
using KAST.Application.Repositories;
using KAST.Infrastructure.Data.Repositories;
using KAST.Infrastructure.Interfaces;
using KAST.Infrastructure.Servcies;
using KAST.Infrastructure.Data;
using KAST.Infrastructure.Persistence;
using KAST.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using KAST.Infrastructure.Constants.Database;
using KAST.Infrastructure.Configurations;



namespace KAST.Infrastructure
{
    public static class DependenceInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Add Infratrucure servcies.
            services
                .AddDatabase(configuration)
                .AddServcies();
            

            return services;
        }


        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultString");

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                var databaseSettings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseDatabase(databaseSettings.DBProvider, databaseSettings.ConnectionString);
            });

                services.AddScoped<IDbContextFactory<ApplicationDbContext>, BlazorContextFactory<ApplicationDbContext>>();
                services.AddTransient<IApplicationDbContext>(provider =>
                provider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>().CreateDbContext());

            //services.AddScoped<ApplicationDbContextInitializer>();           
            return services;
        }

        private static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder builder, string dbProvider,
        string connectionString)
        {
            switch (dbProvider.ToLowerInvariant())
            {
                
                case DbProviderKeys.SqlServer:
                    return builder.UseSqlServer(connectionString,
                        e => e.MigrationsAssembly("KAST.Migrators.MSSQL"));

                case DbProviderKeys.SqLite:
                    return builder.UseSqlite(connectionString,
                        e => e.MigrationsAssembly("KAST.Migrators.SqLite"));

                default:
                    throw new InvalidOperationException($"DB Provider {dbProvider} is not supported.");
            }
        }


        public static IServiceCollection AddServcies(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryService, RepositoryService>();
            services.AddScoped<IKastService, KastService>();

            return services;
        }
    }
}
