using System;
using Dejtingsida.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Dejtingsida.Areas.Identity.IdentityHostingStartup))]
namespace Dejtingsida.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DejtingsidaContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DejtingsidaContextConnection")));

            });
        }
    }
}