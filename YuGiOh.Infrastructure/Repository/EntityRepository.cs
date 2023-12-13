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
        public async Task<TEntity?> GetByIdAsync<TEntity>(object key)
    where TEntity : class, IEntity
        {
            var entities = await _dbContext.Set<TEntity>().ToListAsync();

            if (key != null)
            {
                var comparer = new KeyComparer();
                return entities.SingleOrDefault(e => comparer.Equals(e.GetById(), key));
            }
            DateTime a = DateTime.Now.ToUniversalTime();
            return null;
        }


        public async Task<IEnumerable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IEntity
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
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


    public class KeyComparer : IEqualityComparer<object>
    {
        public bool Equals(object x, object y)
        {
            if (x == null || y == null)
                return false;

            if (x is int xInt && y is int yInt)
            {
                return xInt == yInt;
            }

            var propertiesX = x.GetType().GetProperties();
            var propertiesY = y.GetType().GetProperties();

            if (propertiesX.Length != propertiesY.Length)
            {
                return false; // Número diferente de propiedades, consideramos diferentes
            }

            foreach (var propX in propertiesX)
            {
                var propY = propertiesY.FirstOrDefault(p => p.Name == propX.Name);

                if (propY == null)
                {
                    return false; // No hay una propiedad correspondiente en y
                }

                var valueX = propX.GetValue(x);
                var valueY = propY.GetValue(y);

                if (!object.Equals(valueX, valueY))
                {
                    return false; // Los valores de las propiedades no son iguales
                }
            }

            return true;
        }

        public int GetHashCode(object obj)
        {
            if (obj == null)
                return 0;

            if (obj is int intKey)
            {
                return intKey.GetHashCode();
            }

            var properties = obj.GetType().GetProperties();
            int hashCode = 17;

            foreach (var prop in properties)
            {
                var value = prop.GetValue(obj);
                hashCode = hashCode * 23 + (value?.GetHashCode() ?? 0);
            }

            return hashCode;
        }
    }


}
