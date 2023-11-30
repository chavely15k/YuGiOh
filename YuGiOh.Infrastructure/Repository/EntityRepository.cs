using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YuGiOh.ApplicationCore.Repository;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.Domain.Models;
using YuGiOh.Infrastructure;

namespace YuGiOh.Domain.Models
{
    public class EntityRepository : IEntityRepository
    {
        protected readonly YuGiOhDbContext context;

        public EntityRepository(YuGiOhDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<TEntity> CreateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var result = await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<TEntity> DeleteAsync<TEntity>(object key)
    where TEntity : class, IEntity
        {
            // Asumiendo que GetByIdAsync también se ajusta para trabajar con una clave de tipo object
            var entityToDelete = await GetByIdAsync<TEntity>(key);

            if (entityToDelete != null)
            {
                context.Set<TEntity>().Remove(entityToDelete);
                await context.SaveChangesAsync();
            }

            return entityToDelete;
        }


        public async Task<IEnumerable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            return await context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IEntity
        {
            return await context.Set<TEntity>().ToListAsync();
        }

       
        public async Task<TEntity?> GetByIdAsync<TEntity>(object key)
            where TEntity : class, IEntity
        {
            var entities = await context.Set<TEntity>().ToListAsync();

            if (key != null)
            {
                return entities.SingleOrDefault(e => e.GetById().Equals(key));
            }

            return null;
        }


        public async Task<TEntity> UpdateAsync<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
        public IQueryable<TEntity> Include<TEntity>(Expression<Func<TEntity, object>> include)
         where TEntity : class, IEntity
        {
            return context.Set<TEntity>().Include(include);
        }

    }
}
