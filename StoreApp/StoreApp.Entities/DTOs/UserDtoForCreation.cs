using System.ComponentModel.DataAnnotations;

namespace StoreApp.Entities.DTOs;

public record UserDtoForCreation : UserDto
{
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string? Password { get; init; }
}