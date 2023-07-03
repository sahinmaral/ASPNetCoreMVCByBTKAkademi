using Microsoft.AspNetCore.Mvc;
using StoreApp.Services.Abstract;

namespace StoreApp.Web.Components;

public class CategorySummaryViewComponent : ViewComponent
{
    private readonly IServiceManager _serviceManager;

    public CategorySummaryViewComponent(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IViewComponentResult Invoke()
    {
        int count = _serviceManager.CategoryService.GetAllCategories().ToList().Count;
        return View("Default",count);
    }
}