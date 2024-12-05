using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Filiaitions.GetFiliation;

public record GetFiliationCommand : IRequest<GetFiliationResult>
{
    public Guid Id { get; }
    public GetFiliationCommand(Guid id)
    {
        Id = id;
    }
}
