using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomerCPF_CNPJ;

public record GetCustomerCPF_CNPJCommand : IRequest<GetCustomerCPF_CNPJResult>
{
    public string CPF_CNPJ { get; }
    public GetCustomerCPF_CNPJCommand(string cpf_cnpj)
    {
        CPF_CNPJ = cpf_cnpj;
    }
}
