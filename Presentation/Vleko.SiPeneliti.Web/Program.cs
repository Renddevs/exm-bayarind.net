using Microsoft.Extensions.Configuration;
using Vleko.Bayarind.Web.Helper;
using Vleko.Bayarind.Web.Models;

namespace Vleko.Bayarind.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string _defaultCorsPolicyName = "localhost";
            var builder = WebApplication.CreateBuilder(args);

            IWebHostEnvironment _environment = builder.Environment;
            string _environtmentName = "Development";
            if (builder.Environment.IsDevelopment())
                _environtmentName = "Development";
            else if (builder.Environment.IsStaging())
                _environtmentName = "Staging";
            else if (builder.Environment.IsProduction())
                _environtmentName = "Production";

            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                      .AddJsonFile("appsettings.json")
                                                      .AddJsonFile($"appsettings.{_environtmentName}.json", optional: true)
                                                      .AddEnvironmentVariables()
                                                      .Build();

            var config = configuration;

            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddAuthentication("Bayarind")
            .AddCookie("Bayarind", opt =>
            {
                opt.Cookie.Name = "Bayarind";
            });

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddTransient<IRestAPIHelper, RestAPIHelper>();
            builder.Services.AddSingleton<ITokenHelper, TokenHelper>();
            builder.Services.AddCors(
                options => options.AddPolicy(
                    _defaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(
                            config.GetValue<string>("AllowedHosts").Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray()
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                )
            );
            var menuConfig = configuration.GetSection("Menu").Get<List<MenuModel>>();
            builder.Services.AddSingleton<List<MenuModel>>(menuConfig);

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}