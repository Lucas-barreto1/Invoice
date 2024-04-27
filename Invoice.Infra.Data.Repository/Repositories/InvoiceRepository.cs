using Invoice.Context;
using Invoice.Infra.Data.Repository.Repositories.Base;
using Invoice.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infra.Data.Repository.Repositories;

public class InvoiceRepository: RepositoryBase<Domain.Entities.Invoice>, IInvoiceRepository
{
    public InvoiceRepository(InvoiceContext context) : base(context)
    {

    }
    
    public override async Task<Domain.Entities.Invoice?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include("InvoiceItems.Product") 
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }
        
    public override async Task<IEnumerable<Domain.Entities.Invoice>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include("InvoiceItems.Product") 
            .ToListAsync(cancellationToken);
    }

}