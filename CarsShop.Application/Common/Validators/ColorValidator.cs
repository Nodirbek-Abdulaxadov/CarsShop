namespace CarsShop.Application.Common.Validators;

public class ColorValidator : AbstractValidator<Color>
{
    public ColorValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Color name is required")
            .MaximumLength(50).WithMessage("Color name must not exceed 50 characters");
        RuleFor(x => x.HexCode)
            .NotEmpty()
            .WithMessage("Color code is required");

        RuleFor(x => x.CarId)
            .GreaterThan(0)
            .WithMessage("CarId is required");

        RuleFor(x => x.Images)
            .NotEmpty()
            .WithMessage("Images are required");
    }
}