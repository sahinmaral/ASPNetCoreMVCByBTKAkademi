using StoreApp.Entities;
using StoreApp.Entities.RequestParameters;

namespace StoreApp.Services.Abstract;

public interface IProductService
{
    void DeleteProduct(int id,bool trackChanges=false);
    void CreateProduct(Product product);
    IEnumerable<Product> GetAllProducts(bool trackChanges=false);
    IQueryable<Product> GetAllProductsDetailed(ProductRequestParameters ?p=null,bool trackChanges=false);
    Product GetProductById(int id,bool trackChanges=false);
    void UpdateProduct(Product product,bool trackChanges=false);
}
