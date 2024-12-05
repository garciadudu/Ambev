using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Filiation : BaseEntity
    {
        public string Nome { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
