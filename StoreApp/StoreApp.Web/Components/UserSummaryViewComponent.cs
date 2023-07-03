using Microsoft.AspNetCore.Mvc;
using StoreApp.Services.Abstract;

namespace StoreApp.Web.Components;

public class UserSummaryViewComponent : ViewComponent
{
    private readonly IServiceManager _serviceManager;

    public UserSummaryViewComponent(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public IViewComponentResult Invoke()
    {
        int count = _serviceManager.AuthService.GetAllUsers().Count();
        return View("Default",count);
    }
}