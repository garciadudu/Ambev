using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

public class CreateCustomerResponse
{
    public string Id { get; set; }
    public string CPF_CNPJ { get; set; }
    public string Nome { get; set; }
}
