namespace CarsShop.BusinessLogic.DTOs.CategoryDTOs;

public class UpdateCategoryDto : CategoryDto
{
    public IFormFile? file { get; set; }
}