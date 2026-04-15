using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traceability.Domain.ProductionEvents.Entities;

namespace Traceability.Infrastructure.Persistence.Configurations;

internal sealed class ProductionEventAttributeConfiguration : IEntityTypeConfiguration<ProductionEventAttribute>
{
    public void Configure(EntityTypeBuilder<ProductionEventAttribute> builder)
    {
        builder.ToTable("ProductionEventAttributes");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();

        builder.Property(e => e.Name)
            .IsRequired(true);

        builder.Property(e => e.Value)
            .IsRequired(true);

        builder.Property(e => e.NumericValue)
            .HasDefaultValue(0.0)
            .IsRequired(true);

        builder.HasOne(e => e.ProductionEvent)
            .WithMany(e => e.ProductionEventAttributes)
            .HasForeignKey(e => e.ProductionEventId);

    }
}
