using EMS.Infrastructure.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EMS.FunctionalTests;

public class EmsWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>

            {

                services.RemoveAll<DbContext>();

                var dbName = Guid.NewGuid().ToString();

                services.AddDbContext<EmsDbContext>(options =>
                {
                    options.UseInMemoryDatabase(dbName);
                });
            });
    }
}