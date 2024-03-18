namespace Delivery.Infrastructure.Repositories;

public sealed class PartnerRepository : IPartnerRepository
{
    private readonly ZeDeliveryDbContext _context;

    public PartnerRepository(ZeDeliveryDbContext context)
    {
        _context = context;
    }

    public async Task<Partner> GetPartnerById(int id)
    {
        var result = await _context.Partners.AsNoTracking().FirstOrDefaultAsync(partner => partner.Id == id);
        return result!;
    }

    public async Task<Address> GetAddressById(int id)
    {
        var result = await _context.Addresses.AsNoTracking().FirstOrDefaultAsync(address => address.Id == id);
        return result!;
    }

    public async Task<CoverageArea> GetCoverageAreaById(int id)
    {
        var result = await _context.CoverageAreas.AsNoTracking().FirstOrDefaultAsync(coverageArea => coverageArea.Id == id);
        return result!;
    }

}
