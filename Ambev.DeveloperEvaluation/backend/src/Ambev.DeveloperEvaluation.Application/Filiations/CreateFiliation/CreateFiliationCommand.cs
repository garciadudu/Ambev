using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Filiations.CreateFiliation;

public class CreateFiliationCommand : IRequest<CreateFiliationResult>
{
    public string Id { get; set; }
    public string Codigo { get; set; }
    public string Nome { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateFiliationCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}