namespace Delivery.Infrastructure.DataContext.Configurations;

public sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("address");
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.Type).HasColumnName("type");
        builder.Property(p => p.Coordinates).HasColumnName("coordinates");
        builder.Property(a => a.Coordinates).HasColumnType("geometry(Point)");
    }
}
