using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traceability.Domain.ProductionEvents.Entities;

namespace Traceability.Infrastructure.Persistence.Configurations;

internal sealed class ProductionEventConfigurartion : IEntityTypeConfiguration<ProductionEvent>
{
    public void Configure(EntityTypeBuilder<ProductionEvent> builder)
    {
        builder.ToTable("ProductionEvents");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();
    }
}
