using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;

/// <summary>
/// Validator for GetUserRequest
/// </summary>
public class GetCustomerRequestValidator : AbstractValidator<GetCustomerRequest>
{
    /// <summary>
    /// Initializes validation rules for GetUserRequest
    /// </summary>
    public GetCustomerRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
