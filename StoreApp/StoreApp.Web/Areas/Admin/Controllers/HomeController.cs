using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace StoreApp.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        TempData["info"] = $"Welcome back , {User.Identity.Name}";
        return View();
    }
}