namespace Delivery.Infrastructure.DataContext;

public sealed class ZeDeliveryDbContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<CoverageArea> CoverageAreas { get; set; }
    public DbSet<Partner> Partners { get; set; }

    public ZeDeliveryDbContext(DbContextOptions<ZeDeliveryDbContext> options) : base(options)
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("postgis");
        modelBuilder.ApplyConfiguration(new PartnerConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new CoverageAreaConfiguration());        
    }
}
