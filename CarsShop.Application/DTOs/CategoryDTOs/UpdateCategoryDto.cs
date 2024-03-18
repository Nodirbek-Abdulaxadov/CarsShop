namespace CarsShop.Application.DTOs.CategoryDTOs;

public class UpdateCategoryDto : CategoryDto
{
    public IFormFile? file { get; set; }
}