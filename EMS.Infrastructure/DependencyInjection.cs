using EMS.Application.Common.interfaces;
using EMS.Domain.Entities;
using EMS.Infrastructure.Auth.Extensions;
using EMS.Infrastructure.Configuration;
using EMS.Infrastructure.Contexts;
using EMS.Infrastructure.Identity;
using EMS.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {

        //Database
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
        
        //Business logic
        serviceCollection.AddScoped<IEventService, EventService>();
        serviceCollection.AddScoped<ICategoryService, CategoryService>();
        serviceCollection.AddScoped<ILocationService, LocationService>();
        serviceCollection.AddScoped<IReservationService, ReservationService>();
        
        //Authentication
        serviceCollection
            .AddIdentity<ApplicationUser, ApplicationRole>()
            .AddRoleManager<RoleManager<ApplicationRole>>()
            .AddUserManager<ApplicationUserManager>()
            .AddEntityFrameworkStores<EmsDbContext>()
            .AddDefaultTokenProviders()
            .AddPasswordlessLoginTokenProvider();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IRoleService, RoleService>();
        serviceCollection.AddScoped<ICurrentUserService, CurrentUserService>();
        serviceCollection.Configure<JwtConfiguration>(configuration.GetSection("JwtConfiguration"));
        
        
        return serviceCollection;
    }
}