using KAST.Application;
using KAST.Domain.Identity;
using KAST.Infrastructure;
using KAST.Infrastructure.Data;
using KAST.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KAST.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddApplication()
                .AddInfrastructure(builder.Configuration)
                .AddServerUI();

            var app = builder.Build();
            app.ConfigureServer(builder.Configuration);


            //if (app.Environment.IsDevelopment())
            //    // Initialise and seed database
            //    using (var scope = app.Services.CreateScope())
            //    {
            //        var initializer = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitializer>();
            //        initializer.InitialiseAsync();
            //        initializer.SeedAsync();
            //    }

            app.Run();
        }
    }
}
