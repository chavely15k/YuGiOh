using System.Linq.Expressions;
using YuGiOh.Domain.Models;

namespace YuGiOh.ApplicationCore.Repository;

public interface IEntityRepository
{
    Task<TEntity> CreateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity;
    Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IEntity;

     public Task<TEntity?> GetByIdAsync<TEntity>(object key)
            where TEntity : class, IEntity;
    
    Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity;

    public Task<TEntity> DeleteAsync<TEntity>(object key)
    where TEntity : class, IEntity;

    Task<IEnumerable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
        where TEntity : class, IEntity;

    IQueryable<TEntity> Include<TEntity>(params Expression<Func<TEntity, object>>[] includes)
        where TEntity : class, IEntity;

}
