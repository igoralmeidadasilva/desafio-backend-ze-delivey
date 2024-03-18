namespace Delivery.Infrastructure.DataContext.Configurations;

public class CoverageAreaConfiguration : IEntityTypeConfiguration<CoverageArea>
{
    public void Configure(EntityTypeBuilder<CoverageArea> builder)
    {
        builder.ToTable("coverage_area");
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.Type).HasColumnName("type");
        builder.Property(p => p.Coordinates).HasColumnName("coordinates");
        builder.Property(a => a.Coordinates).HasColumnType("geometry(MultiPolygon)");
    }
}
