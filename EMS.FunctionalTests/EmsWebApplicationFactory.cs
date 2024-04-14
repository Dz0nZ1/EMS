using EMS.Application.Common.interfaces;
using EMS.Infrastructure.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;

namespace EMS.FunctionalTests;

public class EmsWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    // Creating new Mock Services
    // public Mock<ICategoryService> MockCategoryService { get; } = new();
    // public Mock<ILocationService> MockLocationService { get; } = new();
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
                
                //Overriding the real services with mock 
                // services.AddScoped(_ => MockCategoryService.Object);
                // services.AddScoped(_ => MockLocationService.Object);
            });
    }
}