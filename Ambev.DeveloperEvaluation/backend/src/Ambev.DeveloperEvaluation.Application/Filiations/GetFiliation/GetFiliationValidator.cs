using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Filiaitions.GetFiliation;

public class GetFiliationValidator : AbstractValidator<GetFiliationCommand>
{
    public GetFiliationValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}