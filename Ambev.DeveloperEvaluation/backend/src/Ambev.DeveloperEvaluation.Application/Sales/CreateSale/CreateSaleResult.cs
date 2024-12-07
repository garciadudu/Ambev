using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Filiations.CreateFiliation;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleResult
{
    public string Id { get; set; }

    public Int64 Number { get; set; }

    public DateTime Date { get; set; }

    public CreateCustomerResult Customer { get; set; }

    public double TotalSalesAmount { get; set; }

    public string Branch { get; set; }

    public List<CreateProductResult> Products { get; set; }

    public CreateFiliationResult Filiation { get; set; }

    public SaleStatus Status { get; set; }

    public CreateSaleResult()
    {
        Products = new List<CreateProductResult>();
    }
}