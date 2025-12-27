using FluentValidation;

namespace ApiRestfulCSharp.Application.Cars.Commands.Create;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(x => x.Brand)
            .NotEmpty()
            .WithMessage("The brand is mandatory.")
            .MaximumLength(100);

        RuleFor(x => x.Model)
            .NotEmpty()
            .WithMessage("The template is mandatory.");

        RuleFor(x => x.Year)
            .GreaterThan(1886)
            .LessThanOrEqualTo(DateTime.Now.Year + 1)
            .WithMessage("The year must be later than 1886 and consistent with the current one.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("The price must be greater than zero.");
    }
}