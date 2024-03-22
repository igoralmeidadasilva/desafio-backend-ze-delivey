using Delivery.Application.Commands.CreatePartner;

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

        CreateMap<CreatePartnerCommand, Partner>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CoverageAreaId, opt => opt.Ignore())
            .ForMember(dest => dest.AddressId, opt => opt.Ignore())
            .ForMember(dest => dest.TradingName, opt => opt.MapFrom(src => src.TradingName))
            .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.OwnerName))
            .ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.Document))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new Address("Point", src.Address!)))
            .ForMember(dest => dest.CoverageArea, opt => opt.MapFrom(src => new CoverageArea("MultiPolygon", src.CoverageArea!)));
    }
}
