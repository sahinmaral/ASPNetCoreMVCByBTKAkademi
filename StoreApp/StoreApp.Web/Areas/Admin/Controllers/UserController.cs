using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Entities.DTOs;
using StoreApp.Services.Abstract;

namespace StoreApp.Web.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly IServiceManager _serviceManager;

    public UserController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IActionResult Index()
    {
        return View(_serviceManager.AuthService.GetAllUsers().ToList());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new UserDtoForCreation()
        {
            Roles = new HashSet<string>(_serviceManager.AuthService.Roles.Select(x => x.Name).ToList())
        });
    }

    [HttpGet]
    public async Task<IActionResult> Update([FromQuery(Name = "username")] string username)
    {
        var user = await _serviceManager.AuthService.GetUserByUsernameForUpdate(username);
        return View(user);
    }

    [HttpGet]
    public async Task<IActionResult> ResetPassword([FromQuery(Name = "username")] string username)
    {
        return View(new ResetPasswordDto() { Username = username });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] UserDtoForCreation dto)
    {
        if (ModelState.IsValid)
        {
            var result = await _serviceManager.AuthService.CreateUser(dto);
            if (result.Succeeded)
                return RedirectToAction("Index");
            return View(dto);
        }
        return View(dto);
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public async Task<IActionResult> Update([FromForm] UserDtoForUpdate dto)
    {
        if (ModelState.IsValid)
        {
            var result = await _serviceManager.AuthService.UpdateUser(dto);
            if (result.Succeeded)
                return RedirectToAction("Index");
            return View(dto);
        }
        return View(dto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto dto)
    {
        if (ModelState.IsValid)
        {
            var result = await _serviceManager.AuthService.ResetPassword(dto);
            if (result.Succeeded)
                return RedirectToAction("Index");
            return View(dto);
        }
        return View(dto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteUser([FromForm]string username)
    {
        var result = await _serviceManager.AuthService.DeleteUserByUsername(username);
        return RedirectToAction("Index");
    }


}