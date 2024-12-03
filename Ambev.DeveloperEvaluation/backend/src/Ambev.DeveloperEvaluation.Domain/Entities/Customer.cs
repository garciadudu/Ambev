using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public  class Customer: BaseEntity
    {
        public string CPF_CNPJ { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
