using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.DeleteUser;

/// <summary>
/// Validator for DeleteCustomerRequestValidator
/// </summary>
public class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteUserRequest
    /// </summary>
    public DeleteUserRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
