using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Filiations.GetFiliation;

public class GetFiliationRequestValidator : AbstractValidator<GetFiliationRequest>
{
    public GetFiliationRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
