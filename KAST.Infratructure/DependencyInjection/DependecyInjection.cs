using KAST.Infratructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using KAST.Application.Repositories;
using KAST.Infratructure.Data.Repositories;
using KAST.Infratructure.Interfaces;
using KAST.Infratructure.Servcies;



namespace KAST.Infratructure.DependencyInjection
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
