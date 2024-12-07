using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomerCPF_CNPJ;

public class GetCustomerCPF_CNPJValidator : AbstractValidator<GetCustomerCPF_CNPJCommand>
{
   public GetCustomerCPF_CNPJValidator()
    {
        RuleFor(x => x.CPF_CNPJ)
            .NotEmpty()
            .WithMessage("Customer CPF_CNPJ is required");
    }
}
