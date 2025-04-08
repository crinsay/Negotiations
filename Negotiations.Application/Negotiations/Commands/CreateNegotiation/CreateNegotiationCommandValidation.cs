using FluentValidation;

namespace Negotiations.Application.Negotiations.Commands.CreateNegotiation;

public class CreateNegotiationCommandValidation : AbstractValidator<CreateNegotiationCommand>
{
    public CreateNegotiationCommandValidation()
    {
        RuleFor(x => x.SuggestedPrice)
            .GreaterThan(0).WithMessage("Suggested price must be greater than 0.");
    }
}
