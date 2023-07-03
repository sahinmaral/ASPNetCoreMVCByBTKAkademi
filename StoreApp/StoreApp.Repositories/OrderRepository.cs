using Microsoft.EntityFrameworkCore;
using StoreApp.Entities;
using StoreApp.Repositories.Abstract;

namespace StoreApp.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    private readonly StoreAppDbContext _dbContext;

    public OrderRepository(StoreAppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<Order> GetAllOrdersDetailed(bool trackChanges = false)
    {
        var orders = _dbContext.Orders
            .Include(o => o.CartLines)
                .ThenInclude(l => l.Product)
                .OrderBy(o => o.IsShipped)
                    .ThenByDescending(o => o.Id);

        return trackChanges ? orders : orders.AsNoTracking();
    }

    public int GetCountOfNotShippedOrders()
    {
        return _dbContext.Orders.Count(o => o.IsShipped == false);
    }

    public void SaveOrder(Order order)
    {
        _dbContext.AttachRange(order.CartLines.Select(l => l.Product));
        if(order.Id == 0)
            _dbContext.Orders.Add(order);
    }
}