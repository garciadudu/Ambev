using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

public class CreateCustomerRequest
{
    public string CPF_CNPJ { get; set; }
    public string Nome { get; set; }
}