using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IFiliationRepository
    {
        Task<Filiation> CreateAsync(Filiation filiation, CancellationToken cancellationToken = default);

        Task<Filiation?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Filiation>> ListAsync(CancellationToken cancellationToken = default);
    }
}