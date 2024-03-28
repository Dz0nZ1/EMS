using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Domain.Event;

public class ReservationEventConfiguration : IEntityTypeConfiguration<ReservationEvent>
{
    public void Configure(EntityTypeBuilder<ReservationEvent> builder)
    {
        builder.ToTable("ReservationEvent");

        builder.HasKey(x => new { x.EventId, x.ReservationId });

        builder
            .HasOne(x => x.Event)
            .WithMany(x => x.Reservations)
            .HasForeignKey(x => x.EventId);

        builder
            .HasOne(x => x.Reservation)
            .WithMany(x => x.Events)
            .HasForeignKey(x => x.ReservationId);
        
    }
}