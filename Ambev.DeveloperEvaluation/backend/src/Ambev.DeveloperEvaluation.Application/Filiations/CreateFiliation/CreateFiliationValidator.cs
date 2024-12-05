using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Filiations.CreateFiliation;

/// <summary>
/// Validator for CreateUserCommand that defines validation rules for user creation command.
/// </summary>
public class CreateFiliationCommandValidator : AbstractValidator<CreateFiliationCommand>
{
    public CreateFiliationCommandValidator()
    {
        //RuleFor(user => user.Email).SetValidator(new EmailValidator());
        //RuleFor(user => user.Username).NotEmpty().Length(3, 50);
        //RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        //RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        //RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);
        //RuleFor(user => user.Role).NotEqual(UserRole.None);
    }
}