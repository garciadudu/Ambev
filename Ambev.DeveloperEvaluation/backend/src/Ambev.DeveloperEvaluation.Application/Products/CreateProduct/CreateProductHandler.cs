using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public CreateProductHandler(IProductRepository productRepository, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = _mapper.Map<Domain.Entities.Product>(command);

        var createdCustomer = await _productRepository.CreateAsync(product, cancellationToken);
        var result = _mapper.Map<CreateProductResult>(createdCustomer);

        return result;
    }
}
