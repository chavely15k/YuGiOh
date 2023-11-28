using System.Linq.Expressions;
using YuGiOh.Domain.Models;

namespace YuGiOh.ApplicationCore.Repository;

public interface IEntityRepository
{
    Task<TEntity> CreateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity;
    Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IEntity;
    Task<TEntity?> GetByIdAsync<TEntity, TKey>(TKey id)
        where TEntity : class, IEntity
        where TKey : IEquatable<TKey>;
    Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity;

    Task<TEntity> DeleteAsync<TEntity, TKey>(TKey key)
        where TEntity : class, IEntity
        where TKey : IEquatable<TKey>;
    Task<IEnumerable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
        where TEntity : class, IEntity;

    IQueryable<TEntity> Include<TEntity>(Expression<Func<TEntity, object>> include)
        where TEntity : class, IEntity;
}
