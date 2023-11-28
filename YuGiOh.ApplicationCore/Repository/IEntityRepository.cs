using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.Domain.Models;

namespace YuGiOh.ApplicationCore.Repository;

public interface IEntityRepository
{
    Task<TEntity> CreateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity;
    Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IEntity;
    Task<TEntity?> GetByIdAsync<TEntity, TKey>(TKey id)
        where TEntity :class, IEntity
        where TKey : IEquatable<TKey>;
    Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity;

    Task DeleteAsync<TEntity, TKey>(TKey key)
        where TEntity : class, IEntity
        where TKey : IEquatable<TKey>;
    Task<IEnumerable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
        where TEntity : class, IEntity;
}
