using KAST.Service.Layout;
using KAST.Service.UserPreferences;

namespace KAST
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMudTheme(this IServiceCollection services)
        {
            services.AddScoped<LayoutService>();
            services.AddScoped<IUserPreferencesService, UserPreferencesService>();

            return services;
        }
    }
}
