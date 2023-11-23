using System.Linq.Expressions;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.Domain.Models;

namespace YuGiOh.ApplicationCore.Repository
{
    public interface IDataRepository
    {
        Task<TEntity> CreateAsync<TEntity>(TEntity entity) where TEntity : Entity;
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : Entity;
        Task<TEntity?> GetByIdAsync<TEntity, TKey>(TKey id) 
            where TEntity : Entity
            where TKey : IEquatable<TKey>;
        Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : Entity;
        Task DeleteAsync<TEntity, TKey>(TKey key) 
            where TEntity : Entity
            where TKey : IEquatable<TKey>;
        Task<IEnumerable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : Entity;
        Task<IEnumerable<TEntity>> GetPageAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, PageQuery pageQuery)
            where TEntity : Entity;
    }
}