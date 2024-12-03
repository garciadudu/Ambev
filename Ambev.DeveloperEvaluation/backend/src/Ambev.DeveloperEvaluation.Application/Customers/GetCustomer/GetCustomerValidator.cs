using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer;

/// <summary>
/// Validator for GetUserCommand
/// </summary>
public class GetCustomerValidator : AbstractValidator<GetCustomerCommand>
{
    /// <summary>
    /// Initializes validation rules for GetUserCommand
    /// </summary>
    public GetCustomerValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
