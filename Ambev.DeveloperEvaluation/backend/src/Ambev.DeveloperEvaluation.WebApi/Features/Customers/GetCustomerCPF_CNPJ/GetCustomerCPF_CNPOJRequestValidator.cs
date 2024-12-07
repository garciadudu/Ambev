using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomerCPF_CNPJ;

public class GetCustomerCPF_CNPJRequestValidator : AbstractValidator<GetCustomerCPF_CNPJRequest>
{
    /// <summary>
    /// Initializes validation rules for GetUserRequest
    /// </summary>
    public GetCustomerCPF_CNPJRequestValidator()
    {
        RuleFor(x => x.CPF_CNPJ)
            .NotEmpty()
            .WithMessage("Customer CPF_CNPJ is required");
    }
}
