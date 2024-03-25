using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Domain.Event;

public class EventApplicationUserConfiguration : IEntityTypeConfiguration<EventApplicationUser>
{
    public void Configure(EntityTypeBuilder<EventApplicationUser> builder)
    {
        builder.ToTable("EventApplicationUser");

        builder.HasKey(x => new { x.UserId, x.EventId });

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Events)
            .HasForeignKey(x => x.UserId);

        builder
            .HasOne(x => x.Event)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.EventId);
        
    }
}