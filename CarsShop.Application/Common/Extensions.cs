namespace CarsShop.Application.Common;

public static class Extensions
{
    public static bool IsExists(this Car car, List<Car> cars)
        => cars.Any(c => c.Name == car.Name && c.Id != car.Id);

    public static bool IsExists(this Category category, List<Category> categories)
        => categories.Any(c => c.Name == category.Name && c.Id != category.Id);

    public static bool IsExists(this Brend brend, List<Brend> brends)
        => brends.Any(b => b.Name == brend.Name && b.Id != brend.Id);

    public static bool IsExists(this Color color, List<Color> colors)
        => colors.Any(c => c.Name == color.Name && c.Id != color.Id);


    public static string GetErrorMessages(this ValidationResult result)
    {
        var resultMessage = new StringBuilder();
        foreach (var error in result.Errors)
        {
            resultMessage.Append(error.ErrorMessage);
        }
        return resultMessage.ToString();
    }
}