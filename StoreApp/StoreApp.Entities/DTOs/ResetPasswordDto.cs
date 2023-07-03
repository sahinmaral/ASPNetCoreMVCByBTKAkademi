using System.ComponentModel.DataAnnotations;

namespace StoreApp.Entities.DTOs;

public record ResetPasswordDto
{
    [Required(ErrorMessage = "Username is required")]
    public string? Username { get; init; }
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string? Password { get; init; }
    [Required(ErrorMessage = "Confirm Password is required")]
    [DataType(DataType.Password)]
    [Compare("Password",ErrorMessage = "Password and Confirm Password must be match")]
    public string? ConfirmPassword { get; init; }
}