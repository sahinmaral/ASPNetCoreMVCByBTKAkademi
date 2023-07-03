using StoreApp.Entities;
using StoreApp.Repositories.Abstract;
using StoreApp.Services.Abstract;

namespace StoreApp.Services;

public class CategoryManager : ICategoryService
{
    private readonly IRepositoryManager _repositoryManager;

    public CategoryManager(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public IEnumerable<Category> GetAllCategories(bool trackChanges)
    {
        return _repositoryManager.CategoryRepository.FindAll(trackChanges);
    }

    public Category GetCategoryById(int id, bool trackChanges)
    {
        var category = _repositoryManager.CategoryRepository.GetCategoryById(id, trackChanges);
        if (category is null)
        {
            throw new Exception("Category not found");
        }
        return category;
    }
}