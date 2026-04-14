using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traceability.Domain.ProductionRequests.Entities;

namespace Traceability.Infrastructure.Persistence.Configurations;

internal sealed class ProductionRequestConfiguration : IEntityTypeConfiguration<ProductionRequest>
{
    public void Configure(EntityTypeBuilder<ProductionRequest> builder)
    {
        builder.ToTable("ProductionRequests");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();
    }
}
