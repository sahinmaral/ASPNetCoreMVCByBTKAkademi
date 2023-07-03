using Microsoft.AspNetCore.Mvc;
using StoreApp.Services.Abstract;

namespace StoreApp.Web.Components;

public class ProductSummaryViewComponent : ViewComponent
{
    private readonly IServiceManager _serviceManager;

    public ProductSummaryViewComponent(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IViewComponentResult Invoke()
    {
        int count = _serviceManager.ProductService.GetAllProducts().ToList().Count;
        return View("Default",count);
    }
}