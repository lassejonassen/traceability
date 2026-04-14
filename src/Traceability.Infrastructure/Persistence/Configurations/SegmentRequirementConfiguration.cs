using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traceability.Domain.SegmentRequirements.Entities;

namespace Traceability.Infrastructure.Persistence.Configurations;

internal sealed class SegmentRequirementConfiguration : IEntityTypeConfiguration<SegmentRequirement>
{
    public void Configure(EntityTypeBuilder<SegmentRequirement> builder)
    {
        builder.ToTable("SegmentRequirements");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();
    }
}
