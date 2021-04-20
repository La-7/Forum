using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Forum.Web.Areas.Identity.IdentityHostingStartup))]
namespace Forum.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}