using Microsoft.AspNetCore.Mvc;
using StoreApp.Services.Abstract;

namespace StoreApp.Web.Components;

public class ShowcaseViewComponent : ViewComponent
{
    private readonly IServiceManager _serviceManager;
    public ShowcaseViewComponent(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IViewComponentResult Invoke(string page = "default")
    {
        var products = _serviceManager.ProductService.GetAllProductsDetailed().Where(x => x.CanBeShownInShowcase).ToList();
        return View(page, products);
    }
}