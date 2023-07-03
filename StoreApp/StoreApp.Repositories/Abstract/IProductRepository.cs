using StoreApp.Entities;
using StoreApp.Entities.RequestParameters;

namespace StoreApp.Repositories.Abstract;

public interface IProductRepository : IRepositoryBase<Product>
{
    IQueryable<Product> GetAllProducts(bool trackChanges=false);
    IQueryable<Product> GetAllProductsDetailed(ProductRequestParameters p,bool trackChanges=false);
    Product? GetProductById(int id,bool trackChanges=false);
}