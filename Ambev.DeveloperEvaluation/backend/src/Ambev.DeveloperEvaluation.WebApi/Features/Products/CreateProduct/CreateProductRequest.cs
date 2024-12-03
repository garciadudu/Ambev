using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Represents a request to create a new user in the system.
/// </summary>
public class CreateProductRequest
{
    public string Descriptions { get; set; }

    public double Quantity { get; set; }

    public double Price { get; set; }

    public double Discounts { get; set; }

    public double TotalAmount { get; set; }
}