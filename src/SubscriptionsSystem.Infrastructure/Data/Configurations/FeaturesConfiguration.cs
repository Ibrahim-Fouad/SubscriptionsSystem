using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubscriptionsSystem.Domain.Entities;

namespace SubscriptionsSystem.Infrastructure.Data.Configurations;

public class FeaturesConfiguration : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.ToTable($"{nameof(Feature)}s");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Description)
            .IsRequired(false)
            .HasMaxLength(1000);
    }
}