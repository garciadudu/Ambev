using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// API response model for CreateUser operation
/// </summary>
public class CreateProductResponse
{
    public string Descriptions { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public double Discounts { get; set; }
    public double TotalAmount { get; set; }
}
