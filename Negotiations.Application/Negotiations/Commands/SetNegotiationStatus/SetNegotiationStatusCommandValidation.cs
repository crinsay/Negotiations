using FluentValidation;
using Negotiations.Domain.Constants;

namespace Negotiations.Application.Negotiations.Commands.SetNegotiationStatus;

public class SetNegotiationStatusCommandValidation : AbstractValidator<SetNegotiationStatusCommand>
{
    public SetNegotiationStatusCommandValidation()
    {
        RuleFor(dto => dto.Status)
            .Must(status => NegotiationStatuses.AllowedEmployeeStatuses.Contains(status))
            .WithMessage("Status must be one of: Accepted or Declined.");
    }
}