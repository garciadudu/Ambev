using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Filiations.GetFiliation;

public class GetFiliationHandler : IRequestHandler<GetFiliationCommand, GetFiliationResult>
{
    private readonly IFiliationRepository _filiationRepository;
    private readonly IMapper _mapper;

    public GetFiliationHandler(
        IFiliationRepository filiationRepository,
        IMapper mapper)
    {
        _filiationRepository = filiationRepository;
        _mapper = mapper;
    }

    public async Task<GetFiliationResult> Handle(GetFiliationCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetFiliationValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = await _filiationRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user == null)
            throw new KeyNotFoundException($"User with ID {request.Id} not found");

        return _mapper.Map<GetFiliationResult>(user);
    }
}
