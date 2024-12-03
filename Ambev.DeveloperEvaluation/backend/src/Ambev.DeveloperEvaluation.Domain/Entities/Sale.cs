using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


public class Sale : BaseEntity
{
    public int Number { get; set; }

    public DateTime Date { get; set; }


    public Guid CustomerId { get; set; }

    public virtual Customer Customer { get; set; }

    public double TotalSalesAmount { get; set; }

    public string Branch { get; set; }

    public virtual ICollection<Product> Products { get; set; }

    public SaleStatus Status { get; set;  }

    public Sale()
    {
        Date = DateTime.UtcNow;
    }
}