using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreApp.Entities;
using StoreApp.Entities.RequestParameters;
using StoreApp.Services.Abstract;
using StoreApp.Web.Models;

namespace StoreApp.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ProductController : Controller
{
    private readonly IServiceManager _serviceManager;
    private readonly IMapper _mapper;

    public ProductController(IServiceManager serviceManager, IMapper mapper)
    {
        _serviceManager = serviceManager;
        _mapper = mapper;
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

    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            _serviceManager.ProductService.DeleteProduct(id);

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return RedirectToAction("NoProduct", ex.Message);
        }
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = _serviceManager
        .CategoryService
        .GetAllCategories()
        .Select(x => new SelectListItem(text: x.Name, value: x.Id.ToString()));

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] ProductCreateViewModel viewModel, IFormFile file)
    {
        if (ModelState.IsValid)
        {
            string extension = Path.GetExtension(file.FileName);
            string newImageName = string.Concat(Guid.NewGuid().ToString(), extension);
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newImageName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            viewModel.ImageUrl = newImageName;
            _serviceManager.ProductService.CreateProduct(_mapper.Map(viewModel, new Product()));
            return RedirectToAction("Index");
        }
        else
        {

            ViewBag.Categories = _serviceManager
            .CategoryService
            .GetAllCategories()
            .Select(x => new SelectListItem(text: x.Name, value: x.Id.ToString()));

            return View(viewModel);
        }

    }

    [HttpGet]
    public IActionResult Edit([FromRoute] int id)
    {
        try
        {
            var product = _serviceManager.ProductService.GetProductById(id);

            var viewModel = _mapper.Map(product, new ProductUpdateViewModel());

            ViewBag.Categories = _serviceManager
                .CategoryService
                .GetAllCategories()
                .Select(x => new SelectListItem(text: x.Name, value: x.Id.ToString()));

            return View(viewModel);
        }
        catch (Exception ex)
        {
            return View("NoProduct", ex.Message);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromForm] ProductUpdateViewModel viewModel, IFormFile file)
    {
        var requiredModelState = ModelState["file"].Errors.Select(e => e.ErrorMessage).FirstOrDefault("required");

        if (requiredModelState is not null)
        {
            ModelState["file"].ValidationState = ModelValidationState.Valid;
        }

        if (ModelState.IsValid)
        {
            if(file is not null)
            {
                string extension = Path.GetExtension(file.FileName);
                string newImageName = string.Concat(Guid.NewGuid().ToString(), extension);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newImageName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                string oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", viewModel.ImageUrl);
                System.IO.File.Delete(oldPath);

                viewModel.ImageUrl = newImageName;
            }

            _serviceManager.ProductService.UpdateProduct(_mapper.Map(viewModel, new Product()));
            TempData["success"] = $"{viewModel.Name} has been updated";

            return RedirectToAction("Index");
        }
        else
        {

            ViewBag.Categories = _serviceManager
            .CategoryService
            .GetAllCategories()
            .Select(x => new SelectListItem(text: x.Name, value: x.Id.ToString()));

            return View(viewModel);
        }
    }
}