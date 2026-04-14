using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traceability.Domain.SegmentResponses.Entities;

namespace Traceability.Infrastructure.Persistence.Configurations;

internal sealed class SegmentResponseConfiguration : IEntityTypeConfiguration<SegmentResponse>
{
    public void Configure(EntityTypeBuilder<SegmentResponse> builder)
    {
        builder.ToTable("SegmentResponses");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();
    }
}
