namespace Delivery.Application.Profiles;

public sealed class PartnerProfile : Profile
{
    public PartnerProfile()
    {
        CreateMap<PartnerDto, Partner>()
            .ReverseMap();

        CreateMap<AddressDto, Address>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(dest => dest.Coordinates, opt => opt.MapFrom(src => src.Coordinates.Coordinate.CoordinateValue.CoordinateValue));
            
        CreateMap<CoverageAreaDto, CoverageArea>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(dest => dest.Coordinates, opt => opt.MapFrom(src => src.Coordinates.Coordinates.ToArray()));
    }
}
