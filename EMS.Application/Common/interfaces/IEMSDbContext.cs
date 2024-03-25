using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Common.interfaces;

public interface IEmsDbContext
{
    public DbSet<Event> Events { get; }
    public DbSet<Domain.Entities.Location> Locations { get; }
    public DbSet<Domain.Entities.Category> Categories { get; }
    public DbSet<Reservation> Reservations { get;}

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}