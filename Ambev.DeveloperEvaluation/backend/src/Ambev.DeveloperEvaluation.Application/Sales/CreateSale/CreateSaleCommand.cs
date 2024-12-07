using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Filiations.CreateFiliation;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    public Int64 Number { get; set; }

    public DateTime Date { get; set; }

    public CreateCustomerCommand Customer { get; set; }

    public double TotalSalesAmount { get; set; }

    public string Branch { get; set; }

    public List<CreateProductCommand> Products { get; set; }

    public CreateFiliationCommand Filiation { get; set; }

    public SaleStatus Status { get; set; }

    public CreateSaleCommand()
    {
        Products = new List<CreateProductCommand>();
    }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}


