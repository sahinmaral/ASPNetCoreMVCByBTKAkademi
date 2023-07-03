using Microsoft.AspNetCore.Mvc;
using StoreApp.Entities;
using StoreApp.Services.Abstract;

namespace StoreApp.Web.Components;

public class CategorySidebarViewComponent : ViewComponent
{
    private readonly IServiceManager _serviceManager;

    public CategorySidebarViewComponent(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IViewComponentResult Invoke()
    {
        List<Category> categories = _serviceManager.CategoryService.GetAllCategories(false).ToList();
        return View("Default",categories);
    }
}