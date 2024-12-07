using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Npgsql;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        var customer = _context.Customers.Where(x => x.Id == sale.Customer.Id).FirstOrDefault();

        if (customer != null) 
        {
            sale.Customer = customer;

            _context.Entry(sale.Customer).State = EntityState.Unchanged;
        }
        else
        {
            customer = new Customer
            {
                CPF_CNPJ = sale.Customer.CPF_CNPJ,
                Nome = sale.Customer.Nome,
            };
                
            sale.Customer = customer;
        }

        var filiation = _context.Filiations.Where(x => x.Id == sale.Filiation.Id).FirstOrDefault();

        if (filiation != null)
        {
            sale.Filiation = filiation;

            _context.Entry(sale.Filiation).State = EntityState.Unchanged;
        }
        else
        {
            filiation = new Filiation
            {
                Codigo = sale.Filiation.Codigo,
                Nome = sale.Filiation.Nome,
            };

            sale.Filiation = filiation;
        }


        try
        {
            var connectionString = _context.Database.GetDbConnection().ConnectionString;

            using (var conn = new NpgsqlConnection(string.Concat(connectionString, ";password=4dm1n")))
            {
                conn.Open();

                var comando = new NpgsqlCommand("select nextval('seq_venda');", conn);

                var value = await comando.ExecuteScalarAsync();
                
                sale.Number = Int64.Parse(value.ToString());
            }
        } catch (Exception ex) {
        }

        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    public async Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Sales
                .Include(p => p.Customer)
                .Include(p => p.Products)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var sale= await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<Sale>> ListAsync(CancellationToken cancellationToken = default)
    {
        var lists = await _context.Sales
            .Include(p => p.Customer)
            .Include(p => p.Products)
            .ToListAsync(cancellationToken);

        return lists;
    }

}
