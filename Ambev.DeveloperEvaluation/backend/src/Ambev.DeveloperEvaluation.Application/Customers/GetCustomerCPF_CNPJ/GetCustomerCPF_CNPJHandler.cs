using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Customers.GetCustomerCPF_CNPJ;

public class GetCustomerCPF_CNPJHandler : IRequestHandler<GetCustomerCPF_CNPJCommand, GetCustomerCPF_CNPJResult>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomerCPF_CNPJHandler(
        ICustomerRepository customerRepository,
        IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<GetCustomerCPF_CNPJResult> Handle(GetCustomerCPF_CNPJCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetCustomerCPF_CNPJValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cpf_cnpj = await _customerRepository.GetByCPF_CNNPJAsync(request.CPF_CNPJ, cancellationToken);
        
        if (cpf_cnpj == null)
            throw new KeyNotFoundException($"Customer with CPF_CNPJ {request.CPF_CNPJ} not found");

        return _mapper.Map<GetCustomerCPF_CNPJResult>(cpf_cnpj);
    }
}
