using StoreApp.Entities;

namespace StoreApp.Repositories.Abstract;

public interface IRepositoryManager
{
    IOrderRepository OrderRepository{get;}
    IProductRepository ProductRepository {get;}
    ICategoryRepository CategoryRepository {get;}
    void Save();
}