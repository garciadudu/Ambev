using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Filiations.CreateFiliation;

public class CreateFiliationCommandValidator : AbstractValidator<CreateFiliationCommand>
{
    public CreateFiliationCommandValidator()
    {
    }
}