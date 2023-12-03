using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.Domain.Models;
using YuGiOh.Infrastructure;

namespace YuGiOh.Infrastructure.Repository
{
    public class EntityRepository : IEntityRepository
    {
        protected readonly YuGiOhDbContext _dbContext;

        public EntityRepository(YuGiOhDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<TEntity> CreateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var result = await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<TEntity> DeleteAsync<TEntity>(object key)
    where TEntity : class, IEntity
        {
            // Asumiendo que GetByIdAsync también se ajusta para trabajar con una clave de tipo object
            var entityToDelete = await GetByIdAsync<TEntity>(key);

            if (entityToDelete != null)
            {
                _dbContext.Set<TEntity>().Remove(entityToDelete);
                await _dbContext.SaveChangesAsync();
            }

            return entityToDelete;
        }


        public async Task<IEnumerable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IEntity
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }


        public async Task<TEntity?> GetByIdAsync<TEntity>(object key)
            where TEntity : class, IEntity
        {
            var entities = await _dbContext.Set<TEntity>().ToListAsync();

            if (key != null)
            {
                return entities.SingleOrDefault(e => e.GetById().Equals(key));
            }

            return null;
        }




        public async Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public IQueryable<TEntity> Include<TEntity>(params Expression<Func<TEntity, object>>[] includes)
            where TEntity : class, IEntity
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }


    }
}
