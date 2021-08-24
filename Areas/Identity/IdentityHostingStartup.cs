using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VNPT_Review.Areas.Identity.Data;

[assembly: HostingStartup(typeof(VNPT_Review.Areas.Identity.IdentityHostingStartup))]
namespace VNPT_Review.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {

        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityDbContext>(options =>
                {
                    bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
                    if(isDevelopment)
                    {
                        options.UseNpgsql(context.Configuration.GetConnectionString("PostgreSQL"));
                    }
                    else
                    {
                        var pgUser = Environment.GetEnvironmentVariable("USER");
                        var pgPassword = Environment.GetEnvironmentVariable("PASSWORD");
                        var pgHost = Environment.GetEnvironmentVariable("HOST");
                        var pgPort = Environment.GetEnvironmentVariable("PORT");
                        var pgDatabase = Environment.GetEnvironmentVariable("DATABASE");

                        var connStr = $"User Id={pgUser}; Password={pgPassword}; Host={pgHost}; Port={pgPort}; Database={pgDatabase}; sslmode=Require; Trust Server Certificate=true";
                        options.UseNpgsql(connStr);
                    }
                });

                // services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //     .AddEntityFrameworkStores<IdentityDbContext>();

                services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoleManager<RoleManager<IdentityRole>>()                         
                    .AddDefaultUI()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<IdentityDbContext>();
                
                services.ConfigureApplicationCookie(options =>
                {
                    options.AccessDeniedPath = "/accessdenied";
                    options.Cookie.Name = "VNPT_REVIEW";
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.LoginPath = "/login";
                    // ReturnUrlParameter requires 
                    //using Microsoft.AspNetCore.Authentication.Cookies;
                    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                    options.SlidingExpiration = true;
                });

            });
        }

    }
}