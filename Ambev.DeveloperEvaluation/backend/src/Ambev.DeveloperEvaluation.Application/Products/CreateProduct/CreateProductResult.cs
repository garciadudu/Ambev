using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

public class CreateProductResult
{
    public string Descriptions { get; set; }

    public double Quantity { get; set; }

    public double Price { get; set; }

    public double Discounts { get; set; }

    public double TotalAmount { get; set; }
}
