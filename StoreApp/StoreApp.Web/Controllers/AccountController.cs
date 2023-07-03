using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Web.Models;

namespace StoreApp.Web.Controllers;


public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
    {
        return View(new LoginViewModel() { ReturnUrl = ReturnUrl });
    }

    [HttpGet]
    public IActionResult Register([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
    {
        return View(new RegisterViewModel() { ReturnUrl = ReturnUrl });
    }

    public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
    {
        await _signInManager.SignOutAsync();
        return Redirect(ReturnUrl);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([FromForm] LoginViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            IdentityUser? user = await _userManager.FindByNameAsync(viewModel.Name);
            if (user is null)
            {
                ModelState.AddModelError("", "There is no user with such a username");
                return View(viewModel);
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, viewModel.Password, false, false);
            if (signInResult.Succeeded)
            {
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(viewModel);

        }

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([FromForm] RegisterViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if (!viewModel.Password.Equals(viewModel.ConfirmPassword))
            {
                ModelState.AddModelError("", "Password and confirm password are not same");
                return View(viewModel);
            }

            IdentityUser? userCheck = await _userManager.FindByNameAsync(viewModel.Name);
            if (userCheck is not null)
            {
                ModelState.AddModelError("", "There is already an user has same username");
                return View(viewModel);
            }

            IdentityUser newUser = new IdentityUser()
            {
                UserName = viewModel.Name,
                Email = viewModel.Email
            };

            var signUpResult = await _userManager.CreateAsync(newUser, viewModel.Password);
            if (!signUpResult.Succeeded)
            {
                foreach (var error in signUpResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(viewModel);
            }

            var roleResult = await _userManager.AddToRoleAsync(newUser, "User");
            if (roleResult.Succeeded)
                return RedirectToAction("Login", new { ReturnUrl = viewModel.ReturnUrl });


        }
        return View(viewModel);
    }

    public IActionResult AccessDenied([FromQuery(Name = "ReturnUrl")]string returnUrl)
    {
        return View();
    }
}