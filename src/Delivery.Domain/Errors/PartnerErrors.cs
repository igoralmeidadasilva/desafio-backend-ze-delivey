namespace Delivery.Domain.Errors;

public static class PartnerErrors
{
    public static Error PartnerNotFound(int id) => new("Partner.NotFound", $"This Partner with id {id} cannot be found.");
    public static Error NearestPartnerNotFound() => new("Partner.NearestPartnerNotFound", "This Location has no nearby partners.");
}
