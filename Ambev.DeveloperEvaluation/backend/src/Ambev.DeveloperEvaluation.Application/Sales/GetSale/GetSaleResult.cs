using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class GetSaleResult
{
    public Int64 Number { get; set; }

    public DateTime Date { get; set; }

    public virtual GetCustomerResult Customer { get; set; }

    public double TotalSalesAmount { get; set; }

    public string Branch { get; set; }

    public virtual List<GetProductResult> Products { get; set; }

    public SaleStatus Status { get; set; }

    public GetSaleResult()
    {
        Products = new List<GetProductResult>();
    }
}




public class GetCustomerResult
{
    public string Id { get; set; }
    public string CPF_CNPJ { get; set; }
    public string Nome { get; set; }
}

public class GetProductResult
{
    public string Id { get; set; }
    public string Descriptions { get; set; }

    public double Quantity { get; set; }

    public double Price { get; set; }

    public double Discounts { get; set; }

    public double TotalAmount { get; set; }
}
