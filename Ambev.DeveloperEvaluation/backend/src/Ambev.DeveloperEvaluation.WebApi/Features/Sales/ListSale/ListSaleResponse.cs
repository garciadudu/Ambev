using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale
{
    public class ListSaleResponse
    {
        public string Id { get; set; }
        public Int64 Number { get; set; }

        public DateTime Date { get; set; }

        public virtual CreateCustomerResponse Customer { get; set; }

        public double TotalSalesAmount { get; set; }

        public string Branch { get; set; }

        public virtual List<CreateProductResponse> Products { get; set; }

        public SaleStatus Status { get; set; }

        public ListSaleResponse()
        {
            Products = new List<CreateProductResponse>();
        }
    }
}
