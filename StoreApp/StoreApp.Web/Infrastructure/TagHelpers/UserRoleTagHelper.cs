using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StoreApp.Services.Abstract;

namespace StoreApp.Web.Infrastructure.TagHelpers;

[HtmlTargetElement("td", Attributes = "user-role")]
public class UserRoleTagHelper : TagHelper
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;
    [HtmlAttributeName("user-name")]
    public string Username { get; set; }

    public UserRoleTagHelper(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var user = await _userManager.FindByNameAsync(Username);

        TagBuilder list = new TagBuilder("ul");
        var roles = _roleManager.Roles.ToList();

        foreach (var role in roles)
        {

            TagBuilder listItem = new TagBuilder("li");
            listItem.InnerHtml.Append($"{role,-8} : {await _userManager.IsInRoleAsync(user, role.Name)}");
            list.InnerHtml.AppendHtml(listItem);
        }

        output.Content.AppendHtml(list);
    }
}