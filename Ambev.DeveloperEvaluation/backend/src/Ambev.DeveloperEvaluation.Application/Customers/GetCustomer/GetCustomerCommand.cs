using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomer;

/// <summary>
/// Command for retrieving a user by their ID
/// </summary>
public record GetCustomerCommand : IRequest<GetCustomerResult>
{
    public Guid Id { get; }
    public GetCustomerCommand(Guid id)
    {
        Id = id;
    }
}
