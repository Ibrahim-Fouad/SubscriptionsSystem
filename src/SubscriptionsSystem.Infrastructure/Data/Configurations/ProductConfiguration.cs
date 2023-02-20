using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SubscriptionsSystem.Domain.Entities;

namespace SubscriptionsSystem.Infrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable($"{nameof(Product)}s");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.MonthlyPrice)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(p => p.YearlyPrice)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.HasMany(p => p.Features)
            .WithMany()
            .UsingEntity(p => p.ToTable("ProductFeatures"));
    }
}