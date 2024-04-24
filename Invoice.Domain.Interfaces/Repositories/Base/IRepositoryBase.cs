namespace Invoice.Domain.Interfaces.Repositories.Base;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    void Add(TEntity entity);
    Task<TEntity?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    int Save();
}