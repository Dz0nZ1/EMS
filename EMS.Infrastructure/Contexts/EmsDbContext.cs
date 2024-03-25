using System.Reflection;
using EMS.Application.Common.interfaces;
using EMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EMS.Infrastructure.Contexts;

public class EmsDbContext(DbContextOptions<EmsDbContext> options): IdentityDbContext<ApplicationUser,
    ApplicationRole,
    string,
    IdentityUserClaim<string>,
    ApplicationUserRole,
    IdentityUserLogin<string>,
    IdentityRoleClaim<string>,
    IdentityUserToken<string>
>(options), IEmsDbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetValueConverter(new ValueConverter<DateTime, DateTime>(
                        v => v.ToUniversalTime(),
                        v => DateTime.SpecifyKind(v, DateTimeKind.Utc)));
                }
            }
        }
        
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=root;Database=EventMng");
    }

    // public DbSet<Course> Courses => Set<Course>();
    // public DbSet<Enrollment> Enrollments => Set<Enrollment>();


    public DbSet<Event> Events => Set<Event>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Reservation> Reservations => Set<Reservation>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
}