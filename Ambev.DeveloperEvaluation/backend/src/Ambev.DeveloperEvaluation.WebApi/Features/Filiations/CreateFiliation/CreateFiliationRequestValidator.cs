using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Filiations.CreateFiliation;

public class CreateFiliationRequestValidator : AbstractValidator<CreateFiliationRequest>
{
    public CreateFiliationRequestValidator()
    {
    }
}