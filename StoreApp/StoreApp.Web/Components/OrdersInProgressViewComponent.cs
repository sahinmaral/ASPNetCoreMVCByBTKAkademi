using Microsoft.AspNetCore.Mvc;
using StoreApp.Services.Abstract;

namespace StoreApp.Web.Components;

public class OrdersInProgressViewComponent : ViewComponent
{
    private readonly IServiceManager _serviceManager;

    public OrdersInProgressViewComponent(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IViewComponentResult Invoke()
    {
        int count = _serviceManager.OrderService.GetCountOfNotShippedOrders();
        return View("Default",count);
    }
}