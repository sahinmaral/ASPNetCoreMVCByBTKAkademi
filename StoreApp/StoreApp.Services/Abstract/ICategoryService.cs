using StoreApp.Entities;

namespace StoreApp.Services.Abstract;

public interface ICategoryService
{
    IEnumerable<Category> GetAllCategories(bool trackChanges=false);
    Category GetCategoryById(int id, bool trackChanges=false);
}
