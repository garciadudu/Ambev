using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;

/// <summary>
/// API response model for GetUser operation
/// </summary>
public class GetCustomerResponse
{
    public string CPF_CNPJ { get; set; }
    public string Nome { get; set; }
}
