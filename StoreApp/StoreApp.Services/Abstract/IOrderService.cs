using StoreApp.Entities;

namespace StoreApp.Services.Abstract;

public interface IOrderService
{
    IEnumerable<Order> GetAllOrdersDetailed(bool trackChanges=false);
    Order GetOrderById(int id, bool trackChanges=false);
    int GetCountOfNotShippedOrders();
    void CompleteOrder(int id);
    void SaveOrder(Order order);
}