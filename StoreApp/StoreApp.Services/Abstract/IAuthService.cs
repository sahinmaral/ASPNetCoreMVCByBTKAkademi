using Microsoft.AspNetCore.Identity;
using StoreApp.Entities.DTOs;

namespace StoreApp.Services.Abstract;

public interface IAuthService
{
    public IEnumerable<IdentityRole> Roles { get; }
    public IEnumerable<IdentityUser> GetAllUsers();
    public Task<IdentityResult> CreateUser(UserDtoForCreation dto);
    public Task<IdentityResult> UpdateUser(UserDtoForUpdate dto);
    public Task<IdentityResult> ResetPassword(ResetPasswordDto dto);
    public Task<IdentityUser> GetUserByUsername(string username);
    public Task<IdentityResult> DeleteUserByUsername(string username);
    public Task<UserDtoForUpdate> GetUserByUsernameForUpdate(string username);

}