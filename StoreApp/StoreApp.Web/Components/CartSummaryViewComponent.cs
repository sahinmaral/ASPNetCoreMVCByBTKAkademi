using Microsoft.AspNetCore.Mvc;
using StoreApp.Entities;

namespace StoreApp.Web.Components;

public class CartSummaryViewComponent : ViewComponent
{
    private readonly Cart _cart;
    public CartSummaryViewComponent(Cart cart)
    {
        _cart = cart;
    }

    public IViewComponentResult Invoke()
    {
        var count = _cart.CartLines.Count();

        return View("default",count);
    }
}