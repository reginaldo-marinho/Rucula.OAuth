using System.Linq.Expressions;

using Rucula.OAuth.LocalCredentials.Core.Entities;

namespace Rucula.OAuth.LocalCredentials.Core.Repositories;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> SearchByConditionAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> GetByIdAsync(int? id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<bool> SaveChangesAsync();
    Task StartTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
