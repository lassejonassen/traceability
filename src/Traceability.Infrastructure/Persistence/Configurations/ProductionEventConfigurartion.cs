using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Traceability.Domain.ProductionEvents.Entities;
using Traceability.Domain.ProductionEvents.Enums;

namespace Traceability.Infrastructure.Persistence.Configurations;

internal sealed class ProductionEventConfigurartion : IEntityTypeConfiguration<ProductionEvent>
{
    public void Configure(EntityTypeBuilder<ProductionEvent> builder)
    {
        builder.ToTable("ProductionEvents");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();

        builder.Property(e => e.ProductionEventType)
            .HasConversion(new EnumToStringConverter<ProductionEventType>())
            .HasDefaultValue(ProductionEventType.ProductionData)
            .IsRequired(true);
    }
}
