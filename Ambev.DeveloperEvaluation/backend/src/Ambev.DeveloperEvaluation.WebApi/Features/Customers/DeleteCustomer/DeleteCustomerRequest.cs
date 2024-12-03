namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.DeleteCustomer;

/// <summary>
/// Request model for deleting a user
/// </summary>
public class DeleteCustomerRequest
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public Guid Id { get; set; }
}
