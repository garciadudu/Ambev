using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Filiations.CreateFiliation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var customer = new Customer()
        {
            Id = new Guid(command.Customer.Id),
            CPF_CNPJ = command.Customer.CPF_CNPJ,
            Nome = command.Customer.Nome,
        };

        var filiation = new Filiation()
        {
            Id = new Guid(command.Filiation.Id),
            Codigo = command.Filiation.Codigo,
            Nome = command.Filiation.Nome,
        };

        var sale = new Sale()
        {
            Branch = command.Branch,
            Customer = customer,
            Date = command.Date,
            Number = command.Number,
            Products = command.Products.Select(p => new Product()
            {
                Descriptions = p.Descriptions,
                Discounts = p.Discounts,
                Price = p.Price,
                Quantity = p.Quantity,
                TotalAmount = p.TotalAmount,
            }).ToList(),
            TotalSalesAmount = command.Products.Sum(x => x.TotalAmount),
            Filiation = filiation
        };

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

        var createCustomer = new CreateCustomerResult
        {
            Id = new Guid(command.Customer.Id),
            CPF_CNPJ = command.Customer.CPF_CNPJ,
            Nome = command.Customer.Nome,
        };

        var createFiliation = new CreateFiliationResult
        { 
            Id = new Guid(command.Filiation.Id),
            Codigo = command.Filiation.Codigo,
            Nome = command.Filiation.Nome,
        };

        var result = new CreateSaleResult()
        {
            Branch = createdSale.Branch,
            Customer = createCustomer,
            Date = createdSale.Date,
            Number = createdSale.Number,
            Products = createdSale.Products.Select(p => new CreateProductResult()
            {
                Descriptions = p.Descriptions,
                Discounts = p.Discounts,
                Price = p.Price,
                Quantity = p.Quantity,
                TotalAmount = p.TotalAmount,
            }).ToList(),
            TotalSalesAmount = createdSale.TotalSalesAmount,
            Filiation = createFiliation,
            Status= createdSale.Status,
        };

        return result;
    }
}
