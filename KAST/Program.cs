
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using KAST.Infratructure.DependencyInjection;

using MudBlazor.Services;
using KAST.Infratructure.Services;
using KAST.Infratructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Authorization;
using KAST.Infratructure.Servcies;
using KAST.Authentication;

var builder = WebApplication.CreateBuilder(args);

//StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

//builder.Services.AddAuthentication(option =>
//{
//    option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//})
//.AddCookie(options => 
//{
//    options.LoginPath = "/Auth/Login";
//    options.LogoutPath = "/Auth/Logout";
//})
//.AddDiscord(options =>
//{
//    options.ClientId = builder.Configuration.GetValue<string>("Discord:ClientID");
//    options.ClientSecret = builder.Configuration.GetValue<string>("Discord:ClientSecret");
//    options.UserInformationEndpoint = "https://discord.com/api/user/@me";

//    options.ClaimActions.MapCustomJson("urn:discord:url", user => string.Format(CultureInfo.InvariantCulture, "https://cdn.discordapp.com/avatars/{0}/{1}.{2}"));
//    options.CallbackPath = new PathString("/auth/oauthCallback");
//    options.AccessDeniedPath = new PathString("/Auth/DiscordAuthFaild");
//});

builder.Services.AddLocalization();

builder.Services.AddAuthenticationCore();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddInfratruture(builder.Configuration);
builder.Services.AddSingleton<UserAccountService>();

builder.Services.AddSingleton<WeatherForecastService>(); 
builder.Services.AddSingleton<ServerInfoService>();
builder.Services.AddMudServices();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


using (IServiceScope serviceScope = app.Services.CreateScope())
{
    //Apply last Entity Framework migration
    try
    {
        ApplicationDbContext? context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

        if (app.Environment.IsDevelopment())
        {
            context?.Database.EnsureDeleted();
            context?.Database.EnsureCreated();
        }
        else
            context?.Database.Migrate();
    }
    catch (Exception) { throw; }
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();