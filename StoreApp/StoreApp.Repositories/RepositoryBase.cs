using Microsoft.EntityFrameworkCore;
using StoreApp.Entities.Abstract;
using StoreApp.Repositories.Abstract;
using System.Linq.Expressions;

namespace StoreApp.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class,IEntity
    {
        StoreAppDbContext _dbContext;

        protected RepositoryBase(StoreAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Set<T>().Where(x => x.Id == id).Single();

            _dbContext.Entry(entity).State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ?
                _dbContext.Set<T>() :
                _dbContext.Set<T>().AsNoTracking();
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ?
                _dbContext.Set<T>().Where(expression).SingleOrDefault() :
                _dbContext.Set<T>().AsNoTracking().Where(expression).SingleOrDefault();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
