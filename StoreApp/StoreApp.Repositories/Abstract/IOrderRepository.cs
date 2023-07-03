using StoreApp.Entities;

namespace StoreApp.Repositories.Abstract;

public interface IOrderRepository : IRepositoryBase<Order>
{
    IQueryable<Order> GetAllOrdersDetailed(bool trackChanges=false);
    int GetCountOfNotShippedOrders();
    void SaveOrder(Order order);
}