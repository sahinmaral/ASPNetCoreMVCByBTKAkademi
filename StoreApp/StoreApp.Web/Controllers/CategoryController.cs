using Microsoft.AspNetCore.Mvc;
using StoreApp.Repositories.Abstract;
using StoreApp.Services.Abstract;

namespace StoreApp.Web.Controllers;

public class CategoryController : Controller
{
    private readonly IServiceManager _serviceManager;

    public CategoryController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IActionResult Index()
    {
        return View(_serviceManager.CategoryService.GetAllCategories(false).ToList());
    }
}