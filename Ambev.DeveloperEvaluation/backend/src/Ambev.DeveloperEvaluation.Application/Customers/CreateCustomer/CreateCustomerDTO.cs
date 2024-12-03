using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer
{
    public class CreateCustomerDTO
    {
        public Guid Id { get; set; }
        public string CPF_CNPJ { get; set; }
        public string Nome { get; set; }
    }
}
