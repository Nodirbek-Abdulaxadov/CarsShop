using Microsoft.AspNetCore.Http;

namespace CarsShop.Application.DTOs.ColorDTOs;

public class UpdateColorDto : AddColorDto
{
    public int Id { get; set; }
}