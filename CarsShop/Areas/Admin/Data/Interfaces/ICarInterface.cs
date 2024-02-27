﻿namespace CarsShop.Data.Interfaces;

public interface ICarInterface : IRepository<Car>
{
    List<Car> GetCarsWithReleations();
}