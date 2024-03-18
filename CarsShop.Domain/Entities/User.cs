using Microsoft.AspNetCore.Identity;

namespace CarsShop.Domain.Entities;

public class User : IdentityUser
{
    public string FullName { get; set; } = null!;
    public string Address { get; set; } = null!;

    public List<Order> Orders { get; set; } = new();
}