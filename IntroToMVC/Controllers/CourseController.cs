using IntroToMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroToMVC.Controllers;

public class CourseController : Controller
{
    public IActionResult Index()
    {
        var model = Repository.Applications.OrderByDescending(x => x.ApplyAt).ToList();

        return View(model);
    }

    [HttpGet]
    public IActionResult Apply()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Apply([FromForm] Candidate candidate)
    {
        if (Repository.Applications.Any(x => x.Email.Equals(candidate.Email)))
        {
            ModelState.AddModelError("Email", "Email has to be unique");
        }

        if (ModelState.IsValid)
        {
            Repository.Add(candidate);
            return View("Feedback", candidate);
        }
        else
        {
            return View();
        }

    }
}