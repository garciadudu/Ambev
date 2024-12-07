using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class FiliationRepository : IFiliationRepository
    {
        private readonly DefaultContext _context;

        public FiliationRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<Filiation> CreateAsync(Filiation filiation, CancellationToken cancellationToken)
        {
            await _context.Filiations.AddAsync(filiation, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return filiation;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var filiation = await GetByIdAsync(id, cancellationToken);
            if (filiation == null)
                return false;

            _context.Filiations.Remove(filiation);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Filiation?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Filiations.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        }

        public async Task<List<Filiation>> ListAsync(CancellationToken cancellationToken = default)
        {
            var lists = await _context.Filiations
                .ToListAsync(cancellationToken);

            return lists;
        }
    }
}
