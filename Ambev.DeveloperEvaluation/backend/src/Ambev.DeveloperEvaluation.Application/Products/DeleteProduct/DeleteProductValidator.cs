using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

/// <summary>
/// Validator for DeleteUserCommand
/// </summary>
public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteUserCommand
    /// </summary>
    public DeleteProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
