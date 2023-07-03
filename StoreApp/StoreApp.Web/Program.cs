using StoreApp.Web.Infrastructure.Extensions;
using StoreApp.Web.Infrastructure.Mapping;
using StoreApp.Presentation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddControllers().AddApplicationPart(typeof(AssemblyReference).Assembly);
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.ConfigureLocalization();

builder.Services.ConfigureSession();
builder.Services.ConfigureApplicationCookie();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();

builder.Services.ConfigureRouting();


var app = builder.Build();

app.UseStaticFiles();
app.UseSession();


app.UseRouting();

app.UseRequestLocalization();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();

    endpoints.MapControllers();
});

app.ConfigureAndCheckMigration();
app.ConfigureDefaultUserHasAdminRole();

app.Run();