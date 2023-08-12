namespace Infrastructure.Persistance.FluentAPIs;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SampleConfiguration : BaseEntityConfiguration<Sample>, IEntityTypeConfiguration<Sample>
{
    void IEntityTypeConfiguration<Sample>.Configure(EntityTypeBuilder<Sample> builder)
    {
        // Call base configuration
        BaseConfigure(builder);

        // Configure properties
        builder.Property(property => property.Title).IsRequired().HasMaxLength(100);
        builder.Property(property => property.Description).IsRequired().HasMaxLength(500);
        builder.Property(property => property.State).IsRequired();

        // Configure relationships
        /* builder.HasOne(property => property.Parent)
            .WithMany(relation => relation.Children)
            .HasForeignKey(property => property.TestId); */
    }
}
