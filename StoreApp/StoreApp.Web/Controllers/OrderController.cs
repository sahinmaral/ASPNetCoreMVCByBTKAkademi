using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Entities;
using StoreApp.Services.Abstract;

namespace StoreApp.Web.Controllers;

[Authorize(Roles = "User")]
public class OrderController : Controller
{
    private readonly IServiceManager _serviceManager;
    private readonly Cart _cart;
    public OrderController(IServiceManager serviceManager, Cart cart)
    {
        _serviceManager = serviceManager;
        _cart = cart;
    }

    [HttpGet]
    public IActionResult Checkout()
    {
        return View(new Order());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Checkout([FromForm] Order order)
    {
        if (_cart.CartLines.Count() == 0)
        {
            ModelState.AddModelError("", "Sorry, your cart is empty!");
        }

        if (ModelState.IsValid)
        {
            order.CartLines = _cart.CartLines.ToArray();
            _serviceManager.OrderService.SaveOrder(order);
            _cart.Clear();

            return RedirectToPage("/CompletedOrder", new { OrderId = order.Id });
        }

        return View(order);
    }

}