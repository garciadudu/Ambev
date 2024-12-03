using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer;

/// <summary>
/// Command for deleting a user
/// </summary>
public record DeleteCustomerCommand : IRequest<DeleteCustomerResponse>
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteUserCommand
    /// </summary>
    /// <param name="id">The ID of the user to delete</param>
    public DeleteCustomerCommand(Guid id)
    {
        Id = id;
    }
}
