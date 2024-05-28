
using Microsoft.Extensions.Configuration;
using KAST.Application.Repositories;
using KAST.Infrastructure.Data.Repositories;
using KAST.Infrastructure.Interfaces;
using KAST.Infrastructure.Servcies;
using KAST.Infrastructure.Data;



namespace KAST.Infrastructure.DependencyInjection
{
    public static class DependecyInjection
    {

        public static IServiceCollection AddInfratruture(this IServiceCollection services, IConfiguration configuration)
        {
            //Add Infratrucure servcies.

            var connectionString = configuration.GetConnectionString("DefaultString");

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlite(connectionString);

            });


            services.AddScoped<IRepositoryService, RepositoryService>();
            services.AddScoped<IKastService, KastService>();

            return services;
        }
    }
}
