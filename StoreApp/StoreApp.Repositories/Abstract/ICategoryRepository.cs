using StoreApp.Entities;

namespace StoreApp.Repositories.Abstract;

public interface ICategoryRepository : IRepositoryBase<Category>
{
    Category? GetCategoryById(int id, bool trackChanges=false);
}