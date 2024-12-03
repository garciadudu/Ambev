namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class GetCustomerRequest
{
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
