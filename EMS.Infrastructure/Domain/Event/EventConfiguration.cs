using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.Infrastructure.Domain.Event;

public class EventConfiguration : IEntityTypeConfiguration<EMS.Domain.Entities.Event>
{
    public void Configure(EntityTypeBuilder<EMS.Domain.Entities.Event> builder)
    {
        builder.ToTable("Events");

        builder.HasKey(e => e.Id);

        builder.Property<Guid>("CategoryId");
        builder.Property<Guid>("LocationId");

        builder.HasIndex("CategoryId");
        builder.HasOne(x => x.Category).WithMany(x => x.Events).HasForeignKey("CategoryId")
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex("LocationId");
        builder.HasOne(x => x.Location).WithMany(x => x.Events).HasForeignKey("LocationId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}