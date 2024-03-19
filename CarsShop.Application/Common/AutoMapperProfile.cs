namespace CarsShop.Application.Common;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AddBrendDto, Brend>();
        CreateMap<UpdateBrendDto, Brend>();
        CreateMap<Brend, BrendDto>()
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImageUrl))
            .ReverseMap();

        CreateMap<AddCarDto, Car>();
        CreateMap<UpdateCarDto, Car>();
        CreateMap<Car, CarDto>()
            .ReverseMap();

        CreateMap<AddCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
        CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImageUrl))
            .ReverseMap();

        CreateMap<AddColorDto, Color>();
        CreateMap<UpdateColorDto, Color>();
        CreateMap<Color, ColorDto>().ReverseMap();

        CreateMap<Image, ImageDto>().ReverseMap();
    }
}