using StoreApp.Entities;
using StoreApp.Entities.RequestParameters;
using StoreApp.Repositories.Abstract;
using StoreApp.Services.Abstract;

namespace StoreApp.Services;

public class ProductManager : IProductService
{
    private readonly IRepositoryManager _repositoryManager;

    public ProductManager(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public void CreateProduct(Product product)
    {
        if (_repositoryManager.CategoryRepository.GetCategoryById(product.CategoryId) == null)
        {
            throw new Exception("Category of product not found");
        }

        _repositoryManager.ProductRepository.Create(product);
        _repositoryManager.Save();
    }

    public void DeleteProduct(int id, bool trackChanges)
    {
        var deletedProduct = _repositoryManager.ProductRepository.GetProductById(id);
        if (deletedProduct is null)
        {
            throw new Exception("Product not found");
        }

        _repositoryManager.ProductRepository.Delete(id);
        _repositoryManager.Save();
    }

    public IEnumerable<Product> GetAllProducts(bool trackChanges)
    {
        return _repositoryManager.ProductRepository.GetAllProducts(trackChanges);
    }

    public IQueryable<Product> GetAllProductsDetailed(ProductRequestParameters p, bool trackChanges = false)
    {
        return _repositoryManager.ProductRepository.GetAllProductsDetailed(p, trackChanges);
    }

    public Product GetProductById(int id, bool trackChanges)
    {
        var product = _repositoryManager.ProductRepository.GetProductById(id, trackChanges);
        if (product is null)
        {
            throw new Exception("Product not found");
        }
        return product;
    }

    public void UpdateProduct(Product product, bool trackChanges)
    {
        var updatedProduct = _repositoryManager.ProductRepository.GetProductById(product.Id, trackChanges);
        if (product is null)
        {
            throw new Exception("Product not found");
        }

        updatedProduct.Name = product.Name;
        updatedProduct.CategoryId = product.CategoryId;
        updatedProduct.Price = product.Price;

        _repositoryManager.ProductRepository.Update(product);
    }
}