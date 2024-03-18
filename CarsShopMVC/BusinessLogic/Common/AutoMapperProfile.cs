using AutoMapper;

namespace CarsShopMVC.BusinessLogic.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Brend, BrendDto>()
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImageUrl))
            .ReverseMap();
    }
}