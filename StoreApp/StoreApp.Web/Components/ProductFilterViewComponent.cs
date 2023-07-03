using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Web.Components;

public class ProductFilterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("default");
    }
}