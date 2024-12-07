using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Filiations.CreateFiliation;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Application.Filiations.CreateFilation;

public class CreateFiliationHandler: IRequestHandler<CreateFiliationCommand, CreateFiliationResult>
{
    private readonly IFiliationRepository _filiationRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public CreateFiliationHandler(IFiliationRepository filiationRepository, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _filiationRepository = filiationRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
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
