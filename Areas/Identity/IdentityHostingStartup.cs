using System;
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
                services.AddDbContext<VNPT_ReviewIdentityDbContext>(options =>
                    options.UseOracle(
                        context.Configuration.GetConnectionString("Oracle")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<VNPT_ReviewIdentityDbContext>();
            });
        }
    }
}