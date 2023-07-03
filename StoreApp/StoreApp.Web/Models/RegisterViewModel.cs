using System.ComponentModel.DataAnnotations;

namespace StoreApp.Web.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; init; }
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; init; }
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }
    [Required(ErrorMessage = "Confirm Password is required")]
    public string? ConfirmPassword { get; init; }
    private string? _returnUrl;
    public string ReturnUrl
    {
        get
        {
            if (_returnUrl is null) return "/";
            return _returnUrl;
        }
        set
        {
            _returnUrl = value;
        }
    }
}