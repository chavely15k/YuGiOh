using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.Domain.Models;

namespace YuGiOh.Infrastructure.Repository
{
    public class DataRepository : IDataRepository
    {
        protected readonly YuGiOhDbContext context;

        public DataRepository(YuGiOhDbContext context)
        {
            this.context = context;
        }

        public YuGiOhDbContext Context => context;

        public async Task<TEntity> CreateAsync<TEntity>(TEntity entity) where TEntity : Entity
        {
            var result = await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : Entity
        {
             return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync<TEntity, TKey>(TKey id)
            where TEntity : Entity
            where TKey : IEquatable<TKey>
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(e => e.Id.Equals(id));
        }

        public async Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : Entity
        {
            var trackingEntity = await GetByIdAsync<TEntity, Guid>(entity.Id);
            trackingEntity = entity;

            await context.SaveChangesAsync();
            return trackingEntity;
        }

        public async Task DeleteAsync<TEntity, TKey>(TKey key)
            where TEntity : Entity
            where TKey : IEquatable<TKey>
        {
            await context.Set<TEntity>().Where(e => e.Id.Equals(key)).ExecuteDeleteAsync();
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : Entity
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }
        //NotImplementedException;
        public async Task<IEnumerable<TEntity>> GetPageAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, PageQuery pageQuery) 
            where TEntity : Entity
        {
            var entities = await FindAsync<TEntity>(predicate);
            return entities;
        }
    }
}