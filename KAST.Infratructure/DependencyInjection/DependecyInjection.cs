using KAST.Infratructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;


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
            
          
            return services;
        }
    }
}
