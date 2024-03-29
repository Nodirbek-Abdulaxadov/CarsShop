﻿namespace CarsShop.Domain.Entities;

public class Car : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int BrendId { get; set; }
    public Brend? Brend { get; set; }

    public List<Color> Colors { get; set; } = new();
    public List<Order> Orders { get; set; } = new();
}