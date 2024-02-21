namespace CarsShop.BusinessLogic.Common;

public class CustomException(string key, string message)
    : Exception(message)
{
    public string Key { get; } = key;
}