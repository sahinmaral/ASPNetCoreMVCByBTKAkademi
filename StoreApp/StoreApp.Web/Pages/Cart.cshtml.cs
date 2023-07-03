using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Entities;
using StoreApp.Services.Abstract;
using StoreApp.Web.Infrastructure.Extensions;

namespace StoreApp.Web.Pages;

public class CartModel : PageModel
{
    private readonly IServiceManager _serviceManager;
    public Cart Cart { get; set; }
    public string ReturnUrl { get; set; } = "/";

    public CartModel(IServiceManager serviceManager, Cart cartService)
    {
        _serviceManager = serviceManager;
        Cart = cartService;
    }
    public void OnGet(string returnUrl)
    {
        ReturnUrl = returnUrl ?? "/";
    }

    public IActionResult? OnPost(int id, string returnUrl)
    {
        try
        {
            var product = _serviceManager.ProductService.GetProductById(id);

            Cart.AddItem(product, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        catch (System.Exception)
        {
        }

        return null;
    }

    public IActionResult OnPostRemove(int id, string returnUrl)
    {
        Cart.RemoveLine(Cart.CartLines.First(x => x.Product.Id == id).Product);
        return Page();
    }
}