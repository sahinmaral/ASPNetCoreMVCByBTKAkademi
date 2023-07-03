using System.ComponentModel.DataAnnotations;

namespace StoreApp.Entities.DTOs;

public record UserDto
{
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Username is required")]
    public string? Username { get; init; }
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; init; }
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; init; }
    public HashSet<string> Roles { get; set; } = new HashSet<string>();
}