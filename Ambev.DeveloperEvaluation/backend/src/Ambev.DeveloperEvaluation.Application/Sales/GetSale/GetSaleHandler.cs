using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper.Features;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetSaleHandler(
        ISaleRepository saleRepository,
        IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<GetSaleResult> Handle(GetSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);

        var item = new GetSaleResult()
        {
            Branch = sale.Branch ,
            Customer = new GetCustomerResult()
            {
                CPF_CNPJ = sale.Customer.CPF_CNPJ,
                Id = sale.Customer.Id.ToString(),
                Nome = sale.Customer.Nome,
            },
            Date = sale.Date,
            Number = sale.Number,
            Products = sale.Products.Select(p => new GetProductResult()
            {
                Descriptions = p.Descriptions,
                Discounts = p.Discounts,
                Price = p.Price,
                Quantity = p.Quantity,
                TotalAmount = p.TotalAmount,
            }).ToList(),
            Status = sale.Status,
            TotalSalesAmount = sale.TotalSalesAmount
        };

        if (item == null)
            throw new KeyNotFoundException($"sale with ID {request.Id} not found");

        return _mapper.Map<GetSaleResult>(item);
    }
}
