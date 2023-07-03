using StoreApp.Entities;
using StoreApp.Repositories.Abstract;
using StoreApp.Services.Abstract;

namespace StoreApp.Services;

public class OrderManager : IOrderService
{
    private readonly IRepositoryManager _repositoryManager;
    public OrderManager(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public void CompleteOrder(int id)
    {
        var order = _repositoryManager.OrderRepository.FindByCondition(x => x.Id == id, true);
        if (order is null)
        {
            throw new Exception("Order not found");
        }

        order.IsShipped = true;
        _repositoryManager.Save();
    }

    public IEnumerable<Order> GetAllOrdersDetailed(bool trackChanges = false)
    {
        return _repositoryManager.OrderRepository.GetAllOrdersDetailed(trackChanges);
    }

    public int GetCountOfNotShippedOrders() => _repositoryManager.OrderRepository.GetCountOfNotShippedOrders();

    public Order GetOrderById(int id, bool trackChanges = false)
    {
        var order = _repositoryManager.OrderRepository.FindByCondition(x => x.Id == id, trackChanges);
        if (order is null)
        {
            throw new Exception("Order not found");
        }
        return order;
    }

    public void SaveOrder(Order order)
    {
        _repositoryManager.OrderRepository.SaveOrder(order);
        _repositoryManager.Save();
    }
}