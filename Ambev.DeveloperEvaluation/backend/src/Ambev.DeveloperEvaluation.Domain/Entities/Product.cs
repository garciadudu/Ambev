using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


public class Product : BaseEntity
{
    public string Descriptions { get; set; }

    public double Quantity { get; set; }

    public double Price { get; set; }

    public double Discounts { get; set; }

    public double TotalAmount { get; set; }

    public Guid SaleId { get; set; }
    public virtual Sale Sale { get; set; }

    public ProductStatus Status { get; set; }
}