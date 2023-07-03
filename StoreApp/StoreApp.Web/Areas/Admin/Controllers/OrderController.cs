namespace StoreApp.Web.Areas.Admin.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Services.Abstract;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class OrderController : Controller
{
    private readonly IServiceManager _serviceManager;
    public OrderController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IActionResult Index()
    {
        return View(_serviceManager.OrderService.GetAllOrdersDetailed().ToList());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Complete([FromForm]int id)
    {
        _serviceManager.OrderService.CompleteOrder(id);
        return RedirectToAction("Index");
    }
}