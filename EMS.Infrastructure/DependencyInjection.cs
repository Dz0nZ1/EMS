using EMS.Application.Common.interfaces;
using EMS.Infrastructure.Configuration;
using EMS.Infrastructure.Contexts;
using EMS.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {

        var dbConfiguration = new PostgresDbConfiguration();
        configuration.GetSection("PostgresDbConfiguration").Bind(dbConfiguration);
        
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Test")
        {
            serviceCollection.AddDbContext<EmsDbContext>(
                options => options.UseNpgsql(dbConfiguration.ConnectionString,
                    x => x.MigrationsAssembly(typeof(EmsDbContext).Assembly.FullName))
            );
        }
        
        serviceCollection.AddScoped<IEmsDbContext>(provider => provider.GetRequiredService<EmsDbContext>());
        serviceCollection.AddScoped<IEventService, EventService>();
        serviceCollection.AddScoped<ICategoryService, CategoryService>();
        serviceCollection.AddScoped<ILocationService, LocationService>();
        serviceCollection.AddScoped<IReservationService, ReservationService>();
        
        
        return serviceCollection;
    }
}