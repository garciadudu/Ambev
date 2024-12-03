using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

/// <summary>
/// Validator for CreateUserCommand that defines validation rules for user creation command.
/// </summary>
public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        //RuleFor(user => user.Email).SetValidator(new EmailValidator());
        //RuleFor(user => user.Username).NotEmpty().Length(3, 50);
        //RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        //RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        //RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);
        //RuleFor(user => user.Role).NotEqual(UserRole.None);
    }
}