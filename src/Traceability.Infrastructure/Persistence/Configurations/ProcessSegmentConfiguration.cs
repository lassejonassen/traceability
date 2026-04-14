using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Traceability.Domain.ProcessSegments.Entities;

namespace Traceability.Infrastructure.Persistence.Configurations;

internal sealed class ProcessSegmentConfiguration : IEntityTypeConfiguration<ProcessSegment>
{
    public void Configure(EntityTypeBuilder<ProcessSegment> builder)
    {
        builder.ToTable("ProcessSegments");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();

        builder.Property(e => e.Name)
            .IsRequired(true);
    }
}
