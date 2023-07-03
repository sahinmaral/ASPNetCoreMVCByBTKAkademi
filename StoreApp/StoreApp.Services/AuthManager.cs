using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StoreApp.Entities.DTOs;
using StoreApp.Services.Abstract;

namespace StoreApp.Services;

public class AuthManager : IAuthService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMapper _mapper;
    public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _mapper = mapper;
    }

    public IEnumerable<IdentityRole> Roles { get => _roleManager.Roles; }

    public async Task<IdentityResult> CreateUser(UserDtoForCreation dto)
    {
        IdentityUser user = _mapper.Map<IdentityUser>(dto);
        var result = await _userManager.CreateAsync(user, dto.Password);

        string errorMessage = "";

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                errorMessage += $"{error.Description}{Environment.NewLine}";
            }
            throw new Exception(errorMessage);
        }

        if (dto.Roles.Count > 0)
        {
            var roleResult = await _userManager.AddToRolesAsync(user, dto.Roles);
            if (!roleResult.Succeeded)
            {
                foreach (var error in roleResult.Errors)
                {
                    errorMessage += $"{error.Description}{Environment.NewLine}";
                }
                throw new Exception(errorMessage);
            }
        }
        else
        {
            var roleResult = await _userManager.AddToRoleAsync(user, dto.Roles.First());
            if (!roleResult.Succeeded)
            {
                foreach (var error in roleResult.Errors)
                {
                    errorMessage += $"{error.Description}{Environment.NewLine}";
                }
                throw new Exception(errorMessage);
            }
        }

        return result;
    }

    public async Task<IdentityResult> DeleteUserByUsername(string username)
    {
        var user = await GetUserByUsername(username);
        if(user is null)
            throw new Exception("User could not found");

        return await _userManager.DeleteAsync(user);
    }

    public IEnumerable<IdentityUser> GetAllUsers()
    {
        return _userManager.Users;
    }

    public async Task<IdentityUser> GetUserByUsername(string username) => await _userManager.FindByNameAsync(username);

    public async Task<UserDtoForUpdate> GetUserByUsernameForUpdate(string username)
    {
        IdentityUser? user = await GetUserByUsername(username);
        if (user is null)
            throw new Exception("User could not found");

        var userDto = _mapper.Map<UserDtoForUpdate>(user);
        userDto.Roles = new HashSet<string>(Roles.Select(r => r.Name).ToList());
        userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));
        return userDto;
    }

    public async Task<IdentityResult> ResetPassword(ResetPasswordDto dto)
    {
        var user = await GetUserByUsername(dto.Username);
        if (user is null)
            throw new Exception("User could not found");

        await _userManager.RemovePasswordAsync(user);
        var result = await _userManager.AddPasswordAsync(user,dto.Password);

        return result;
    }

    public async Task<IdentityResult> UpdateUser(UserDtoForUpdate dto)
    {
        IdentityUser? user = await GetUserByUsername(dto.Username);
        if (user is null)
            throw new Exception("User could not found");

        user.PhoneNumber = dto.PhoneNumber;
        user.Email = dto.Email;

        var updateUserResult = await _userManager.UpdateAsync(user);

        string errorMessage = "";

        if (!updateUserResult.Succeeded)
        {
            foreach (var error in updateUserResult.Errors)
            {
                errorMessage += $"{error.Description}{Environment.NewLine}";
            }
            throw new Exception(errorMessage);
        }

        var userRoles = await _userManager.GetRolesAsync(user);

        if (dto.Roles.Count > 0)
        {
            foreach (var dtoRole in dto.Roles)
            {
                if (!userRoles.Contains(dtoRole))
                {
                    await _userManager.AddToRoleAsync(user, dtoRole);
                }
            }

            foreach (var userRole in userRoles)
            {
                if (!dto.Roles.Contains(userRole))
                {
                    await _userManager.RemoveFromRoleAsync(user, userRole);
                }
            }
        }

        return updateUserResult;
    }
}
