using Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{

    public class CreateSaleDTO
    {
        public string Id { get; set; }
        public Int64 Number { get; set; }

        public DateTime Date { get; set; }

        public CreateCustomerDTO Customer { get; set; }

        public double TotalSalesAmount { get; set; }

        public string Branch { get; set; }

        public List<CreateProductDTO> Products { get; set; }

        public SaleStatusDTO Status { get; set; }

        public CreateSaleDTO()
        {
            Products = new List<CreateProductDTO>();
        }
    }
}
