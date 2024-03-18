namespace CarsShop.Application.Common.Exceptions;

public class CarsShopException(string message)
    : Exception(message)
{
}