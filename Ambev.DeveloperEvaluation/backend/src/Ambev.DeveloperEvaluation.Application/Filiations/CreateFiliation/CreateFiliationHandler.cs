using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Filiations.CreateFiliation;

namespace Ambev.DeveloperEvaluation.Application.Filiaitions.CreateFilation;

public class CreateFiliationHandler : IRequestHandler<CreateFiliationCommand, CreateFiliationResult>
{
    private readonly IFiliationRepository _filiationRepository;
    private readonly IMapper _mapper;

    public CreateFiliationHandler(IFiliationRepository filiationRepository, IMapper mapper)
    {
        _filiationRepository = filiationRepository;
        _mapper = mapper;
    }

    public async Task<CreateFiliationResult> Handle(CreateFiliationCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateFiliationCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var filiation = _mapper.Map<Domain.Entities.Filiation>(command);

        var createdFilation = await _filiationRepository.CreateAsync(filiation, cancellationToken);
        var result = _mapper.Map<CreateFiliationResult>(createdFilation);

        return result;
    }
}
