using System.Linq.Expressions;

namespace StoreApp.Repositories.Abstract;

public interface IRepositoryBase<T>
{
    void Delete(int id);
    void Create(T entity);
    void Update(T entity);
    IQueryable<T> FindAll(bool trackChanges);
    T? FindByCondition(Expression<Func<T,bool>> expression,bool trackChanges);
}