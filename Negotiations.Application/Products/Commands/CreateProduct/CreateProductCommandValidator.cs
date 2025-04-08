using FluentValidation;

namespace Negotiations.Application.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100)
            .WithMessage("The name must contain between 3 and 100 characters.");

        RuleFor(dto => dto.Price)
            .GreaterThan(0)
            .Must(p => decimal.Round(p, 2) == p)
            .WithMessage("Price must have no more than 2 decimal places.");
    }
}
