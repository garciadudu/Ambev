using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Filiations.GetFiliation;

public class GetFiliaitonRequestValidator : AbstractValidator<GetFiliationRequest>
{
    public GetFiliaitonRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
