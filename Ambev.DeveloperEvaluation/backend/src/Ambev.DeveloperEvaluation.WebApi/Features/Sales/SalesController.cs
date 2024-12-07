using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.WebApi.Sales.Sales;

[ApiController]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ISaleRepository _saleRepository;

    public SalesController(IMediator mediator, IMapper mapper, ISaleRepository saleRepository)
    {
        _mediator = mediator;
        _mapper = mapper;
        _saleRepository = saleRepository;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateSaleCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
        {
            Success = true,
            Message = "Sale created successfully",
            Data = _mapper.Map<CreateSaleResponse>(response)
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSaleRequest { Id = id };
        var validator = new GetSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetSaleCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        var item = new GetSaleResponse()
        {
            Branch = response.Branch = response.Branch,
            Customer = new Features.Customers.CreateCustomer.CreateCustomerResponse()
            {
                CPF_CNPJ = response.Customer.CPF_CNPJ,
                Id = response.Customer.Id,
                Nome = response.Customer.Nome,
            },
            Date = response.Date,
            Number = response.Number,
            Products = response.Products.Select(p => new Features.Products.CreateProduct.CreateProductResponse()
            {
                Descriptions = p.Descriptions,
                Discounts = p.Discounts,
                Price = p.Price,
                Quantity = p.Quantity,
                TotalAmount = p.TotalAmount,
            }).ToList(),
            Status = response.Status,
            TotalSalesAmount = response.TotalSalesAmount
        };

        return Ok(new ApiResponseWithData<GetSaleResponse>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = _mapper.Map<GetSaleResponse>(item)
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSale([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteSaleRequest { Id = id };
        var validator = new DeleteSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteSaleCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sale deleted successfully"
        });
    }

    [HttpGet("/api/Sales")]
    [ProducesResponseType(typeof(ApiResponseWithData<ListSaleResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var result = await _saleRepository.ListAsync(cancellationToken);

        var list = result.Select(x => new ListSaleResponse()
        {
            Id = x.Id.ToString(),
            Branch = x.Branch,
            Customer = new Features.Customers.CreateCustomer.CreateCustomerResponse()
            {
                CPF_CNPJ = x.Customer.CPF_CNPJ,
                Id = x.Customer.Id.ToString(),
                Nome = x.Customer.Nome
            },
            Date = x.Date,
            Number = x.Number,
            Products = x.Products.Select(p => new Features.Products.CreateProduct.CreateProductResponse()
            {
                Descriptions = p.Descriptions,
                Discounts = p.Discounts,
                Price = p.Price,
                Quantity = p.Quantity,
                TotalAmount = p.TotalAmount,
            }).ToList(),
            Status = x.Status,
            TotalSalesAmount = x.TotalSalesAmount,
        });

        return Ok(new ApiResponseWithData<IEnumerable<ListSaleResponse>>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = list
        });
    }
}
