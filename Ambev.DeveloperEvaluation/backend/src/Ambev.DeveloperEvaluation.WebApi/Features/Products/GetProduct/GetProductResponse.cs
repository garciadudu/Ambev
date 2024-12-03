using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

public class GetProductResponse
{
    public string Id { get; set; }
    public string Descriptions { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public double Discounts { get; set; }
    public double TotalAmount { get; set; }
}
