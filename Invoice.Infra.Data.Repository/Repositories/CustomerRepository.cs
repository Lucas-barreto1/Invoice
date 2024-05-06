using Invoice.Context;
using Invoice.Domain.Entities;
using Invoice.Domain.Interfaces.Repositories;
using Invoice.Infra.Data.Repository.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infra.Data.Repository.Repositories;

public class CustomerRepository: RepositoryBase<Customer>, ICustomerRepository
{
    public CustomerRepository(InvoiceContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Product>> GetProductsByCustomerId(Guid customerId, CancellationToken cancellationToken = default)
    {
        return await _context.Customers
            .Where(c => c.Id == customerId)
            .Include(c => c.Invoices)
            .ThenInclude(i => i.InvoiceItems)
            .ThenInclude(ii => ii.Product)
            .SelectMany(c => c.Invoices.SelectMany(i => i.InvoiceItems.Select(ii => ii.Product)))
            .ToListAsync(cancellationToken);
    }
}