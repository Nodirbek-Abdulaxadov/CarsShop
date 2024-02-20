namespace CarsShop.BusinessLogic.Common;

public class CustomException(string message)
    : Exception(message)
{
}