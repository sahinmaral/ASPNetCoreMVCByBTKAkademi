using Microsoft.AspNetCore.Mvc;
using StoreApp.Entities;
using StoreApp.Entities.RequestParameters;
using StoreApp.Repositories;
using StoreApp.Repositories.Abstract;
using StoreApp.Services.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers;

public class ProductController : Controller
{
    private readonly IServiceManager _serviceManager;

    public ProductController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IActionResult Index(ProductRequestParameters p)
    {
        var products = _serviceManager.ProductService.GetAllProductsDetailed(p).ToList();
        var pagination = new Pagination
        {
            CurrentPage = p.PageNumber,
            ItemsPerPage = p.PageSize,
            TotalItems = _serviceManager.ProductService.GetAllProducts().Count()
        };

        return View(new ProductListViewModel() { Products = products, Pagination = pagination });
    }

    public IActionResult Get(int id)
    {
        try
        {
            Product product = _serviceManager.ProductService.GetProductById(id);
            return View(product);
        }
        catch (Exception ex)
        {
            return View("NoProduct", ex.Message);
        }


    }
}