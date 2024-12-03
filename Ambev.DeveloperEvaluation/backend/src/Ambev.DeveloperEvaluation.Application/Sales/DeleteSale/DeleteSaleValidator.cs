using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Validator for DeleteUserCommand
/// </summary>
public class DeleteSaleValidator : AbstractValidator<DeleteSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteUserCommand
    /// </summary>
    public DeleteSaleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
