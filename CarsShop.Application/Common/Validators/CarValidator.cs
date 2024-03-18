namespace CarsShop.Application.Common.Validators;

public class CarValidator : AbstractValidator<Car>
{
    public CarValidator()
    {
        RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.BrendId).GreaterThan(0).WithMessage("Brend is required");
        RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Category is required");
    }
}