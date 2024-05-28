using KAST.Infrastructure.Constants.Localization;
using KAST.UI.Middlewares;
using KAST.UI.Services.Layout;
using KAST.UI.Services.Navigation;
using KAST.UI.Services.UserPreferences;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System.Linq;

namespace KAST.UI
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddMudExtension(this IServiceCollection services)
        {
            services.AddScoped<LayoutService>();
            services.AddScoped<IUserPreferencesService, UserPreferencesService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddMudBlazorDialog()
               .AddMudServices(mudServicesConfiguration =>
               {
                   mudServicesConfiguration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                   mudServicesConfiguration.SnackbarConfiguration.PreventDuplicates = false;
                   mudServicesConfiguration.SnackbarConfiguration.NewestOnTop = true;
                   mudServicesConfiguration.SnackbarConfiguration.ShowCloseIcon = true;
                   mudServicesConfiguration.SnackbarConfiguration.VisibleStateDuration = 4000;
                   mudServicesConfiguration.SnackbarConfiguration.HideTransitionDuration = 500;
                   mudServicesConfiguration.SnackbarConfiguration.ShowTransitionDuration = 500;
                   mudServicesConfiguration.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
               });

            services.AddScoped<LocalizationCookiesMiddleware>()
           .Configure<RequestLocalizationOptions>(options =>
           {
               options.AddSupportedUICultures(LocalizationConstants.SupportedLanguages.Select(x => x.Code).ToArray());
               options.AddSupportedCultures(LocalizationConstants.SupportedLanguages.Select(x => x.Code).ToArray());
               options.FallBackToParentUICultures = true;
           })
           .AddLocalization(options => options.ResourcesPath = LocalizationConstants.ResourcesPath);

            return services;
        }

    }
}
