namespace Delivery.Domain.Interfaces.Repositories;

public interface IPartnerRepository
{
    Task<Partner> GetPartnerById(int id);
    Task<Address> GetAddressById(int id);
    Task<CoverageArea> GetCoverageAreaById(int id);
    Task<IEnumerable<Partner>> GetPartners();
    
}
