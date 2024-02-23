namespace CarsShop.BusinessLogic.Common;

public static class Mapper
{
    /*public static CategoryDto ToCategoryDto(this Category category)
        => new()
        {
            Id = category.Id,
            Name = category.Name
        };

    public static BrendDto ToBrendDto(this Brend brend)
        => new()
        {
            Id = brend.Id,
            Name = brend.Name
        };*/

    public static CarDto ToCarDto(this Car car)
        => new()
        {
            Id = car.Id,
            Name = car.Name,
            Description = car.Description,
            Price = car.Price,
            Category = (CategoryDto)car.Category,
            Brend = (BrendDto)car.Brend
        };
}