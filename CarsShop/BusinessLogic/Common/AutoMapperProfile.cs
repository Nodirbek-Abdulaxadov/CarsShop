using AutoMapper;

namespace CarsShop.BusinessLogic.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Brend, BrendDto>()
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImageUrl))
            .ReverseMap();
    }
}