using Microsoft.EntityFrameworkCore;
using StoreApp.Entities;
using StoreApp.Entities.RequestParameters;
using StoreApp.Repositories.Abstract;
using StoreApp.Repositories.Extensions;

namespace StoreApp.Repositories;

public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    private readonly StoreAppDbContext _dbContext;
    public ProductRepository(StoreAppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);
    public IQueryable<Product> GetAllProductsDetailed(ProductRequestParameters p, bool trackChanges = false)
    {
        return p is null
            ?    FindAll(trackChanges)
                .Include(x => x.Category)
            :    FindAll(trackChanges)
                .Include(x => x.Category)
                .FilteredByCategoryId(p.CategoryId)
                .FilteredBySearchTerm(p.SearchTerm)
                .FilteredByMinAndMaxPrice(p.MinPrice, p.MaxPrice, p.IsValidPrice)
                .ToPaginate(p.PageNumber,p.PageSize);
    }
    public Product? GetProductById(int id, bool trackChanges) => FindByCondition(x => x.Id == id, trackChanges);
}
