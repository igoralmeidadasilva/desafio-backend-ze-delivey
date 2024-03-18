namespace Delivery.Infrastructure.DataContext.Configurations;

public sealed class PartnerConfiguration : IEntityTypeConfiguration<Partner>
{
    public void Configure(EntityTypeBuilder<Partner> builder)
    {
        builder.ToTable("partners");

        builder.Property(p => p.Id).HasColumnName("id");

        builder.Property(p => p.TradingName).HasColumnName("tradingname");

        builder.Property(p => p.OwnerName).HasColumnName("ownername");

        builder.Property(p => p.Document).HasColumnName("document");

        builder.Property(p => p.CoverageAreaId).HasColumnName("coverageareaid");

        builder.Property(p => p.AddressId).HasColumnName("addressid");

        // builder.HasOne(p => p.CoverageArea)
        //     .WithMany()
        //     .HasForeignKey(p => p.CoverageAreaId);

        // builder.HasOne(p => p.Address)
        //     .WithMany()
        //     .HasForeignKey(p => p.AddressId);
    }
}
