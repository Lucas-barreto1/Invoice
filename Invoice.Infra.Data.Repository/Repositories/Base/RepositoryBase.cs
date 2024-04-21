using Invoice.Context;
using Invoice.Domain.Entities.Base;
using Invoice.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Invoice.Infra.Data.Repository.Repositories.Base;


public abstract class RepositoryBase<TEntity>(InvoiceContext context): IRepositoryBase<TEntity> where TEntity : EntityBase
{
    protected readonly InvoiceContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    
    public void Add(TEntity entity) => _dbSet.Add(entity);
    
    public async Task<TEntity?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    )
        => await _dbSet
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    
    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _dbSet.ToListAsync(cancellationToken);
    
    public void Update(TEntity entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }
        _dbSet.Update(entity);
    }
    
    public void Delete(TEntity entity) => _dbSet.Remove(entity);
    
    public int Save() => _context.SaveChanges();
   
}