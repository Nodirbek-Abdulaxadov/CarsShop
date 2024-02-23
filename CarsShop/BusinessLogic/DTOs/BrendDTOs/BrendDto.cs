
namespace CarsShop.BusinessLogic.DTOs.BrendDTOs;

public class BrendDto : CategoryDto
{
    public static explicit operator BrendDto(Brend brend)
        => new()
        {
            Id = brend.Id,
            Name = brend.Name,
            ImagePath = brend.ImageUrl
        };
}
