using StoreApp.Entities;
using StoreApp.Repositories.Abstract;

namespace StoreApp.Repositories;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    private readonly StoreAppDbContext _dbContext;

    public CategoryRepository(StoreAppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Category? GetCategoryById(int id, bool trackChanges) => FindByCondition(x => x.Id == id, trackChanges);
}