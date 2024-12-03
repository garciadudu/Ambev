using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.DeleteCustomer;

/// <summary>
/// Validator for DeleteUserRequest
/// </summary>
public class DeleteCustomerRequestValidator : AbstractValidator<DeleteCustomerRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteUserRequest
    /// </summary>
    public DeleteCustomerRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
