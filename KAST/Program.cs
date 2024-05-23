
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using KAST.Infratructure.DependencyInjection;

using MudBlazor.Services;
using KAST.Application.Services;
using KAST.Infratructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

builder.Services.AddInfratruture(builder.Configuration);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
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