using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers;

public class EmployeeController : Controller
{
    public IActionResult Index()
    {
        string[] usernames = new string[]{
            "sahinmaral","ahmetkesen","busevaran"
        };

        return View("Index", usernames);
    }

}