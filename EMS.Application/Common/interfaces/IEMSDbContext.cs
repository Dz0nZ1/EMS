using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Common.interfaces;

public interface IEmsDbContext
{
    public DbSet<Domain.Entities.Event> Events { get; }
    public DbSet<Domain.Entities.Location> Locations { get; }
    public DbSet<Domain.Entities.Category> Categories { get; }
    public DbSet<Domain.Entities.Reservation> Reservations { get;}
    
    public DbSet<Domain.Entities.ApplicationUser> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}