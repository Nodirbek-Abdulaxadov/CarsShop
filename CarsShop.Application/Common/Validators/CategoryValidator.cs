﻿namespace CarsShop.Application.Common.Validators;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(3, 50).WithMessage("Name must be between 3 and 50 characters");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Image is required");
    }
}