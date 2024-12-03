using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResult>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public CreateCustomerHandler(ICustomerRepository customerRepository, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var customer = _mapper.Map<Domain.Entities.Customer>(command);

        var createdCustomer = await _customerRepository.CreateAsync(customer, cancellationToken);
        var result = _mapper.Map<CreateCustomerResult>(createdCustomer);

        return result;
    }
}
