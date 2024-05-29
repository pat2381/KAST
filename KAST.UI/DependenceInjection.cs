using KAST.Domain.Identity;
using KAST.Infrastructure.Constants.Localization;
using KAST.Infrastructure.Data;
using KAST.UI.Components;
using KAST.UI.Middlewares;
using KAST.UI.Services;
using KAST.UI.Services.Layout;
using KAST.UI.Services.Navigation;
using KAST.UI.Services.UserPreferences;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using System;
using System.Linq;

namespace KAST.UI
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddServerUI(this IServiceCollection services)
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


            services.AddRazorComponents()
               .AddInteractiveServerComponents();


            services.AddCascadingAuthenticationState();
            services.AddScoped<IdentityUserAccessor>();
            services.AddScoped<IdentityRedirectManager>();
            services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
                .AddIdentityCookies();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();


            return services;
        }


        public static WebApplication ConfigureServer(this WebApplication app, IConfiguration configuration)
        {

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAntiforgery();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();

            return app;
        }
    }
}
