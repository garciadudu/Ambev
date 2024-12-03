using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProduct
{
    public class ListProductResult
    {
        public string Id { get; set; }
        public string Descriptions { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Discounts { get; set; }
        public double TotalAmount { get; set; }
    }
}
