using BuiderAux.IdentityServer.Configuration;
using BuiderAux.IdentityServer.ModelDb;
using BuiderAux.IdentityServer.ModelDb.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

internal class Program
{
    private static void Main(string[] args)
    {
        //CreateHostBuilder(args).Build().Run();
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<ApplicationDbContext>();

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddDefaultTokenProviders();

        builder.Services.AddIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
            options.EmitStaticAudienceClaim = true;
        }).AddInMemoryIdentityResources(
            IdentityConfiguration.IdentityResources)
          .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
          .AddInMemoryClients(IdentityConfiguration.Clients)
          .AddAspNetIdentity<ApplicationUser>();

        builder.Services.Sig



        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseIdentityServer();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    //public static IHostBuilder CreateHostBuilder(string[] args) =>
    //        Host.CreateDefaultBuilder(args)
    //            .ConfigureWebHostDefaults(webBuilder =>
    //            {
    //                webBuilder.UseStartup<Program>();
    //                webBuilder.UseUrls("http://localhost:5082"); // Defina a porta aqui
    //            });
}